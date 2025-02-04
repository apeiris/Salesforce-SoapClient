using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using ServiceReference1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using sf = ServiceReference1;

namespace SoapClient
{
    public partial class Form1 : Form
    {

        //private static readonly IConfiguration _config = new ConfigurationBuilder()
        //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensure correct base directory
        //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //.Build();
        private static IConfiguration _config;
        public static sf.SoapClient sc;
        private static sf.SoapClient loginClient;
        private static sf.SessionHeader sessionHeader;
        private static EndpointAddress endpoint;

        static loginResponse lresp;
        static LoginResult lres;
        static LoginScopeHeader lsr;

        static string accessToken = "";

        private ServiceReference1.Soap soapClient;
        private static string authUrl;
        private static string clientId;
        private static string clientSecret;
        private static string userName;
        private static string password;

        public Form1(IConfiguration config)
        {
            InitializeComponent();
            _config = config;
            authUrl = config["Salesforce:authUrl"];
            clientId = config["Salesforce:clientId"];
            clientSecret = config["Salesforce:clientSecret"];
            userName = config["Salesforce:userName"];
            password = config["Salesforce:password"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
                    string x = $"Access Token  ({accessToken}) copied to Clipboard";
                    label1.Text = accessToken;
                    toolStripStatusLabel1.Text = x;
                    Clipboard.SetText(accessToken);
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
        /*

        private async Task<string> GetAccessToken()
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
        */

        public async Task<string> GetAccessToken()
        {
            string _username = _config["Salesforce:userName"];
            string _password = _config["Salesforce:password"];
            string _securityToken = _config["Salesforce:securityToken"];
            string _soapUrl = _config["Salesforce:soapUrl"];

            using (HttpClient client = new HttpClient())
            {
                string soapBody = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"">
              <soapenv:Body>
                <login xmlns=""urn:partner.soap.sforce.com"">
                  <username>{_username}</username>
                  <password>{_password}</password>
                </login>
              </soapenv:Body>
            </soapenv:Envelope>";
                var content = new StringContent(soapBody, Encoding.UTF8, "text/xml");
                // Set SOAP headers
                client.DefaultRequestHeaders.Add("SOAPAction", "''");
                HttpResponseMessage response = await client.PostAsync(_soapUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    XDocument doc = XDocument.Parse(responseBody);  // Parse the XML response to extract the session ID
                    XNamespace ns = "urn:partner.soap.sforce.com";
                    string sessionId = doc.Descendants(ns + "sessionId").FirstOrDefault()?.Value;

                    if (string.IsNullOrEmpty(sessionId))
                    {
                        throw new Exception("Failed to retrieve session ID from SOAP response.");
                    }
                    return sessionId;
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve access token. Status: {response.StatusCode}, Error: {errorBody}");
                }
            }
        }

        private async void CallSoap(String accessToken)
        {
            string serviceUrl = _config["Salesforce:soapUrl"]; // Use full SOAP endpoint
            var binding = new BasicHttpBinding { Security = { Mode = BasicHttpSecurityMode.Transport }, MaxReceivedMessageSize = int.MaxValue };
            var SsoapClient = new ChannelFactory<SoapChannel>(binding, new EndpointAddress(serviceUrl));
            var channel = SsoapClient.CreateChannel();
            try
            {
                ((IClientChannel)channel).Open();

                using (OperationContextScope scope = new OperationContextScope((IClientChannel)channel))
                {
                    var header = MessageHeader.CreateHeader("SessionHeader", "urn:irissystems-dev-ed-my.salesforce.com", new sf.SessionHeader { sessionId = accessToken });
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



        private async void btnCallSoap_Click(object sender, EventArgs e)
        {

            accessToken = await GetAccessToken();

            await Task.Run(() => CallSoap(accessToken));
        }
        private async Task<List<Account>> ListAccounts(string accessToken)
        {
            var binding = new BasicHttpBinding
            {
                Security = { Mode = BasicHttpSecurityMode.Transport },
                MaxReceivedMessageSize = int.MaxValue
            };
            var channel = new ChannelFactory<SoapChannel>(binding, new EndpointAddress(_config["Salesforce:soapUrl"])).CreateChannel();
            List<Account> accounts = new List<Account>();
            try
            {
                ((IClientChannel)channel).Open();
                using (OperationContextScope scope = new OperationContextScope((IClientChannel)channel))
                {
                    var header = MessageHeader.CreateHeader("SessionHeader", "urn:irissystems-dev-ed-my.salesforce.com", new sf.SessionHeader { sessionId = accessToken });
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    var query = "SELECT Id, Name,AccountNumber FROM Account";  // Query to list accounts
                    var request = new sf.queryRequest { queryString = query };
                    var queryResponse = channel.query(request); // Call the SOAP API
                    if (queryResponse.result != null && queryResponse.result.records != null)
                    {       // Parse the records
                        accounts = queryResponse.result.records
                            .Select(record => new Account
                            {
                                Id = record.Any.FirstOrDefault(field => field.LocalName == "Id")?.InnerText,
                                Name = record.Any.FirstOrDefault(field => field.LocalName == "Name")?.InnerText,
                                AccountNumber = record.Any.FirstOrDefault(field => field.LocalName == "AccountNumber")?.InnerText
                            }).ToList();
                    }
                }
                ((IClientChannel)channel).Close();
            }
            catch (Exception ex)
            {
                ((IClientChannel)channel).Abort();
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                ((IClientChannel)channel).Close();
            }
            return accounts;
        }
        private async Task<string> CreateEdiPartnerAsync(string accessToken)
        {
            var binding = new BasicHttpBinding
            {
                Security = { Mode = BasicHttpSecurityMode.Transport },
                MaxReceivedMessageSize = int.MaxValue
            };
            var channel = new ChannelFactory<SoapChannel>(binding, new EndpointAddress(_config["Salesforce:soapUrl"])).CreateChannel();

            string ediPartnerId = null;
            try
            {
                ((IClientChannel)channel).Open();
                using (OperationContextScope scope = new OperationContextScope((IClientChannel)channel))
                {
                    var header = MessageHeader.CreateHeader("SessionHeader", "urn:irissystems-dev-ed-my.salesforce.com", new sf.SessionHeader { sessionId = accessToken });
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);

                    // Define new EDI Partner record
                    var ediPartner = new sf.sObject
                    {
                        type = "EDI_Partner__c",
                        Any = new System.Xml.XmlElement[]
                        {
                    CreateXmlElement("Name", "ACME EDI Partner"),
                    CreateXmlElement("Account__c", "001XXXXXXXXXXXX") // Salesforce Account ID
                        }
                    };

                    // Call the SOAP API to create the record
                    var request = new sf.createRequest { sObjects = new sf.sObject[] { ediPartner } };
                    var createResponse = await Task.Run(() => channel.create(request));

                    if (createResponse.result[0].success)
                    {
                        ediPartnerId = createResponse.result[0].id;
                        Console.WriteLine($"EDI Partner Created! ID: {ediPartnerId}");
                    }
                    else
                    {
                        throw new Exception("Error: " + createResponse.result[0].errors[0].message);
                    }
                }
                ((IClientChannel)channel).Close();
            }
            catch (Exception ex)
            {
                ((IClientChannel)channel).Abort();
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                ((IClientChannel)channel).Close();
            }
            return ediPartnerId;
        }
        // Define the Account class for deserialization
        public class Account
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string AccountNumber { get; set; }
        }
        private async void btnListAccounts_Click(object sender, EventArgs e)
        {
            List<Account> accounts = await ListAccounts(accessToken);
            dataGridView1.DataSource = accounts;
        }
        // Helper method to create XML elements
        static System.Xml.XmlElement CreateXmlElement(string fieldName, string fieldValue)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement element = doc.CreateElement(fieldName);
            element.InnerText = fieldValue;
            return element;
        }

        private async void btnCreateEdiPartner_Click(object sender, EventArgs e)
        {
            await Task.Run(() => CreateEdiPartnerAsync(accessToken));
        }

        private void tbpScaffold_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //=======================================================
    }
}

