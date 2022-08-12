using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using libraryManager;

namespace libraryView.Forms
{
    public partial class FrmCreate : Form
    {
        private Label lblName;
        private TextBox txtName;

        private Label lblAuthor;
        private TextBox txtAuthor;

        private Label lblDate;
        private TextBox txtDate;

        private Button btnDone;

        public FrmCreate(BookRepo repo)
        {
            InitializeComponent();

            BackColor = Color.FromArgb(52, 73, 94);
            Size = new Size(586, 261);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;


            lblName = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(12, 9),
                Text = "Numele cartii",
                ForeColor = Color.LightGray
            };

            txtName = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 9.75f),
                Size = new Size(153, 25),
                Location = new Point(12, 31)
            };

            lblAuthor = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(12, 73),
                Text = "Autorul cartii",
                ForeColor = Color.LightGray
            };

            txtAuthor = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 9.75f),
                Size = txtName.Size,
                Location = new Point(12, 95)
            };

            lblDate = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(12, 132),
                Text = "Data publicarii\n(YYYY-MM-DD)",
                ForeColor = Color.LightGray
            };

            txtDate = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 9.75f),
                Size = txtName.Size,
                Location = new Point(12, 173)
            };

            btnDone = new Button
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(89, 37),
                Location = new Point(474, 180),
                FlatAppearance = { BorderSize = 1, BorderColor = Color.DarkGray },
                Text = "Done",
                ForeColor = Color.LightGray,
                Cursor = Cursors.Hand
            };

            btnDone.Click += (s, e) => btnDone_Click(s, e, repo);

        }

        private void btnDone_Click(object sender, EventArgs e, BookRepo repo)
        {
            Regex regex = new Regex(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$");

            if (!String.IsNullOrWhiteSpace(txtName.Text) && !String.IsNullOrWhiteSpace(txtAuthor.Text) &&
                regex.IsMatch(txtDate.Text))
            {
                repo.create(new Book(txtName.Text, txtAuthor.Text, DateTime.Parse(txtDate.Text)));

                this.Close();
            }
            else
            {
                MessageBox.Show("Campuri invalide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        private void FrmCreate_Load(object sender, EventArgs e)
        {

        }
    }
}
