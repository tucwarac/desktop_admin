#region Using library
using desktop_admin.Helpers;
using desktop_admin.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcLeftSideBody : UserControl
    {
        #region Declare variables
        Forms.Main _main;

        //
        bool _isOnMenuChanging = false;
        int _menuClickedNumber;

        //
        //string _menuFontColor = "#4F4F4F";

        //
        List<MenuInfoModel> _menuInfoModelList = new List<MenuInfoModel>();
        #endregion

        #region Constructor
        public UcLeftSideBody(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //events binding
                SetActiveEventToPanelControlsType(this.Controls);

                //
                _menuInfoModelList = (List<MenuInfoModel>)_main.getMenuInfo();

                //
                setAllMenuCursor();

                ////
                //setAllMenuFontColor();
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
            setAllMenuControlBorderRounded();
        } 
        #endregion

        #region menu_MouseHover
        private void menu_MouseHover(object sender, EventArgs e)
        {
            try
            {
                iconActive(((Control)sender).Parent, true);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region menu_MouseLeave
        private void menu_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Control control = ((Control)sender).Parent;
                
                if (_menuClickedNumber == getMenuNumber(control)) { return; }

                iconActive(((Control)sender).Parent, false);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region menu_MouseClick
        private void menu_MouseClick(object sender, EventArgs e)
        {
            try
            {
                iconClick(((Control)sender).Parent);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region iconActive
        private void iconActive(Control control, bool value)
        {
            if (value)
            {
                control.BackColor = SystemColors.ControlLight;
                return;
            }

            control.BackColor = Color.Gainsboro;
        }
        #endregion

        #region SetActiveEventToPanelControlsType
        public void SetActiveEventToPanelControlsType(Control.ControlCollection ContrlColl)
        {
            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() == typeof(PictureBox) || ContrlColl[i].GetType() == typeof(Label))
                {
                    ContrlColl[i].MouseHover += new EventHandler(this.menu_MouseHover);
                    ContrlColl[i].MouseLeave += new EventHandler(this.menu_MouseLeave);
                    ContrlColl[i].MouseClick += new MouseEventHandler(this.menu_MouseClick);
                }

                if (ContrlColl[i].Controls.Count > 0)
                {
                    //Self call function
                    SetActiveEventToPanelControlsType(ContrlColl[i].Controls);
                }
            }
        }
        #endregion

        #region iconClick
        private void iconClick(Control control)
        {
            int menuNumber = getMenuNumber(control);

            if (_menuClickedNumber == menuNumber)
            {
                return;
            }

            if (_isOnMenuChanging) { return; }
            _isOnMenuChanging = true;

            //
            clearIconActive();

            iconActive(control, true);

            _menuClickedNumber = menuNumber;

            _main.changeMenuOnLeftSide(menuNumber);

            _isOnMenuChanging = false;
        }
        #endregion

        #region clearIconActive
        private void clearIconActive()
        {
            Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() == typeof(Panel))
                {
                    iconActive(ContrlColl[i], false);
                }
            }
        }
        #endregion

        #region setAllMenuControlBorderRounded
        private void setAllMenuControlBorderRounded()
        {
            Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() == typeof(Panel))
                {
                    UtilityHelper.borderRounded(ContrlColl[i], 10);
                }
            }
        } 
        #endregion

        #region getMenuNumber
        private int getMenuNumber(Control control)
        {
            var menuNumberStr = control.Name.Substring(control.Name.Length - 1, 1);
            int menuNumber = Convert.ToInt32(menuNumberStr);

            return menuNumber;
        }
        #endregion

        #region getControlFromMenuNumber
        private Control getControlFromMenuNumber(int menuNumber)
        {
            Control control = null;

            Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() != typeof(Panel))
                {
                    continue;
                }

                if (getMenuNumber(ContrlColl[i]) != menuNumber)
                {
                    continue;                    
                }

                control = ContrlColl[i];
            }

            return control;
        }
        #endregion

        #region setMenuActive
        public void setMenuActive(int menuNumber)
        {
            //Check before
            bool menuIsVisible = _menuInfoModelList.Where(x => x.id == menuNumber).Select(n => n.visible).FirstOrDefault();
            if (!menuIsVisible) {
                dynamic[] items = new dynamic[3];
                items[0] = false;
                items[1] = "Warning, The first menu number selected is visible false";
                _main.ModalPopup(items);
                return;
            }

            _menuClickedNumber = menuNumber;

            //Change
            _main.changeMenuOnLeftSide(menuNumber);

            Control control = getControlFromMenuNumber(menuNumber);

            if (control != null)
            {
                iconActive(control, true);
            }

            //_menuClickedNumber = menuNumber;
        }
        #endregion

        #region getActiveMenuName
        public string getActiveMenuName()
        {
            return getMenuNameFromMenuNumber(_menuClickedNumber);
        } 
        #endregion

        #region getMenuNameFromMenuNumber
        private string getMenuNameFromMenuNumber(int menuNumber)
        {
            string menuName = "";

            Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() != typeof(Panel))
                {
                    continue;
                }

                if (getMenuNumber(ContrlColl[i]) != menuNumber)
                {
                    continue;
                }

                for (int n = 0; n < ContrlColl[i].Controls.Count; n++)
                {
                    if (ContrlColl[i].Controls[n].GetType() != typeof(Label))
                    {
                        continue;
                    }

                    menuName = ContrlColl[i].Controls[n].Text;
                }
            }

            return menuName;
        }
        #endregion

        #region setAllMenuCursor
        private void setAllMenuCursor()
        {
            Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

            for (int i = 0; i < ContrlColl.Count; i++)
            {
                if (ContrlColl[i].GetType() != typeof(Panel))
                {
                    continue;
                }

                for (int n = 0; n < ContrlColl[i].Controls.Count; n++)
                {
                    if (ContrlColl[i].Controls[n].GetType() != typeof(PictureBox) && ContrlColl[i].Controls[n].GetType() != typeof(Label))
                    {
                        continue;
                    }

                    ContrlColl[i].Controls[n].Cursor = Cursors.Hand;
                }
            }
        }
        #endregion

        #region setMenuOnOff
        public void setMenuOnOff()
        {
            for (int i = 0; i < _menuInfoModelList.Count(); i++)
            {
                tableLayoutPanel1.RowStyles[i].Height = (!_menuInfoModelList[i].visible) ? 0 : tableLayoutPanel1.RowStyles[i].Height;
            }
        }
        #endregion

        //#region setAllMenuFontColor
        //private void setAllMenuFontColor()
        //{
        //    Control.ControlCollection ContrlColl = tableLayoutPanel1.Controls;

        //    for (int i = 0; i < ContrlColl.Count; i++)
        //    {
        //        if (ContrlColl[i].GetType() != typeof(Panel))
        //        {
        //            continue;
        //        }

        //        for (int n = 0; n < ContrlColl[i].Controls.Count; n++)
        //        {
        //            if (ContrlColl[i].Controls[n].GetType() != typeof(Label))
        //            {
        //                continue;
        //            }

        //            ContrlColl[i].Controls[n].ForeColor = ColorTranslator.FromHtml(_menuFontColor);
        //        }
        //    }
        //}
        //#endregion
    }
}
