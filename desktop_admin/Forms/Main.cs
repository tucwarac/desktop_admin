#region Using library
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using desktop_admin.Helpers;
using desktop_admin.Models;
#endregion

namespace desktop_admin.Forms
{
    public partial class Main : Form
    {
        #region minimize and maximize from taskbar
        //minimize and maximize from taskbar
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        //-------------------------------------------------------------------------------------- 
        #endregion

        #region Embed Font
        ////Embed Font----------------------------------------------------------------------------
        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        //    IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        //private PrivateFontCollection fonts = new PrivateFontCollection();

        //public FontFamily font;
        ////-------------------------------------------------------------------------------------- 
        #endregion

        #region Declare variables
        //
        Point MouseDownLocation;

        //
        //private LoginModel _loginModel;

        //
        private Size _screenSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        private bool _isMaximizeSize = false;

        //
        static Timer _timer_autoClose;
        const int _countdown = 1;
        static int _counting;
        static Popups.ModalBackground _modalBackground;
        static Popups.Modal _modal;

        //
        Menus.Dashboard _dashboard;
        //more menu

        //
        private UserControls.UcHeader _ucHeader;
        private UserControls.UcLeftSide _ucleftSide;
        private UserControls.UcFooter _ucFooter;

        //
        int _stepDivide = 4;
        int _formSizingStep;
        double _opacityStep;
        const int _formMinHeight = 35;

        //
        List<MenuInfoModel> _MenuInfoModel_List = new List<MenuInfoModel>();

        //
        string _allFontColor = "#333333";
        #endregion

        #region Constructor
        public Main()
        {
            InitializeComponent();

            try
            {
                ////Initial Font-------------------------------------------------------------------------
                //byte[] fontData = Properties.Resources.fontName;
                //IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                //Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                //uint dummy = 0;
                //fonts.AddMemoryFont(fontPtr, Properties.Resources.fontName.Length);
                //AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.fontName.Length, IntPtr.Zero, ref dummy);
                //Marshal.FreeCoTaskMem(fontPtr);

                //font = fonts.Families[0];
                ////--------------------------------------------------------------------------------------

                //events binding
                this.Shown += new EventHandler(this.Main_Shown);
                this.FormClosing += new FormClosingEventHandler(this.Main_FormClosing);

                //
                new SystemSettingModel().SetDefault_SystemSetting();

                //
                this.Text = SystemSettingModel.applicationName;
                this.Icon = Properties.Resources.appIcon;
                this.Opacity = 0;
                this.FormBorderStyle = FormBorderStyle.None;

                this.Size = (SystemSettingModel.applicationSize.Width > _screenSize.Width 
                    || SystemSettingModel.applicationSize.Height > _screenSize.Height) ? 
                    _screenSize : SystemSettingModel.applicationSize;

                this.StartPosition = FormStartPosition.CenterScreen;

                //Set the control border to rounded
                setThemeBorderRounded();

                //
                _formSizingStep = SystemSettingModel.applicationSize.Height / _stepDivide;
                _opacityStep = (1.0 / _stepDivide) / 2;

                //Header
                _ucHeader = new UserControls.UcHeader(this);
                _ucHeader.Dock = DockStyle.Fill;
                //Add Header
                panelHeader.Controls.Add(_ucHeader);

                //leftSide
                _ucleftSide = new UserControls.UcLeftSide(this);
                _ucleftSide.Dock = DockStyle.Fill;
                //Add leftSide
                panelLeftSide.Controls.Add(_ucleftSide);

                //Footer
                _ucFooter = new UserControls.UcFooter(this);
                _ucFooter.Dock = DockStyle.Fill;
                //Add Header
                panelFooter.Controls.Add(_ucFooter);

                //Set MoveEvent
                SetMoveEventToPanelControlsType(this.Controls, panelContent);

                //
                checkTheFormActionLeftRight();
            }
            catch (Exception ex)
            {
                ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region checkTheFormActionLeftRight
        private void checkTheFormActionLeftRight()
        {
            switch (SystemSettingModel.formActionLeftRight)
            {
                case 0: //left
                    areaOnOff_leftSide(true);
                    areaOnOff_header(false);
                    areaOnOff_footer(false);


                    break;

                case 1: //right
                    areaOnOff_leftSide(true);
                    areaOnOff_header(true);
                    areaOnOff_footer(false);

                    //
                    _ucHeader.setHeaderBgColor(Color.Transparent);
                    _ucHeader.setHeaderTitleVisible(false);
                    _ucHeader.headerAreaChanging(SizeType.Percent, 0, SizeType.Percent, 0, SizeType.Percent, 100);
                    break;
            }
        } 
        #endregion

        #region eventMouseDown
        public void eventMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            if (_isMaximizeSize) { return; }

            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.SizeAll;
                MouseDownLocation = e.Location;
            }
        }
        #endregion

        #region eventMouseMove
        public void eventMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            if (_isMaximizeSize) { Cursor = Cursors.Default; return; }

            if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region eventMouseDoubleClick
        public void eventMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            formMaximize();
        }
        #endregion

        #region formMinimize
        public void formMinimize()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region formMaximize
        public void formMaximize()
        {
            if (this.Size == _screenSize)
            {
                this.Size = SystemSettingModel.applicationSize;
                this.Left = (_screenSize.Width / 2) - (SystemSettingModel.applicationSize.Width / 2);
                this.Top = (_screenSize.Height / 2) - (SystemSettingModel.applicationSize.Height / 2);

                _isMaximizeSize = false;
            }
            else
            {
                this.Left = Top = 0;
                this.Size = _screenSize;

                _isMaximizeSize = true;
            }

            _ucHeader.setHeaderTitleLocationCenter();

            setThemeBorderRounded();
        }
        #endregion

        #region ExceptionHandle
        public void ExceptionHandle(string message, bool isExit)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => this.CenterToScreen()));
            }
            else
            {
                this.CenterToScreen();
            }

            MessageBox.Show(message);

            if (isExit)
                Application.Exit();
        }
        #endregion

        #region ShowDialogBox
        public bool ShowDialogBox(int typeId, List<string> textList, int sizeId)
        {
            this.CenterToScreen();

            _modalBackground = new Forms.Popups.ModalBackground(this);
            _modalBackground.Show();

            _modal = new Popups.Modal(this, typeId, textList, sizeId);

            if (typeId == 0)
            {
                _counting = 0;

                _timer_autoClose = new Timer();
                _timer_autoClose.Interval = 600;
                _timer_autoClose.Tick += new EventHandler(TimerTick_autoClose);
                _timer_autoClose.Start();

                _modal.ShowDialog();
                return true;
            }

            bool ret = false;
            if (_modal.ShowDialog() == DialogResult.OK)
            {
                ret = true;
            }

            _modal.Dispose();
            _modalBackground.Close();
            return ret;
        }
        #endregion

        #region TimerTick_autoClose
        private static void TimerTick_autoClose(object sender, EventArgs e)
        {
            if (_counting < _countdown)
            {
                _counting++;
                return;
            }
            _timer_autoClose.Stop();
            _modal.Dispose();
            _modalBackground.Close();
        }
        #endregion

        #region leftSideExpandCollapse
        public void leftSideExpandCollapse()
        {
            if (tableLayoutPanel_mainAll.ColumnStyles[0].Width != 0)
            {
                areaOnOff_leftSide(false);
                areaOnOff_header(true);

                //
                _ucHeader.headerAreaChanging(SizeType.Percent, 30, SizeType.Percent, 70, SizeType.Absolute, 100);
                _ucHeader.setHeaderBgColor(Color.Gainsboro);
                _ucHeader.setHeaderTitleVisible(true);
                _ucHeader.setHeaderTitleLocationCenter();
                _ucHeader.setLeftSideActionButtonVisible(true);
                _ucHeader.setFormActionButtonVisible(true);

                //
                string activeMenuName = _ucleftSide.getActiveMenuName();
                _ucHeader.setHeaderMenuNameText(activeMenuName);
            }
            else
            {
                areaOnOff_leftSide(true);
                areaOnOff_header(true);

                _ucHeader.headerAreaChanging(SizeType.Percent, 30, SizeType.Percent, 70, SizeType.Absolute, 100);
                _ucHeader.setHeaderBgColor(Color.Transparent);
                _ucHeader.setHeaderTitleVisible(false);
                _ucHeader.setLeftSideActionButtonVisible(false);

                string activeMenuName = _ucleftSide.getActiveMenuName();
                _ucHeader.setHeaderMenuNameText(activeMenuName);

                //
                switch (SystemSettingModel.formActionLeftRight)
                {
                    case 0: //left
                        _ucHeader.setFormActionButtonVisible(false);
                        break;

                    case 1: //right
                        _ucHeader.setFormActionButtonVisible(true);
                        break;
                }
            }

            //
            setThemeBorderRounded();
        }
        #endregion

        #region SetMoveEventToPanelControlsType
        public void SetMoveEventToPanelControlsType(Control.ControlCollection ContrlColl, Control controlExcept)
        {
            for (int i = 0; i < ContrlColl.Count; i++)
            {
                //Control Except
                if (ContrlColl[i] == controlExcept) { continue; }

                //do it
                if (ContrlColl[i].GetType() == typeof(TableLayoutPanel) || ContrlColl[i].GetType() == typeof(Panel))
                {
                    //remove
                    ContrlColl[i].MouseDown -= new MouseEventHandler(this.eventMouseDown);
                    ContrlColl[i].MouseMove -= new MouseEventHandler(this.eventMouseMove);
                    ContrlColl[i].MouseDoubleClick -= new MouseEventHandler(this.eventMouseDoubleClick);

                    //add
                    ContrlColl[i].MouseDown += new MouseEventHandler(this.eventMouseDown);
                    ContrlColl[i].MouseMove += new MouseEventHandler(this.eventMouseMove);
                    ContrlColl[i].MouseDoubleClick += new MouseEventHandler(this.eventMouseDoubleClick);
                }

                //find in sub control
                if (ContrlColl[i].Controls.Count > 0)
                {
                    //Self call function
                    SetMoveEventToPanelControlsType(ContrlColl[i].Controls, controlExcept);
                }
            }
        }
        #endregion

        #region Main_Shown
        private void Main_Shown(object sender, EventArgs e)
        {
            try
            {
                if (SystemSettingModel.animationOpening) 
                {
                    animationOpening();
                }
                else
                {
                    this.Opacity = 1;
                }

                //Create menu
                createContentForMenu();

                //Set Menu Visible and Set the first menu active
                setMenuVisible();
            }
            catch (Exception ex)
            {
                ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region Main_FormClosing
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (SystemSettingModel.animationClosing) 
                {
                    animationClosing();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandle(ex.Message, true);
            }
        }
        #endregion

        #region animationOpening
        private void animationOpening()
        {
            this.Size = new Size(0, _formMinHeight);

            this.Left = (_screenSize.Width / 2) - (SystemSettingModel.applicationSize.Width / 2);
            this.Top = (_screenSize.Height / 2) - (SystemSettingModel.applicationSize.Height / 2);

            do
            {
                this.Size = new Size(this.Size.Width + _formSizingStep, this.Size.Height);

                this.Opacity = this.Opacity + _opacityStep;

                if (this.Size.Width > SystemSettingModel.applicationSize.Width)
                {
                    this.Size = new Size(SystemSettingModel.applicationSize.Width, this.Size.Height);
                    break;
                }
            }
            while (this.Size.Width < SystemSettingModel.applicationSize.Width);

            do
            {
                this.Size = new Size(this.Size.Width, this.Size.Height + _formSizingStep);
                
                this.Opacity = this.Opacity + _opacityStep;

                if (this.Size.Height > SystemSettingModel.applicationSize.Height)
                {
                    this.Size = new Size(this.Size.Width, SystemSettingModel.applicationSize.Height);
                    break;
                }
            }
            while (this.Size.Height < SystemSettingModel.applicationSize.Height);

            this.Opacity = 1;
        }
        #endregion

        #region animationClosing
        public void animationClosing()
        {
            do
            {
                this.Size = new Size(this.Size.Width, this.Size.Height - _formSizingStep);

                this.Opacity = this.Opacity - _opacityStep;

                if (this.Size.Height < _formMinHeight)
                {
                    this.Size = new Size(this.Size.Width, _formMinHeight);
                    break;
                }
            }
            while (this.Size.Height > _formMinHeight);

            do
            {
                this.Size = new Size(this.Size.Width - _formSizingStep, this.Size.Height);

                this.Opacity = this.Opacity - _opacityStep;
            }
            while (this.Size.Width > _formSizingStep);

            this.Opacity = 0;
        }
        #endregion

        #region setThemeBorderRounded
        private void setThemeBorderRounded()
        {
            if (!SystemSettingModel.themeIsBorderRounded) { return; }

            UtilityHelper.borderRounded(this, SystemSettingModel.borderRoundedNumber);
            //UtilityHelper.borderRounded(panelLeftSide, _systemSettingModel.borderRoundedNumber);

            if (_ucleftSide != null)
            {
                _ucleftSide.setControlBorderRounded();
            }
        }
        #endregion

        #region createContentForMenu
        private void createContentForMenu()
        {
            //
            _dashboard = new Menus.Dashboard(this) { TopLevel = false };
            _dashboard.FormBorderStyle = FormBorderStyle.None;
            _dashboard.Dock = DockStyle.Fill;
            _dashboard.Show();
            _MenuInfoModel_List.Add(new MenuInfoModel() { 
                id=(_dashboard.Tag==null)?0: Convert.ToInt32(_dashboard.Tag), 
                name=_dashboard.Name, 
                text=_dashboard.Text, 
                visible=false 
            });

            //more menu
        }
        #endregion

        #region setMenuVisible
        private void setMenuVisible()
        {
            //
            _MenuInfoModel_List[0].visible = SystemSettingModel.menusVisible[1];
            //_MenuInfoModel_List[1].visible = SystemSettingModel.menusVisible[2];
            //_MenuInfoModel_List[2].visible = SystemSettingModel.menusVisible[3];

            //Set the first menu active
            _ucleftSide.setMenuActive(SystemSettingModel.menuNumberActive);

            //
            _ucleftSide.setMenuOnOff();
        } 
        #endregion

        #region changeMenuOnLeftSide
        public void changeMenuOnLeftSide(int menuNumber)
        {
            //clear first
            panelContent.Controls.Clear();

            switch (menuNumber)
            {
                case 1:
                    panelContent.Controls.Add(_dashboard);
                    _dashboard.StartContent();
                    break;

                //more menu
            }

            //------------------------------------------------------------
            areaOnOff_header(true);

            _ucHeader.headerAreaChanging(SizeType.Percent, 30, SizeType.Percent, 70, SizeType.Absolute, 100);
            _ucHeader.setHeaderBgColor(Color.Transparent);
            _ucHeader.setLeftSideActionButtonVisible(false);

            string activeMenuName = _ucleftSide.getActiveMenuName();
            _ucHeader.setHeaderMenuNameText(activeMenuName);

            switch (SystemSettingModel.formActionLeftRight)
            {
                case 0: //left
                    _ucHeader.setHeaderTitleVisible(false);
                    _ucHeader.setFormActionButtonVisible(false);
                    break;

                case 1: //right
                    
                    break;
            }
            //------------------------------------------------------------

            //Set MoveEvent
            SetMoveEventToPanelControlsType(panelContent.Controls, null);

            //Set Font
            //UtilityHelper.SetFontToAllControlsInControls(this.Controls, font, null);

            //Set Font Color
            UtilityHelper.SetFontColorToAllControlsInControls(this.Controls, _allFontColor);
        }
        #endregion

        #region setToCenterScreen
        public void setToCenterScreen()
        {
            this.CenterToScreen();
        }
        #endregion

        #region areaOnOff_leftSide
        private void areaOnOff_leftSide(bool value)
        {
            tableLayoutPanel_mainAll.ColumnStyles[0].SizeType = SizeType.Percent;
            tableLayoutPanel_mainAll.ColumnStyles[0].Width = (value) ? SystemSettingModel.percentOfMainLayoutLeftSide : 0;
        }
        #endregion

        #region areaOnOff_header
        private void areaOnOff_header(bool value)
        {
            tableLayoutPanel_mainRight.RowStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel_mainRight.RowStyles[0].Height = (value) ? SystemSettingModel.percentOfMainLayoutHeaderSide : 0;
        }
        #endregion

        #region areaOnOff_footer
        private void areaOnOff_footer(bool value)
        {
            tableLayoutPanel_mainRight.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel_mainRight.RowStyles[2].Height = (value) ? SystemSettingModel.percentOfMainLayoutFooterSide : 0;
        }
        #endregion

        #region getMenuInfo
        public object getMenuInfo()
        {
            return (object)_MenuInfoModel_List;
        } 
        #endregion

        #region ModalPopup
        public void ModalPopup(dynamic result)
        {
            string defualtErrorText = "Error in some functions on api";

            //if (((Array)result).Length > 2)
            //{
            //    int dialogBoxTypeId = 1;
            //    List<string> textList = new List<string>();
            //    textList.Add((result[1] != null) ? (string)result[1] : defualtErrorText);
            //    UtilityHelper.ShowDialogBox(this, dialogBoxTypeId, textList, 1);
            //}
            //else //"catch exception from api functions"
            //{
            //    ExceptionHandle((result[1] != null) ? (string)result[1] : defualtErrorText, false);
            //}

            ExceptionHandle((result[1] != null) ? (string)result[1] : defualtErrorText, false);
        }
        #endregion
    }
}
