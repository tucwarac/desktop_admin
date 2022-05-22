#region Using library
using System;
using System.Drawing;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcFormAction : UserControl
    {
        #region Declare variables
        Forms.Main _main;
        //
        Point _position1 = new Point(6, 4);
        Point _position2 = new Point(34, 4);
        Point _position3 = new Point(62, 4);
        #endregion

        #region Constructor
        public UcFormAction(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //events binding
                this.pictureBoxMinimize.MouseLeave += new EventHandler(this.pictureBoxMinimize_MouseLeave);
                this.pictureBoxMinimize.MouseHover += new EventHandler(this.pictureBoxMinimize_MouseHover);
                this.pictureBoxMinimize.MouseClick += new MouseEventHandler(this.pictureBoxMinimize_MouseClick);
                //
                this.pictureBoxResizeApp.MouseLeave += new EventHandler(this.pictureBoxResizeApp_MouseLeave);
                this.pictureBoxResizeApp.MouseHover += new EventHandler(this.pictureBoxResizeApp_MouseHover);
                this.pictureBoxResizeApp.MouseClick += new MouseEventHandler(this.pictureBoxResizeApp_MouseClick);
                //
                this.pictureBoxCloseApp.MouseLeave += new EventHandler(this.pictureBoxCloseApp_MouseLeave);
                this.pictureBoxCloseApp.MouseHover += new EventHandler(this.pictureBoxCloseApp_MouseHover);
                this.pictureBoxCloseApp.MouseClick += new MouseEventHandler(this.pictureBoxCloseApp_MouseClick);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion

        #region pictureBoxMinimize_Mouse
        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e)
        {
            iconActive(true);
        }
        private void pictureBoxMinimize_MouseLeave(object sender, EventArgs e)
        {
            iconActive(false);
        }
        private void pictureBoxMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            _main.formMinimize();
        }
        #endregion

        #region pictureBoxResizeApp_Mouse
        private void pictureBoxResizeApp_MouseHover(object sender, EventArgs e)
        {
            iconActive(true);
        }
        private void pictureBoxResizeApp_MouseLeave(object sender, EventArgs e)
        {
            iconActive(false);
        }
        private void pictureBoxResizeApp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            _main.formMaximize();
        }
        #endregion

        #region pictureBoxCloseApp_Mouse
        private void pictureBoxCloseApp_MouseHover(object sender, EventArgs e)
        {
            iconActive(true);
        }
        private void pictureBoxCloseApp_MouseLeave(object sender, EventArgs e)
        {
            iconActive(false);
        }
        private void pictureBoxCloseApp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            Application.Exit();
        }
        #endregion

        #region iconActive
        private void iconActive(bool value)
        {
            if (value)
            {
                this.pictureBoxMinimize.Image = Properties.Resources.minimize_2;
                this.pictureBoxResizeApp.Image = Properties.Resources.maximize_2;
                this.pictureBoxCloseApp.Image = Properties.Resources.close_2;
                return;
            }

            this.pictureBoxMinimize.Image = Properties.Resources.minimize;
            this.pictureBoxResizeApp.Image = Properties.Resources.maximize;
            this.pictureBoxCloseApp.Image = Properties.Resources.close;
        } 
        #endregion

        #region reOrdorIcon
        public void reOrdorIcon(int type)
        {
            switch (type)
            {
                case 1:
                    pictureBoxMinimize.Location = _position1;
                    pictureBoxResizeApp.Location = _position2;
                    pictureBoxCloseApp.Location = _position3;
                    break;
                case 2:
                    pictureBoxMinimize.Location = _position2;
                    pictureBoxResizeApp.Location = _position3;
                    pictureBoxCloseApp.Location = _position1;
                    break;
                default:
                    break;
            }
        } 
        #endregion
    }
}
