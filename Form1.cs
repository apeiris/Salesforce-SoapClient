using System.Linq.Expressions;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServiceReference1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using sf = ServiceReference1;

namespace SoapClient
{
    public partial class Form1 : Form
    {

        private static readonly IConfiguration _config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensure correct base directory
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        public static sf.SoapClient sc;
        private static sf.SoapClient loginClient;
        private static sf.SessionHeader sessionHeader;
        private static EndpointAddress endpoint;
        static loginResponse lresp;
        static LoginResult lres;
        static LoginScopeHeader lsr;

        private ServiceReference1.Soap soapClient;
        private static string authUrl;
        private static string clientId;
        private static string clientSecret;
        private static string userName;
        private static string password;
        private string accessToken;
        public Form1(IConfiguration config)
        {
            InitializeComponent();
            authUrl = config["Salesforce:authUrl"];
            clientId = config["Salesforce:clientId"];
            clientSecret = config["Salesforce:clientSecret"];
            userName = config["Salesforce:userName"];
            password = config["Salesforce:password"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(_config["Salesforce:password"] + "  *** * * * * Password=" + password);
            btnGetAccessToken.PerformClick();
            btnGetAccessToken.Visible = false;
        }

        private async void btnGetAccessToken_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "Retrieving Access Token..";
                accessToken = await GetAccessToken();

                if (!string.IsNullOrEmpty(accessToken))
                {
                    string x = $"Access Token  ({accessToken}) Retrieved Successfully";
                    toolStripStatusLabel1.Text = x;
                 //   MessageBox.Show("Access Token  (" + accessToken + ") Retrieved Successfully");
                }
                else
                {
                    toolStripStatusLabel1.Text = "Failed to retrieve Access Token";
                }

            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error: " + ex.Message;
            }
        }


        private async System.Threading.Tasks.Task<string> GetAccessToken()
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage response = await client.PostAsync(_config["Salesforce:authUrl"], content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    return tokenResponse.access_token;
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve access token. Status: {response.StatusCode}, Error: {errorBody}");
                }
            }
        }

        private async void btnCallSoap_Click(object sender, EventArgs e)
        {
            string serviceUrl = _config["Salesforce:soapUrl"]; // Use full SOAP endpoint
            var binding = new BasicHttpBinding { Security = { Mode = BasicHttpSecurityMode.Transport }, MaxReceivedMessageSize = int.MaxValue };
            var SsoapClient = new ChannelFactory<SoapChannel>(binding, new EndpointAddress(serviceUrl));
            var channel = SsoapClient.CreateChannel();
            try
            {
                ((IClientChannel)channel).Open();
                string sid = await GetAccessToken();
                using (OperationContextScope scope = new OperationContextScope((IClientChannel)channel))
                {
                   var header = MessageHeader.CreateHeader("SessionHeader", "urn:irissystems-dev-ed-my.salesforce.com", new sf.SessionHeader { sessionId =sid });
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    var request = new sf.describeSObjectsRequest
                    {
                        sObjectType = new string[] { "Account" }
                    };
                    var describeResult = channel.describeSObjects(request);
                }
                ((IClientChannel)channel).Close();
            }
            catch (Exception ex)
            {
                ((IClientChannel)channel).Abort();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ((IClientChannel)channel).Close();
            }
        }





    }



}

