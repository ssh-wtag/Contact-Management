using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Interfaces;
using ContactManagerClassLibrary.Infrastructure.Services;
using System.Windows.Forms;
using static DEMO.ViewAll;

namespace DEMO
{
    public partial class MainForm : Form
    {
        #region Initialization

        private readonly IContactManager cmservice;

        public MainForm(IContactManager contactManager)
        {
            cmservice = contactManager;
            InitializeComponent();

            HideAll();
            AttachEvents();

            viewAll1.Visible = true;
        }

        //public MainForm()
        //{
        //    InitializeComponent();

        //    HideAll();
        //    AttachEvents();

        //    viewAll1.Visible = true;
        //}

        private void AttachEvents()
        {
            viewAll1.DetailsButtonClicked += Show_ViewDetails;
            viewAll1.AddContactButtonClicked += Show_AddContact;
            viewDetails1.BackButtonClicked += Show_ViewAll;
            viewDetails1.ContactDeleted += Show_ViewAll;
            addContact1.ContactSaveClicked += Show_ViewAll;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //cmservice = new ContactManagerService();
            List<Contact> contacts = await cmservice.ShowAllAsync();
            viewAll1.LoadGrid();
            viewAll1.LoadData(contacts);
        }

        #endregion

        #region Control Visibility

        private void HideAll()
        {
            viewAll1.Visible = false;
            viewDetails1.Visible = false;
            addContact1.Visible = false;
        }

        private async void Show_ViewAll(object sender, EventArgs e)
        {
            HideAll();
            viewAll1.Visible = true;
            viewAll1.LoadData(await cmservice.ShowAllAsync());
        }

        private void Show_ViewDetails(object sender, EventArgs e)
        {
            HideAll();
            viewDetails1.Reset();
            viewDetails1.Visible = true;

            int Id = (int)e.GetType().GetProperty("Id").GetValue(e);
            viewDetails1.CurrentId = Id;
            viewDetails1.LoadData();
        }

        private void Show_AddContact(object sender, EventArgs e)
        {
            HideAll();
            addContact1.Visible = true;
        }

        #endregion
    }
}
