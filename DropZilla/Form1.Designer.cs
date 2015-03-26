namespace DropZilla
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pan_perform = new System.Windows.Forms.Panel();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.txt_Name = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_Mail = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_deleteFiles = new System.Windows.Forms.Button();
            this.btn_deleteFolder = new System.Windows.Forms.Button();
            this.btn_addFiles = new System.Windows.Forms.Button();
            this.btn_addFolder = new System.Windows.Forms.Button();
            this.cmb_sort = new System.Windows.Forms.ComboBox();
            this.lbl_sort = new System.Windows.Forms.Label();
            this.pan_Explorer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trv_folders = new System.Windows.Forms.TreeView();
            this.cms_download = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ltv_files = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastEditHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chk_view = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pan_perform.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.pan_Explorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_download.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // pan_perform
            // 
            this.pan_perform.Controls.Add(this.lbl_progress);
            this.pan_perform.Controls.Add(this.progressBar1);
            this.pan_perform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_perform.Location = new System.Drawing.Point(0, 0);
            this.pan_perform.Name = "pan_perform";
            this.pan_perform.Size = new System.Drawing.Size(704, 597);
            this.pan_perform.TabIndex = 7;
            this.pan_perform.Visible = false;
            this.pan_perform.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_progress.Location = new System.Drawing.Point(215, 204);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(221, 33);
            this.lbl_progress.TabIndex = 11;
            this.lbl_progress.Text = "Downloading...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 268);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(662, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Value = 100;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_Name});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(704, 24);
            this.mainMenuStrip.TabIndex = 8;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // txt_Name
            // 
            this.txt_Name.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_Mail});
            this.txt_Name.Image = global::DropZilla.Properties.Resources.icon;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(85, 20);
            this.txt_Name.Text = "txt_Name";
            // 
            // txt_Mail
            // 
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Size = new System.Drawing.Size(115, 22);
            this.txt_Mail.Text = "txt_Mail";
            this.txt_Mail.Click += new System.EventHandler(this.txt_Reshow_Click);
            // 
            // btn_deleteFiles
            // 
            this.btn_deleteFiles.Image = global::DropZilla.Properties.Resources.file_delete;
            this.btn_deleteFiles.Location = new System.Drawing.Point(233, 35);
            this.btn_deleteFiles.Name = "btn_deleteFiles";
            this.btn_deleteFiles.Size = new System.Drawing.Size(32, 32);
            this.btn_deleteFiles.TabIndex = 6;
            this.btn_deleteFiles.UseVisualStyleBackColor = true;
            this.btn_deleteFiles.Click += new System.EventHandler(this.btn_deleteFiles_Click);
            // 
            // btn_deleteFolder
            // 
            this.btn_deleteFolder.Image = global::DropZilla.Properties.Resources.folder_delete;
            this.btn_deleteFolder.Location = new System.Drawing.Point(58, 35);
            this.btn_deleteFolder.Name = "btn_deleteFolder";
            this.btn_deleteFolder.Size = new System.Drawing.Size(32, 32);
            this.btn_deleteFolder.TabIndex = 5;
            this.btn_deleteFolder.UseVisualStyleBackColor = true;
            this.btn_deleteFolder.Click += new System.EventHandler(this.btn_deleteFolder_Click);
            // 
            // btn_addFiles
            // 
            this.btn_addFiles.Image = global::DropZilla.Properties.Resources.file_add;
            this.btn_addFiles.Location = new System.Drawing.Point(186, 35);
            this.btn_addFiles.Name = "btn_addFiles";
            this.btn_addFiles.Size = new System.Drawing.Size(32, 32);
            this.btn_addFiles.TabIndex = 4;
            this.btn_addFiles.UseVisualStyleBackColor = true;
            this.btn_addFiles.Click += new System.EventHandler(this.btn_addFiles_Click);
            // 
            // btn_addFolder
            // 
            this.btn_addFolder.Image = global::DropZilla.Properties.Resources.folder_add;
            this.btn_addFolder.Location = new System.Drawing.Point(13, 35);
            this.btn_addFolder.Name = "btn_addFolder";
            this.btn_addFolder.Size = new System.Drawing.Size(32, 32);
            this.btn_addFolder.TabIndex = 3;
            this.btn_addFolder.UseVisualStyleBackColor = true;
            this.btn_addFolder.Click += new System.EventHandler(this.btn_addFolder_Click);
            // 
            // cmb_sort
            // 
            this.cmb_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sort.FormattingEnabled = true;
            this.cmb_sort.Items.AddRange(new object[] {
            "Typ",
            "Name"});
            this.cmb_sort.Location = new System.Drawing.Point(608, 41);
            this.cmb_sort.Name = "cmb_sort";
            this.cmb_sort.Size = new System.Drawing.Size(81, 21);
            this.cmb_sort.TabIndex = 13;
            this.cmb_sort.SelectedIndexChanged += new System.EventHandler(this.cmb_sort_SelectedIndexChanged);
            // 
            // lbl_sort
            // 
            this.lbl_sort.AutoSize = true;
            this.lbl_sort.Location = new System.Drawing.Point(526, 44);
            this.lbl_sort.Name = "lbl_sort";
            this.lbl_sort.Size = new System.Drawing.Size(76, 13);
            this.lbl_sort.TabIndex = 12;
            this.lbl_sort.Text = "Sortieren nach";
            // 
            // pan_Explorer
            // 
            this.pan_Explorer.Controls.Add(this.splitContainer1);
            this.pan_Explorer.Location = new System.Drawing.Point(14, 73);
            this.pan_Explorer.Name = "pan_Explorer";
            this.pan_Explorer.Size = new System.Drawing.Size(678, 511);
            this.pan_Explorer.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trv_folders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ltv_files);
            this.splitContainer1.Size = new System.Drawing.Size(678, 511);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // trv_folders
            // 
            this.trv_folders.AllowDrop = true;
            this.trv_folders.ContextMenuStrip = this.cms_download;
            this.trv_folders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_folders.Location = new System.Drawing.Point(0, 0);
            this.trv_folders.Name = "trv_folders";
            this.trv_folders.Size = new System.Drawing.Size(172, 511);
            this.trv_folders.TabIndex = 5;
            this.trv_folders.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trv_folders_ItemDrag);
            this.trv_folders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_folders_NodeMouseClick);
            this.trv_folders.DragDrop += new System.Windows.Forms.DragEventHandler(this.trv_folders_DragDrop);
            this.trv_folders.DragEnter += new System.Windows.Forms.DragEventHandler(this.trv_folders_DragEnter);
            this.trv_folders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trv_folders_KeyDown);
            this.trv_folders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trv_folders_MouseDown);
            // 
            // cms_download
            // 
            this.cms_download.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cms_download.Name = "cms_download";
            this.cms_download.Size = new System.Drawing.Size(129, 26);
            this.cms_download.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_download_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "Download";
            // 
            // ltv_files
            // 
            this.ltv_files.AllowDrop = true;
            this.ltv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.TypeHeader,
            this.LastEditHeader,
            this.SizeHeader});
            this.ltv_files.ContextMenuStrip = this.cms_download;
            this.ltv_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltv_files.Location = new System.Drawing.Point(0, 0);
            this.ltv_files.Name = "ltv_files";
            this.ltv_files.Size = new System.Drawing.Size(496, 511);
            this.ltv_files.TabIndex = 7;
            this.ltv_files.UseCompatibleStateImageBehavior = false;
            this.ltv_files.DragDrop += new System.Windows.Forms.DragEventHandler(this.ltv_files_DragDrop);
            this.ltv_files.DragEnter += new System.Windows.Forms.DragEventHandler(this.ltv_files_DragEnter);
            this.ltv_files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ltv_files_KeyDown);
            this.ltv_files.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ltv_files_MouseDown);
            this.ltv_files.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltv_files_MouseMove);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 200;
            // 
            // TypeHeader
            // 
            this.TypeHeader.Text = "Type";
            this.TypeHeader.Width = 100;
            // 
            // LastEditHeader
            // 
            this.LastEditHeader.Text = "Änderungsdatum";
            this.LastEditHeader.Width = 100;
            // 
            // SizeHeader
            // 
            this.SizeHeader.Text = "Größe";
            // 
            // chk_view
            // 
            this.chk_view.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_view.BackgroundImage = global::DropZilla.Properties.Resources.View_Details;
            this.chk_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chk_view.Location = new System.Drawing.Point(485, 35);
            this.chk_view.Name = "chk_view";
            this.chk_view.Size = new System.Drawing.Size(35, 32);
            this.chk_view.TabIndex = 14;
            this.chk_view.UseVisualStyleBackColor = true;
            this.chk_view.CheckedChanged += new System.EventHandler(this.chk_view_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 597);
            this.Controls.Add(this.cmb_sort);
            this.Controls.Add(this.chk_view);
            this.Controls.Add(this.lbl_sort);
            this.Controls.Add(this.pan_Explorer);
            this.Controls.Add(this.btn_deleteFiles);
            this.Controls.Add(this.btn_deleteFolder);
            this.Controls.Add(this.btn_addFiles);
            this.Controls.Add(this.btn_addFolder);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.pan_perform);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "DropZilla";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.pan_perform.ResumeLayout(false);
            this.pan_perform.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.pan_Explorer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_download.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_deleteFolder;
        private System.Windows.Forms.Button btn_deleteFiles;
        private System.Windows.Forms.Panel pan_perform;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem txt_Name;
        private System.Windows.Forms.ToolStripMenuItem txt_Mail;
        private System.Windows.Forms.Button btn_addFolder;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cmb_sort;
        private System.Windows.Forms.Label lbl_sort;
        private System.Windows.Forms.Panel pan_Explorer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trv_folders;
        private System.Windows.Forms.ListView ltv_files;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip cms_download;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader TypeHeader;
        private System.Windows.Forms.ColumnHeader LastEditHeader;
        private System.Windows.Forms.CheckBox chk_view;
        private System.Windows.Forms.ColumnHeader SizeHeader;
        private System.Windows.Forms.Timer timer1;
    }
}

