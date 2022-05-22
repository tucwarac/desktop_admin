using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_admin.UserControls
{
    public partial class UcFooter : UserControl
    {
        #region Declare variables
        //
        Forms.Main _main;
        #endregion

        #region Constructor
        public UcFooter(Forms.Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;

                //
                this.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion
    }
}
