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
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetAccessToken
            // 
            btnGetAccessToken.Location = new Point(0, 437);
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
            btnCallSoap.Location = new Point(39, 314);
            btnCallSoap.Name = "btnCallSoap";
            btnCallSoap.Size = new Size(158, 23);
            btnCallSoap.TabIndex = 2;
            btnCallSoap.Text = "Call Soap";
            btnCallSoap.UseVisualStyleBackColor = true;
            btnCallSoap.Click += btnCallSoap_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1379, 485);
            Controls.Add(btnCallSoap);
            Controls.Add(statusStrip1);
            Controls.Add(btnGetAccessToken);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetAccessToken;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnCallSoap;
    }
}
