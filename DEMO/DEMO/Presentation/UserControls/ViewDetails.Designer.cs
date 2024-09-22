namespace DEMO
{
    partial class ViewDetails
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDetails));
            lbViewDetails = new Label();
            btnGoBack = new Button();
            gridViewDetails = new DataGridView();
            cbFamily = new CheckBox();
            cbFriend = new CheckBox();
            cbWork = new CheckBox();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)gridViewDetails).BeginInit();
            SuspendLayout();
            // 
            // lbViewDetails
            // 
            lbViewDetails.AutoSize = true;
            lbViewDetails.BackColor = Color.Transparent;
            lbViewDetails.Font = new Font("Arial", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbViewDetails.Location = new Point(27, 52);
            lbViewDetails.Name = "lbViewDetails";
            lbViewDetails.Size = new Size(175, 28);
            lbViewDetails.TabIndex = 0;
            lbViewDetails.Text = "Contact Details";
            lbViewDetails.Click += lbViewDetails_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGoBack.BackColor = Color.Salmon;
            btnGoBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoBack.FlatStyle = FlatStyle.Popup;
            btnGoBack.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            btnGoBack.ForeColor = SystemColors.ActiveCaptionText;
            btnGoBack.Location = new Point(671, 26);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(157, 82);
            btnGoBack.TabIndex = 1;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // gridViewDetails
            // 
            gridViewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridViewDetails.BackgroundColor = Color.LightCoral;
            gridViewDetails.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridViewDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridViewDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewDetails.ColumnHeadersVisible = false;
            gridViewDetails.GridColor = Color.LightCoral;
            gridViewDetails.Location = new Point(27, 132);
            gridViewDetails.Name = "gridViewDetails";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightCoral;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridViewDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridViewDetails.Size = new Size(801, 166);
            gridViewDetails.TabIndex = 2;
            gridViewDetails.CellValueChanged += gridViewDetails_CellValueChanged;
            gridViewDetails.Resize += gridViewDetails_Resize;
            // 
            // cbFamily
            // 
            cbFamily.Anchor = AnchorStyles.Bottom;
            cbFamily.AutoSize = true;
            cbFamily.BackColor = Color.Transparent;
            cbFamily.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic);
            cbFamily.Location = new Point(136, 328);
            cbFamily.Name = "cbFamily";
            cbFamily.Size = new Size(93, 27);
            cbFamily.TabIndex = 3;
            cbFamily.Text = "Family";
            cbFamily.UseVisualStyleBackColor = false;
            cbFamily.CheckedChanged += cbFamily_CheckedChanged;
            // 
            // cbFriend
            // 
            cbFriend.Anchor = AnchorStyles.Bottom;
            cbFriend.AutoSize = true;
            cbFriend.BackColor = Color.Transparent;
            cbFriend.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic);
            cbFriend.Location = new Point(388, 328);
            cbFriend.Name = "cbFriend";
            cbFriend.Size = new Size(90, 27);
            cbFriend.TabIndex = 4;
            cbFriend.Text = "Friend";
            cbFriend.UseVisualStyleBackColor = false;
            cbFriend.CheckedChanged += cbFriend_CheckedChanged;
            // 
            // cbWork
            // 
            cbWork.Anchor = AnchorStyles.Bottom;
            cbWork.AutoSize = true;
            cbWork.BackColor = Color.Transparent;
            cbWork.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic);
            cbWork.Location = new Point(640, 328);
            cbWork.Name = "cbWork";
            cbWork.Size = new Size(78, 27);
            cbWork.TabIndex = 5;
            cbWork.Text = "Work";
            cbWork.UseVisualStyleBackColor = false;
            cbWork.CheckedChanged += cbWork_CheckedChanged;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.BackColor = Color.Salmon;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Arial", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(198, 372);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(448, 40);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete Contact";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ViewDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnDelete);
            Controls.Add(cbWork);
            Controls.Add(cbFriend);
            Controls.Add(cbFamily);
            Controls.Add(gridViewDetails);
            Controls.Add(btnGoBack);
            Controls.Add(lbViewDetails);
            DoubleBuffered = true;
            Name = "ViewDetails";
            Size = new Size(854, 426);
            Load += ViewDetails_Load;
            ((System.ComponentModel.ISupportInitialize)gridViewDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbViewDetails;
        private Button btnGoBack;
        private DataGridView gridViewDetails;
        private CheckBox cbFamily;
        private CheckBox cbFriend;
        private CheckBox cbWork;
        private Button btnDelete;
    }
}
