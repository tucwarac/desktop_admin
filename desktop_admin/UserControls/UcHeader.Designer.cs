
namespace desktop_admin.UserControls
{
    partial class UcHeader
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
            this.panelHeaderLeft = new System.Windows.Forms.Panel();
            this.panelHeaderCenter = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaderRight
            // 
            this.panelHeaderRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeaderRight.Location = new System.Drawing.Point(603, 3);
            this.panelHeaderRight.Name = "panelHeaderRight";
            this.panelHeaderRight.Size = new System.Drawing.Size(94, 24);
            this.panelHeaderRight.TabIndex = 2;
            // 
            // panelHeaderLeft
            // 
            this.panelHeaderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeaderLeft.Location = new System.Drawing.Point(3, 3);
            this.panelHeaderLeft.Name = "panelHeaderLeft";
            this.panelHeaderLeft.Size = new System.Drawing.Size(174, 24);
            this.panelHeaderLeft.TabIndex = 3;
            // 
            // panelHeaderCenter
            // 
            this.panelHeaderCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeaderCenter.Location = new System.Drawing.Point(183, 3);
            this.panelHeaderCenter.Name = "panelHeaderCenter";
            this.panelHeaderCenter.Size = new System.Drawing.Size(414, 24);
            this.panelHeaderCenter.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelHeaderCenter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelHeaderLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelHeaderRight, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 30);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // UcHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcHeader";
            this.Size = new System.Drawing.Size(700, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHeaderRight;
        private System.Windows.Forms.Panel panelHeaderLeft;
        private System.Windows.Forms.Panel panelHeaderCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
