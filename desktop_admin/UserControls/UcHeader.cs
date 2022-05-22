#region Using library
using desktop_admin.Helpers;
using desktop_admin.Models;
using System;
using System.Drawing;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcHeader : UserControl
    {
        #region Declare variables
        Forms.Main _main;
        Label _labelHeaderTitle;
        Label _labelHeaderMenuName;

        //
        UcFormAction _ucFormAction;
        UcLeftSideAction _ucLeftSideAction;
        #endregion

        #region Constructor
        public UcHeader(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //
                setHeaderBgColor(Color.Transparent);

                //
                _labelHeaderTitle = new Label();
                _labelHeaderTitle.AutoSize = true;
                _labelHeaderTitle.Location = new Point(5, 3);
                //_labelHeaderTitle.Font = new Font(_main.font, 12, FontStyle.Bold);
                _labelHeaderTitle.ForeColor = ColorTranslator.FromHtml("#4F4F4F");
                panelHeaderCenter.Controls.Add(_labelHeaderTitle);

                //
                _labelHeaderMenuName = new Label();
                _labelHeaderMenuName.AutoSize = false;
                _labelHeaderMenuName.TextAlign = ContentAlignment.MiddleLeft;
                _labelHeaderMenuName.Padding = new Padding(10, 3, 0, 0);
                //_labelHeaderMenuName.Font = new Font(_main.font, 12, FontStyle.Regular);
                _labelHeaderMenuName.ForeColor = ColorTranslator.FromHtml("#4F4F4F");
                _labelHeaderMenuName.Dock = DockStyle.Left;
                panelHeaderLeft.Controls.Add(_labelHeaderMenuName);

                //
                _ucFormAction = new UcFormAction(_main);
                _ucLeftSideAction = new UcLeftSideAction(_main);

                switch (SystemSettingModel.formActionLeftRight)
                {
                    case 0: //left
                        //
                        _ucLeftSideAction.Dock = DockStyle.Left;
                        panelHeaderLeft.Controls.Add(_ucLeftSideAction);
                        //
                        _ucFormAction.Dock = DockStyle.Left;
                        _ucFormAction.reOrdorIcon(2);
                        panelHeaderLeft.Controls.Add(_ucFormAction);
                        break;

                    case 1: //right
                        //
                        _ucFormAction.Dock = DockStyle.Right;
                        _ucFormAction.reOrdorIcon(1);
                        panelHeaderRight.Controls.Add(_ucFormAction);
                        //
                        _ucLeftSideAction.Dock = DockStyle.Left;
                        panelHeaderLeft.Controls.Add(_ucLeftSideAction);
                        break;
                }

                //
                setHeaderTitleText(SystemSettingModel.applicationName);
                setHeaderTitleVisible(true);
                setHeaderTitleLocationCenter();
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion

        #region setHeaderTitleVisible
        public void setHeaderTitleVisible(bool value)
        {
            _labelHeaderTitle.Visible = value;
        }
        #endregion

        #region setLeftSideActionButtonVisible
        public void setLeftSideActionButtonVisible(bool value)
        {
            _ucLeftSideAction.Visible = value;
        }
        #endregion

        #region setFormActionButtonVisible
        public void setFormActionButtonVisible(bool value)
        {
            _ucFormAction.Visible = value;
        }
        #endregion

        #region setHeaderTitleText
        public void setHeaderTitleText(string text)
        {
            _labelHeaderTitle.Text = text;
        }
        #endregion

        #region setHeaderTitleLocationCenter
        public void setHeaderTitleLocationCenter()
        {
            _labelHeaderTitle.Location = new Point(
                ((panelHeaderCenter.Size.Width / 2) + ((panelHeaderRight.Size.Width - panelHeaderLeft.Size.Width) / 2)) - (_labelHeaderTitle.Size.Width / 2)
                , _labelHeaderTitle.Location.Y);
        }
        #endregion

        #region setHeaderBgColor
        public void setHeaderBgColor(Color color)
        {
            this.BackColor = color;
        }
        #endregion

        #region setHeaderMenuName
        public void setHeaderMenuNameText(string menuName)
        {
            _labelHeaderMenuName.Text = menuName;
        }
        #endregion

        #region headerAreaChanging
        public void headerAreaChanging(SizeType sizeType1, int widthCol1, SizeType sizeType2, int widthCol2, SizeType sizeType3, int widthCol3)
        {
            tableLayoutPanel1.ColumnStyles[0].SizeType = sizeType1;
            tableLayoutPanel1.ColumnStyles[0].Width = widthCol1;

            tableLayoutPanel1.ColumnStyles[1].SizeType = sizeType2;
            tableLayoutPanel1.ColumnStyles[1].Width = widthCol2;

            tableLayoutPanel1.ColumnStyles[2].SizeType = sizeType3;
            tableLayoutPanel1.ColumnStyles[2].Width = widthCol3;
        } 
        #endregion
    }
}
