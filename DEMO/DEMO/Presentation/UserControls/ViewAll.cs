using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Services;

namespace DEMO
{
    public partial class ViewAll : UserControl
    {
        #region Initialization

        private ContactManagerService cmservice;
        public event EventHandler DetailsButtonClicked;
        public event EventHandler AddContactButtonClicked;

        public ViewAll()
        {
            InitializeComponent();
        }

        private void ViewAll_Load(object sender, EventArgs e)
        {
            cmservice = new ContactManagerService();
        }

        #endregion

        #region Loading Data in Grid

        public void LoadGrid(List<Contact> contacts)
        {
            gridViewAll.Columns.Clear();
            gridViewAll.Rows.Clear();

            gridViewAll.Columns.Add("ContactId", "ID");
            gridViewAll.Columns.Add("Name", "Name");
            gridViewAll.Columns.Add("Number", "Phone Number");

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "DetailsButton";
            buttonColumn.HeaderText = "Details";
            buttonColumn.Text = "View";
            buttonColumn.UseColumnTextForButtonValue = true;

            gridViewAll.Columns.Add(buttonColumn);

            //gridViewAll.Columns.Add("Groups", "Groups");

            foreach (var c in contacts)
            {
                gridViewAll.Rows.Add(c.ContactId, c.Name, c.Number); //, string.Join(", ", c.Groups.Select(g => g.GroupName) ));
            }

            gridViewAll.Columns["ContactID"].Visible = false;
            gridViewAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewAll.CellContentClick += DataGridView1_CellContentClick;

            return;
        }

        #endregion

        #region Searching Contacts

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbSearch.Text.ToString().ToLower().Trim();

            List<Contact> contacts = cmservice.SearchContact(key);

            LoadGrid(contacts);

            return;
        }

        #endregion

        #region Button Events

        #region View Details

        public class ContactEventArgs : EventArgs
        {
            public int Id { get; }

            public ContactEventArgs(int id)
            {
                Id = id;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridViewAll.Columns["DetailsButton"].Index && e.RowIndex >= 0)
            {
                int id = (int)gridViewAll.Rows[e.RowIndex].Cells["ContactID"].Value;

                //MessageBox.Show(id.ToString());

                DetailsButtonClicked?.Invoke(this, new ContactEventArgs(id));
            }
        }

        #endregion

        #region Add Contact

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContactButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #endregion

        #region Unused Methods

        private void lbSearch_Click(object sender, EventArgs e)
        {

        }

        private void gridViewAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

    }
}
