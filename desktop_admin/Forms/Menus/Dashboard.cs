﻿using desktop_admin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_admin.Forms.Menus
{
    public partial class Dashboard : Form
    {
        #region Declare variables
        Main _main;
        #endregion

        #region Constructor
        public Dashboard(Main main)
        {
            InitializeComponent();

            try
            {
                _main = main;
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        } 
        #endregion

        #region StartContent
        public void StartContent()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _main.ExceptionHandle(ex.Message, true);
            }
        }
        #endregion
    }
}
