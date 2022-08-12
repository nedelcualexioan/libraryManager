using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryManager;
using libraryView.Panels;

namespace libraryView.Forms
{
    public partial class FrmHome : Form
    {
        private PictureBox pctLogo;

        private Home pnlHome;
        private ShowAll pnlShowAll;

        private BookRepo repo;
        public FrmHome()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(52, 73, 94);
            this.Size = new Size(728, 456);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Library";

            this.MaximizeBox = false;

            repo = new BookRepo();

            pnlHome = new Home(this, repo);
            
            foreach (Control c in this.Controls)
            {
                c.Hide();
            }

            pctLogo = new PictureBox
            {
                Parent = this,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(161, 122),
                Top = 2,
                ImageLocation = Application.StartupPath + @"\pictures\logo.png"
            };

            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;
            pctLogo.BringToFront();

            pnlHome.Show();


            pnlHome.showAllClick += homeShowAll_Click;


        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void homeShowAll_Click(object sender, EventArgs e)
        {
            pnlShowAll = new ShowAll(this, repo);
            pnlShowAll.backClick += showAllBack_Click;

            pnlHome.Hide();

            pnlShowAll.Show();
        }

        private void showAllBack_Click(object sender, EventArgs e)
        {
            pnlShowAll.Hide();
            pnlHome.Show();
        }
    }
}
