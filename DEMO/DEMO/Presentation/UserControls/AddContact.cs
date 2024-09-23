using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;
using ContactManagerClassLibrary.Infrastructure.Services;

namespace DEMO
{
    public partial class AddContact : UserControl
    {
        #region Initialization

        ContactManagerService cmservice;
        public EventHandler ContactSaveClicked;

        public AddContact()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            cmservice = null;

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

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            cmservice = new ContactManagerService();

            string name = tbName.Text.Trim();
            string number = tbNumber.Text.Trim();
            string email = tbEmail.Text.Trim();
            string address = tbAddress.Text.Trim();

            var fieldError = cmservice.ValidateFields(name, number, email, address);
            if (fieldError != string.Empty)
            {
                MessageBox.Show(fieldError, "Warning");
                return;
            }

            cmservice = new ContactManagerService();

            Contact newContact = new Contact
            {
                Name = name,
                Number = number,
                Email = email,
                Address = address,
                Groups = new List<Group>()
            };

            using (var context = new Context())
            {
                foreach (var item in cbGroup.CheckedItems)
                {
                    switch (item.ToString())
                    {
                        case "Family":
                            newContact.Groups.Add(cmservice.GetGroupById(1, context));
                            break;
                        case "Friend":
                            newContact.Groups.Add(cmservice.GetGroupById(2, context));
                            break;
                        case "Work":
                            newContact.Groups.Add(cmservice.GetGroupById(3, context));
                            break;
                    }
                }

                var addError = cmservice.AddContact(newContact, context);
                if (addError != string.Empty)
                {
                    MessageBox.Show(addError, "Error!");
                }
                else
                {
                    MessageBox.Show("Contact Saved Successfully.", "Contact Saved");

                    ContactSaveClicked(sender, e);
                    Reset();
                }
                
                return;
            }
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
