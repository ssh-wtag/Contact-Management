﻿using DEMO.Domain.Models;
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
            Contact editedContact = new();
            editedContact.ContactId = CurrentId;
            editedContact.Name = gridViewDetails.Rows[0].Cells[1].Value.ToString().Trim();
            editedContact.Number = gridViewDetails.Rows[1].Cells[1].Value.ToString().Trim();
            editedContact.Email = gridViewDetails.Rows[2].Cells[1].Value.ToString().Trim();
            editedContact.Address = gridViewDetails.Rows[3].Cells[1].Value.ToString().Trim();

            if(editedContact.Name.Length > 100)
            {
                MessageBox.Show("Name Too Long", "Warning");
                gridViewDetails.Rows[0].Cells[1].Value = cmservice.GetContactById(CurrentId).Name;
                return;
            }

            if (!cmservice.ValidateName(editedContact.Name))
            {
                MessageBox.Show("Name Cannot be Empty", "Warning");
                gridViewDetails.Rows[0].Cells[1].Value = cmservice.GetContactById(CurrentId).Name;
                return;
            }

            if (editedContact.Number.Length > 100)
            {
                MessageBox.Show("Number Too Long", "Warning");
                gridViewDetails.Rows[0].Cells[1].Value = cmservice.GetContactById(CurrentId).Name;
                return;
            }

            if (!cmservice.ValidateNumber(editedContact.Number))
            {
                MessageBox.Show("Phone Numbers Cannot be Empty and May Only Contain Digits, a Plus Sign (+) at the Start, and Hyphens (-)", "Warning");
                gridViewDetails.Rows[1].Cells[1].Value = cmservice.GetContactById(CurrentId).Number;
                return;
            }

            if (editedContact.Email.Length > 150)
            {
                MessageBox.Show("Email Too Long", "Warning");
                gridViewDetails.Rows[0].Cells[1].Value = cmservice.GetContactById(CurrentId).Name;
                return;
            }

            if (editedContact.Address.Length > 1000)
            {
                MessageBox.Show("Address Too Long", "Warning");
                gridViewDetails.Rows[0].Cells[1].Value = cmservice.GetContactById(CurrentId).Name;
                return;
            }

            Group family = new Group(); family.GroupId = 1; family.GroupName = "Family";
            Group friend = new Group(); friend.GroupId = 2; friend.GroupName = "Friend";
            Group work = new Group(); work.GroupId = 3; work.GroupName = "Work";

            editedContact.Groups = new List<Group>();

            if (cbFamily.Checked)
                editedContact.Groups.Add(family);
            if (cbFriend.Checked)
                editedContact.Groups.Add(friend);
            if (cbWork.Checked)
                editedContact.Groups.Add(work);

            if (!cmservice.EditContact(editedContact))
                MessageBox.Show($"Contact Could Not be Edited.");

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
            DialogResult result = MessageBox.Show(
                $"Contact \"{CurrentContact.Name}\" Will Be Deleted?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool success = cmservice.DeleteContact(CurrentId);
                if (success)
                {
                    SuccessfullyDeleted(sender, e);
                }
            }

            return;
        }

        public void SuccessfullyDeleted(object sender, EventArgs e)
        {
            ContactDeleted?.Invoke(this, EventArgs.Empty);
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
