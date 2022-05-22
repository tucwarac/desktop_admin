
namespace desktop_admin.UserControls
{
    partial class UcLeftSideBody
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelMenu1 = new System.Windows.Forms.Panel();
            this.labelMenu1 = new System.Windows.Forms.Label();
            this.pictureBoxMenu1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panelMenu1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(147, 424);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelMenu1
            // 
            this.panelMenu1.Controls.Add(this.labelMenu1);
            this.panelMenu1.Controls.Add(this.pictureBoxMenu1);
            this.panelMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu1.Location = new System.Drawing.Point(3, 3);
            this.panelMenu1.Name = "panelMenu1";
            this.panelMenu1.Padding = new System.Windows.Forms.Padding(3);
            this.panelMenu1.Size = new System.Drawing.Size(141, 39);
            this.panelMenu1.TabIndex = 0;
            // 
            // labelMenu1
            // 
            this.labelMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMenu1.Font = new System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelMenu1.Location = new System.Drawing.Point(43, 3);
            this.labelMenu1.Name = "labelMenu1";
            this.labelMenu1.Size = new System.Drawing.Size(95, 33);
            this.labelMenu1.TabIndex = 1;
            this.labelMenu1.Text = "Dashboard";
            this.labelMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxMenu1
            // 
            this.pictureBoxMenu1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxMenu1.Image = global::desktop_admin.Properties.Resources.chart_40px;
            this.pictureBoxMenu1.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMenu1.Name = "pictureBoxMenu1";
            this.pictureBoxMenu1.Size = new System.Drawing.Size(40, 33);
            this.pictureBoxMenu1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMenu1.TabIndex = 0;
            this.pictureBoxMenu1.TabStop = false;
            // 
            // UcLeftSideBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcLeftSideBody";
            this.Size = new System.Drawing.Size(147, 424);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelMenu1;
        private System.Windows.Forms.Label labelMenu1;
        private System.Windows.Forms.PictureBox pictureBoxMenu1;
    }
}
