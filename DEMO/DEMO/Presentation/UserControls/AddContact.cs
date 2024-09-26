using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;
using ContactManagerClassLibrary.Infrastructure.Interfaces;
using ContactManagerClassLibrary.Infrastructure.Services;

namespace DEMO
{
    public partial class AddContact : UserControl
    {
        #region Initialization

        private readonly IContactManager cmservice;
        public EventHandler ContactSaveClicked;

        public AddContact(IContactManager contactManager)
        {
            cmservice = contactManager;
            InitializeComponent();
        }

        public void Reset()
        {
            tbName.Text = string.Empty;
            tbNumber.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbAddress.Text = string.Empty;

            for (int i = 0; i < cbGroup.Items.Count; i++)
            {
                cbGroup.SetItemChecked(i, false);
            }
        }

        #endregion

        #region Adding a New Contact

        private async void btnSaveContact_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string number = tbNumber.Text.Trim();
            string email = tbEmail.Text.Trim();
            string address = tbAddress.Text.Trim();
            bool[] groups = new bool[cbGroup.Items.Count];
            Array.Fill(groups, false);

            foreach (var item in cbGroup.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Family":
                        groups[(int)GroupType.Family] = true;
                        break;
                    case "Friend":
                        groups[(int)GroupType.Friend] = true;
                        break;
                    case "Work":
                        groups[(int)GroupType.Work] = true;
                        break;
                }
            }

            Result result = await cmservice.AddContactAsync(name, number, email, address, groups);

            if (result.IsSuccess)
            {
                MessageBox.Show("Contact Saved Successfully.", "Contact Saved");

                ContactSaveClicked(sender, e);
                Reset();
            }
            else
            {
                MessageBox.Show(result.Error, "Error!");
            }

            return;
        }

        #endregion

        #region Button Events

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            ContactSaveClicked(sender, e);
            Reset();
        }

        #endregion

        #region Unused Methods

        private void AddContact_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
