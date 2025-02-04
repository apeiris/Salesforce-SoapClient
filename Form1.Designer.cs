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
            components = new System.ComponentModel.Container();
            btnGetAccessToken = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnCallSoap = new Button();
            tabControl1 = new TabControl();
            tbpScaffold = new TabPage();
            label1 = new Label();
            tbpAccounts = new TabPage();
            dataGridView1 = new DataGridView();
            btnListAccounts = new Button();
            tbpEDIPartner = new TabPage();
            btnCreateEdiPartner = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            oneToolStripMenuItem = new ToolStripMenuItem();
            twoToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpScaffold.SuspendLayout();
            tbpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tbpEDIPartner.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
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
            tabControl1.Controls.Add(tbpEDIPartner);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1379, 463);
            tabControl1.TabIndex = 3;
            // 
            // tbpScaffold
            // 
            tbpScaffold.Controls.Add(label1);
            tbpScaffold.Controls.Add(btnCallSoap);
            tbpScaffold.Controls.Add(btnGetAccessToken);
            tbpScaffold.Location = new Point(4, 24);
            tbpScaffold.Name = "tbpScaffold";
            tbpScaffold.Padding = new Padding(3);
            tbpScaffold.Size = new Size(1371, 435);
            tbpScaffold.TabIndex = 0;
            tbpScaffold.Text = "Scaffold";
            tbpScaffold.UseVisualStyleBackColor = true;
            tbpScaffold.MouseClick += tbpScaffold_MouseClick;
            // 
            // label1
            // 
            label1.ContextMenuStrip = contextMenuStrip1;
            label1.Location = new Point(110, 112);
            label1.Name = "label1";
            label1.Size = new Size(1028, 38);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // tbpAccounts
            // 
            tbpAccounts.Controls.Add(dataGridView1);
            tbpAccounts.Controls.Add(btnListAccounts);
            tbpAccounts.Location = new Point(4, 24);
            tbpAccounts.Name = "tbpAccounts";
            tbpAccounts.Padding = new Padding(3);
            tbpAccounts.Size = new Size(1371, 435);
            tbpAccounts.TabIndex = 1;
            tbpAccounts.Text = "Accounts";
            tbpAccounts.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1204, 379);
            dataGridView1.TabIndex = 1;
            // 
            // btnListAccounts
            // 
            btnListAccounts.Location = new Point(6, 391);
            btnListAccounts.Name = "btnListAccounts";
            btnListAccounts.Size = new Size(147, 23);
            btnListAccounts.TabIndex = 0;
            btnListAccounts.Text = "List Accounts";
            btnListAccounts.UseVisualStyleBackColor = true;
            btnListAccounts.Click += btnListAccounts_Click;
            // 
            // tbpEDIPartner
            // 
            tbpEDIPartner.Controls.Add(btnCreateEdiPartner);
            tbpEDIPartner.Location = new Point(4, 24);
            tbpEDIPartner.Name = "tbpEDIPartner";
            tbpEDIPartner.Padding = new Padding(3);
            tbpEDIPartner.Size = new Size(1371, 435);
            tbpEDIPartner.TabIndex = 2;
            tbpEDIPartner.Text = "EDI Partner";
            tbpEDIPartner.UseVisualStyleBackColor = true;
            // 
            // btnCreateEdiPartner
            // 
            btnCreateEdiPartner.Location = new Point(88, 372);
            btnCreateEdiPartner.Name = "btnCreateEdiPartner";
            btnCreateEdiPartner.Size = new Size(289, 23);
            btnCreateEdiPartner.TabIndex = 0;
            btnCreateEdiPartner.Text = "Create EDI Partner";
            btnCreateEdiPartner.UseVisualStyleBackColor = true;
            btnCreateEdiPartner.Click += btnCreateEdiPartner_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { oneToolStripMenuItem, twoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(95, 48);
            // 
            // oneToolStripMenuItem
            // 
            oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            oneToolStripMenuItem.Size = new Size(94, 22);
            oneToolStripMenuItem.Text = "one";
            // 
            // twoToolStripMenuItem
            // 
            twoToolStripMenuItem.Name = "twoToolStripMenuItem";
            twoToolStripMenuItem.Size = new Size(94, 22);
            twoToolStripMenuItem.Text = "two";
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
            tbpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tbpEDIPartner.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
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
        private Button btnListAccounts;
        private DataGridView dataGridView1;
        private TabPage tbpEDIPartner;
        private Button btnCreateEdiPartner;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem oneToolStripMenuItem;
        private ToolStripMenuItem twoToolStripMenuItem;
    }
}
