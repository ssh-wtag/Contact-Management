using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Services;
using System.Data;

namespace DEMO
{
    public partial class ViewDetails : UserControl
    {
        #region Initialization

        public int CurrentId;
        private Contact CurrentContact;
        private DataTable dataTable;

        private ContactManagerService cmservice;

        public EventHandler BackButtonClicked;
        public EventHandler ContactDeleted;

        public ViewDetails()
        {
            InitializeComponent();
        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {
            cmservice = new ContactManagerService();
        }

        public void LoadGrid()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Column Name");
            dataTable.Columns.Add("Value");
        }

        public void Reset()
        {
            CurrentId = -1;
            CurrentContact = null;
            cmservice = null;

            gridViewDetails.CellValueChanged -= gridViewDetails_CellValueChanged;

            cbFamily.CheckedChanged -= cbFamily_CheckedChanged;
            cbFriend.CheckedChanged -= cbFriend_CheckedChanged;
            cbWork.CheckedChanged -= cbWork_CheckedChanged;

            cbFamily.Checked = false;
            cbFriend.Checked = false;
            cbWork.Checked = false;
        }

        #endregion

        #region Loading Data in Grid

        public void LoadData()
        {
            LoadGrid();

            cmservice = new ContactManagerService();
            CurrentContact = cmservice.GetContactById(CurrentId);

            dataTable.Rows.Add("Name", CurrentContact.Name);
            dataTable.Rows.Add("Number", CurrentContact.Number);
            dataTable.Rows.Add("Email", CurrentContact.Email);
            dataTable.Rows.Add("Address", CurrentContact.Address);

            gridViewDetails.DataSource = dataTable;

            gridViewDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridViewDetails.Columns[0].ReadOnly = true;
            gridViewDetails.AllowUserToAddRows = false;

            string groups = string.Join(", ", CurrentContact.Groups.Select(g => g.GroupName));

            if (groups.Contains("Family"))
                cbFamily.Checked = true;
            if (groups.Contains("Friend"))
                cbFriend.Checked = true;
            if (groups.Contains("Work"))
                cbWork.Checked = true;

            gridViewDetails.CellValueChanged += gridViewDetails_CellValueChanged;

            cbFamily.CheckedChanged += cbFamily_CheckedChanged;
            cbFriend.CheckedChanged += cbFriend_CheckedChanged;
            cbWork.CheckedChanged += cbWork_CheckedChanged;

            //MessageBox.Show(string.Join(", ", CurrentContact.Groups.Select(g => g.GroupName)));
        }

        #endregion

        #region Edit Contact

        private void EditContact()
        {
            int id = CurrentId;
            string name = gridViewDetails.Rows[0].Cells[1].Value.ToString().Trim();
            string number = gridViewDetails.Rows[1].Cells[1].Value.ToString().Trim();
            string email = gridViewDetails.Rows[2].Cells[1].Value.ToString().Trim();
            string address = gridViewDetails.Rows[3].Cells[1].Value.ToString().Trim();
            bool[] groups = new bool[3];
            Array.Fill(groups, false);

            if (cbFamily.Checked)
                groups[0] = true;
            if (cbFriend.Checked)
                groups[1] = true;
            if (cbWork.Checked)
                groups[2] = true;

            Result result = cmservice.EditContact(id, name, number, email, address, groups);
            if (!result.IsSuccess)
            {
                MessageBox.Show($"Contact Could Not be Edited. {result.Error}", "Warning");

                var contact = cmservice.GetContactById(CurrentId);
                gridViewDetails.Rows[0].Cells[1].Value = contact.Name;
                gridViewDetails.Rows[1].Cells[1].Value = contact.Number;
                gridViewDetails.Rows[2].Cells[1].Value = contact.Email;
                gridViewDetails.Rows[3].Cells[1].Value = contact.Address;
            }

            return;
        }

        private void gridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            EditContact();
        }

        private void cbFamily_CheckedChanged(object sender, EventArgs e)
        {
            EditContact();
        }

        private void cbFriend_CheckedChanged(object sender, EventArgs e)
        {
            EditContact();
        }

        private void cbWork_CheckedChanged(object sender, EventArgs e)
        {
            EditContact();
        }

        #endregion

        #region Delete Contact

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show(
                $"Contact \"{CurrentContact.Name}\" Will Be Deleted?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (choice == DialogResult.Yes)
            {
                Result result = cmservice.DeleteContact(CurrentId);
                if (result.IsSuccess)
                    ContactDeleted?.Invoke(this, EventArgs.Empty);
                else
                    MessageBox.Show(result.Error, "Error");
            }

            return;
        }

        #endregion

        #region Button Events

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Reset();
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void gridViewDetails_Resize(object sender, EventArgs e)
        {
            float newFontSize = Math.Max(8, this.ClientSize.Height / 40);
            gridViewDetails.Font = new Font(gridViewDetails.Font.FontFamily, newFontSize);

            int newRowHeight = (int)(this.ClientSize.Height/8);
            gridViewDetails.RowTemplate.Height = newRowHeight;

            foreach (DataGridViewRow row in gridViewDetails.Rows)
            {
                row.Height = newRowHeight;
            }
        }

        #endregion

        #region Unused Methods

        private void lbViewDetails_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
