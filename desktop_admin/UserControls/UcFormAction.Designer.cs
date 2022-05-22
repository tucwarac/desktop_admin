
namespace desktop_admin.UserControls
{
    partial class UcFormAction
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
            this.panelHeaderRight = new System.Windows.Forms.Panel();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxResizeApp = new System.Windows.Forms.PictureBox();
            this.pictureBoxCloseApp = new System.Windows.Forms.PictureBox();
            this.panelHeaderRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResizeApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseApp)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderRight
            // 
            this.panelHeaderRight.Controls.Add(this.pictureBoxMinimize);
            this.panelHeaderRight.Controls.Add(this.pictureBoxResizeApp);
            this.panelHeaderRight.Controls.Add(this.pictureBoxCloseApp);
            this.panelHeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeaderRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panelHeaderRight.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderRight.Name = "panelHeaderRight";
            this.panelHeaderRight.Size = new System.Drawing.Size(90, 30);
            this.panelHeaderRight.TabIndex = 3;
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = global::desktop_admin.Properties.Resources.minimize;
            this.pictureBoxMinimize.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 3;
            this.pictureBoxMinimize.TabStop = false;
            // 
            // pictureBoxResizeApp
            // 
            this.pictureBoxResizeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxResizeApp.Image = global::desktop_admin.Properties.Resources.maximize;
            this.pictureBoxResizeApp.Location = new System.Drawing.Point(34, 6);
            this.pictureBoxResizeApp.Name = "pictureBoxResizeApp";
            this.pictureBoxResizeApp.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxResizeApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResizeApp.TabIndex = 2;
            this.pictureBoxResizeApp.TabStop = false;
            // 
            // pictureBoxCloseApp
            // 
            this.pictureBoxCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCloseApp.Image = global::desktop_admin.Properties.Resources.close;
            this.pictureBoxCloseApp.Location = new System.Drawing.Point(62, 6);
            this.pictureBoxCloseApp.Name = "pictureBoxCloseApp";
            this.pictureBoxCloseApp.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxCloseApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCloseApp.TabIndex = 1;
            this.pictureBoxCloseApp.TabStop = false;
            // 
            // UcFormAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelHeaderRight);
            this.Name = "UcFormAction";
            this.Size = new System.Drawing.Size(90, 30);
            this.panelHeaderRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResizeApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderRight;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxResizeApp;
        private System.Windows.Forms.PictureBox pictureBoxCloseApp;
    }
}
