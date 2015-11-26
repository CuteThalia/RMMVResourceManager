namespace RMMVResourceManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileBoxLbl = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.ListBox();
            this.previewBtn = new System.Windows.Forms.Button();
            this.stopPreviewBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.importFromWeb = new System.Windows.Forms.Button();
            this.currentProjHeaderLbl = new System.Windows.Forms.Label();
            this.currentProjLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(517, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(60, 17);
            this.statusLbl.Text = "Status: Ok";
            // 
            // folderBox
            // 
            this.folderBox.FormattingEnabled = true;
            this.folderBox.Location = new System.Drawing.Point(12, 79);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(190, 316);
            this.folderBox.TabIndex = 2;
            this.folderBox.SelectedIndexChanged += new System.EventHandler(this.folderBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder:";
            // 
            // fileBoxLbl
            // 
            this.fileBoxLbl.AutoSize = true;
            this.fileBoxLbl.Location = new System.Drawing.Point(208, 65);
            this.fileBoxLbl.Name = "fileBoxLbl";
            this.fileBoxLbl.Size = new System.Drawing.Size(31, 13);
            this.fileBoxLbl.TabIndex = 5;
            this.fileBoxLbl.Text = "Files:";
            // 
            // fileBox
            // 
            this.fileBox.FormattingEnabled = true;
            this.fileBox.Location = new System.Drawing.Point(208, 81);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(190, 316);
            this.fileBox.TabIndex = 4;
            this.fileBox.SelectedIndexChanged += new System.EventHandler(this.fileBox_SelectedIndexChanged);
            // 
            // previewBtn
            // 
            this.previewBtn.Enabled = false;
            this.previewBtn.Location = new System.Drawing.Point(404, 81);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(100, 23);
            this.previewBtn.TabIndex = 6;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // stopPreviewBtn
            // 
            this.stopPreviewBtn.Enabled = false;
            this.stopPreviewBtn.Location = new System.Drawing.Point(404, 110);
            this.stopPreviewBtn.Name = "stopPreviewBtn";
            this.stopPreviewBtn.Size = new System.Drawing.Size(100, 23);
            this.stopPreviewBtn.TabIndex = 7;
            this.stopPreviewBtn.Text = "Stop Preview";
            this.stopPreviewBtn.UseVisualStyleBackColor = true;
            this.stopPreviewBtn.Click += new System.EventHandler(this.stopPreviewBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Enabled = false;
            this.importBtn.Location = new System.Drawing.Point(404, 139);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(100, 23);
            this.importBtn.TabIndex = 8;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Enabled = false;
            this.exportBtn.Location = new System.Drawing.Point(405, 169);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(99, 23);
            this.exportBtn.TabIndex = 9;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(404, 199);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 23);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // importFromWeb
            // 
            this.importFromWeb.Enabled = false;
            this.importFromWeb.Location = new System.Drawing.Point(404, 259);
            this.importFromWeb.Name = "importFromWeb";
            this.importFromWeb.Size = new System.Drawing.Size(100, 23);
            this.importFromWeb.TabIndex = 11;
            this.importFromWeb.Text = "Import From Web";
            this.importFromWeb.UseVisualStyleBackColor = true;
            this.importFromWeb.Click += new System.EventHandler(this.importFromWeb_Click);
            // 
            // currentProjHeaderLbl
            // 
            this.currentProjHeaderLbl.AutoSize = true;
            this.currentProjHeaderLbl.Location = new System.Drawing.Point(12, 28);
            this.currentProjHeaderLbl.Name = "currentProjHeaderLbl";
            this.currentProjHeaderLbl.Size = new System.Drawing.Size(80, 13);
            this.currentProjHeaderLbl.TabIndex = 12;
            this.currentProjHeaderLbl.Text = "Current Project:";
            // 
            // currentProjLbl
            // 
            this.currentProjLbl.AutoSize = true;
            this.currentProjLbl.Location = new System.Drawing.Point(99, 28);
            this.currentProjLbl.Name = "currentProjLbl";
            this.currentProjLbl.Size = new System.Drawing.Size(33, 13);
            this.currentProjLbl.TabIndex = 13;
            this.currentProjLbl.Text = "None";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 422);
            this.Controls.Add(this.currentProjLbl);
            this.Controls.Add(this.currentProjHeaderLbl);
            this.Controls.Add(this.importFromWeb);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.stopPreviewBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.fileBoxLbl);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RMMV Resource Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ListBox folderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileBoxLbl;
        private System.Windows.Forms.ListBox fileBox;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Button stopPreviewBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button importFromWeb;
        private System.Windows.Forms.Label currentProjHeaderLbl;
        private System.Windows.Forms.Label currentProjLbl;
    }
}

