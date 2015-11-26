namespace RMMVResourceManager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using IrrKlang;

    public partial class MainForm : Form
    {
        private readonly ISoundEngine soundEngine = new ISoundEngine();

        private List<FileInfo> currentFolderFiles;

        private ISound currentlyPlayingSound;

        private List<DirectoryInfo> directoriesInfos;

        public MainForm()
        {
            this.InitializeComponent();
            Configuration.LoadConfig();
            currentProjLbl.Text = Configuration.Instance.LastProject;
            if (string.IsNullOrEmpty(Configuration.Instance.LastProject) != true)
            {
                this.LoadFolders();
            }
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                Configuration.Instance.LastProject = dialog.SelectedPath;
                Configuration.Instance.Serialize();

                currentProjLbl.Text = Configuration.Instance.LastProject;
                this.LoadFolders();
            }
        }

        //method to check
        private static bool isDirectoryExcluded(List<string> excludedDirList, string target)
        {
            return excludedDirList.Any(d => new DirectoryInfo(target).FullName.Contains(d));
        }

        private static bool isFileExcluded(List<string> excludedFileList, string target)
        {
            return excludedFileList.Any(e => new FileInfo(target).Extension == e);
        }

        private bool isValidRPGMakerFolder(string path)
        {
            var info = new DirectoryInfo(Configuration.Instance.LastProject);
            if (info.GetFiles("*.rpgproject").Length == 0)
            {
                MessageBox.Show("This folder is not a folder containing an RPG Maker Project!");
                this.statusLbl.ForeColor = Color.DarkRed;
                this.statusLbl.Text = "Status: The folder selected does not contain a valid RPG Maker MV Project!";
                return false;
            }
            return true;
        }

        private void LoadFolders()
        {
            var info = new DirectoryInfo(Configuration.Instance.LastProject);
            if (this.isValidRPGMakerFolder(info.FullName))
            {
                this.directoriesInfos =
                    info.GetDirectories("*.*", SearchOption.AllDirectories)
                        .Where(
                            d => !isDirectoryExcluded(Configuration.Instance.DirectoryIgnoreList.ToList(), d.FullName))
                        .ToList();
                for (var i = 0; i < this.directoriesInfos.Count; i++)
                {
                    this.folderBox.Items.Add(
                        this.directoriesInfos[i].FullName.Replace(Configuration.Instance.LastProject, "")
                            .Replace("\\", "/")
                            .Remove(0, 1));
                }
            }
        }

        public void LoadFiles()
        {
            if (this.folderBox.SelectedItem != "" && this.folderBox.SelectedItem != null)
            {
                this.fileBox.Items.Clear();

                var directory = this.directoriesInfos[this.folderBox.SelectedIndex];
                if (directory != null)
                {
                    this.importBtn.Enabled = true;
                    this.currentFolderFiles =
                        directory.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                            .Where(f => !isFileExcluded(Configuration.Instance.FileTypeIgnoreList.ToList(), f.FullName))
                            .ToList();

                    for (var i = 0; i < this.currentFolderFiles.Count; i++)
                    {
                        this.fileBox.Items.Add(this.currentFolderFiles[i].Name);
                    }
                }
            }
            else
            {
                this.importBtn.Enabled = false;
            }
        }

        private void folderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.previewBtn.Enabled = false;
            this.stopPreviewBtn.Enabled = false;
            this.exportBtn.Enabled = false;
            this.deleteBtn.Enabled = false;
            this.importFromWeb.Enabled = true;
            this.importBtn.Enabled = true;
            this.LoadFiles();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            if (this.fileBox.SelectedItem != "" && this.fileBox.SelectedItem != null)
            {
                var file = this.currentFolderFiles[this.fileBox.SelectedIndex];
                if (file.Extension == ".png" || file.Extension == ".bmp" || file.Extension == ".jpeg"
                    || file.Extension == ".jpg" || file.Extension == ".gif")
                {
                    var preview = new PreviewForm(new Bitmap(file.FullName));
                    preview.Show();
                }
                else if (file.Extension == ".ogg")
                {
                    if (this.stopPreviewBtn.Enabled != true)
                    {
                        this.stopPreviewBtn.Enabled = true;
                    }
                    if (this.currentlyPlayingSound != null)
                    {
                        this.currentlyPlayingSound.Stop();
                        this.currentlyPlayingSound = null;
                    }
                    this.currentlyPlayingSound = this.soundEngine.Play2D(file.FullName);
                }
                else if (file.Extension == ".js" || file.Extension == ".xml" || file.Extension == ".json"
                         || file.Extension == ".html" || file.Extension == ".txt")
                {
                    var preview = new PreviewForm(file.FullName, false);
                    preview.Show();
                }
                else if (file.Extension == ".rpgsave")
                {
                    var preview = new PreviewForm(file.FullName, true);
                    preview.Show();
                }
            }
        }

        private void stopPreviewBtn_Click(object sender, EventArgs e)
        {
            if (this.currentlyPlayingSound != null)
            {
                this.currentlyPlayingSound.Stop();
                this.currentlyPlayingSound = null;
                this.stopPreviewBtn.Enabled = false;
            }
        }

        private void fileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fileBox.SelectedItem != "" && this.fileBox.SelectedItem != null)
            {
                this.previewBtn.Enabled = true;
                this.exportBtn.Enabled = true;
                this.deleteBtn.Enabled = true;
                var file = this.currentFolderFiles[this.fileBox.SelectedIndex];
                if (file.Extension != ".ogg")
                {
                    this.stopPreviewBtn.Enabled = false;
                }
            }
            else
            {
                this.previewBtn.Enabled = false;
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            var directory = this.directoriesInfos[this.folderBox.SelectedIndex];
            var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.Multiselect = true;
            if (directory.FullName.Contains(@"\audio\"))
            {
                dialog.Filter = "Audio Files (*.ogg, *.m4a)|*.ogg;*.m4a";
            }
            else if (directory.FullName.Contains(@"\img\"))
            {
                dialog.Filter = "Image Files (*.png)|*.png";
            }
            else if (directory.FullName.Contains(@"\js\"))
            {
                dialog.Filter = "JS Files (*.js)|*.js";
            }
            dialog.ShowDialog();

            if (dialog.FileNames != null && dialog.FileNames.Length > 0)
            {
                for (var i = 0; i < dialog.FileNames.Length; i++)
                {
                    if (File.Exists(dialog.FileNames[i]))
                    {
                        var splitname = dialog.FileNames[i].Split('\\');
                        File.Copy(dialog.FileNames[i], directory.FullName + "\\" + splitname.Last(), true);
                    }
                }
                this.LoadFiles();
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            var file = this.currentFolderFiles[this.fileBox.SelectedIndex];
            var dialog = new SaveFileDialog();
            if (file.Extension == ".ogg")
            {
                dialog.Filter = "Audio Files (*.ogg)|*.ogg";
            }
            else if (file.Extension == ".m4a")
            {
                dialog.Filter = "Audio Files (*.m4a)|*.m4a";
            }
            else if (file.Extension == ".png")
            {
                dialog.Filter = "Image Files (*.png)|*.png";
            }
            else if (file.Extension == ".js")
            {
                dialog.Filter = "JS Files (*.js)|*.js";
            }
            else
            {
                dialog.Filter = "All Files (*.*)|*.*";
            }

            dialog.ShowDialog();

            if (string.IsNullOrEmpty(dialog.FileName) != true)
            {
                File.Copy(file.FullName, dialog.FileName);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var file = this.currentFolderFiles[this.fileBox.SelectedIndex];
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                    this.LoadFiles();
                }
                catch (Exception ex)
                {
                    this.statusLbl.ForeColor = Color.DarkRed;
                    this.statusLbl.Text = "Status: " + ex.Message;
                }
            }
        }

        private void importFromWeb_Click(object sender, EventArgs e)
        {
            var import = new WebImport(this.directoriesInfos[this.folderBox.SelectedIndex], this);
            import.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }
        
    }
}