
namespace desktop_admin.UserControls
{
    partial class UcLeftSideAction
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
            this.panelBody = new System.Windows.Forms.Panel();
            this.pictureBoxCollapse = new System.Windows.Forms.PictureBox();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCollapse)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.pictureBoxCollapse);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(30, 30);
            this.panelBody.TabIndex = 4;
            // 
            // pictureBoxCollapse
            // 
            this.pictureBoxCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCollapse.Image = global::desktop_admin.Properties.Resources.menu_squared_50px;
            this.pictureBoxCollapse.Location = new System.Drawing.Point(5, 3);
            this.pictureBoxCollapse.Name = "pictureBoxCollapse";
            this.pictureBoxCollapse.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxCollapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCollapse.TabIndex = 4;
            this.pictureBoxCollapse.TabStop = false;
            // 
            // UcLeftSideAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBody);
            this.Name = "UcLeftSideAction";
            this.Size = new System.Drawing.Size(30, 30);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCollapse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.PictureBox pictureBoxCollapse;
    }
}
