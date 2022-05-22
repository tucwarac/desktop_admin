#region Using library
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace desktop_admin.Models
{
    public class SystemSettingModel
    {
        #region Declare variable
        public static string applicationName { set; get; }
        public static Size applicationSize { set; get; }

        public static int borderRoundedNumber { set; get; }

        //
        public static bool themeIsBorderRounded { set; get; }
        public static bool animationOpening { set; get; }
        public static bool animationClosing { set; get; }
        public static int formActionLeftRight { set; get; }
        public static int percentOfMainLayoutLeftSide { set; get; }
        public static int percentOfMainLayoutHeaderSide { set; get; }
        public static int percentOfMainLayoutFooterSide { set; get; }

        //
        public static Dictionary<int, bool> menusVisible = new Dictionary<int, bool>();
        public static int menuNumberActive { set; get; }

        //
        public static int httpRestApi_timeout { set; get; }
        public static Dictionary<int, string> responseStatus = new Dictionary<int, string>();
        #endregion

        #region SetDefault_SystemSetting
        public void SetDefault_SystemSetting()
        {
            //
            applicationName = "Desktop admin";
            applicationSize = new Size(1024, 600);
            borderRoundedNumber = 20;

            //
            themeIsBorderRounded = (ConfigurationManager.AppSettings.Get("themeBorderRounded") == "0") ? false : true;
            animationOpening = (ConfigurationManager.AppSettings.Get("animationOpening") == "0") ? false : true;
            animationClosing = (ConfigurationManager.AppSettings.Get("animationClosing") == "0") ? false : true;
            formActionLeftRight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("formActionLeftRight"));

            //
            percentOfMainLayoutLeftSide = 15;
            percentOfMainLayoutHeaderSide = 30;
            percentOfMainLayoutFooterSide = 20;

            //
            menusVisible.Add(1, true);
            //menusVisible.Add(2, false);
            //menusVisible.Add(3, false);
            menuNumberActive = 1;

            //
            httpRestApi_timeout = 60000; //60 sec
            responseStatus.Add(1, "error");
            responseStatus.Add(2, "success");
        } 
        #endregion
    }
}
