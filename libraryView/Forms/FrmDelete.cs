using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryManager;

namespace libraryView.Forms
{
    public partial class FrmDelete : Form
    {

        private Label lblName;
        private TextBox txtName;

        private Label lblAuthor;
        private TextBox txtAuthor;

        private Button btnDelete;

        public FrmDelete(BookRepo repo)
        {
            InitializeComponent();

            Size = new Size(586, 200);
            BackColor = Color.FromArgb(52, 73, 94);

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
                Size = new Size(198, 25),
                Location = new Point(12, 31)
            };

            lblAuthor = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = lblName.Font,
                Location = new Point(12, 75),
                Text = "Autorul cartii",
                ForeColor = Color.LightGray
            };

            txtAuthor = new TextBox
            {
                Parent = this,
                Size = txtName.Size,
                Location = new Point(12, 97)
            };

            btnDelete = new Button
            {
                Parent = this,
                Size = new Size(89, 37),
                Location = new Point(475, 117),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 1, BorderColor = Color.DarkGray },
                Text = "Sterge",
                ForeColor = Color.LightGray,
                Cursor = Cursors.Hand
            };

            btnDelete.Click += (s, e) => btnDelete_Click(s, e, repo);
        }

        private void btnDelete_Click(object sender, EventArgs e, BookRepo repo)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) == false && String.IsNullOrWhiteSpace(txtAuthor.Text) == false)
            {

                repo.deleteByDetails(txtName.Text, txtAuthor.Text);

                MessageBox.Show("Stergere initiata", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            else
            {
                MessageBox.Show("Campuri invalide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
