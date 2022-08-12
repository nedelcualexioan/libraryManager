using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryManager;

namespace libraryView.Forms
{
    public partial class FrmOptions : Form
    {

        private Label lblName;
        private TextBox txtName;

        private Label lblAuthor;
        private TextBox txtAuthor;

        private Button btnNext;

        public FrmOptions(BookRepo repo, string action)
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

            btnNext = new Button
            {
                Parent = this,
                Size = new Size(89, 37),
                Location = new Point(475, 117),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 1, BorderColor = Color.DarkGray },
                ForeColor = Color.LightGray,
                Cursor = Cursors.Hand
            };

            if (action == "delete")
            {
                btnNext.Text = "Sterge";

                btnNext.Click += (s, e) => btnDelete_Click(s, e, repo);
            }
            else if (action == "search")
            {
                btnNext.Text = "Cauta";

                btnNext.Click += (s, e) => btnSearch_Click(s, e, repo);
            }
            else if(action == "update")
            {
                btnNext.Text = "Continua";

                btnNext.Click += (s, e) => btnUpdate_Click(s, e, repo);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e, BookRepo repo)
        {
            if (!(String.IsNullOrWhiteSpace(txtName.Text)) && String.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                if (repo.getName(txtName.Text) != null)
                {
                    MessageBox.Show(repo.getName(txtName.Text).ToString());
                }
                else
                {
                    MessageBox.Show("Nu a fost gasita nicio carte cu acest nume", "Eroare", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (String.IsNullOrWhiteSpace(txtName.Text) && !(String.IsNullOrWhiteSpace(txtAuthor.Text)))
            {
                if (repo.getByAuthor(txtAuthor.Text).Count != 0)
                {
                    string text = "";

                    foreach (Book b in repo.getByAuthor(txtAuthor.Text))
                    {
                        text += b.ToString() + "\n";
                    }

                    MessageBox.Show(text);
                }
                else
                {
                    MessageBox.Show("Nu a fost gasita nicio carte apartinand acestui autor", "Eroare",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!(String.IsNullOrWhiteSpace(txtName.Text)) && !String.IsNullOrWhiteSpace(txtAuthor.Text))
            {

                Book b = repo.getByNameAndAuthor(txtName.Text, txtAuthor.Text);

                if (b != null)
                {
                    MessageBox.Show(b.ToString());
                }
                else
                {
                    MessageBox.Show("Nu a fost gasita nicio carte care sa corespunda filtrelor", "Eroare",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Trebuie completat cel putin un camp", "Eroare", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            this.Close();
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

        private void btnUpdate_Click(object sender, EventArgs e, BookRepo repo)
        {
            if (repo.isBookByNameAndAuthor(txtName.Text, txtAuthor.Text))
            {
                FrmCreate update = new FrmCreate(repo, "update",
                    repo.getByNameAndAuthor(txtName.Text, txtAuthor.Text));

                this.Hide();

                update.Closed += (s, args) => this.Close();
                update.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nu a fost gasita nicio inregistrare care sa corespunda detaliilor oferite", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
