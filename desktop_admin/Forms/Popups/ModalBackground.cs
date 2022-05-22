#region Using library
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms; 
#endregion

namespace desktop_admin.Forms.Popups
{
    public partial class ModalBackground : Form
    {
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

        #region Constructor
        public ModalBackground(Form main)
        {
            InitializeComponent();

            //
            this.StartPosition = main.StartPosition;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = main.Size;
            this.BackColor = Color.Black;
            this.Opacity = 0.5;
            this.Location = main.Location;
            this.Enabled = false;

            //CreateRoundRectRgn
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 260, 260));
        } 
        #endregion
    }
}
