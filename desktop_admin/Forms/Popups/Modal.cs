#region Using library
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using desktop_admin.Helpers; 
#endregion

namespace desktop_admin.Forms.Popups
{
    public partial class Modal : Form
    {
        #region Declare variables
        Main _main;
        #endregion

        #region Constructor
        public Modal(Main main, int typeId, List<string> textList, int sizeId)
        {
            InitializeComponent();

            try
            {
                _main = main;

                this.StartPosition = _main.StartPosition;
                //this.Icon = Properties.Resources.appIcon;

                //Events binding
                this.buttonOK.Click += new EventHandler(this.ButtonOK_Click);
                this.buttonCancel.Click += new EventHandler(this.ButtonCancel_Click);

                //Set Font
                //UtilityHelper.SetFontToAllControlsInControls(this.Controls, _main.font, null);

                //Set Position
                SetPositionByCotrols(sizeId, textList, typeId);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region SetPositionByCotrols
        private void SetPositionByCotrols(int sizeId, List<string> textList, int typeId)
        {
            //sizing by passed size id and set controls
            switch (sizeId)
            {
                case 1: //small
                    this.Size = new Size(_main.Size.Width - 624, _main.Size.Height - 570);

                    panel_richTextBox.Dock = DockStyle.None;
                    panel_richTextBox.Visible = false;

                    if (textList.Count == 1)
                    {
                        labelLine1.Text = textList[0];
                        labelLine1.Visible = true;
                        
                        labelLine1.Location = new Point((panel1.Size.Width / 2) - (labelLine1.Size.Width / 2), (panel1.Size.Height / 2) - (labelLine1.Size.Height / 2));
                    }
                    else if (textList.Count == 2)
                    {
                        labelLine1.Text = textList[0];
                        labelLine2.Text = textList[1];

                        labelLine1.Visible = true;
                        labelLine2.Visible = true;

                        int lineDitance = 10;
                        labelLine1.Location = new Point((panel1.Size.Width / 2) - (labelLine1.Size.Width / 2), (panel1.Size.Height / 2) - labelLine1.Size.Height);
                        labelLine2.Location = new Point((panel1.Size.Width / 2) - (labelLine2.Size.Width / 2), (panel1.Size.Height / 2) + lineDitance);
                    }
                    break;

                case 2: //large
                    this.Size = new Size(_main.Size.Width - 300, _main.Size.Height - 230);

                    panel_richTextBox.Dock = DockStyle.Fill;
                    panel_richTextBox.Visible = true;

                    Font fontBold = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);

                    for (int i = 0; i < textList.Count; i++)
                    {
                        if (i != textList.Count - 1)
                        {
                            richTextBox1.AppendText(textList[i] + "\r\n");
                        }
                        else
                        {
                            richTextBox1.AppendText(textList[i]);
                        }
                    }

                    //Modify richTextBox style
                    Font font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);
                    ChangeColorForSpecialWord(richTextBox1, "Version", Color.Green, font);
                    ChangeColorForSpecialWord(richTextBox1, "(latest)", Color.Red, richTextBox1.Font);

                    //
                    richTextBox1.Select(0, 0);
                    break;
            }

            //location of action button
            if (typeId == 0)
            {
                buttonCancel.Visible = false;
                buttonOK.Visible = false;
            }
            else if (typeId == 1)
            {
                buttonCancel.Visible = false;
                buttonOK.Location = new Point((panel2.Size.Width / 2) - (buttonOK.Size.Width / 2));
            }
            else if (typeId == 2)
            {
                int lineDitance = 20;
                buttonOK.Location = new Point(((panel2.Size.Width / 2) - buttonOK.Width) - (lineDitance / 2), buttonOK.Location.Y);
                buttonCancel.Location = new Point((panel2.Size.Width / 2) + (lineDitance / 2), buttonCancel.Location.Y);
            }
            else if (typeId == 3)
            {
                buttonOK.Visible = false;
                buttonCancel.Location = new Point((panel2.Size.Width / 2) - (buttonCancel.Size.Width / 2));
                buttonCancel.Text = "Close";
            }
        }
        #endregion

        #region ButtonOK_Click
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion

        #region ButtonCancel_Click
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region ChangeColorForSpecialWord
        private void ChangeColorForSpecialWord(RichTextBox richTextBox, string specialWord, Color color, Font font)
        {
            if (string.IsNullOrEmpty(specialWord))
                return;

            int pos = 0;
            do
            {
                // Find the index of a specified word
                pos = richTextBox.Find(specialWord, pos, RichTextBoxFinds.None);

                if (pos < 0) { break; }

                richTextBox.Select(pos, specialWord.Length);
                richTextBox.SelectionColor = color;
                richTextBox.SelectionFont = font;

                pos = pos + specialWord.Length;

            } while (pos < richTextBox.Text.Length);
        } 
        #endregion
    }
}
