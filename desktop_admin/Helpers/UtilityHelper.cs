#region Using library
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Emgu.CV;
#endregion

namespace desktop_admin.Helpers
{
    class UtilityHelper
    {
        #region Declare variables
        static Random random = new Random();

        public static string _WebcamDontWorkingText = "ไม่สามารถใช้งาน Webcam, กรุณาตรวจสอบ";
        #endregion

        #region CreateRoundRectRgn
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        #endregion

        #region borderRounded
        public static void borderRounded(Control control, int borderRounded)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, borderRounded, borderRounded));
        }
        #endregion

        #region ConvertImageToBase64
        public static string ConvertImageToBase64(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Bmp);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        #endregion

        #region ConvertBase64ToImage
        public static Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                return Image.FromStream(memoryStream, true);
            }
        }
        #endregion

        #region GetRandomString
        public static string GetRandomString(int length)
        {
            const string chars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        #region TaskDelay
        public static void TaskDelay(int sec)
        {
            int sleepTime = sec * 1000;
            Task.Delay(sleepTime).Wait();
        }
        #endregion

        #region SetFontToAllControlsInControls
        public static void SetFontToAllControlsInControls(Control.ControlCollection ContrlColl, FontFamily font, Control controlExcept)
        {
            for (int i = 0; i < ContrlColl.Count; i++)
            {
                //Control Except
                if (ContrlColl[i] == controlExcept) { 
                    continue;
                }

                if (ContrlColl[i].GetType() != typeof(Label) 
                    || ContrlColl[i].GetType() != typeof(Button)
                    || ContrlColl[i].GetType() != typeof(MaskedTextBox)
                    || ContrlColl[i].GetType() != typeof(NumericUpDown)
                   )
                {
                    continue;
                }

                ContrlColl[i].Font = new Font(font, ContrlColl[i].Font.Size, ContrlColl[i].Font.Style);

                if (ContrlColl[i].Controls.Count > 0)
                {
                    //Self call function
                    SetFontToAllControlsInControls(ContrlColl[i].Controls, font, controlExcept);
                }
            }
        }
        #endregion

        #region SetFontColorToAllControlsInControls
        public static void SetFontColorToAllControlsInControls(Control.ControlCollection ContrlColl, string hexColorCode)
        {
            for (int i = 0; i < ContrlColl.Count; i++)
            {
                ContrlColl[i].ForeColor = ColorTranslator.FromHtml(hexColorCode);

                if (ContrlColl[i].Controls.Count > 0)
                {
                    //Self call function
                    SetFontColorToAllControlsInControls(ContrlColl[i].Controls, hexColorCode);
                }
            }
        }
        #endregion

        //#region WebCamCheck
        //public static bool WebCamCheck()
        //{
        //    bool ret = false;

        //    using (VideoCapture capture = new VideoCapture())
        //    {
        //        ret = (capture.IsOpened);

        //        capture.Pause();
        //        capture.Stop();
        //        capture.Dispose();
        //    }

        //    return ret;
        //}
        //#endregion

        #region GetDataFromAppSetting
        private List<string[]> GetAllDataFromAppSetting()
        {
            List<string[]> arrayList = new List<string[]>();
            string[] valueArray;

            foreach (string keyName in ConfigurationManager.AppSettings)
            {
                valueArray = new string[2];

                valueArray[0] = keyName;
                valueArray[1] = ConfigurationManager.AppSettings[keyName];

                arrayList.Add(valueArray);
            }

            return arrayList;
        }
        #endregion

        #region FileSizeFormatter
        public static string FileSizeFormatter(Int64 bytes)
        {
            string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }
        #endregion

        #region GetDateTimeFixedFormat
        public static string GetDateTimeFixedFormat()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        } 
        #endregion
    }
}
