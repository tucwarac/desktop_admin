
namespace desktop_admin.Forms
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_mainAll = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeftSide = new System.Windows.Forms.Panel();
            this.panelRightSide = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_mainRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_mainAll.SuspendLayout();
            this.panelRightSide.SuspendLayout();
            this.tableLayoutPanel_mainRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_mainAll
            // 
            this.tableLayoutPanel_mainAll.ColumnCount = 2;
            this.tableLayoutPanel_mainAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel_mainAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel_mainAll.Controls.Add(this.panelLeftSide, 0, 0);
            this.tableLayoutPanel_mainAll.Controls.Add(this.panelRightSide, 1, 0);
            this.tableLayoutPanel_mainAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_mainAll.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_mainAll.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_mainAll.Name = "tableLayoutPanel_mainAll";
            this.tableLayoutPanel_mainAll.RowCount = 1;
            this.tableLayoutPanel_mainAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_mainAll.Size = new System.Drawing.Size(1024, 600);
            this.tableLayoutPanel_mainAll.TabIndex = 0;
            // 
            // panelLeftSide
            // 
            this.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftSide.Location = new System.Drawing.Point(0, 0);
            this.panelLeftSide.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeftSide.Name = "panelLeftSide";
            this.panelLeftSide.Size = new System.Drawing.Size(153, 600);
            this.panelLeftSide.TabIndex = 0;
            // 
            // panelRightSide
            // 
            this.panelRightSide.Controls.Add(this.tableLayoutPanel_mainRight);
            this.panelRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightSide.Location = new System.Drawing.Point(153, 0);
            this.panelRightSide.Margin = new System.Windows.Forms.Padding(0);
            this.panelRightSide.Name = "panelRightSide";
            this.panelRightSide.Size = new System.Drawing.Size(871, 600);
            this.panelRightSide.TabIndex = 1;
            // 
            // tableLayoutPanel_mainRight
            // 
            this.tableLayoutPanel_mainRight.ColumnCount = 1;
            this.tableLayoutPanel_mainRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_mainRight.Controls.Add(this.panelHeader, 0, 0);
            this.tableLayoutPanel_mainRight.Controls.Add(this.panelContent, 0, 1);
            this.tableLayoutPanel_mainRight.Controls.Add(this.panelFooter, 0, 2);
            this.tableLayoutPanel_mainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_mainRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_mainRight.Name = "tableLayoutPanel_mainRight";
            this.tableLayoutPanel_mainRight.RowCount = 3;
            this.tableLayoutPanel_mainRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_mainRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_mainRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_mainRight.Size = new System.Drawing.Size(871, 600);
            this.tableLayoutPanel_mainRight.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(871, 30);
            this.panelHeader.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 30);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(871, 550);
            this.panelContent.TabIndex = 1;
            // 
            // panelFooter
            // 
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooter.Location = new System.Drawing.Point(0, 580);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(871, 20);
            this.panelFooter.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.tableLayoutPanel_mainAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.tableLayoutPanel_mainAll.ResumeLayout(false);
            this.panelRightSide.ResumeLayout(false);
            this.tableLayoutPanel_mainRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_mainAll;
        private System.Windows.Forms.Panel panelLeftSide;
        private System.Windows.Forms.Panel panelRightSide;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_mainRight;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFooter;
    }
}