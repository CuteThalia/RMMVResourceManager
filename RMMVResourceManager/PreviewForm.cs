namespace RMMVResourceManager
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using ScintillaNET;

    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            this.InitializeComponent();
        }

        public PreviewForm(Image image)
        {
            this.InitializeComponent();

            this.Width = image.Width + 75;
            this.scintilla1.Hide();
            if (image.Height <= this.Height)
            {
                this.Height = image.Height + 75;
            }
            else
            {
                this.Height = 600;
            }
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.Image = image;
            this.pictureBox1.Parent = this.panel1;
        }

        public PreviewForm(string file, bool isrpgsave)
        {
            this.InitializeComponent();
            this.pictureBox1.Hide();
            if (isrpgsave)
            {
                var savedata = File.ReadAllText(file);
                var decoded = LzString.DecompressFromBase64(savedata);
                this.scintilla1.WrapMode = WrapMode.Word;
                this.scintilla1.Document = new Document();
                this.scintilla1.AddText(decoded);
                this.scintilla1.Refresh();
            }
            else
            {
                this.StartDocumentLoading(file);
            }
        }

        private async void StartDocumentLoading(string file)
        {
            var loader = this.scintilla1.CreateLoader(256);
            if (loader == null)
            {
                MessageBox.Show("We were unable to create the loader. Closing prewview.");
                this.Close();
            }

            var cts = new CancellationTokenSource();
            var document = await this.LoadFileAsync(loader, file, cts.Token);
            this.scintilla1.Document = document;

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            this.scintilla1.StyleResetDefault();
            this.scintilla1.Styles[Style.Default].Font = "Consolas";
            this.scintilla1.Styles[Style.Default].Size = 10;
            this.scintilla1.StyleClearAll();

            // Configure the CPP (JavaScript) lexer styles, based off Visual Studios default C# style.
            this.scintilla1.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            this.scintilla1.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            this.scintilla1.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            this.scintilla1.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            this.scintilla1.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            this.scintilla1.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            this.scintilla1.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            this.scintilla1.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            this.scintilla1.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            this.scintilla1.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            this.scintilla1.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            this.scintilla1.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            this.scintilla1.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            this.scintilla1.Lexer = Lexer.Cpp;

            // Set the keywords
            this.scintilla1.SetKeywords(
                0,
                "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            this.scintilla1.SetKeywords(
                1,
                "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void function");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task<Document> LoadFileAsync(ILoader loader, string path, CancellationToken cancellationToken)
        {
            try
            {
                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
                using (var reader = new StreamReader(file))
                {
                    var count = 0;
                    var buffer = new char[4096];
                    while ((count = await reader.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                    {
                        // Check for cancellation
                        cancellationToken.ThrowIfCancellationRequested();

                        // Add the data to the document
                        if (!loader.AddData(buffer, count))
                        {
                            throw new IOException("The data could not be added to the loader.");
                        }
                    }

                    return loader.ConvertToDocument();
                }
            }
            catch
            {
                loader.Release();
                throw;
            }
        }
    }
}