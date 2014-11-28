namespace SDNUMobile.SDK.OAuthDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.grpAuthorize = new System.Windows.Forms.GroupBox();
            this.wbAuthorize = new System.Windows.Forms.WebBrowser();
            this.txtConsumerKey = new System.Windows.Forms.TextBox();
            this.txtConsumerSecret = new System.Windows.Forms.TextBox();
            this.txtRequestToken = new System.Windows.Forms.TextBox();
            this.txtRequestSecret = new System.Windows.Forms.TextBox();
            this.txtVerifier = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtAccessSecret = new System.Windows.Forms.TextBox();
            this.btnGetRequestToken = new System.Windows.Forms.Button();
            this.btnGetAccessToken = new System.Windows.Forms.Button();
            this.btnGetPeopleInfo = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            this.grpAuthorize.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.btnGetPeopleInfo);
            this.grpGeneral.Controls.Add(this.btnGetAccessToken);
            this.grpGeneral.Controls.Add(this.btnGetRequestToken);
            this.grpGeneral.Controls.Add(this.txtAccessSecret);
            this.grpGeneral.Controls.Add(this.txtAccessToken);
            this.grpGeneral.Controls.Add(this.txtVerifier);
            this.grpGeneral.Controls.Add(this.txtRequestSecret);
            this.grpGeneral.Controls.Add(this.txtRequestToken);
            this.grpGeneral.Controls.Add(this.txtConsumerSecret);
            this.grpGeneral.Controls.Add(this.txtConsumerKey);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpGeneral.Location = new System.Drawing.Point(8, 8);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(231, 425);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // grpAuthorize
            // 
            this.grpAuthorize.Controls.Add(this.wbAuthorize);
            this.grpAuthorize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAuthorize.Location = new System.Drawing.Point(239, 8);
            this.grpAuthorize.Name = "grpAuthorize";
            this.grpAuthorize.Size = new System.Drawing.Size(537, 425);
            this.grpAuthorize.TabIndex = 1;
            this.grpAuthorize.TabStop = false;
            this.grpAuthorize.Text = "Authorize";
            // 
            // wbAuthorize
            // 
            this.wbAuthorize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbAuthorize.Location = new System.Drawing.Point(3, 17);
            this.wbAuthorize.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAuthorize.Name = "wbAuthorize";
            this.wbAuthorize.Size = new System.Drawing.Size(531, 405);
            this.wbAuthorize.TabIndex = 0;
            this.wbAuthorize.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbAuthorize_Navigated);
            // 
            // txtConsumerKey
            // 
            this.txtConsumerKey.Location = new System.Drawing.Point(6, 20);
            this.txtConsumerKey.Name = "txtConsumerKey";
            this.txtConsumerKey.Size = new System.Drawing.Size(219, 21);
            this.txtConsumerKey.TabIndex = 0;
            this.txtConsumerKey.Tag = "#Consumer Key#";
            this.txtConsumerKey.Text = "#Consumer Key#";
            // 
            // txtConsumerSecret
            // 
            this.txtConsumerSecret.Location = new System.Drawing.Point(6, 47);
            this.txtConsumerSecret.Name = "txtConsumerSecret";
            this.txtConsumerSecret.Size = new System.Drawing.Size(219, 21);
            this.txtConsumerSecret.TabIndex = 1;
            this.txtConsumerSecret.Tag = "#Consumer Secret#";
            this.txtConsumerSecret.Text = "#Consumer Secret#";
            // 
            // txtRequestToken
            // 
            this.txtRequestToken.Location = new System.Drawing.Point(6, 83);
            this.txtRequestToken.Name = "txtRequestToken";
            this.txtRequestToken.ReadOnly = true;
            this.txtRequestToken.Size = new System.Drawing.Size(219, 21);
            this.txtRequestToken.TabIndex = 2;
            this.txtRequestToken.Tag = "#Request Token#";
            this.txtRequestToken.Text = "#Request Token#";
            // 
            // txtRequestSecret
            // 
            this.txtRequestSecret.Location = new System.Drawing.Point(6, 110);
            this.txtRequestSecret.Name = "txtRequestSecret";
            this.txtRequestSecret.ReadOnly = true;
            this.txtRequestSecret.Size = new System.Drawing.Size(219, 21);
            this.txtRequestSecret.TabIndex = 3;
            this.txtRequestSecret.Tag = "#Request Secret#";
            this.txtRequestSecret.Text = "#Request Secret#";
            // 
            // txtVerifier
            // 
            this.txtVerifier.Location = new System.Drawing.Point(6, 137);
            this.txtVerifier.Name = "txtVerifier";
            this.txtVerifier.ReadOnly = true;
            this.txtVerifier.Size = new System.Drawing.Size(219, 21);
            this.txtVerifier.TabIndex = 4;
            this.txtVerifier.Tag = "#Verifier#";
            this.txtVerifier.Text = "#Verifier#";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(6, 164);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.ReadOnly = true;
            this.txtAccessToken.Size = new System.Drawing.Size(219, 21);
            this.txtAccessToken.TabIndex = 5;
            this.txtAccessToken.Tag = "#Access Token#";
            this.txtAccessToken.Text = "#Access Token#";
            // 
            // txtAccessSecret
            // 
            this.txtAccessSecret.Location = new System.Drawing.Point(6, 191);
            this.txtAccessSecret.Name = "txtAccessSecret";
            this.txtAccessSecret.ReadOnly = true;
            this.txtAccessSecret.Size = new System.Drawing.Size(219, 21);
            this.txtAccessSecret.TabIndex = 6;
            this.txtAccessSecret.Tag = "#Access Secret#";
            this.txtAccessSecret.Text = "#Access Secret#";
            // 
            // btnGetRequestToken
            // 
            this.btnGetRequestToken.Location = new System.Drawing.Point(6, 337);
            this.btnGetRequestToken.Name = "btnGetRequestToken";
            this.btnGetRequestToken.Size = new System.Drawing.Size(219, 23);
            this.btnGetRequestToken.TabIndex = 7;
            this.btnGetRequestToken.Text = "Get Request Token And Authorize";
            this.btnGetRequestToken.UseVisualStyleBackColor = true;
            this.btnGetRequestToken.Click += new System.EventHandler(this.btnGetRequestToken_Click);
            // 
            // btnGetAccessToken
            // 
            this.btnGetAccessToken.Location = new System.Drawing.Point(6, 366);
            this.btnGetAccessToken.Name = "btnGetAccessToken";
            this.btnGetAccessToken.Size = new System.Drawing.Size(219, 23);
            this.btnGetAccessToken.TabIndex = 8;
            this.btnGetAccessToken.Text = "Get Access Token";
            this.btnGetAccessToken.UseVisualStyleBackColor = true;
            this.btnGetAccessToken.Click += new System.EventHandler(this.btnGetAccessToken_Click);
            // 
            // btnGetPeopleInfo
            // 
            this.btnGetPeopleInfo.Location = new System.Drawing.Point(6, 395);
            this.btnGetPeopleInfo.Name = "btnGetPeopleInfo";
            this.btnGetPeopleInfo.Size = new System.Drawing.Size(219, 23);
            this.btnGetPeopleInfo.TabIndex = 9;
            this.btnGetPeopleInfo.Text = "Get People Infomation";
            this.btnGetPeopleInfo.UseVisualStyleBackColor = true;
            this.btnGetPeopleInfo.Click += new System.EventHandler(this.btnGetPeopleInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.grpAuthorize);
            this.Controls.Add(this.grpGeneral);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDNUMobile.SDK.OAuthDemo";
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpAuthorize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpAuthorize;
        private System.Windows.Forms.WebBrowser wbAuthorize;
        private System.Windows.Forms.TextBox txtConsumerKey;
        private System.Windows.Forms.TextBox txtConsumerSecret;
        private System.Windows.Forms.TextBox txtRequestToken;
        private System.Windows.Forms.TextBox txtRequestSecret;
        private System.Windows.Forms.TextBox txtVerifier;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.TextBox txtAccessSecret;
        private System.Windows.Forms.Button btnGetRequestToken;
        private System.Windows.Forms.Button btnGetAccessToken;
        private System.Windows.Forms.Button btnGetPeopleInfo;
    }
}

