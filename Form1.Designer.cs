namespace SoapClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetAccessToken = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnCallSoap = new Button();
            tabControl1 = new TabControl();
            tbpScaffold = new TabPage();
            tbpAccounts = new TabPage();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpScaffold.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetAccessToken
            // 
            btnGetAccessToken.Location = new Point(275, 290);
            btnGetAccessToken.Name = "btnGetAccessToken";
            btnGetAccessToken.Size = new Size(134, 23);
            btnGetAccessToken.TabIndex = 0;
            btnGetAccessToken.Text = "Login";
            btnGetAccessToken.UseVisualStyleBackColor = true;
            btnGetAccessToken.Click += btnGetAccessToken_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 463);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1379, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnCallSoap
            // 
            btnCallSoap.Location = new Point(75, 290);
            btnCallSoap.Name = "btnCallSoap";
            btnCallSoap.Size = new Size(158, 23);
            btnCallSoap.TabIndex = 2;
            btnCallSoap.Text = "Call Soap";
            btnCallSoap.UseVisualStyleBackColor = true;
            btnCallSoap.Click += btnCallSoap_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpScaffold);
            tabControl1.Controls.Add(tbpAccounts);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1379, 463);
            tabControl1.TabIndex = 3;
            // 
            // tbpScaffold
            // 
            tbpScaffold.Controls.Add(btnCallSoap);
            tbpScaffold.Controls.Add(btnGetAccessToken);
            tbpScaffold.Location = new Point(4, 24);
            tbpScaffold.Name = "tbpScaffold";
            tbpScaffold.Padding = new Padding(3);
            tbpScaffold.Size = new Size(1371, 435);
            tbpScaffold.TabIndex = 0;
            tbpScaffold.Text = "Scaffold";
            tbpScaffold.UseVisualStyleBackColor = true;
            // 
            // tbpAccounts
            // 
            tbpAccounts.Location = new Point(4, 24);
            tbpAccounts.Name = "tbpAccounts";
            tbpAccounts.Padding = new Padding(3);
            tbpAccounts.Size = new Size(1371, 435);
            tbpAccounts.TabIndex = 1;
            tbpAccounts.Text = "Accounts";
            tbpAccounts.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1379, 485);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tbpScaffold.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetAccessToken;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnCallSoap;
        private TabControl tabControl1;
        private TabPage tbpScaffold;
        private TabPage tbpAccounts;
    }
}
