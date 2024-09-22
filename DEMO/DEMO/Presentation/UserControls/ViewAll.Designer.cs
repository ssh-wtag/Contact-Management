using DEMO.Domain.Models;

namespace DEMO
{
    partial class ViewAll
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAll));
            gridViewAll = new DataGridView();
            contactBindingSource = new BindingSource(components);
            lbSearch = new Label();
            tbSearch = new TextBox();
            btnAddContact = new Button();
            ((System.ComponentModel.ISupportInitialize)gridViewAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contactBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gridViewAll
            // 
            gridViewAll.AllowUserToAddRows = false;
            gridViewAll.AllowUserToDeleteRows = false;
            gridViewAll.AllowUserToResizeColumns = false;
            gridViewAll.AllowUserToResizeRows = false;
            gridViewAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridViewAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewAll.BackgroundColor = Color.MistyRose;
            gridViewAll.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridViewAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridViewAll.DefaultCellStyle = dataGridViewCellStyle2;
            gridViewAll.EnableHeadersVisualStyles = false;
            gridViewAll.GridColor = SystemColors.ButtonFace;
            gridViewAll.Location = new Point(27, 132);
            gridViewAll.Name = "gridViewAll";
            gridViewAll.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridViewAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridViewAll.Size = new Size(801, 265);
            gridViewAll.TabIndex = 0;
            gridViewAll.CellValueChanged += gridViewAll_CellValueChanged;
            // 
            // contactBindingSource
            // 
            contactBindingSource.DataSource = typeof(Contact);
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.BackColor = Color.Transparent;
            lbSearch.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSearch.Location = new Point(27, 26);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(201, 29);
            lbSearch.TabIndex = 1;
            lbSearch.Text = "Search Contacts";
            lbSearch.Click += lbSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.MistyRose;
            tbSearch.Location = new Point(27, 68);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(497, 23);
            tbSearch.TabIndex = 2;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // btnAddContact
            // 
            btnAddContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddContact.BackColor = Color.Salmon;
            btnAddContact.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddContact.FlatStyle = FlatStyle.Popup;
            btnAddContact.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddContact.ForeColor = Color.Black;
            btnAddContact.Location = new Point(671, 26);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(157, 82);
            btnAddContact.TabIndex = 3;
            btnAddContact.Text = "New Contact";
            btnAddContact.UseVisualStyleBackColor = false;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // ViewAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnAddContact);
            Controls.Add(tbSearch);
            Controls.Add(lbSearch);
            Controls.Add(gridViewAll);
            DoubleBuffered = true;
            Name = "ViewAll";
            Size = new Size(854, 426);
            Load += ViewAll_Load;
            ((System.ComponentModel.ISupportInitialize)gridViewAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)contactBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridViewAll;
        private Label lbSearch;
        private TextBox tbSearch;
        private BindingSource contactBindingSource;
        private Button btnAddContact;
    }
}
