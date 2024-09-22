namespace DEMO
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            viewAll1 = new ViewAll();
            viewDetails1 = new ViewDetails();
            addContact1 = new AddContact();
            SuspendLayout();
            // 
            // viewAll1
            // 
            viewAll1.BackgroundImage = (Image)resources.GetObject("viewAll1.BackgroundImage");
            viewAll1.BackgroundImageLayout = ImageLayout.Stretch;
            viewAll1.Dock = DockStyle.Fill;
            viewAll1.Location = new Point(0, 0);
            viewAll1.Name = "viewAll1";
            viewAll1.Size = new Size(972, 450);
            viewAll1.TabIndex = 0;
            // 
            // viewDetails1
            // 
            viewDetails1.BackgroundImage = (Image)resources.GetObject("viewDetails1.BackgroundImage");
            viewDetails1.BackgroundImageLayout = ImageLayout.Stretch;
            viewDetails1.Dock = DockStyle.Fill;
            viewDetails1.Location = new Point(0, 0);
            viewDetails1.Name = "viewDetails1";
            viewDetails1.Size = new Size(972, 450);
            viewDetails1.TabIndex = 1;
            // 
            // addContact1
            // 
            addContact1.BackgroundImageLayout = ImageLayout.Stretch;
            addContact1.Dock = DockStyle.Fill;
            addContact1.Location = new Point(0, 0);
            addContact1.Name = "addContact1";
            addContact1.Size = new Size(972, 450);
            addContact1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(972, 450);
            Controls.Add(viewAll1);
            Controls.Add(addContact1);
            Controls.Add(viewDetails1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Contact Manager";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ViewAll viewAll1;
        private ViewDetails viewDetails1;
        private AddContact addContact1;
    }
}
