namespace RMMVResourceManager
{
    using System;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public partial class WebImport : Form
    {
        /// <summary>
        ///     Instance of Directory info, to easily get the folder to save to.
        /// </summary>
        private readonly DirectoryInfo directoryInfo;

        /// <summary>
        ///     Instance of MainForm, stored to update the file list when download
        ///     is completed.
        /// </summary>
        private readonly MainForm mainInstance;

        public WebImport(DirectoryInfo directory, MainForm instance)
        {
            this.InitializeComponent();
            this.directoryInfo = directory;
            this.mainInstance = instance;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void okBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.urlTextBox.Text))
            {
                if (!string.IsNullOrEmpty(this.fileNameText.Text))
                {
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadDataCompleted += (o, args) =>
                                {
                                    if (args.Result != null)
                                    {
                                        File.WriteAllBytes(
                                            this.directoryInfo.FullName + @"\" + this.fileNameText.Text,
                                            args.Result);
                                        this.mainInstance.LoadFiles();
                                        this.okBtn.Enabled = true;
                                        this.cancelBtn.Enabled = true;
                                    }
                                };

                            client.DownloadProgressChanged +=
                                (o, args) =>
                                    {
                                        this.downloadBar.Value = (int)(args.BytesReceived / args.TotalBytesToReceive)
                                                                 * 100;
                                    };

                            client.DownloadDataAsync(new Uri(this.urlTextBox.Text, UriKind.RelativeOrAbsolute));
                            this.okBtn.Enabled = false;
                            this.cancelBtn.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}