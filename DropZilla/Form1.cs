using DropboxRestAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropZilla
{
    public partial class Form1 : Form
    {
        #region Vars
        private const string myPath = "token";
        private Client client;
        private ToolStripProgressBar toolBar;
        private ToolStripMenuItem txt_Quota;
        private ToolStripMenuItem txt_LogOff;
        private const string DRAG_SOURCE_PREFIX = "__DragNDrop__Temp__";
        private object objDragItem;
        private FileSystemWatcher tempDirectoryWatcher;
        private Hashtable watchers = null;
        private string dragItemTempFileName = string.Empty;
        private bool itemDragStart = false;
        private bool isFolderDrag = false;
        private bool SearchActive = false;
        private bool CancelOpearation = false;
        private uint fileCounter; 
        private List<string> FilesToDownload;
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        #endregion

        #region Form Control
        public Form1()
        {
            InitializeComponent();
            FilesToDownload = new List<string>();
            this.Hide();
            this.Icon = DropZilla.Properties.Resources.main;
            toolBar = new ToolStripProgressBar("toolBar");
            txt_Name.DropDownItems.Add(toolBar);
            txt_Quota = new ToolStripMenuItem("txt_Quota");
            txt_Quota.Click += new EventHandler(txt_Reshow_Click);
            txt_Name.DropDownItems.Add(txt_Quota);
            txt_LogOff = new ToolStripMenuItem("txt_LogOff");
            txt_LogOff.Text = "Abmelden";
            txt_LogOff.Click += txt_LogOff_Click;
            txt_Name.DropDownItems.Add(txt_LogOff);
            mainMenuStrip.ImageList = new ImageList();
            cmb_sort.SelectedIndex = 0;
            pan_perform.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            LoadDropbox();
            #region Load Picture
            trv_folders.ImageList = new ImageList();
            trv_folders.ImageList.ImageSize = new System.Drawing.Size(16, 16);
            trv_folders.ImageList.Images.Add("folder_app", DropZilla.Properties.Resources.folder_app48);
            trv_folders.ImageList.Images.Add("folder_camera", DropZilla.Properties.Resources.folder_camera48);
            trv_folders.ImageList.Images.Add("folder_gray", DropZilla.Properties.Resources.folder_gray48);
            trv_folders.ImageList.Images.Add("folder_public", DropZilla.Properties.Resources.folder_public48);
            trv_folders.ImageList.Images.Add("folder_star", DropZilla.Properties.Resources.folder_star48);
            trv_folders.ImageList.Images.Add("folder_user_gray", DropZilla.Properties.Resources.folder_user_gray48);
            trv_folders.ImageList.Images.Add("folder_user", DropZilla.Properties.Resources.folder_user48);
            trv_folders.ImageList.Images.Add("folder", DropZilla.Properties.Resources.folder48);

            ltv_files.LargeImageList = new ImageList();
            ltv_files.LargeImageList.ImageSize = new System.Drawing.Size(48, 48);
            ltv_files.LargeImageList.Images.Add("excel", DropZilla.Properties.Resources.excel48);
            ltv_files.LargeImageList.Images.Add("music", DropZilla.Properties.Resources.music48);
            ltv_files.LargeImageList.Images.Add("package", DropZilla.Properties.Resources.package48);
            ltv_files.LargeImageList.Images.Add("page_white_acrobat", DropZilla.Properties.Resources.page_white_acrobat48);
            ltv_files.LargeImageList.Images.Add("page_white_actionscript", DropZilla.Properties.Resources.page_white_actionscript48);
            ltv_files.LargeImageList.Images.Add("page_white_c", DropZilla.Properties.Resources.page_white_c48);
            ltv_files.LargeImageList.Images.Add("page_white_code", DropZilla.Properties.Resources.page_white_code48);
            ltv_files.LargeImageList.Images.Add("page_white_cplusplus", DropZilla.Properties.Resources.page_white_cplusplus48);
            ltv_files.LargeImageList.Images.Add("page_white_csharp", DropZilla.Properties.Resources.page_white_csharp);
            ltv_files.LargeImageList.Images.Add("page_white_cup", DropZilla.Properties.Resources.page_white_cup48);
            ltv_files.LargeImageList.Images.Add("page_white_dvd", DropZilla.Properties.Resources.page_white_dvd);
            ltv_files.LargeImageList.Images.Add("page_white_flash", DropZilla.Properties.Resources.page_white_flash48);
            ltv_files.LargeImageList.Images.Add("page_white_gear", DropZilla.Properties.Resources.page_white_gear48);
            ltv_files.LargeImageList.Images.Add("page_white_h", DropZilla.Properties.Resources.page_white_h48);
            ltv_files.LargeImageList.Images.Add("page_white_paint", DropZilla.Properties.Resources.page_white_paint48);
            ltv_files.LargeImageList.Images.Add("page_white_php", DropZilla.Properties.Resources.page_white_php48);
            ltv_files.LargeImageList.Images.Add("page_white_picture", DropZilla.Properties.Resources.page_white_picture48);
            ltv_files.LargeImageList.Images.Add("page_white_ruby", DropZilla.Properties.Resources.page_white_ruby48);
            ltv_files.LargeImageList.Images.Add("page_white_text", DropZilla.Properties.Resources.page_white_text48);
            ltv_files.LargeImageList.Images.Add("page_white_tux", DropZilla.Properties.Resources.page_white_tux48);
            ltv_files.LargeImageList.Images.Add("page_white_vector", DropZilla.Properties.Resources.page_white_vector48);
            ltv_files.LargeImageList.Images.Add("page_white_visualstudio", DropZilla.Properties.Resources.page_white_visualstudio48);
            ltv_files.LargeImageList.Images.Add("page_white_compressed", DropZilla.Properties.Resources.page_white_zip48);
            ltv_files.LargeImageList.Images.Add("page_white", DropZilla.Properties.Resources.page_white48);
            ltv_files.LargeImageList.Images.Add("page_white_powerpoint", DropZilla.Properties.Resources.powerpoint48);
            ltv_files.LargeImageList.Images.Add("page_white_word", DropZilla.Properties.Resources.word48);

            ltv_files.SmallImageList = new ImageList();
            ltv_files.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
            ltv_files.SmallImageList.Images.Add("excel", DropZilla.Properties.Resources.excel48);
            ltv_files.SmallImageList.Images.Add("music", DropZilla.Properties.Resources.music48);
            ltv_files.SmallImageList.Images.Add("package", DropZilla.Properties.Resources.package48);
            ltv_files.SmallImageList.Images.Add("page_white_acrobat", DropZilla.Properties.Resources.page_white_acrobat48);
            ltv_files.SmallImageList.Images.Add("page_white_actionscript", DropZilla.Properties.Resources.page_white_actionscript48);
            ltv_files.SmallImageList.Images.Add("page_white_c", DropZilla.Properties.Resources.page_white_c48);
            ltv_files.SmallImageList.Images.Add("page_white_code", DropZilla.Properties.Resources.page_white_code48);
            ltv_files.SmallImageList.Images.Add("page_white_cplusplus", DropZilla.Properties.Resources.page_white_cplusplus48);
            ltv_files.SmallImageList.Images.Add("page_white_csharp", DropZilla.Properties.Resources.page_white_csharp);
            ltv_files.SmallImageList.Images.Add("page_white_cup", DropZilla.Properties.Resources.page_white_cup48);
            ltv_files.SmallImageList.Images.Add("page_white_dvd", DropZilla.Properties.Resources.page_white_dvd);
            ltv_files.SmallImageList.Images.Add("page_white_flash", DropZilla.Properties.Resources.page_white_flash48);
            ltv_files.SmallImageList.Images.Add("page_white_gear", DropZilla.Properties.Resources.page_white_gear48);
            ltv_files.SmallImageList.Images.Add("page_white_h", DropZilla.Properties.Resources.page_white_h48);
            ltv_files.SmallImageList.Images.Add("page_white_paint", DropZilla.Properties.Resources.page_white_paint48);
            ltv_files.SmallImageList.Images.Add("page_white_php", DropZilla.Properties.Resources.page_white_php48);
            ltv_files.SmallImageList.Images.Add("page_white_picture", DropZilla.Properties.Resources.page_white_picture48);
            ltv_files.SmallImageList.Images.Add("page_white_ruby", DropZilla.Properties.Resources.page_white_ruby48);
            ltv_files.SmallImageList.Images.Add("page_white_text", DropZilla.Properties.Resources.page_white_text48);
            ltv_files.SmallImageList.Images.Add("page_white_tux", DropZilla.Properties.Resources.page_white_tux48);
            ltv_files.SmallImageList.Images.Add("page_white_vector", DropZilla.Properties.Resources.page_white_vector48);
            ltv_files.SmallImageList.Images.Add("page_white_visualstudio", DropZilla.Properties.Resources.page_white_visualstudio48);
            ltv_files.SmallImageList.Images.Add("page_white_compressed", DropZilla.Properties.Resources.page_white_zip48);
            ltv_files.SmallImageList.Images.Add("page_white", DropZilla.Properties.Resources.page_white48);
            ltv_files.SmallImageList.Images.Add("page_white_powerpoint", DropZilla.Properties.Resources.powerpoint48);
            ltv_files.SmallImageList.Images.Add("page_white_word", DropZilla.Properties.Resources.word48);
            #endregion

            #if ShowAcceptForm
                File.Delete(myPath);
            #endif

            //Setting the tempDirectoryWatcher to monitor the creation of a file from our application
            tempDirectoryWatcher = new FileSystemWatcher();
            tempDirectoryWatcher.Path = Path.GetTempPath();
            tempDirectoryWatcher.Filter = string.Format("{0}*.tmp", DRAG_SOURCE_PREFIX);
            tempDirectoryWatcher.NotifyFilter = NotifyFilters.FileName;
            tempDirectoryWatcher.IncludeSubdirectories = false;
            tempDirectoryWatcher.EnableRaisingEvents = true;
            tempDirectoryWatcher.Created += new FileSystemEventHandler(TempDirectoryWatcherCreated);
        }

        private void btn_addFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK || trv_folders.SelectedNode == null)
                return;

            pan_perform.Visible = true;
            lbl_progress.Text = "Uploading...";
            List<string> l = new List<string>();
            l.Add((string)trv_folders.SelectedNode.Tag);
            l.AddRange(openFileDialog1.FileNames);
            bgw_Upload.RunWorkerAsync(new object[] { trv_folders.SelectedNode, l });
        }

        private void btn_addFolder_Click(object sender, EventArgs e)
        {
            if (trv_folders.SelectedNode != null)
            {
                TreeNode t = trv_folders.SelectedNode;

                AddFolder sf = new AddFolder();
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sf.isNew)
                    {
                        // Create a new folder
                        client.Core.FileOperations.CreateFolderAsync(((string)t.Tag).TrimEnd('/') + "/" + sf.FolderName).Wait();
                        LoadDirectory((string)t.Tag, t);
                    }
                    else
                    {
                        pan_perform.Visible = true;
                        bgw_Upload.RunWorkerAsync(new object[] { t, new List<string>() { (string)t.Tag, sf.FolderName } });
                    }
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.CancelOpearation = true;
        }

        private void btn_deleteFiles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchten Sie " + ltv_files.SelectedItems.Count + " Dateien wirklich löschen?", "Dateien löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ltv_files.SelectedItems != null)
                {
                    string path = "";
                    foreach (ListViewItem lvItem in ltv_files.SelectedItems)
                    {
                        client.Core.FileOperations.DeleteAsync((string)lvItem.Tag).Wait();
                        path = (string)lvItem.Tag;
                    }
                    LoadFiles((string)trv_folders.SelectedNode.Tag);
                }
            }
        }

        private void btn_deleteFolder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchten Sie " + trv_folders.SelectedNode.Text + " wirklich löschen?", "Ordner löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (trv_folders.SelectedNode != null)
                {
                    TreeNode t = trv_folders.SelectedNode;
                    TreeNode parent = t.Parent;
                    client.Core.FileOperations.DeleteAsync((string)t.Tag).Wait();
                    parent.Nodes.Remove(t);
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (Cursor.Position.X >= 150 && txt_search.Text != "" && txt_search.Text != "Suchen...")
                Search();
        }

        private void chk_view_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_view.Checked)
            {
                ltv_files.View = View.Details;
            }
            else
            {
                ltv_files.View = View.LargeIcon;
            }
            LoadFiles((string)trv_folders.SelectedNode.Tag);
        }

        private void cmb_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltv_files.Sorting = SortOrder.Ascending;
            if (cmb_sort.SelectedIndex == 0)
                ltv_files.ListViewItemSorter = new TypeItemComparer();
            else
                ltv_files.ListViewItemSorter = new NameItemComparer();
        }

        private void cms_download_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            var contr = cms.SourceControl as ListView;
            cms.Close();
            SearchActive = false;
            
            if (contr == null)
            {
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pan_perform.Visible = true;
                    lbl_fileCountMax.Text = "von " + GetFileCount((string)trv_folders.SelectedNode.Tag, true).ToString();
                    bgw_Download.RunWorkerAsync(new object[] { Path.Combine(folderBrowserDialog1.SelectedPath, trv_folders.SelectedNode.Text), (string)trv_folders.SelectedNode.Tag });
                }
            }
            else
            {
                if (e.ClickedItem.Text == "Download")
                {
                    pan_perform.Visible = true;
                    if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] sFiles = new string[ltv_files.SelectedItems.Count];
                        for (int i = 0; i < ltv_files.SelectedItems.Count; i++)
                        {
                            sFiles[i] = (string)ltv_files.SelectedItems[i].Tag;
                        }
                        lbl_fileCountMax.Text = "von " + sFiles.Length.ToString();
                        bgw_DownloadFiles.RunWorkerAsync(new object[] { folderBrowserDialog1.SelectedPath, sFiles });
                    }
                }
                else
                {
                    TreeNode node = trv_folders.Nodes[0];
                    string s = ltv_files.SelectedItems[0].Tag.ToString();
                    string[] comp = s.Substring(0, s.LastIndexOf("/")).Split(new char[] { '/' });
                    for (int i = 1; i < comp.Length; i++)
                    {
                        TreeNode newnode = node.Nodes[comp[i]];
                        if (newnode == null)
                        {
                            TreeNode child = new TreeNode();
                            child.Name = comp[i];
                            child.Text = comp[i];
                            string path = "";
                            for (int j = 1; j < i; j++)
                                path += "/" + comp[j];
                            child.Tag = path;
                            child.ImageKey = "folder";
                            child.SelectedImageKey = "folder";
                            node.Nodes.Add(child);
                        }
                        node = newnode;
                    }
                    LoadDirectory(ltv_files.SelectedItems[0].Tag.ToString().Substring(0, ltv_files.SelectedItems[0].Tag.ToString().LastIndexOf("/")), node);
                }
            }
        }

        private void cms_download_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)sender;
            var contr = cms.SourceControl as ListView;
            if (SearchActive && contr != null)
                cms_download.Items[1].Visible = true;
            else
                cms_download.Items[1].Visible = false;
        }

        private void ltv_files_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ltv_files.SelectedItems.Count >= 1)
            {
                btn_deleteFiles.PerformClick();
            }
        }

        private void trv_folders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && trv_folders.SelectedNode != null)
            {
                btn_deleteFolder.PerformClick();
            }
        }

        private void trv_folders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node.Nodes.Count < 1)
                    LoadDirectory((string)e.Node.Tag, e.Node);
                else
                    LoadFiles((string)e.Node.Tag);
            }
        }

        private void txt_LogOff_Click(object sender, EventArgs e)
        {
            File.Delete(myPath);
            Application.Restart();
        }

        private void txt_Reshow_Click(object sender, EventArgs e)
        {
            txt_Name.ShowDropDown();
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.ForeColor = System.Drawing.Color.Black;
            txt_search.Text = "";
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txt_search_Leave(object sender, EventArgs e)
        {
            if (txt_search.Text == "" || txt_search.Text == "Suchen...")
            {
                txt_search.ForeColor = System.Drawing.SystemColors.ScrollBar;
                txt_search.Text = "Suchen...";
            }
            else
                Search();
        }

        #region Form resize
        private void btn_search_LocationChanged(object sender, EventArgs e)
        {
            txt_search.Location = new System.Drawing.Point(btn_search.Location.X + 2, btn_search.Location.Y + 4);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            btn_addFiles.Location = new System.Drawing.Point(e.SplitX + 15, 35);
            btn_deleteFiles.Location = new System.Drawing.Point(e.SplitX + 62, 35);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            btn_search.Location = new System.Drawing.Point(this.Size.Width - 198, 0);
            pan_perform.Size = new System.Drawing.Size(this.Size.Width - 29, this.Size.Height - 76);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            pan_Explorer.Size = new System.Drawing.Size(pan_perform.Size.Width - 13, pan_perform.Size.Height - 48);
            lbl_sort.Location = new System.Drawing.Point(pan_perform.Size.Width - 166, lbl_sort.Location.Y);
            chk_view.Location = new System.Drawing.Point(lbl_sort.Location.X - 41, chk_view.Location.Y);
            cmb_sort.Location = new System.Drawing.Point(lbl_sort.Location.X + 85, cmb_sort.Location.Y);
        }
        #endregion

        #region Drag'n Drop
        private void ltv_files_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Effect == System.Windows.Forms.DragDropEffects.Copy || e.Effect == System.Windows.Forms.DragDropEffects.Move)
            {
                string[] f = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
                string[] files = new string[f.Length];
                f.CopyTo(files, 0);
                List<string> l = new List<string>();
                l.Add((string)trv_folders.SelectedNode.Tag);
                l.AddRange(files);
                pan_perform.Visible = true;
                lbl_progress.Text = "Uploading...";
                bgw_Upload.RunWorkerAsync(new object[] { trv_folders.SelectedNode, l });
            }
        }

        private void ltv_files_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.Copy;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;
        }

        private void ltv_files_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ClearDragData();
            if (e.Button == MouseButtons.Left && ltv_files.SelectedItems.Count > 0)
            {
                objDragItem = ltv_files.SelectedItems[0].Text;
                itemDragStart = true;
                isFolderDrag = false;
            }
        }

        private void ltv_files_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
            {
                FilesToDownload.Clear();
                return;
            }
            if (itemDragStart && objDragItem != null)
            {
                foreach (ListViewItem lvitem in ltv_files.SelectedItems)
                {
                    FilesToDownload.Add((string)lvitem.Tag);
                }
                //lbl_progress.Text = "Downloading...";
                //pan_perform.Visible = true;
                dragItemTempFileName = string.Format("{0}{1}{2}.tmp", Path.GetTempPath(), DRAG_SOURCE_PREFIX, ltv_files.SelectedItems[0].Text);
                try
                {
                    CreateDragItemTempFile(dragItemTempFileName);

                    string[] fileList = new string[] { dragItemTempFileName };
                    System.Windows.Forms.DataObject fileDragData = new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.FileDrop, fileList);
                    DoDragDrop(fileDragData, System.Windows.Forms.DragDropEffects.Move);

                    ClearDragData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void trv_folders_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ClearDragData();
            if (e.Button == MouseButtons.Left && trv_folders.SelectedNode != null)
            {
                objDragItem = trv_folders.SelectedNode.Text;
                itemDragStart = true;
                isFolderDrag = true;
            }
        }

        private void trv_folders_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop) && this.itemDragStart)
                e.Effect = System.Windows.Forms.DragDropEffects.Move;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;
        }

        private void trv_folders_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == System.Windows.Forms.DragDropEffects.Copy || e.Effect == System.Windows.Forms.DragDropEffects.Move || this.itemDragStart)
            {
                TreeNode targetNode = trv_folders.GetNodeAt(trv_folders.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                //TreeNode node 
                List<string> l = new List<string>();
                l.Add((string)targetNode.Tag);
                foreach (ListViewItem lvItem in ltv_files.SelectedItems)
                {
                    l.Add((string)lvItem.Tag);
                }
                pan_perform.Visible = true;
                lbl_progress.Text = "Moving...";
                bgw_Move.RunWorkerAsync(new object[] { trv_folders.SelectedNode, l });
            }
        }

        private void trv_folders_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                return;

            //if (itemDragStart && objDragItem != null)
            //{
            FilesToDownload.Add((string)trv_folders.SelectedNode.Tag);
            lbl_progress.Text = "Downloading...";
            pan_perform.Visible = true;
            dragItemTempFileName = string.Format("{0}{1}{2}.tmp", Path.GetTempPath(), DRAG_SOURCE_PREFIX, trv_folders.SelectedNode.Text);
            try
            {
                CreateDragItemTempFile(dragItemTempFileName);

                string[] fileList = new string[] { dragItemTempFileName };
                System.Windows.Forms.DataObject fileDragData = new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.FileDrop, fileList);
                DoDragDrop(fileDragData, System.Windows.Forms.DragDropEffects.Move);

                ClearDragData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
        }
        #endregion
        #endregion

        #region BackgroundWorker
        void bgw_DownloadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pan_perform.Visible = false;
        }

        void bgw_DownloadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] objects = (object[])e.Argument;
            string[] files = (string[])objects[1];
            string localPath = (string)objects[0];

            for (int i = 0; i < files.Length; i++)
            {
                string filename = files[i].Substring(files[i].LastIndexOf("/") + 1);
                using (Stream stream = new FileStream(Path.Combine(localPath, filename), FileMode.Create))
                {
                    client.Core.Metadata.FilesAsync(files[i], stream);
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                    while (stream.Position < stream.Length || stream.Length == 0)
                    {
                        if (stream.Length != 0)
                        {
                            if (!sw.IsRunning)
                                sw.Start();
                            if (this.CancelOpearation)
                            {
                                stream.Close();
                                DeleteFile(Path.Combine(localPath, filename));
                                this.CancelOpearation = false;
                                break;
                            }
                            int x = (int)Math.Round(((double)stream.Position / (double)stream.Length) * 100, 0);
                            bgw_DownloadFiles.ReportProgress(x, new object[] { stream.Position, sw.ElapsedMilliseconds, files.Length, i + 1});
                        }
                        Thread.Sleep(100);
                    }
                }
            }
        }

        void bgw_DownloadFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            object[] obj = (object[])e.UserState;
            lbl_speed.Text = ToSpeed(Convert.ToDouble(obj[0]) / (Convert.ToDouble(obj[1]) / 1000));
            lbl_fileCount.Text = string.Format("Datei {0}", obj[2]);
        }

        void bgw_DownloadOnDrag_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlPropertyThreadSafe(pan_perform, "Visible", false);
        }

        void bgw_DownloadOnDrag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!pan_perform.Visible)
                SetControlPropertyThreadSafe(pan_perform, "Visible", true);
            SetControlPropertyThreadSafe(progressBar1, "Value", e.ProgressPercentage);
            object[] obj = (object[])e.UserState;
            SetControlPropertyThreadSafe(lbl_speed, "Text", ToSpeed(Convert.ToDouble(obj[0]) / (Convert.ToDouble(obj[1]) / 1000)));
            SetControlPropertyThreadSafe(lbl_fileCount, "Text", string.Format("Datei {0}", obj[2]));
        }

        void bgw_DownloadOnDrag_DoWork(object sender, DoWorkEventArgs e)
        {
            string dropedFilePath = (string)e.Argument;
            if (dropedFilePath.Trim() != string.Empty && objDragItem != null)
            {
                string dropPath = dropedFilePath.Substring(0, dropedFilePath.LastIndexOf('\\'));

                if (File.Exists(dropedFilePath))
                    File.Delete(dropedFilePath);
                RefreshWindowsExplorer();

                if (isFolderDrag)
                {
                    int cnt = 0;
                    foreach(string s in FilesToDownload)
                        cnt += GetFileCount(s, true);
                    SetControlPropertyThreadSafe(lbl_fileCountMax, "Text", "von " + cnt.ToString());
                }
                else
                    lbl_fileCountMax.Text = "von " + FilesToDownload.Count.ToString();
                fileCounter = 0;
                for (int i = 0; i < FilesToDownload.Count; i++)
                {
                    if (isFolderDrag)
                    {
                        DownloadFolder(dropPath + "\\" + FilesToDownload[i].Substring(1), FilesToDownload[i]);
                    }
                    else
                    {
                        string filename = FilesToDownload[i].Substring(FilesToDownload[i].LastIndexOf("/") + 1);
                        using (Stream stream = new FileStream(Path.Combine(dropPath, filename), FileMode.Create))
                        {
                            client.Core.Metadata.FilesAsync(FilesToDownload[i], stream);
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                            while (stream.Position < stream.Length || stream.Length == 0)
                            {
                                if (stream.Length != 0)
                                {
                                    if (!sw.IsRunning)
                                        sw.Start();
                                    if (this.CancelOpearation)
                                    {
                                        stream.Close();
                                        DeleteFile(Path.Combine(dropPath, filename));
                                        this.CancelOpearation = false;
                                        break;
                                    }
                                    int x = (int)Math.Round(((double)stream.Position / (double)stream.Length) * 100, 0);
                                    bgw_DownloadOnDrag.ReportProgress(x, new object[] { stream.Position, sw.ElapsedMilliseconds, i});
                                }
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
                RefreshWindowsExplorer();
                FilesToDownload.Clear();
            }
            objDragItem = null;
        }

        void bgw_Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pan_perform.Visible = false;
        }

        void bgw_Download_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] objects = (string[])e.Argument;
            DownloadFolder(objects[0], objects[1]);
        }

        void bgw_Download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            object[] obj = (object[])e.UserState;
            lbl_speed.Text = ToSpeed(Convert.ToDouble(obj[0]) / (Convert.ToDouble(obj[1]) / 1000));
            lbl_fileCount.Text = string.Format("Datei {0}", obj[2]);
        }

        void bgw_Move_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pan_perform.Visible = false;
            TreeNode t = (TreeNode)e.Result;
            LoadDirectory((string)t.Tag, t);
        }

        void bgw_Move_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void bgw_Move_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] objects = (object[])e.Argument;
            List<string> files = (List<string>)objects[1];
            string targetPath = files[0];
            if (!targetPath.EndsWith("/"))
                targetPath += "/";
            files.RemoveAt(0);

            for (int i = 0; i < files.Count; i++)
            {
                client.Core.FileOperations.MoveAsync(files[i], targetPath + GetFileName(files[i])).Wait();
                bgw_Move.ReportProgress(i * 100 / files.Count);
            }
            e.Result = objects[0];
        }

        void bgw_Upload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] objects = (object[])e.Result;
            pan_perform.Visible = false;
            lbl_progress.Text = "Uploading...";
            LoadDirectory((string)objects[0], (TreeNode)objects[1]);
        }

        void bgw_Upload_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] objects = (object[])e.Argument;
            List<string> files = (List<string>)objects[1];
            string path = files[0];
            if (!path.EndsWith("/"))
                path += "/";

            //Upload all Files
            for (int i = 1; i < files.Count; i++)
            {
                if (!isFolder(files[i]))
                {
                    UploadFile(files[i], path + Path.GetFileName(files[i]));
                }
            }

            //Upload all Directories
            for (int i = 1; i < files.Count; i++)
            {
                if (isFolder(files[i]))
                {
                    string s = path + GetDirectoryName(files[i]);
                    UploadFolder(files[i], path);
                }
            }
            Thread.Sleep(1000);
            e.Result = new object[] { path, objects[0] };
        }

        void bgw_Upload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            object[] obj = (object[])e.UserState;
            lbl_speed.Text = ToSpeed(Convert.ToDouble(obj[0]) / (Convert.ToDouble(obj[1]) / 1000));

        }
        #endregion

        #region Helper Methods
        private void ClearDragData()
        {
            try
            {
                if (File.Exists(dragItemTempFileName))
                    File.Delete(dragItemTempFileName);
                objDragItem = null;
                dragItemTempFileName = string.Empty;
                itemDragStart = false;
                ClearFileWatchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDragItemTempFile(string dragItemTempFileName)
        {
            FileStream fsDropFile = null;

            try
            {
                fsDropFile = new FileStream(dragItemTempFileName, FileMode.Create);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fsDropFile != null)
                {
                    fsDropFile.Flush();
                    fsDropFile.Close();
                    fsDropFile.Dispose();
                    File.SetAttributes(dragItemTempFileName, File.GetAttributes(dragItemTempFileName) | FileAttributes.Hidden);
                }
            }
        }

        private void DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch
            {
            }
        }

        private int GetFileCount(string path="/", bool includeSubDirs = false)
        {
            int count = 0;
            var t = client.Core.Metadata.MetadataAsync(path);
            t.Wait();

            foreach (var element in t.Result.contents)
            {
                if (!element.is_dir)
                    count++;
                else if (includeSubDirs)
                    count += GetFileCount(element.path, true);
            }

            return count;
        }

        private void DownloadFolder(string localPath, string RemotePath)
        {
            //var Folder2 = client.Core.Metadata.MetadataAsync("/", list: true);
            Task<DropboxRestAPI.Models.Core.MetaData> t = client.Core.Metadata.MetadataAsync(RemotePath, list: true);
            t.Wait();
            var Folder = t.Result;

            Directory.CreateDirectory(localPath);
            foreach (var file in Folder.contents)
            {
                if (!file.is_dir)
                {
                    using (Stream stream = new FileStream(Path.Combine(localPath, file.Name), FileMode.Create))
                    {
                        client.Core.Metadata.FilesAsync(file.path, stream);
                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                        while (stream.Position < stream.Length || stream.Length == 0)
                        {
                            if (stream.Length != 0)
                            {
                                if (!sw.IsRunning)
                                    sw.Start();
                                if (this.CancelOpearation)
                                {
                                    stream.Close();
                                    DeleteFile(Path.Combine(localPath, file.Name));
                                    this.CancelOpearation = false;
                                    break;
                                }
                                int x = (int)Math.Round(((double)stream.Position / (double)stream.Length) * 100, 0);
                                if (bgw_DownloadOnDrag.IsBusy)
                                    bgw_DownloadOnDrag.ReportProgress(x, new object[] { stream.Position, sw.ElapsedMilliseconds, fileCounter + 1 });
                                else
                                    bgw_Download.ReportProgress(x, new object[] { stream.Position, sw.ElapsedMilliseconds, fileCounter + 1 });
                            }
                            Thread.Sleep(100);
                        }
                        fileCounter++;
                    }
                }
            }

            foreach (var file in Folder.contents)
            {
                if (file.is_dir)
                {
                    DownloadFolder(Path.Combine(localPath, file.Name), RemotePath + "/" + file.Name);
                }
            }
        }

        private string GetDirectoryName(string path)
        {
            string s = path;
            if (s.EndsWith("\\"))
            {
                s = s.Substring(0, s.Length - 1);
            }
            s = s.Substring(s.LastIndexOf("\\") + 1);

            return s;
        }

        private string GetFileName(string path)
        {
            string s = path;
            s = s.Substring(s.LastIndexOf("/") + 1);

            return s;
        }

        private int GetFileCount(string[] files)
        {
            int count = 0;
            foreach (string file in files)
            {
                if (isFolder(file))
                {
                    List<string> newFiles = new List<string>();
                    newFiles.AddRange(Directory.GetFiles(file));
                    newFiles.AddRange(Directory.GetDirectories(file));
                    count += GetFileCount(newFiles.ToArray());
                }
                else
                    count++;
            }
            return count;
        }

        private static string GetFileTypeDescription(string fileNameOrExtension)
        {
            NativeMethods.SHFILEINFO shfi;
            if (IntPtr.Zero != NativeMethods.SHGetFileInfo(
                                fileNameOrExtension,
                                 NativeMethods.FILE_ATTRIBUTE_NORMAL,
                                out shfi,
                                (uint)Marshal.SizeOf(typeof(NativeMethods.SHFILEINFO)),
                                 NativeMethods.SHGFI_USEFILEATTRIBUTES | NativeMethods.SHGFI_TYPENAME))
            {
                return shfi.szTypeName;
            }
            return null;
        }

        private void Init_pan_perform()
        {
            pan_perform.Visible = true;
            progressBar1.Value = 0;
        }

        private bool isFolder(string Path)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(Path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return true;
            else
                return false;
        }

        private async Task LoadDirectory(string path = "/", TreeNode node = null)
        {
            // Get root folder with content
            var rootFolder = await client.Core.Metadata.MetadataAsync(path, list: true, locale: "de");
            TreeNode root = new TreeNode();
            root.Name = "root";
            root.Text = "Dropbox";
            root.Tag = rootFolder.path;
            root.ImageKey = "folder";
            root.SelectedImageKey = "folder";

            ltv_files.Items.Clear();
            foreach (var folder in rootFolder.contents)
            {
                if (folder.is_dir)
                {
                    TreeNode child = new TreeNode();
                    child.Name = folder.Name;
                    child.Text = folder.Name;
                    child.Tag = folder.path;
                    child.ImageKey = folder.icon;
                    child.SelectedImageKey = folder.icon;
                    root.Nodes.Add(child);
                }
                else
                {
                    if (ltv_files.View == View.LargeIcon)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = folder.Name;
                        lvItem.Tag = folder.path;
                        lvItem.ImageKey = folder.icon;
                        DateTime dt = Convert.ToDateTime(folder.modified);
                        lvItem.ToolTipText = "Elementtyp: " + GetFileTypeDescription(folder.Extension) + Environment.NewLine +
                                            string.Format("Änderungsdatum: {0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()) + Environment.NewLine +
                                            "Größe: " + folder.size;
                        ltv_files.Items.Add(lvItem);
                        ltv_files.ShowItemToolTips = true;
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = folder.Name;
                        lvItem.SubItems.Add(GetFileTypeDescription(folder.Extension));
                        DateTime dt = Convert.ToDateTime(folder.modified);
                        lvItem.SubItems.Add(string.Format("{0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()));
                        lvItem.SubItems.Add(folder.size);
                        lvItem.Tag = folder.path;
                        lvItem.ImageKey = folder.icon;
                        ltv_files.Items.Add(lvItem);
                    }
                }
            }
            if (node == null)
            {
                trv_folders.Nodes.Add(root);
                root.Toggle();
                trv_folders.SelectedNode = root;
            }
            else
            {
                TreeNode[] t = new TreeNode[root.Nodes.Count];
                root.Nodes.CopyTo(t, 0);
                foreach (TreeNode trn in t)
                {
                    if (!NodeExits(node, trn.Text))
                    {
                        node.Nodes.Add(trn);
                    }
                }
                //node.Nodes.AddRange(t);
            }

            var accountInfo = await client.Core.Accounts.AccountInfoAsync();
            txt_Quota.Text = ToFileSize(accountInfo.quota_info.normal + accountInfo.quota_info.shared) + " von " + ToFileSize(accountInfo.quota_info.quota);
        }

        private async Task LoadDropbox()
        {
            if (File.Exists(myPath))
            {
                string myToken = "";
                using (StreamReader sr = new StreamReader(myPath))
                {
                    myToken = sr.ReadLine();
                }
                var options = new Options
                {
                    ClientId = "scaqzp9gex6tkqo",
                    ClientSecret = "atwuwn48zjdlvpw",
                    RedirectUri = "https://www.dropbox.com/1/oauth2/redirect_receiver",
                    AccessToken = myToken
                };

                // Initialize a new Client (without an AccessToken)
                client = new Client(options);
            }
            else
            {
                var options = new Options
                {
                    ClientId = "scaqzp9gex6tkqo",
                    ClientSecret = "atwuwn48zjdlvpw",
                    RedirectUri = "https://www.dropbox.com/1/oauth2/redirect_receiver"
                };

                // Initialize a new Client (without an AccessToken)
                client = new Client(options);

                //Get the OAuth Request Url
                var authRequestUrl = await client.Core.OAuth2.AuthorizeAsync("code");

                AcceptForm af = new AcceptForm(authRequestUrl.AbsoluteUri);
                //this.Show();
                //this.Opacity = 100;
                if (af.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    this.Close();
                this.Opacity = 0;
                string authCode = af.Response;

                // Exchange the Authorization Code with Access/Refresh tokens
                var token = await client.Core.OAuth2.TokenAsync(authCode);
                using (StreamWriter sw = new StreamWriter(myPath))
                {
                    sw.WriteLine(client.UserAccessToken);
                }
            }

            LoadingForm lf = new LoadingForm(this);
            lf.Show();
            // Get account info
            var accountInfo = await client.Core.Accounts.AccountInfoAsync();

            //txt_User.Text =  accountInfo.uid.ToString();
            txt_Name.Text = accountInfo.display_name;
            txt_Mail.Text = accountInfo.email;
            txt_Quota.Text = ToFileSize(accountInfo.quota_info.normal + accountInfo.quota_info.shared) + " von " + ToFileSize(accountInfo.quota_info.quota);
            toolBar.Maximum = Convert.ToInt32(accountInfo.quota_info.quota / 1048576);
            toolBar.Value = Convert.ToInt32((accountInfo.quota_info.normal + accountInfo.quota_info.shared) / 1048576);

            //// Find a file in the root folder
            //var file = rootFolder.contents.FirstOrDefault(x => x.is_dir == false);

            await LoadDirectory();
            lf.Close();
        }

        private async Task LoadFiles(string path = "/")
        {
            var rootFolder = await client.Core.Metadata.MetadataAsync(path, list: true);

            ltv_files.Items.Clear();
            foreach (var folder in rootFolder.contents)
            {
                if (!folder.is_dir)
                {
                    if (ltv_files.View == View.LargeIcon)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = folder.Name;
                        lvItem.Tag = folder.path;
                        lvItem.ImageKey = folder.icon;
                        DateTime dt = Convert.ToDateTime(folder.modified);
                        lvItem.ToolTipText = "Elementtyp: " + GetFileTypeDescription(folder.Extension) + Environment.NewLine +
                                            string.Format("Änderungsdatum: {0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()) + Environment.NewLine +
                                            "Größe: " + folder.size;
                        ltv_files.Items.Add(lvItem);
                        ltv_files.ShowItemToolTips = true;
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = folder.Name;
                        lvItem.SubItems.Add(GetFileTypeDescription(folder.Extension));
                        DateTime dt = Convert.ToDateTime(folder.modified);
                        lvItem.SubItems.Add(string.Format("{0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()));
                        lvItem.SubItems.Add(folder.size);
                        lvItem.Tag = folder.path;
                        lvItem.ImageKey = folder.icon;
                        ltv_files.Items.Add(lvItem);
                    }
                }
            }
        }

        private bool NodeExits(TreeNode root, string name)
        {
            foreach (TreeNode child in root.Nodes)
            {
                if (child.Text == name)
                    return true;
            }
            return false;
        }

        public static void RefreshWindowsExplorer()
        {
            // Refresh any open explorer windows
            // based on http://stackoverflow.com/questions/2488727/refresh-windows-explorer-in-win7
            Guid CLSID_ShellApplication = new Guid("13709620-C279-11CE-A49E-444553540000");
            Type shellApplicationType = Type.GetTypeFromCLSID(CLSID_ShellApplication, true);

            object shellApplication = Activator.CreateInstance(shellApplicationType);
            object windows = shellApplicationType.InvokeMember("Windows", System.Reflection.BindingFlags.InvokeMethod, null, shellApplication, new object[] { });

            Type windowsType = windows.GetType();
            object count = windowsType.InvokeMember("Count", System.Reflection.BindingFlags.GetProperty, null, windows, null);
            for (int i = 0; i < (int)count; i++)
            {
                object item = windowsType.InvokeMember("Item", System.Reflection.BindingFlags.InvokeMethod, null, windows, new object[] { i });
                Type itemType = item.GetType();

                // Only refresh Windows Explorer, without checking for the name this could refresh open IE windows
                string itemName = (string)itemType.InvokeMember("Name", System.Reflection.BindingFlags.GetProperty, null, item, null);
                if (itemName == "Windows Explorer")
                {
                    itemType.InvokeMember("Refresh", System.Reflection.BindingFlags.InvokeMethod, null, item, null);
                }
            }
            //Refresh desktop by passing F5 key to its handle
            NativeMethods.SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
            //IntPtr d = NativeMethods.FindWindow("Progman", "Program Manager");
            //d = NativeMethods.FindWindowEx(d, IntPtr.Zero, "SHELLDLL_DefView", null);
            //d = NativeMethods.FindWindowEx(d, IntPtr.Zero, "SysListView32", null);
            //NativeMethods.PostMessage(d, 0x100, new IntPtr(0x74), IntPtr.Zero);//WM_KEYDOWN = 0x100  VK_F5 = 0x74
            //NativeMethods.PostMessage(d, 0x101, new IntPtr(0x74), new IntPtr(1 << 31));//WM_KEYUP = 0x101
        }

        public void Search()
        {
            SearchActive = true;
            txt_search.AutoCompleteCustomSource.Add(txt_search.Text);
            var t = client.Core.Metadata.SearchAsync((String)trv_folders.SelectedNode.Tag, txt_search.Text);
            t.Wait();
            if (t.Result.Count() == 0)
            {
                txt_search.SelectAll();
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.IsBalloon = true;
                ToolTip1.ShowAlways = true;
                ToolTip1.UseAnimation = false;
                ToolTip1.UseFading = false;
                ToolTip1.ToolTipIcon = ToolTipIcon.Info;
                ToolTip1.Show("K", txt_search, 75, 0, 1);
                ToolTip1.UseFading = true;
                ToolTip1.ToolTipTitle = "Leider";
                ToolTip1.Show("... wurden keine Dateien gefunden", txt_search, 75, txt_search.Size.Height, 3000);
                return;
            }
            txt_search.Text = "Suchen...";
            ltv_files.Items.Clear();
            foreach (var file in t.Result)
            {
                if (ltv_files.View == View.LargeIcon)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = file.Name;
                    lvItem.Tag = file.path;
                    lvItem.ImageKey = file.icon;
                    DateTime dt = Convert.ToDateTime(file.modified);
                    lvItem.ToolTipText = "Elementtyp: " + GetFileTypeDescription(file.Extension) + Environment.NewLine +
                                        string.Format("Änderungsdatum: {0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()) + Environment.NewLine +
                                        "Größe: " + file.size + Environment.NewLine +
                                        file.path;
                    ltv_files.Items.Add(lvItem);
                    ltv_files.ShowItemToolTips = true;
                }
                else
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = file.Name;
                    lvItem.SubItems.Add(GetFileTypeDescription(file.Extension));
                    DateTime dt = Convert.ToDateTime(file.modified);
                    lvItem.SubItems.Add(string.Format("{0} {1}", dt.ToShortDateString(), dt.ToShortTimeString()));
                    lvItem.SubItems.Add(file.size);
                    lvItem.ToolTipText = file.path;
                    lvItem.Tag = file.path;
                    lvItem.ImageKey = file.icon;
                    ltv_files.Items.Add(lvItem);
                }
            }
            ltv_files.Focus();
        }

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        private string ToFileSize(long Filesize)
        {
            double size2 = Filesize;
            string[] eee = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            do
            {
                i++;
                size2 /= 1024;
            } while (size2 >= 1);
            if (i >= 4)
                size2 = Math.Round(size2 * 1024, 2);
            else
                size2 = Math.Round(size2 * 1024, 1);
            return size2.ToString() + eee[i - 1];
        }

        private string ToSpeed(double bytesPerSecond)
        {
            double size = bytesPerSecond;
            string[] ary = { "Byte/s", "kByte/s", "MByte/s" };
            int i = 0;
            do
            {
                i++;
                size /= 1000;
            } while (size >= 1);
            if (i >= 2)
                size = Math.Round(size * 1000, 2);
            else
                size = Math.Round(size * 1000, 1);
            return string.Format("{0} {1}", size.ToString("0.00"), ary[i - 1]);
        }

        private void UploadFile(string file, string path)
        {
            FileInfo f = new FileInfo(file);
            if (f.Length >= 148000000)
            {
                using (Stream fileStream = new FileStream(file, FileMode.Open))
                {
                    BinaryReader bStream = new BinaryReader(fileStream);
                    long? pos = null;
                    string id = null;
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    Task<DropboxRestAPI.Models.Core.ChunkedUpload> t;
                    while (fileStream.Position < fileStream.Length)
                    {
                        byte[] b = bStream.ReadBytes(4000000);
                        if (pos == null || id == null)
                            t = client.Core.Metadata.ChunkedUploadAsync(b, b.Length);
                        else
                            t = client.Core.Metadata.ChunkedUploadAsync(b, b.Length, uploadId: id, offset: pos);
                        while (!t.IsCompleted)
                        {
                            if (this.CancelOpearation)
                            {
                                fileStream.Close();
                                this.CancelOpearation = false;
                                return;
                            }
                            bgw_Upload.ReportProgress(Convert.ToInt32((Convert.ToDouble(fileStream.Position) / Convert.ToDouble(fileStream.Length)) * 100), new object[] { fileStream.Position, sw.ElapsedMilliseconds });
                            Thread.Sleep(200);
                        }

                        pos = t.Result.offset;
                        id = t.Result.upload_id;
                    }
                    sw.Stop();
                    client.Core.Metadata.CommitChunkedUploadAsync(path, id);
                }
            }
            else
            {
                Stream fileStream = new FileStream(file, FileMode.Open);

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                client.Core.Metadata.FilesPutAsync(fileStream, path);
                while (fileStream.Position < fileStream.Length || fileStream.Length == 0)
                {
                    if (!sw.IsRunning)
                        sw.Start();
                    if (this.CancelOpearation)
                    {
                        fileStream.Close();
                        this.CancelOpearation = false;
                        break;
                    }
                    bgw_Upload.ReportProgress(Convert.ToInt32((Convert.ToDouble(fileStream.Position) / Convert.ToDouble(fileStream.Length)) * 100), new object[] { fileStream.Position, sw.ElapsedMilliseconds });
                    Thread.Sleep(100);
                }
                fileStream.Close();
            }
        }

        private void UploadFolder(string LocalPath, string path)
        {
            string newFolder = Path.GetFileName(LocalPath.TrimEnd(Path.DirectorySeparatorChar));
            string newPath = path;
            bool bFound = false;
            if (!newPath.EndsWith("/"))
                newPath += "/" + newFolder;
            else
                newPath += newFolder;

            // Check if folder already exists
            Task<IEnumerable<DropboxRestAPI.Models.Core.MetaData>> t = client.Core.Metadata.SearchAsync(path, newFolder);
            t.Wait();
            foreach (DropboxRestAPI.Models.Core.MetaData searchResult in t.Result)
            {
                if (searchResult.is_dir)
                    bFound = true;
            }
            if (!bFound)
                client.Core.FileOperations.CreateFolderAsync(newPath).Wait();

            foreach (string File in Directory.GetFiles(LocalPath))
            {
                UploadFile(File, newPath + "/" + Path.GetFileName(File));
                //using (var fileStream = System.IO.File.OpenRead(File))
                //{
                //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                //    client.Core.Metadata.FilesPutAsync(fileStream, newPath + "/" + Path.GetFileName(File));
                //    while (fileStream.Position < fileStream.Length || fileStream.Length == 0)
                //    {
                //        if (!sw.IsRunning)
                //            sw.Start();
                //        if (this.CancelOpearation)
                //        {
                //            fileStream.Close();
                //            this.CancelOpearation = false;
                //            break;
                //        }
                //        bgw_Upload.ReportProgress(Convert.ToInt32((Convert.ToDouble(fileStream.Position) / Convert.ToDouble(fileStream.Length)) * 100), new object[] { fileStream.Position, sw.ElapsedMilliseconds });
                //        Thread.Sleep(100);
                //    }
                //}
            }

            foreach (string dir in Directory.GetDirectories(LocalPath))
            {
                UploadFolder(dir, newPath);
            }
        }
        #endregion

        #region FileSystemWatcher Methods
        private void TempDirectoryWatcherCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                CreateFileWatchers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileWatcherCreated(object sender, FileSystemEventArgs e)
        {
            new Thread(() => pan_perform.Invoke((MethodInvoker)(() => Init_pan_perform()))).Start();

            bgw_DownloadOnDrag.RunWorkerAsync(e.FullPath);
        }

        public void CreateFileWatchers()
        {
            try
            {
                if (watchers == null)
                {
                    int i = 0;
                    Hashtable tempWatchers = new Hashtable();
                    FileSystemWatcher watcher;
                    //Adding FileSystemWatchers and adding Created event to it 
                    foreach (string driveName in Directory.GetLogicalDrives())
                    {
                        //this checking may sound absurd to you.
                        //but in OS like Windows 2000,
                        //even if there is no floppy drive present
                        //An "A:/" will be shown in My Computer.
                        //To avoid exceptions like this I've added this check.
                        if (Directory.Exists(driveName))
                        {
                            watcher = new FileSystemWatcher();
                            watcher.Filter = string.Format("{0}*.tmp", DRAG_SOURCE_PREFIX);
                            watcher.NotifyFilter = NotifyFilters.FileName;
                            watcher.Created += new FileSystemEventHandler(FileWatcherCreated);
                            watcher.IncludeSubdirectories = true;
                            watcher.Path = driveName;
                            watcher.EnableRaisingEvents = true;
                            tempWatchers.Add("file_watcher" + i.ToString(), watcher);
                            i = i + 1;
                        }
                    }
                    watchers = tempWatchers;
                    tempWatchers = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearFileWatchers()
        {
            try
            {
                if (watchers != null && watchers.Count > 0)
                {
                    for (int i = 0; i < watchers.Count; i++)
                    {
                        ((FileSystemWatcher)watchers["file_watcher" + i.ToString()]).Dispose();
                    }
                    watchers.Clear();
                    watchers = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DragNDrop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }

    #region ListView sorter
    static class Extension
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            ICollection<TSource> c = source as ICollection<TSource>;
            if (c != null)
                return c.Count;

            int result = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    result++;
            }
            return result;
        }
    }

    class NameItemComparer : IComparer
    {
        private int col;
        public NameItemComparer()
        {
            col = 0;
        }
        public NameItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).Text,
            ((ListViewItem)y).Text);
            return returnVal;
        }
    }

    class TypeItemComparer : IComparer
    {
        private int col;
        public TypeItemComparer()
        {
            col = 0;
        }
        public TypeItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            string X = ((ListViewItem)x).Text;
            string Y = ((ListViewItem)y).Text;
            returnVal = String.Compare(X.Substring(X.Length - 3),
            Y.Substring(Y.Length - 3));
            return returnVal;
        }
    }
    #endregion
}
