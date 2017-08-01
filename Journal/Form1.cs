using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace Journal
{
    public partial class Form1 : Form
    {
        //private string path = "../../../Entries"; //for debugging
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/Journal/Entries"; //for release

        private XML_handler xml;

        private string tab_log_title="Text";
        private string tab_log_title_unsaved="Text *";
        private string tab_media_title = "Media";
        //private string tab_media_title_unsaved = "Media *";

        private string default_search_hint = "Word search (case insensitive)...";
        private string default_caption_hint = "Image caption...";

        //light blue that matches the journal icon's blue
        private Color main_color = Color.FromArgb(90, 180, 240);

        //list of listbox item indices of entries that have media files
        private List<int> media_entry_indices = new List<int>();

        //stores last listbox item index that was hovered over so 
        //that the program can know when to redraw the background color
        private int prev_index = 0;

        public Form1()
        {
            InitializeComponent();

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            
            xml = new XML_handler();


            





            show_panel("entries");
            populate_entries("");

            //loads entry when clicked
            Listbox_entries.Click += new EventHandler(load_entry);
            Tab_entry_field.TabPages[0].Text = tab_log_title;
            Tab_entry_field.TabPages[1].Text = tab_media_title;

            //changes text color of top menu
            //menuStrip1.ForeColor = Color.White;
            menuStrip1.ForeColor = Color.FromArgb(50,50,50);

            //Adds drag and drop functionality
            panel3_drag_drop.DragEnter += new DragEventHandler(Form1_DragEnter);
            panel3_drag_drop.DragDrop += new DragEventHandler(Form1_DragDrop);
            

            //reset_toolstrip(null, new EventArgs());
            toolStripStatusLabel1.Text = "";

            //sets search bar's hint
            textBox_search_Leave(null, new EventArgs());
            richTextBox_caption_Leave(null, new EventArgs());

        }

        //draws customized listbox including text color and hover background color
        private void myListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

            Brush myBrush;

            //changes listbox items text to black if they have media files associated
            if (media_entry_indices.IndexOf(e.Index) != -1)
                myBrush = Brushes.Black;
            else
                myBrush = Brushes.Gray;


            //gets index of listbox item that is being hovered over
            var relativePoint = Listbox_entries.PointToClient(Cursor.Position);
            int index = Listbox_entries.IndexFromPoint(relativePoint.X, relativePoint.Y);

            //if the item state is selected then change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                                          e.Index, e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          main_color);//Choose the color
            }
            //if item is being hovered
            else if (index == e.Index)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                                          e.Index, e.State,
                                          e.ForeColor,
                                          Color.LightGray);//Choose the color
            }

            //-1 is invalid index
            if (e.Index >=0)
            {
                e.DrawBackground();

                e.Graphics.DrawString(Listbox_entries.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                // If the ListBox has focus, draw a focus rectangle around the selected item.
                e.DrawFocusRectangle();
            }
        }

        

        private void load_entry(object sender, EventArgs e)
        {

            //if user hasn't saved
            if (Tab_entry_field.TabPages[0].Text == tab_log_title_unsaved)
            {
                string selected_date = Textbox_log.Tag.ToString();
                Boolean successful = save_entry();
                if (successful)
                {
                    Tab_entry_field.TabPages[0].Text = tab_log_title;
                    Tab_entry_field.Refresh();
                }
                else
                    return;
            }

            //resets image stuff
            pictureBox1.Visible = false;
            richTextBox_caption.Visible = false;



            //selected entry
            string new_date = get_selected_date();

            //when nothing is selected
            if (new_date == "")
            {
                if (Tab_entry_field.SelectedTab == Tab_entry_field.TabPages["tabPage2"])
                    Label_no_images.Visible = true;
                return;
            }

            //Loads text
            if (Tab_entry_field.SelectedTab == Tab_entry_field.TabPages["tabPage1"])
            {
                //Textbox_log.Focus();

                //Loads entry text log
                try
                {
                    string file_path=path + "/" + new_date + "/" + new_date + ".txt";

                    //creates the txt file if it doesn't exist
                    if (File.Exists(file_path)==false)
                        File.Create(file_path).Close();

                    var lines = File.ReadLines(file_path);
                    StringBuilder new_lines = new StringBuilder();
                    foreach (var line in lines)
                        new_lines.Append(line + System.Environment.NewLine);

                    Textbox_log.Text = new_lines.ToString();
                    //Textbox_log2.Text = new_lines.ToString();
                    Textbox_log.Tag = new_date;


                    show_word_count();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error reading entry: "+exception.ToString());
                }
            }
            //Loads media
            else if (Tab_entry_field.SelectedTab == Tab_entry_field.TabPages["tabPage2"])
            {
                label6_log_info.Text = "";
                toolStripStatusLabel1.Text = "Loading thumbnails...";
                statusStrip1.Refresh();

                Imagelist_media.Images.Clear();
                Label_no_images.Visible = false;


                List<string> thumbnails = load_media(new_date);

                for (int x = 0; x < thumbnails.Count; x++)
                {
                    string new_path = path + "/" + new_date + "/thumbnails/" + Path.ChangeExtension(thumbnails[x], "thumb");
                    Imagelist_media.Images.Add(Image.FromFile(new_path));
                }

                listView1.Items.Clear();
                //listView1.GridLines = true;
                //listView1.View = View.LargeIcon;

                for (int counter = 0; counter < Imagelist_media.Images.Count; counter++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = counter;
                    //item.ImageKey = counter.ToString();
                    item.Tag = Path.GetFullPath(path+"/"+new_date+"/"+thumbnails[counter]);
                    Image image = Imagelist_media.Images[counter];
                    this.listView1.Items.Add(item);
                }

                if(thumbnails.Count==0)
                    Label_no_images.Visible = true;

                this.listView1.LargeImageList = Imagelist_media;

                //select first item, then displays by default
                if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                    listView1.Select();
                    listView1_SelectedIndexChanged(null, new EventArgs());
                }

                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();

            }
            else
            {
                label6_log_info.Text = "";
            }
        }

        //returns list of image file names (not full path) like elon_musk.png and creates thumbnails if non-existant
        private List<string> load_media(string new_date)
        {

            //loads list of regular images
            List<string> regular_images = load_regular_images(new_date);

            //creates thumbnail directory if it doesn't exist
            Directory.CreateDirectory(path+"/"+new_date+"/thumbnails");

            //loads list of thumbnails
            List<string> thumbnails = new List<string>();
            foreach (var image_name in Directory.GetFiles(path + "/" + new_date+"/thumbnails"))
            {
                //gets elon_musk.thumb from ../Entries/1-15-16/thumbnails/elon_musk.thumb
                string[] split_path = image_name.ToString().Split('\\');
                if (split_path.Length == 1)
                    split_path = image_name.ToString().Split('/');
                string new_image_name = split_path[split_path.Length - 1].ToLower();

                //if valid thumbnail
                if (new_image_name.Contains(".thumb"))
                    thumbnails.Add(new_image_name);
            }


            //removes images that already have thumbnails
            List<string> all_regular = new List<string>(regular_images);
            int x =0; 
            while(x < regular_images.Count)
            {
                string temp_image = Path.ChangeExtension(regular_images[x], "thumb");
                bool exists = false;
                for (int y = 0; y < thumbnails.Count; y++)
                {
                    if (thumbnails[y] == temp_image)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                    regular_images.RemoveAt(x);
                else
                    x++;
            }


            //creates thumbnails for remaining images
            for (x = 0; x < regular_images.Count; x++)
            {
                using (FileStream stream = new FileStream(path + "/" + new_date + "/" + regular_images[x], FileMode.Open, FileAccess.Read))
                {
                    Image thumb = Image.FromStream(stream).GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                    //saves ../Entries/1-15-16/elon_musk.png as ../Entries/1-15-16/thumbnails/elon_musk.thumb
                    string new_thumbnail_path = Path.ChangeExtension(path + "/" + new_date + "/thumbnails/" + regular_images[x], "thumb");
                    thumb.Save(new_thumbnail_path);
                    stream.Close();
                }
            }

            return all_regular;
        }

        //returns list of image names
        private List<string> load_regular_images(string new_date)
        {
            //loads list of regular images
            List<string> regular_images = new List<string>();
            foreach (var image_name in Directory.GetFiles(path + "/" + new_date))
            {
                //gets elon_musk.png from ../Entries/1-15-16\elon_musk.png
                string[] split_path = image_name.ToString().Split('\\');
                if (split_path.Length == 1)
                    split_path = image_name.ToString().Split('/');
                string new_image_name = split_path[split_path.Length - 1].ToLower();

                //if valid image
                if (new_image_name.Contains(".jpg") || new_image_name.Contains(".png") || new_image_name.Contains(".gif"))
                    regular_images.Add(new_image_name);
            }

            return regular_images;
        }

        //shows text log word count
        private void show_word_count()
        {
            string date = get_selected_date();
            string lines = Textbox_log.Text;

            //gives info for label
            int count_words = lines.Split().Length;
            label6_log_info.Text = date + ": " + count_words + " words";
        }

        //returns the date the user has selected in the listbox
        private string get_selected_date()
        {
            var item = Listbox_entries.SelectedItem;
            if (item == null)
                return "";

            string selected_item = Listbox_entries.SelectedItem.ToString();

            //user is displaying textual dates, convert to numeric date
            if (radioButton1_textual_dates.Checked)
                return convert_date("numeric", selected_item);

            return selected_item;
        }


        //creates new entry
        private void create_entry(object sender, EventArgs e)
        {
            //string entry_date = Textbox_new_entry.Text;
            int year=Int32.Parse(dateTimePicker1.Value.Date.Year.ToString());
            string month=dateTimePicker1.Value.Date.Month.ToString();
            string day=dateTimePicker1.Value.Date.Day.ToString();

            //converts 2016 to 16
            if (year > 2000)
                year -= 2000;
            else if (year > 1900)
                year -= 1900;
            string new_year = year.ToString();

            //turns 1-1-8 into 1-1-08
            if (year < 10)
                new_year = "0" + new_year;

            string numeric_date = month + "-" + day + "-" + new_year;

                //creates entry folder
                string new_path = path + "/" + numeric_date;
                Directory.CreateDirectory(new_path);

                //creates text file if it doesn't exist, and load it if it does
                new_path += "/" + numeric_date + ".txt";
                if (!File.Exists(new_path))
                {
                    File.Create(new_path).Close();

                    populate_entries("");
                }
                else
                {
                    MessageBox.Show("This entry already exists");
                    load_entry(null, new EventArgs());
                }

        }

        //saves log text
        private Boolean save_entry()
        {
            //log text
            string text = Textbox_log.Text;


            //string date = get_selected_date();
            string date = Textbox_log.Tag.ToString();

            //if no date is selected
            if (date == "")
            {
                MessageBox.Show("There is no entry selected");
                return false;
            }

            //makes sure user wants to delete all text
            if (text.Trim() == "")
            {
                var confirmResult = MessageBox.Show("Are you sure you want to save an empty log?", "Empty Entry Log Text", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    File.WriteAllLines(path + "/" + date + "/" + date + ".txt", Textbox_log.Lines);
                    return true;
                }
                else
                    return false;
            }


            File.WriteAllLines(path + "/" + date + "/" + date + ".txt", Textbox_log.Lines);
            show_word_count();
            return true;

            
        }


        

        //populates list box with journal entries
        private void populate_entries(string restriction)
        {
            List<string> dates = get_journal_entries(restriction.ToLower());

            this.Listbox_entries.DataSource = dates;

            //selects the first entry if there are entries
            if (dates.Count > 0)
            {
                label5_no_entries.Hide();
                load_entry(null, new EventArgs());
            }
            else
                label5_no_entries.Show();

            label6_num_entries.Text = dates.Count + " entries";


        }

        //returns arraylist of journal entries that contain the restriction string
        private List<string> get_journal_entries(string restriction)
        {
            List<string> file_names = new List<string>();
            foreach (var file in Directory.GetDirectories(path))
            {
                //gets 1-1-16 from ../../../Entries\1-1-16
                StringBuilder temp_name = new StringBuilder(Path.GetFileName(file));
                string file_name = temp_name.ToString();

                //if user is searching for a string
                if (restriction != "")
                {
                    string temp_path = path + "/" + file_name + "/" + file_name + ".txt";
                    if (File.Exists(temp_path) && File.ReadAllText(temp_path).ToLower().Contains(restriction))
                    {
                        file_names.Add(file_name);
                    }
                }
                else
                    file_names.Add(file_name);
            }


            //sorts date entries newest to oldest using Insertion sort
            List<int> temp_dates = new List<int>();
            List<string> new_dates = new List<string>();
            for (int x = 0; x < file_names.Count; x++)
            {
                //the larger the number, the more recent
                int new_date = Int32.Parse(convert_date("long_number", file_names[x]));

                int index = temp_dates.Count;
                for (int y = 0; y < temp_dates.Count; y++)
                {
                    if (new_date > temp_dates[y])
                    {
                        index = y;
                        break;
                    }
                }


                temp_dates.Insert(index, new_date);

                if(radioButton1_textual_dates.Checked)
                    new_dates.Insert(index, convert_date("textual", file_names[x]));
                else if(radioButton2_numeric_dates.Checked)
                    new_dates.Insert(index, file_names[x]);
            }


            //gets indices that contain media
            media_entry_indices = new List<int>();
            for (int x = 0; x < new_dates.Count; x++)
            {
                string date = new_dates[x];
                if(radioButton1_textual_dates.Checked)
                    date = convert_date("numeric", new_dates[x]);

                Boolean contains_images = entry_contains_media(date);

                if (contains_images)
                    media_entry_indices.Add(x);
            }

            return new_dates;
        }

        //returns whether numeric_date entry contains media
        private Boolean entry_contains_media(string numeric_date)
        {
            if (Directory.Exists(path + "/" + numeric_date))
            {

                string[] file_names;
                try
                {
                    file_names = Directory.GetFiles(path + "/" + numeric_date);
                }
                catch (Exception exception)
                {
                    Console.Write(exception.ToString());
                    file_names=new string[0];
                }


                foreach (var image_name in file_names)
                {
                    string new_image_name = image_name.ToString().ToLower();

                    //if valid image
                    if (new_image_name.Contains(".jpg") || new_image_name.Contains(".jpeg") || new_image_name.Contains(".png") || new_image_name.Contains(".gif"))
                        return true;
                }
            }
            return false;
        }

        //populates preferences page
        private void populate_preferences()
        {
            pref_textbox1.Text = path;
        }

        //converts 5-7-16 to May 7, 2016
        private string convert_date(string type, string date)
        {
            if (type == "textual")
            {
                string[] split_date = date.Split('-');

                int month = Int32.Parse(split_date[0]);
                int day = Int32.Parse(split_date[1]);
                int year = Int32.Parse(split_date[2]);

                //converts month and year
                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string new_year = (year + 2000).ToString();
                string new_month = months[month - 1];



                return new_month + " " + day + ", " + new_year;
            }
            else if (type == "numeric")
            {
                //removes "," from January 15, 2016
                StringBuilder temp_date = new StringBuilder(date);
                temp_date.Replace(",", "");
                date = temp_date.ToString();

                //breaks up January 15, 2016 into [January, 15, 2016]
                string[] split_date = date.Split(' ');

                //converts month
                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                int new_month=0;
                try{
                    new_month = Array.IndexOf(months, split_date[0]) + 1;
                }
                catch (Exception exception){
                    Console.WriteLine(exception.ToString());
                    return "";
                }

                //converts year
                int year = Int32.Parse(split_date[2]);
                string new_year = (year - 2000).ToString();
                if (year - 2000 < 10)
                    new_year = "0" + new_year;

                //doesn't need to convert day
                string day = split_date[1];

                return new_month + "-" + day + "-" + new_year;
            }
            //should already be in Numeric format
            else if (type == "long_number")
            {
                string[] split_date = date.Split('-');

                int month = Int32.Parse(split_date[0]);
                int day = Int32.Parse(split_date[1]);
                int year = Int32.Parse(split_date[2]);


                string new_month = "";
                if (month < 10)
                    new_month = "0" + month.ToString();
                else
                    new_month = month.ToString();

                string new_day = "";
                if (day < 10)
                    new_day = "0" + day.ToString();
                else
                    new_day = day.ToString();

                return year.ToString() + new_month + new_day;
            }

            return "0";
        }

        //Loads image when thumbnail is clicked
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            richTextBox_caption.Visible = true;

            //uses foreach even though there's always only one selected item
            var selectedItems = listView1.SelectedItems;
            foreach (ListViewItem image in selectedItems)
            {
                //releases old image to free up RAM
                var oldImage = pictureBox1.Image;
                if (oldImage != null)
                    ((IDisposable)oldImage).Dispose();


                string image_path = image.Tag.ToString();

                //Puts in new image
                FileStream fs = new System.IO.FileStream(image_path, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
                fs.Close();

                pictureBox1.Tag = image_path;
                richTextBox_caption.Tag = image_path;

                //image caption
                string caption = xml.get_caption(path + "/" + get_selected_date() + "/metadata.xml", image_path);
                richTextBox_caption.Text = caption;
                if (caption != "")
                    richTextBox_caption_Enter(null, new EventArgs());
                else
                    richTextBox_caption_Leave(null, new EventArgs());
            }
        }


        // handles keypresses in textbox
        void Textbox_Keypress(object sender, KeyEventArgs e)
        {

            //Ctrl+S = saves journal entry
            if (e.Control && e.KeyCode == Keys.S && Tab_entry_field.TabPages[0].Text != tab_log_title)
            {
                Boolean successful=save_entry();

                if (successful)
                {
                    Tab_entry_field.TabPages[0].Text = tab_log_title;
                    Tab_entry_field.Refresh();

                    //removes annoying windows beep sound effect
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            //Ctrl+A = select all text
            else if (e.Control && e.KeyCode == Keys.A)
            {
                Textbox_log.SelectAll();
                Textbox_log.Focus();

                //removes annoying windows beep sound effect
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            //if entry is edited without it being a shortcut
            else if ((e.Control == false || (e.Control && e.KeyCode == Keys.V)) && e.Shift == false && Tab_entry_field.TabPages[0].Text != tab_log_title_unsaved)
            {
                Tab_entry_field.TabPages[0].Text = tab_log_title_unsaved;
                Tab_entry_field.Refresh();
            }
        }

        //I guess I have to override this since this is called when a tab is changed
        private void load_entry(object sender, TabControlCancelEventArgs e)
        {
            //this is called when an entry is selected, and stuff
            load_entry(sender, new EventArgs());
        }

        //Opens clicked picture in Windows Photo Viewer
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string new_path = pictureBox1.Tag.ToString();
            Process.Start(@new_path);
        }

        //siwtches between different panels
        private void show_panel(string panel_name)
        {
            if (panel_name == "entries")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
            else if (panel_name == "about")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
            }
            else if(panel_name=="preferences")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;

                populate_preferences();
            }
        }

        //both MouseLeave and MouseMove allow for the cursor to change from default to Pointer when hovering over thumbnails
        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Hand)
                this.Cursor = Cursors.Arrow;
        }

        //Changes cursor when hovering over thumbnails
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = listView1.GetItemAt(e.Location.X, e.Location.Y);
            if (lvi == null)
            {
                bool found = false;
                int i = 0;
                ListViewItem.ListViewSubItem lvsi = null;
                while (!found && i < listView1.Items.Count)
                {
                    lvsi = listView1.Items[i].GetSubItemAt(e.Location.X, e.Location.Y);
                    if (lvsi != null)
                        found = true;
                    i++;
                }
                if (found && this.Cursor == Cursors.Arrow)
                    this.Cursor = Cursors.Hand;
                else if (this.Cursor == Cursors.Hand)
                    this.Cursor = Cursors.Arrow;
            }
            else
            {
                if (this.Cursor == Cursors.Arrow)
                    this.Cursor = Cursors.Hand;
            }
        }

        //Drag and drop effect
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        //Copyies images that are dragged and dropped
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //gets selected journal entry
            string selected_date = get_selected_date();

            //no entry date selected
            if (selected_date == "")
            {
                drag_status.Text = "Please select an entry to add media.";
                drag_status.Show();

                return;
            }



            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] existing_images = Directory.GetFiles(path + "/" + selected_date);

            bool successful = true;
            foreach (string file in files)
            {
                //gets only file name
                string file_name = Path.GetFileName(file);

                //makes sure not duplicate
                bool exists = false;
                for (int x = 0; x < existing_images.Length; x++)
                {
                    if (existing_images[x].Contains(file_name))
                        exists = true;
                }

                if (exists == false)
                {
                    //copies only images
                    if (file_name.ToLower().Contains(".jpg") || file_name.ToLower().Contains(".jpeg") || file_name.ToLower().Contains(".png") || file_name.ToLower().Contains(".gif"))
                        File.Copy(file, path + "/" + selected_date + "/" + file_name);
                    else
                    {
                        drag_status.Text = "Image needs to be a jpg, png, or gif";
                        drag_status.Show();
                        successful = false;
                    }
                }
                else
                {
                    drag_status.Text = "Image \""+file_name+"\" already exists";
                    drag_status.Show();
                    successful = false;
                }
            }

            if (successful)
            {
                drag_status.Text = "Image copy successful!";
                //if no media for entry before, make entry date text black to show now has media
                if (existing_images.Length == 1)
                {
                    get_journal_entries("");
                    Listbox_entries.Refresh();
                }

            }

            drag_status.Show();

        }

        //hides toolstrip when not in use
        private void reset_drag_status(object sender, EventArgs e)
        {
            drag_status.Hide();
        }

        //deletes an image from the selected journal entry
        private void delete_image(object sender, EventArgs e)
        {
            string image_path=contextMenu_item_delete.Tag.ToString();
            contextMenu_item_delete.Click -= delete_image;

            
            if(File.Exists(image_path))
            {
                //deletes the image and its thumbnail
                File.Delete(image_path);
                //File.Delete(Path.ChangeExtension(image_path, "thumb"));

                //if no media for entry before, make entry date text black to show now has media
                string[] existing_images = Directory.GetFiles(path + "/" + Textbox_log.Tag.ToString());
                if (existing_images.Length == 1)
                {
                    get_journal_entries("");
                    Listbox_entries.Refresh();
                }
            }

            load_entry(null, new EventArgs());
        }

        //deletes the entire journal entry
        private void delete_entry(object sender, EventArgs e)
        {
            string entry = contextMenu_item_delete.Tag.ToString();
            contextMenu_item_delete.Click -= delete_entry;

            string numeric_entry="";
            if(radioButton1_textual_dates.Checked)
                numeric_entry = convert_date("numeric", entry);
            else
                numeric_entry=entry;

            var confirmResult = MessageBox.Show("Are you sure you want to delete the entire journal entry for " + entry + "?", "Delete journal entry", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string to_delete_path=path + "/" + numeric_entry;
                if (Directory.Exists(to_delete_path))
                {
                    Directory.Delete(to_delete_path, true);

                    toolStripStatusLabel1.Text = "Deleting entry...";

                    //sleeps 1 second
                    Thread.Sleep(1000);
                    toolStripStatusLabel1.Text = "Entry deleted";

                    populate_entries("");
                    
                }
                else
                    toolStripStatusLabel1.Text = "Entry doesn't exist...";


                
            }
            

        }
        

        //right click only when selecting listbox item
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Hide();
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                if (Listbox_entries.IndexFromPoint(e.Location).ToString() != "-1")
                {
                    //selects entry that is right clicked since it isn't selected by default
                    Listbox_entries.SelectedIndex = Listbox_entries.IndexFromPoint(e.Location);
                    load_entry(null, new EventArgs());
                    contextMenuStrip1.Show();

                    contextMenu_item_delete.Tag = Listbox_entries.SelectedItem.ToString();
                    contextMenu_item_delete.Click -= delete_entry;
                    contextMenu_item_delete.Click += delete_entry;
                }
            }
        }

        //right click only when selecting image thumbnail
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Hide();
            if (e.Button == MouseButtons.Right)
            {

                ListViewItem lvi = listView1.GetItemAt(e.Location.X, e.Location.Y);
                if (lvi == null)
                {
                    bool found = false;
                    int index = 0;
                    int i = 0;
                    ListViewItem.ListViewSubItem lvsi = null;
                    while (!found && i < listView1.Items.Count)
                    {
                        lvsi = listView1.Items[i].GetSubItemAt(e.Location.X, e.Location.Y);
                        if (lvsi != null)
                        {
                            found = true;
                            index = i;
                            break;
                        }
                        i++;
                    }
                    if (found)
                    {
                        //MessageBox.Show(listView1.SelectedItems[index].Tag.ToString());
                        contextMenu_item_delete.Tag = listView1.SelectedItems[index].Tag.ToString();
                        contextMenu_item_delete.Click -= delete_image;
                        contextMenu_item_delete.Click += delete_image;
                    }
                }
                else
                {
                    //MessageBox.Show(lvi.Tag.ToString());
                    contextMenu_item_delete.Tag = lvi.Tag.ToString();
                    contextMenu_item_delete.Click -= delete_image;
                    contextMenu_item_delete.Click += delete_image;
                }
            }
        }

        //displays main journal entry content
        private void entriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_panel("entries");
        }

        //displays the about page
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_panel("about");
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_panel("preferences");
        }



        //removes flickering when resizing form (retrieved from stackoverflow)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //searches when user presses enter
        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string search_text = textBox_search.Text;
                
                populate_entries(search_text);
            }
        }

        //resets entry list if user clears search bar
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            if (textBox_search.Text == "")
            {
                populate_entries("");
            }
        }

        //hides search bar's Hint on focus
        private void textBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == default_search_hint)
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = SystemColors.ControlText;
            }
        }

        //shows search bar's Hint out of focus
        private void textBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text == "")
            {
                textBox_search.Text = default_search_hint;
                textBox_search.ForeColor = Color.Gray;
            }
        }

        //changes entry date format if settings changed
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_search.Text == default_search_hint)
            {
                populate_entries("");
            }
            else
            {
                string search_text = textBox_search.Text;
                populate_entries(search_text);
            }
        }

        //Changes cursor
        private void Listbox_entries_MouseLeave(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Hand)
                this.Cursor = Cursors.Arrow;
        }

        //changes cursor and item background color
        private void Listbox_entries_MouseMove(object sender, MouseEventArgs e)
        {
            int index = Listbox_entries.IndexFromPoint(e.Location.X, e.Location.Y);
            //Console.WriteLine("Mousemove: " + e.Location.X + " " + e.Location.Y);

            try
            {
                //redraw hover item background
                if (index != prev_index && index != -1)
                {
                    //refreshes the rectangle area that contains items at index and prev index
                    Listbox_entries.Invalidate(Listbox_entries.GetItemRectangle(index));
                    Listbox_entries.Invalidate(Listbox_entries.GetItemRectangle(prev_index));
                    prev_index = index;
                }

                if (index != -1)
                {
                    if (this.Cursor == Cursors.Arrow)
                        this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (this.Cursor == Cursors.Hand)
                        this.Cursor = Cursors.Arrow;
                }
            } catch(Exception ex)
            {

            }
        }

        //called when the program is closed
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt user to save data
            if(e.CloseReason == CloseReason.UserClosing)
            {
                //if user hasn't saved
                if (Tab_entry_field.TabPages[0].Text == tab_log_title_unsaved)
                {
                    var confirmResult = MessageBox.Show("Do you want to save the current entry before closing?", "Unsaved entry text", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        string selected_date = get_selected_date();

                        Boolean successful=save_entry();

                        //stops closing if save failed
                        if (successful == false)
                            e.Cancel = true;

                    }
                }
            }

            // Autosave and clear up ressources
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                //if unsaved data, save it.
                if (Tab_entry_field.TabPages[0].Text == tab_log_title_unsaved)
                    save_entry();
            }
        }

        //enables folderbrowserdialog to search for directory
        private void pref_button3_Click(object sender, EventArgs e)
        {

        }

        //handles image caption keypresses
        private void richTextBox_caption_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+S = saves caption entry
            if (e.Control && e.KeyCode == Keys.S)
            {
                string date = get_selected_date();

                string image_path = pictureBox1.Tag.ToString();
                string caption = richTextBox_caption.Text;

                xml.add_caption(path+"/"+date+"/metadata.xml", image_path, caption);


                //removes annoying windows beep sound effect
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            //Ctrl+A = select all text
            else if (e.Control && e.KeyCode == Keys.A)
            {
                richTextBox_caption.SelectAll();
                richTextBox_caption.Focus();

                //removes annoying windows beep sound effect
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
        
        //hides search bar's Hint on focus
        private void richTextBox_caption_Enter(object sender, EventArgs e)
        {
            if (richTextBox_caption.Text == default_caption_hint)
            {
                richTextBox_caption.Text = "";
                richTextBox_caption.ForeColor = SystemColors.ControlText;
            }
            else
                richTextBox_caption.ForeColor = SystemColors.ControlText;
        }

        //shows search bar's Hint out of focus
        private void richTextBox_caption_Leave(object sender, EventArgs e)
        {
            if (richTextBox_caption.Text == "")
            {
                richTextBox_caption.Text = default_caption_hint;
                richTextBox_caption.ForeColor = Color.Gray;
            }
        }
    }
}
