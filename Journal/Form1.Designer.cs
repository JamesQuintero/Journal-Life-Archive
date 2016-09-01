namespace Journal
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Listbox_entries = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenu_item_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_entry_field = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Textbox_log = new System.Windows.Forms.RichTextBox();
            this.Textbox_log2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox_caption = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label_no_images = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3_drag_drop = new System.Windows.Forms.Panel();
            this.drag_status = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Imagelist_media = new System.Windows.Forms.ImageList(this.components);
            this.Button_new_entry = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6_log_info = new System.Windows.Forms.Label();
            this.radioButton2_numeric_dates = new System.Windows.Forms.RadioButton();
            this.radioButton1_textual_dates = new System.Windows.Forms.RadioButton();
            this.label6_num_entries = new System.Windows.Forms.Label();
            this.label5_no_entries = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.entriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.preference_body = new System.Windows.Forms.Panel();
            this.pref_button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pref_button2 = new System.Windows.Forms.Button();
            this.pref_button1 = new System.Windows.Forms.Button();
            this.pref_textbox1 = new System.Windows.Forms.TextBox();
            this.pref_label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.Tab_entry_field.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3_drag_drop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.preference_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // Listbox_entries
            // 
            this.Listbox_entries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Listbox_entries.ContextMenuStrip = this.contextMenuStrip1;
            this.Listbox_entries.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Listbox_entries.Font = new System.Drawing.Font("Proxima Nova Rg", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Listbox_entries.FormattingEnabled = true;
            this.Listbox_entries.ItemHeight = 17;
            this.Listbox_entries.Location = new System.Drawing.Point(12, 111);
            this.Listbox_entries.Name = "Listbox_entries";
            this.Listbox_entries.Size = new System.Drawing.Size(203, 378);
            this.Listbox_entries.TabIndex = 0;
            this.Listbox_entries.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.myListBox_DrawItem);
            this.Listbox_entries.SelectedIndexChanged += new System.EventHandler(this.load_entry);
            this.Listbox_entries.MouseLeave += new System.EventHandler(this.Listbox_entries_MouseLeave);
            this.Listbox_entries.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Listbox_entries_MouseMove);
            this.Listbox_entries.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenu_item_delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // contextMenu_item_delete
            // 
            this.contextMenu_item_delete.Name = "contextMenu_item_delete";
            this.contextMenu_item_delete.Size = new System.Drawing.Size(107, 22);
            this.contextMenu_item_delete.Text = "Delete";
            // 
            // Tab_entry_field
            // 
            this.Tab_entry_field.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_entry_field.Controls.Add(this.tabPage1);
            this.Tab_entry_field.Controls.Add(this.tabPage2);
            this.Tab_entry_field.Controls.Add(this.tabPage3);
            this.Tab_entry_field.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab_entry_field.Location = new System.Drawing.Point(221, 12);
            this.Tab_entry_field.Name = "Tab_entry_field";
            this.Tab_entry_field.SelectedIndex = 0;
            this.Tab_entry_field.Size = new System.Drawing.Size(811, 477);
            this.Tab_entry_field.TabIndex = 1;
            this.Tab_entry_field.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.load_entry);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Textbox_log);
            this.tabPage1.Controls.Add(this.Textbox_log2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(803, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Textbox_log
            // 
            this.Textbox_log.AcceptsTab = true;
            this.Textbox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Textbox_log.DetectUrls = false;
            this.Textbox_log.Font = new System.Drawing.Font("Proxima Nova Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox_log.Location = new System.Drawing.Point(3, -1);
            this.Textbox_log.Name = "Textbox_log";
            this.Textbox_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Textbox_log.Size = new System.Drawing.Size(801, 451);
            this.Textbox_log.TabIndex = 1;
            this.Textbox_log.Text = "";
            this.Textbox_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_Keypress);
            // 
            // Textbox_log2
            // 
            this.Textbox_log2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_log2.Font = new System.Drawing.Font("Proxima Nova Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox_log2.Location = new System.Drawing.Point(-1, -1);
            this.Textbox_log2.Multiline = true;
            this.Textbox_log2.Name = "Textbox_log2";
            this.Textbox_log2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Textbox_log2.Size = new System.Drawing.Size(808, 453);
            this.Textbox_log2.TabIndex = 0;
            this.Textbox_log2.Visible = false;
            this.Textbox_log2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_Keypress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox_caption);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.Label_no_images);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(803, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Media";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox_caption
            // 
            this.richTextBox_caption.AcceptsTab = true;
            this.richTextBox_caption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_caption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_caption.DetectUrls = false;
            this.richTextBox_caption.Font = new System.Drawing.Font("Proxima Nova Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_caption.Location = new System.Drawing.Point(181, 376);
            this.richTextBox_caption.Name = "richTextBox_caption";
            this.richTextBox_caption.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_caption.Size = new System.Drawing.Size(622, 74);
            this.richTextBox_caption.TabIndex = 3;
            this.richTextBox_caption.Text = "";
            this.richTextBox_caption.Enter += new System.EventHandler(this.richTextBox_caption_Enter);
            this.richTextBox_caption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_caption_KeyDown);
            this.richTextBox_caption.Leave += new System.EventHandler(this.richTextBox_caption_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(181, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(626, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Label_no_images
            // 
            this.Label_no_images.AutoSize = true;
            this.Label_no_images.Location = new System.Drawing.Point(6, 12);
            this.Label_no_images.Name = "Label_no_images";
            this.Label_no_images.Size = new System.Drawing.Size(232, 16);
            this.Label_no_images.TabIndex = 1;
            this.Label_no_images.Text = "No images to show. Click on Add Media.";
            this.Label_no_images.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Location = new System.Drawing.Point(-1, -1);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(180, 451);
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(160, 160);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3_drag_drop);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(803, 448);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Add Media";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Leave += new System.EventHandler(this.reset_drag_status);
            // 
            // panel3_drag_drop
            // 
            this.panel3_drag_drop.AllowDrop = true;
            this.panel3_drag_drop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3_drag_drop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3_drag_drop.Controls.Add(this.drag_status);
            this.panel3_drag_drop.Controls.Add(this.label4);
            this.panel3_drag_drop.Location = new System.Drawing.Point(43, 32);
            this.panel3_drag_drop.Name = "panel3_drag_drop";
            this.panel3_drag_drop.Size = new System.Drawing.Size(734, 386);
            this.panel3_drag_drop.TabIndex = 0;
            // 
            // drag_status
            // 
            this.drag_status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drag_status.AutoSize = true;
            this.drag_status.Location = new System.Drawing.Point(270, 198);
            this.drag_status.Name = "drag_status";
            this.drag_status.Size = new System.Drawing.Size(124, 16);
            this.drag_status.TabIndex = 1;
            this.drag_status.Text = "Drag and drop status";
            this.drag_status.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Maven Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Drop your images here";
            // 
            // Imagelist_media
            // 
            this.Imagelist_media.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.Imagelist_media.ImageSize = new System.Drawing.Size(150, 150);
            this.Imagelist_media.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Button_new_entry
            // 
            this.Button_new_entry.BackColor = System.Drawing.Color.Transparent;
            this.Button_new_entry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_new_entry.Font = new System.Drawing.Font("Proxima Nova Rg", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_new_entry.Location = new System.Drawing.Point(140, 12);
            this.Button_new_entry.Name = "Button_new_entry";
            this.Button_new_entry.Size = new System.Drawing.Size(75, 23);
            this.Button_new_entry.TabIndex = 3;
            this.Button_new_entry.Text = "Add Entry";
            this.Button_new_entry.UseVisualStyleBackColor = false;
            this.Button_new_entry.Click += new System.EventHandler(this.create_entry);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Maven Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label6_log_info);
            this.panel1.Controls.Add(this.radioButton2_numeric_dates);
            this.panel1.Controls.Add(this.radioButton1_textual_dates);
            this.panel1.Controls.Add(this.label6_num_entries);
            this.panel1.Controls.Add(this.label5_no_entries);
            this.panel1.Controls.Add(this.textBox_search);
            this.panel1.Controls.Add(this.Listbox_entries);
            this.panel1.Controls.Add(this.Tab_entry_field);
            this.panel1.Controls.Add(this.Button_new_entry);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 525);
            this.panel1.TabIndex = 6;
            // 
            // label6_log_info
            // 
            this.label6_log_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6_log_info.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6_log_info.Location = new System.Drawing.Point(415, 20);
            this.label6_log_info.Name = "label6_log_info";
            this.label6_log_info.Size = new System.Drawing.Size(610, 15);
            this.label6_log_info.TabIndex = 11;
            this.label6_log_info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButton2_numeric_dates
            // 
            this.radioButton2_numeric_dates.AutoSize = true;
            this.radioButton2_numeric_dates.Location = new System.Drawing.Point(122, 72);
            this.radioButton2_numeric_dates.Name = "radioButton2_numeric_dates";
            this.radioButton2_numeric_dates.Size = new System.Drawing.Size(93, 17);
            this.radioButton2_numeric_dates.TabIndex = 10;
            this.radioButton2_numeric_dates.Text = "MM-DD-YYYY";
            this.radioButton2_numeric_dates.UseVisualStyleBackColor = true;
            this.radioButton2_numeric_dates.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton1_textual_dates
            // 
            this.radioButton1_textual_dates.AutoSize = true;
            this.radioButton1_textual_dates.Checked = true;
            this.radioButton1_textual_dates.Location = new System.Drawing.Point(12, 72);
            this.radioButton1_textual_dates.Name = "radioButton1_textual_dates";
            this.radioButton1_textual_dates.Size = new System.Drawing.Size(108, 17);
            this.radioButton1_textual_dates.TabIndex = 9;
            this.radioButton1_textual_dates.TabStop = true;
            this.radioButton1_textual_dates.Text = "Month DD, YYYY";
            this.radioButton1_textual_dates.UseVisualStyleBackColor = true;
            this.radioButton1_textual_dates.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label6_num_entries
            // 
            this.label6_num_entries.AutoSize = true;
            this.label6_num_entries.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6_num_entries.Location = new System.Drawing.Point(12, 95);
            this.label6_num_entries.Name = "label6_num_entries";
            this.label6_num_entries.Size = new System.Drawing.Size(43, 16);
            this.label6_num_entries.TabIndex = 8;
            this.label6_num_entries.Text = "label6";
            // 
            // label5_no_entries
            // 
            this.label5_no_entries.AutoSize = true;
            this.label5_no_entries.Font = new System.Drawing.Font("Proxima Nova Rg", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5_no_entries.Location = new System.Drawing.Point(14, 115);
            this.label5_no_entries.Name = "label5_no_entries";
            this.label5_no_entries.Size = new System.Drawing.Size(84, 17);
            this.label5_no_entries.TabIndex = 7;
            this.label5_no_entries.Text = "No entries...";
            this.label5_no_entries.Visible = false;
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_search.Location = new System.Drawing.Point(13, 41);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(202, 23);
            this.textBox_search.TabIndex = 6;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);
            this.textBox_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_search_KeyDown);
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 501);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Maven Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(469, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Version 1.0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maven Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Created by James Quintero";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maven Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "jamesaquint@gmail.com";
            this.label2.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Maven Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(390, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "https://github.com/JamesQuintero";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.ImageLocation = "";
            this.pictureBox2.Location = new System.Drawing.Point(415, 57);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entriesToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // entriesToolStripMenuItem
            // 
            this.entriesToolStripMenuItem.Name = "entriesToolStripMenuItem";
            this.entriesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.entriesToolStripMenuItem.Text = "Journal";
            this.entriesToolStripMenuItem.Click += new System.EventHandler(this.entriesToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.preference_body);
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 525);
            this.panel3.TabIndex = 12;
            // 
            // preference_body
            // 
            this.preference_body.Controls.Add(this.pref_button3);
            this.preference_body.Controls.Add(this.label6);
            this.preference_body.Controls.Add(this.pref_button2);
            this.preference_body.Controls.Add(this.pref_button1);
            this.preference_body.Controls.Add(this.pref_textbox1);
            this.preference_body.Controls.Add(this.pref_label1);
            this.preference_body.Location = new System.Drawing.Point(17, 20);
            this.preference_body.Name = "preference_body";
            this.preference_body.Size = new System.Drawing.Size(793, 481);
            this.preference_body.TabIndex = 0;
            // 
            // pref_button3
            // 
            this.pref_button3.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pref_button3.Location = new System.Drawing.Point(461, 70);
            this.pref_button3.Name = "pref_button3";
            this.pref_button3.Size = new System.Drawing.Size(75, 23);
            this.pref_button3.TabIndex = 5;
            this.pref_button3.Text = "Browse...";
            this.pref_button3.UseVisualStyleBackColor = true;
            this.pref_button3.Click += new System.EventHandler(this.pref_button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Proxima Nova Rg", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Preferences";
            // 
            // pref_button2
            // 
            this.pref_button2.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pref_button2.Location = new System.Drawing.Point(542, 70);
            this.pref_button2.Name = "pref_button2";
            this.pref_button2.Size = new System.Drawing.Size(96, 23);
            this.pref_button2.TabIndex = 3;
            this.pref_button2.Text = "Use Default";
            this.pref_button2.UseVisualStyleBackColor = true;
            // 
            // pref_button1
            // 
            this.pref_button1.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pref_button1.Location = new System.Drawing.Point(643, 70);
            this.pref_button1.Name = "pref_button1";
            this.pref_button1.Size = new System.Drawing.Size(75, 23);
            this.pref_button1.TabIndex = 2;
            this.pref_button1.Text = "Save";
            this.pref_button1.UseVisualStyleBackColor = true;
            // 
            // pref_textbox1
            // 
            this.pref_textbox1.Location = new System.Drawing.Point(109, 71);
            this.pref_textbox1.Name = "pref_textbox1";
            this.pref_textbox1.Size = new System.Drawing.Size(345, 20);
            this.pref_textbox1.TabIndex = 1;
            // 
            // pref_label1
            // 
            this.pref_label1.AutoSize = true;
            this.pref_label1.Font = new System.Drawing.Font("Proxima Nova Rg", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pref_label1.Location = new System.Drawing.Point(16, 72);
            this.pref_label1.Name = "pref_label1";
            this.pref_label1.Size = new System.Drawing.Size(86, 16);
            this.pref_label1.TabIndex = 0;
            this.pref_label1.Text = "Entry Storage:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1044, 550);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Proxima Nova Rg", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 400);
            this.Name = "Form1";
            this.Text = "Life Archive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.Tab_entry_field.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel3_drag_drop.ResumeLayout(false);
            this.panel3_drag_drop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.preference_body.ResumeLayout(false);
            this.preference_body.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Listbox_entries;
        private System.Windows.Forms.TabControl Tab_entry_field;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox Textbox_log2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList Imagelist_media;
        private System.Windows.Forms.Button Button_new_entry;
        private System.Windows.Forms.Label Label_no_images;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenu_item_delete;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3_drag_drop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label drag_status;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Label label5_no_entries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6_num_entries;
        private System.Windows.Forms.RadioButton radioButton2_numeric_dates;
        private System.Windows.Forms.RadioButton radioButton1_textual_dates;
        private System.Windows.Forms.RichTextBox Textbox_log;
        private System.Windows.Forms.Label label6_log_info;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Panel preference_body;
        private System.Windows.Forms.Label pref_label1;
        private System.Windows.Forms.TextBox pref_textbox1;
        private System.Windows.Forms.Button pref_button2;
        private System.Windows.Forms.Button pref_button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button pref_button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox richTextBox_caption;
    }
}

