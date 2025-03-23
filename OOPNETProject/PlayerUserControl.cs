using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Diagnostics;
using ClassLibrary1.Models.Two;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Globalization;
using ClassLibrary1.Resources;
using static System.Windows.Forms.DataFormats;
using System.Drawing.Imaging;

namespace OOPNETProject
{
    public partial class PlayerUserControl : UserControl
    {
        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";
        private readonly string _defaultpicturePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicPath));
        private const string rPicSavePath = @"..\..\..\..\..\Images\";
        private readonly string _PicSavePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicSavePath));

        private readonly string currentloc = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public bool IsFavorite { get; set; }
        public ClassLibrary1.Models.Two.StartingEleven playerObject { get; set; }

        public bool IsSelected = false;

        public static List<PlayerUserControl>? dragdroplist;

        private Color originalbackcolor;

        public PlayerUserControl(string name, string number, string position)
        {
            InitializeComponent();
            lblName.Text = name;
            lblNumber.Text = number;
            lblPosition.Text = position;


            this.MouseDown += PlayerUserControl_MouseDown;
            foreach (Control control in this.Controls) // give me all controls
            {
                control.MouseDown += PlayerUserControl_MouseDown;
                //if (control is GroupBox gb) //groupbox was just for style but this is required now
                //{
                //    foreach (Control control1 in gb.Controls)
                //    {
                //        control1.MouseDown += PlayerUserControl_MouseDown;
                //    }
                //}
                switch (control)
                {
                    case (GroupBox):
                    case (Control):
                        foreach (Control control1 in control.Controls)
                        {
                            control1.MouseDown += PlayerUserControl_MouseDown;
                        }
                        break;
                    default:
                        break;
                }
                if (dragdroplist == null)
                {
                    dragdroplist = new List<PlayerUserControl>();
                }
            }
            //DoDragDrop(this, DragDropEffects.Move);
        }

        public PlayerUserControl(string name, string number, string position, string rpicturePATH) : this(name, number, position)
        {
            try
            {
                if (!string.IsNullOrEmpty(rpicturePATH))
                {
                    try
                    {
                        pBPlayer.BackgroundImage = Image.FromFile(Path.Combine(currentloc, rpicturePATH));
                    }
                    catch (Exception)
                    {
                        pBPlayer.BackgroundImage = Image.FromFile(_defaultpicturePATH);
                    }
                }
                else
                {
                    pBPlayer.BackgroundImage = Image.FromFile(_defaultpicturePATH);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public PlayerUserControl(StartingEleven player) : this(player.Name, player.ShirtNumber.ToString(), player.Position.ToString(), null)
        {
            playerObject = player;
            lblCaptain.Visible = player.Captain;
        }
        public PlayerUserControl(StartingEleven player, bool isfavorite) : this(player.Name, player.ShirtNumber.ToString(), player.Position.ToString(), player.PicturePath)
        {
            playerObject = player;
            lblCaptain.Visible = player.Captain;
            pBFavorite.Visible = isfavorite;
            IsFavorite = isfavorite;
        }

        public PlayerUserControl(StartingEleven player, bool isfavorite, CultureInfo currentcultureinfo) : this(player, isfavorite)
        {
            Thread.CurrentThread.CurrentUICulture = currentcultureinfo;

            groupBox1.Text = Resource.info;

            label1.Text = Resource.number + ":";
            label2.Text = Resource.name + ":";
            label3.Text = Resource.position + ":";
        }

        public PlayerUserControl(StartingEleven player, CultureInfo currentcultureinfo) : this(player, false, currentcultureinfo)
        {
        }

        private void PlayerUserControl_MouseDown(object sender, MouseEventArgs e) //BUG fix right click
        {
            Debug.WriteLine("MouseDown");
            //if (sender is not UserControl)
            //{
            //    var con = sender as Control;
            //    var parent = con.Parent;
            //    if (parent is not PlayerUserControl)
            //    {
            //        StartDragAndDrop(this as PlayerUserControl);
            //    }
            //    StartDragAndDrop(parent as PlayerUserControl);
            //}

            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenuStrip1.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                    }
                    break;
                case MouseButtons.Left:
                    {
                        if (IsSelected)
                        {
                            //StartDragAndDrop(this as PlayerUserControl); //ez
                            //dragdroplist.ToList().ForEach(p => { StartDragAndDrop(p); }); // WORKING!!!
                            StartDragAndDrop(this as PlayerUserControl);

                        }
                    }
                    break;
            }



        }

        private void StartDragAndDrop(PlayerUserControl? uc)
        {
            if (IsSelected)
            {
                Debug.WriteLine("StartDragAndDrop_UC");
                if (uc is null)
                {
                    return;
                }
                uc.DoDragDrop(uc, DragDropEffects.Move);
            }

        }



        private void PlayerUserControl_DragEnter(object sender, DragEventArgs e)
        {
            if (IsSelected)
            {
                Debug.WriteLine("DragEnter");
                if (sender is not PlayerUserControl playerUserControl)
                {
                    return;
                }

                e.Effect = DragDropEffects.Move;
            }
        }

        public void SetFavorite(bool isfavorite)
        {
            pBFavorite.Visible = isfavorite;
            IsFavorite = isfavorite;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlayerUserControl control &&
                   EqualityComparer<Label>.Default.Equals(lblNumber, control.lblNumber) &&
                   EqualityComparer<Label>.Default.Equals(lblPosition, control.lblPosition) &&
                   EqualityComparer<Label>.Default.Equals(lblName, control.lblName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(lblNumber, lblPosition, lblName);
        }

        private void changePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                var dialog = new OpenFileDialog();

                dialog.Filter = "Picture (*.bmp,*.jpg,*.png,*.jpeg)|*.bmp;*.jpg;*.jpeg;*.png";

                dialog.InitialDirectory = Application.StartupPath;

                var result = dialog.ShowDialog();

                ImageFormat format = null;

                if (result == DialogResult.OK)
                {
                    this.SetPicturePath(dialog.FileName);
                    string ext = Path.GetExtension(dialog.FileName);
                    string name = Path.GetFileNameWithoutExtension(dialog.FileName);
                    switch (ext)
                    {
                        case ".jpeg":
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        default:
                            format = ImageFormat.Jpeg;
                            break;
                    }
                    string pathtosaveto = _PicSavePATH + name + ext;
                    if (!File.Exists(pathtosaveto))
                    {
                        pBPlayer.BackgroundImage.Save(pathtosaveto, format);
                    }

                    playerObject.PicturePath = rPicSavePath + name + ext;
                }

            }
            catch (Exception)
            {

                throw new InvalidDataException();
            }




        }

        private void SetPicturePath(string safeFileName)
        {
            pBPlayer.BackgroundImage = Image.FromFile(safeFileName);
            //playerObject.PicturePath = safeFileName;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsSelected && dragdroplist?.Count < 3) // not sure if useful since only 3 can go into favorites in Form 1 logic anyway.
            {
                originalbackcolor = this.BackColor;
                this.BackColor = Color.Orange;
                IsSelected = true;
                if (!dragdroplist.Contains(this))
                {
                    dragdroplist.Add(this);
                }
            }
            else if (!IsSelected && dragdroplist?.Count == 3)
            {
               MyMessageDialog(Resource.maxthreeselections);
            }
            else
            {
                UnselectDragDrop();
            }

        }

        private void MyMessageDialog(string text)
        {
            Task.Run(() => MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning));
        }

        private void PlayerUserControl_DragOver(object sender, DragEventArgs e)
        {
        }

        private void PlayerUserControl_DragLeave(object sender, EventArgs e)
        {
        }

        public void UnselectDragDrop()
        {
            this.BackColor = Color.Transparent;
            IsSelected = false;
            if (dragdroplist.Contains(this))
            {
                dragdroplist.Remove(this);
            }
        }

        private void PlayerUserControl_DragDrop(object sender, DragEventArgs e)
        {
            UnselectDragDrop();
        }

        public static IList<PlayerUserControl> GetDragDropList()
        {
            return new List<PlayerUserControl>(dragdroplist);
        }
    }
}
