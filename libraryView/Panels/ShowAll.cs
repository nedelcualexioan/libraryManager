using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryManager;

namespace libraryView.Panels
{
    public class ShowAll : Panel
    {
        private Panel pnlMain;

        private ComboBox cmbSort;

        private Label lblBack;

        public event EventHandler backClick;

        public ShowAll(Control par, BookRepo repo)
        {
            this.Parent = par;

            this.Size = par.Size;
            this.BackColor = par.BackColor;
            

            pnlMain = new Panel
            {
                Parent = this,
                Size = new Size(695, 262),
                Location = new Point(12, 143),
                BorderStyle = BorderStyle.FixedSingle
            };

            cmbSort = new ComboBox
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(118, 23),
                Location = new Point(12, 114),
                Font = new Font("Segoe UI", 9F),
                Text = "Sortati dupa:",
                TabStop = false
            };

            lblBack = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Text = "<= Back",
                Location = new Point(12, 9),
                Cursor = Cursors.Hand
            };

            lblBack.Click += lblBack_Click;

            cmbSort.KeyPress += cmbSort_KeyPress;
            cmbSort.SelectedIndexChanged += (s, e) => cmbSort_SelectedIndexChanged(s, e, repo);

            cmbSort.Items.Add("Numele cartii");
            cmbSort.Items.Add("Data publicarii");

            populate(repo.getAll());

        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            if (backClick != null)
            {
                backClick(this, null);
            }
        }

        private void populate(List<Book> list)
        {
            int x = 14, y = 9;

            foreach (Book book in list)
            {
                Label lblBook = new Label
                {
                    Parent = pnlMain,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(x, y),
                    Text = book.BookName,
                    ForeColor = Color.LightGray
                };

                if (list.IndexOf(book) != list.Count - 1)
                {
                    lblBook.Text += ",";
                }

                x += lblBook.Width + 5;

                if (x >= this.Width - 14)
                {
                    x = 14;
                    y += 19;
                }
            }
        }

        private void cmbSort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e, BookRepo repo)
        {
            string selected = this.cmbSort.GetItemText(this.cmbSort.SelectedItem);

            pnlMain.Controls.Clear();

            if (selected.Contains("Nume"))
            {
                populate(repo.getAllSortByName());
            }
            else if (selected.Contains("Data"))
            {
                populate(repo.getAllSortByDate());
            }
        }


    }
}
