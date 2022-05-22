
namespace desktop_admin.UserControls
{
    partial class UcLeftSide
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
            this.panelLeftSideFooter = new System.Windows.Forms.Panel();
            this.panelLeftSideTop = new System.Windows.Forms.Panel();
            this.panelLeftSideTitle = new System.Windows.Forms.Panel();
            this.panelLeftSideBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panelLeftSideFooter, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelLeftSideTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelLeftSideTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelLeftSideBody, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(153, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelLeftSideFooter
            // 
            this.panelLeftSideFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftSideFooter.Location = new System.Drawing.Point(3, 543);
            this.panelLeftSideFooter.Name = "panelLeftSideFooter";
            this.panelLeftSideFooter.Size = new System.Drawing.Size(147, 54);
            this.panelLeftSideFooter.TabIndex = 3;
            // 
            // panelLeftSideTop
            // 
            this.panelLeftSideTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftSideTop.Location = new System.Drawing.Point(3, 3);
            this.panelLeftSideTop.Name = "panelLeftSideTop";
            this.panelLeftSideTop.Size = new System.Drawing.Size(147, 24);
            this.panelLeftSideTop.TabIndex = 4;
            // 
            // panelLeftSideTitle
            // 
            this.panelLeftSideTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftSideTitle.Location = new System.Drawing.Point(3, 33);
            this.panelLeftSideTitle.Name = "panelLeftSideTitle";
            this.panelLeftSideTitle.Size = new System.Drawing.Size(147, 74);
            this.panelLeftSideTitle.TabIndex = 5;
            // 
            // panelLeftSideBody
            // 
            this.panelLeftSideBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftSideBody.Location = new System.Drawing.Point(3, 113);
            this.panelLeftSideBody.Name = "panelLeftSideBody";
            this.panelLeftSideBody.Size = new System.Drawing.Size(147, 424);
            this.panelLeftSideBody.TabIndex = 6;
            // 
            // UcLeftSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcLeftSide";
            this.Size = new System.Drawing.Size(153, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelLeftSideFooter;
        private System.Windows.Forms.Panel panelLeftSideTop;
        private System.Windows.Forms.Panel panelLeftSideTitle;
        private System.Windows.Forms.Panel panelLeftSideBody;
    }
}
