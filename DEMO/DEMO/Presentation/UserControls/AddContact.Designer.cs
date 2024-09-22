namespace DEMO
{
    partial class AddContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddContact));
            lbAddContact = new Label();
            tbName = new TextBox();
            tbNumber = new TextBox();
            tbEmail = new TextBox();
            tbAddress = new TextBox();
            cbGroup = new CheckedListBox();
            lbGroup = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSaveContact = new Button();
            btnGoBack = new Button();
            SuspendLayout();
            // 
            // lbAddContact
            // 
            lbAddContact.Anchor = AnchorStyles.Top;
            lbAddContact.AutoSize = true;
            lbAddContact.BackColor = Color.Transparent;
            lbAddContact.Font = new Font("Arial", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbAddContact.Location = new Point(331, 35);
            lbAddContact.Name = "lbAddContact";
            lbAddContact.Size = new Size(193, 37);
            lbAddContact.TabIndex = 0;
            lbAddContact.Text = "Add Contact";
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Left;
            tbName.Location = new Point(149, 135);
            tbName.Name = "tbName";
            tbName.Size = new Size(500, 23);
            tbName.TabIndex = 1;
            // 
            // tbNumber
            // 
            tbNumber.Anchor = AnchorStyles.Left;
            tbNumber.Location = new Point(149, 187);
            tbNumber.Name = "tbNumber";
            tbNumber.Size = new Size(500, 23);
            tbNumber.TabIndex = 2;
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.Left;
            tbEmail.Location = new Point(149, 239);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(500, 23);
            tbEmail.TabIndex = 3;
            // 
            // tbAddress
            // 
            tbAddress.Anchor = AnchorStyles.Left;
            tbAddress.Location = new Point(149, 291);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(500, 23);
            tbAddress.TabIndex = 4;
            // 
            // cbGroup
            // 
            cbGroup.Anchor = AnchorStyles.Right;
            cbGroup.BackColor = Color.MistyRose;
            cbGroup.BorderStyle = BorderStyle.None;
            cbGroup.Font = new Font("Arial", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            cbGroup.FormattingEnabled = true;
            cbGroup.Items.AddRange(new object[] { "Family", "Friend", "Work" });
            cbGroup.Location = new Point(710, 202);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(106, 81);
            cbGroup.TabIndex = 5;
            // 
            // lbGroup
            // 
            lbGroup.Anchor = AnchorStyles.Right;
            lbGroup.AutoSize = true;
            lbGroup.BackColor = Color.Transparent;
            lbGroup.Font = new Font("Arial", 21.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lbGroup.Location = new Point(710, 147);
            lbGroup.Name = "lbGroup";
            lbGroup.Size = new Size(103, 34);
            lbGroup.TabIndex = 6;
            lbGroup.Text = "Group";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 133);
            label1.Name = "label1";
            label1.Size = new Size(82, 27);
            label1.TabIndex = 7;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 185);
            label2.Name = "label2";
            label2.Size = new Size(105, 27);
            label2.TabIndex = 8;
            label2.Text = "Number:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(64, 237);
            label3.Name = "label3";
            label3.Size = new Size(79, 27);
            label3.TabIndex = 9;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(36, 289);
            label4.Name = "label4";
            label4.Size = new Size(107, 27);
            label4.TabIndex = 10;
            label4.Text = "Address:";
            // 
            // btnSaveContact
            // 
            btnSaveContact.Anchor = AnchorStyles.Bottom;
            btnSaveContact.BackColor = Color.Salmon;
            btnSaveContact.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveContact.FlatStyle = FlatStyle.Popup;
            btnSaveContact.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            btnSaveContact.ForeColor = SystemColors.ActiveCaptionText;
            btnSaveContact.Location = new Point(352, 349);
            btnSaveContact.Name = "btnSaveContact";
            btnSaveContact.Size = new Size(142, 63);
            btnSaveContact.TabIndex = 11;
            btnSaveContact.Text = "Save Contact";
            btnSaveContact.UseVisualStyleBackColor = false;
            btnSaveContact.Click += btnSaveContact_Click;
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
            btnGoBack.TabIndex = 12;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // AddContact
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnGoBack);
            Controls.Add(btnSaveContact);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbGroup);
            Controls.Add(cbGroup);
            Controls.Add(tbAddress);
            Controls.Add(tbEmail);
            Controls.Add(tbNumber);
            Controls.Add(tbName);
            Controls.Add(lbAddContact);
            DoubleBuffered = true;
            Name = "AddContact";
            Size = new Size(854, 426);
            Load += AddContact_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbAddContact;
        private TextBox tbName;
        private TextBox tbNumber;
        private TextBox tbEmail;
        private TextBox tbAddress;
        private CheckedListBox cbGroup;
        private Label lbGroup;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSaveContact;
        private Button btnGoBack;
    }
}
