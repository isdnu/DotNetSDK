using System;
using System.Text;
using System.Windows.Forms;

namespace SDNUMobile.SDK.OAuthDemo
{
    public partial class MainForm : Form
    {
        private OAuthClient _client;
        private RequestToken _requestToken;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGetRequestToken_Click(object sender, EventArgs e)
        {
            this._client = new OAuthClient(JsonDeserializer.Instance, this.txtConsumerKey.Text, this.txtConsumerSecret.Text);
            this._client.RequestRequestTokenAsync(result =>
            {
                this.Invoke(new Action(() => 
                {
                    if (!result.Success)
                    {
                        this.ShowError("Failed to get request token!", result.Error.ErrorDescription);
                        return;
                    }

                    RequestToken requestToken = result.Token as RequestToken;
                    this.txtRequestToken.Text = requestToken.TokenID;
                    this.txtRequestSecret.Text = requestToken.TokenSecret;

                    String authorizeUrl = this._client.GetAuthorizeUrl(requestToken);
                    this.wbAuthorize.Navigate(authorizeUrl);

                    this._requestToken = requestToken;
                }));
            });
        }

        private void btnGetAccessToken_Click(object sender, EventArgs e)
        {
            if (this._client == null || this._requestToken == null || String.Equals(this.txtRequestToken.Text, this.txtRequestToken.Tag as String))
            {
                this.ShowError("Please get request token first!", null);
                return;
            }

            this._client.RequestAccessTokenAsync(this._requestToken, this.txtVerifier.Text, result =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!result.Success)
                    {
                        this.ShowError("Failed to get access token!", result.Error.ErrorDescription);
                        return;
                    }

                    AccessToken accessToken = result.Token as AccessToken;
                    this.txtAccessToken.Text = accessToken.TokenID;
                    this.txtAccessSecret.Text = accessToken.TokenSecret;
                }));
            });
        }

        private void btnGetPeopleInfo_Click(object sender, EventArgs e)
        {
            if (this._client == null || String.Equals(this.txtAccessToken.Text, this.txtAccessToken.Tag as String))
            {
                this.ShowError("Please get access token first!", null);
                return;
            }

            this._client.RequestRestMethodAsync(new RestMethod.People.Get(), result =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!result.Success)
                    {
                        this.ShowError("Failed to get people information!", result.Error.ErrorDescription);
                        return;
                    }

                    Entity.People.PeopleInfo info = result.Result;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(String.Format("[IdentityNumber] {0}", info.IdentityNumber));
                    sb.AppendLine(String.Format("[Name] {0}", info.Name));
                    sb.AppendLine(String.Format("[Sex] {0}", info.Sex));
                    sb.AppendLine(String.Format("[Nation] {0}", info.Nation));
                    sb.AppendLine(String.Format("[OrganizationName] {0}", info.OrganizationName));

                    MessageBox.Show(sb.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            });
        }

        private void wbAuthorize_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;

            if (browser.Url.ToString().StartsWith(this._client.DefaultCallbackUrl))
            {
                this.txtVerifier.Text = this._client.GetVerifierFromCallbackUrl(browser.Url.ToString());
            }
        }

        private DialogResult ShowError(String content, String extra)
        {
            String errorContent = content;

            if (!String.IsNullOrEmpty(extra))
            {
                errorContent += Environment.NewLine + Environment.NewLine + extra;
            }

            return MessageBox.Show(errorContent, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}