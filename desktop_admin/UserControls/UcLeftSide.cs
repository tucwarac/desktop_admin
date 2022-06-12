#region Using library
using desktop_admin.Helpers;
using desktop_admin.Models;
using System;
using System.Drawing;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcLeftSide : UserControl
    {
        #region Declare variables
        Forms.Main _main;

        //
        UcLeftSideBody _ucLeftSideBody;
        #endregion

        #region Constructor
        public UcLeftSide(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //
                this.BackColor = Color.Gainsboro;

                UcFormAction ucFormAction = new UcFormAction(_main);
                UcLeftSideAction ucLeftSideAction = new UcLeftSideAction(_main);

                switch (SystemSettingModel.formActionLeftRight)
                {
                    case 0: //left
                        //UcFormAction
                        ucFormAction.Dock = DockStyle.Left;
                        ucFormAction.reOrdorIcon(2);
                        panelLeftSideTop.Controls.Add(ucFormAction);

                        //UcLeftSideAction
                        ucLeftSideAction.Dock = DockStyle.Right;
                        panelLeftSideTop.Controls.Add(ucLeftSideAction);
                        break;

                    case 1: //right
                        //UcFormAction
                        ucLeftSideAction.Dock = DockStyle.Right;
                        panelLeftSideTop.Controls.Add(ucLeftSideAction);
                        break;
                }

                //UcLeftSideTitle
                UcLeftSideTitle ucLeftSideTitle = new UcLeftSideTitle(_main);
                ucLeftSideTitle.Dock = DockStyle.Fill;
                panelLeftSideTitle.Controls.Add(ucLeftSideTitle);

                //UcLeftSideBody
                _ucLeftSideBody = new UcLeftSideBody(_main);
                _ucLeftSideBody.Dock = DockStyle.Fill;
                _ucLeftSideBody.setControlBorderRounded();
                panelLeftSideBody.Controls.Add(_ucLeftSideBody);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region setControlborderRounded
        public void setControlBorderRounded()
        {
            _ucLeftSideBody.setControlBorderRounded();
        }
        #endregion

        #region setMenuActive
        public void setMenuActive(int menuNumber)
        {
            _ucLeftSideBody.setMenuActive(menuNumber);
        }
        #endregion

        #region getActiveMenuName
        public string getActiveMenuName()
        {
            return _ucLeftSideBody.getActiveMenuName();
        }
        #endregion

        #region setMenuOnOff
        public void setMenuOnOff()
        {
            _ucLeftSideBody.setMenuOnOff();
        }
        #endregion

        #region GenerateMenus
        public void GenerateMenus()
        {
            _ucLeftSideBody.GenerateMenus();
        }
        #endregion
    }
}
