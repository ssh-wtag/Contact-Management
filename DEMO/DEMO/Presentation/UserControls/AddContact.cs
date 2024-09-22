using DEMO.Domain.Models;
using DEMO.Infrastructure.Data;
using DEMO.Logic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Contact newContact = new Contact
            {
                Name = tbName.Text.Trim(),
                Number = tbNumber.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                Groups = new List<Group>()
            };

            using (var context = new Context())
            {
                foreach (var item in cbGroup.CheckedItems)
                {
                    if (item.ToString() == "Family")
                        newContact.Groups.Add(context.Groups.Find(1));
                    else if (item.ToString() == "Friend")
                        newContact.Groups.Add(context.Groups.Find(2));
                    else if (item.ToString() == "Work")
                        newContact.Groups.Add(context.Groups.Find(3));
                }

                if (!cmservice.ValidateName(newContact.Name))
                {
                    MessageBox.Show("Name Cannot be Empty", "Warning");
                    return;
                }

                if (!cmservice.ValidateNumber(newContact.Number))
                {
                    MessageBox.Show("Phone Numbers Cannot be Empty and May Only Contain Digits, a Plus Sign (+) at the Start, and Hyphens (-)", "Warning");
                    return;
                }

                if (newContact.Name.Length > 100)
                {
                    MessageBox.Show("Name Too Long", "Warning");
                    return;
                }

                if (newContact.Number.Length > 100)
                {
                    MessageBox.Show("Number Too Long", "Warning");
                    return;
                }

                if (newContact.Email.Length > 150)
                {
                    MessageBox.Show("Email Too Long", "Warning");
                    return;
                }

                if (newContact.Address.Length > 1000)
                {
                    MessageBox.Show("Address Too Long", "Warning");
                    return;
                }

                if (!cmservice.AddContact(newContact, context))
                {
                    return;
                }

                MessageBox.Show("Contact Saved Successfully.", "Contact Saved");

                ContactSaveClicked(sender, e);
                Reset();

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
