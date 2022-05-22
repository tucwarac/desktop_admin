#region Using library
using desktop_admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.UserControls
{
    public partial class UcLeftSideTitle : UserControl
    {
        #region Declare variables
        Forms.Main _main;
        #endregion

        #region Constructor
        public UcLeftSideTitle(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                labelAppname.Text = SystemSettingModel.applicationName;
                labelAppname.ForeColor = ColorTranslator.FromHtml("#4F4F4F");
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion
    }
}
