using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryManager;
using libraryView.Forms;

namespace libraryView.Panels
{
    public class Home : Panel
    {
        private Button btnShowAll;
        private Button btnAdd;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnUpdate;

        public event EventHandler showAllClick;

        public Home(Control par, BookRepo repo)
        {
            this.Parent = par;

            this.Size = par.Size;
            this.BackColor = par.BackColor;

            Initialize();

            btnShowAll.Click += BtnShowAll_Click;

            btnAdd.Click += (s, e) => BtnAdd_Click(s, e, repo);

            btnSearch.Click += (s, e) => BtnSearch_Click(s, e, repo);

            btnDelete.Click += (s, e) => BtnDelete_Click(s, e, repo);

            btnUpdate.Click += (s, e) => BtnUpdate_Click(s, e, repo);
        }

        private void BtnUpdate_Click(object sender, EventArgs e, BookRepo repo)
        {
            FrmOptions update = new FrmOptions(repo, "update");

            update.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e, BookRepo repo)
        {
            FrmOptions del = new FrmOptions(repo, "delete");

            del.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e, BookRepo repo)
        {
            FrmCreate add = new FrmCreate(repo, "create");

            add.ShowDialog();
        }

        private void BtnSearch_Click(object sender, EventArgs e, BookRepo repo)
        {
            FrmOptions search = new FrmOptions(repo, "search");

            search.ShowDialog();
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            if (showAllClick != null)
            {
                showAllClick(this, null);
            }
        }



        private void Initialize()
        {

            btnShowAll = new Button
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 1, BorderColor = Color.Black },
                Font = new Font("Segoe UI", 9F),
                Location = new Point(12, 147),
                Size = new Size(124, 47),
                Text = "Afisati toate cartile",
                TabStop = false,
                Cursor = Cursors.Hand,
                ForeColor = Color.LightGray
            };

            clone(btnShowAll, ref btnAdd);
            btnAdd.Text = "Adaugati o noua carte";

            clone(btnAdd, ref btnSearch);
            btnSearch.Text = "Cautati o carte in baza de date";

            clone(btnSearch, ref btnDelete);
            btnDelete.Text = "Stergeti o carte";

            clone(btnDelete, ref btnUpdate);
            btnUpdate.Text = "Actualizati detaliile unei carti";


        }

        private void clone(Button source, ref Button dest)
        {
            dest = new Button
            {
                Parent = source.Parent,
                FlatStyle = source.FlatStyle,
                FlatAppearance =
                    { BorderSize = source.FlatAppearance.BorderSize, BorderColor = source.FlatAppearance.BorderColor },
                Font = source.Font,
                Location = new Point(source.Location.X, source.Location.Y + 53),
                Size = source.Size,
                Cursor = Cursors.Hand,
                TabStop = false,
                ForeColor = source.ForeColor
            };
        }

    }
}
