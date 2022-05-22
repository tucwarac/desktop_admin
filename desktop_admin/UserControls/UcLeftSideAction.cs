#region Using library
using System;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcLeftSideAction : UserControl
    {
        #region Declare variables
        Forms.Main _main;
        #endregion

        #region Constructor
        public UcLeftSideAction(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //events binding
                this.pictureBoxCollapse.MouseLeave += new EventHandler(this.pictureBoxCollapse_MouseLeave);
                this.pictureBoxCollapse.MouseHover += new EventHandler(this.pictureBoxCollapse_MouseHover);
                this.pictureBoxCollapse.MouseClick += new MouseEventHandler(this.pictureBoxCollapse_MouseClick);
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion

        #region pictureBoxCollapse_Mouse
        private void pictureBoxCollapse_MouseHover(object sender, EventArgs e)
        {
            this.pictureBoxCollapse.Image = Properties.Resources.menu_squared_50px_2;
        }
        private void pictureBoxCollapse_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxCollapse.Image = Properties.Resources.menu_squared_50px;
        }
        private void pictureBoxCollapse_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            _main.leftSideExpandCollapse();
        }
        #endregion
    }
}
