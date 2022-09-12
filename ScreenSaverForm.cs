using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        private Point mouseLocation;
        private Random rand = new Random();
        private bool previewMode = true;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);


        public ScreenSaverForm()
        {
            InitializeComponent();

            this.Load += (s, e) => {
                Cursor.Hide();
                TopMost = true;

                // Use the string from the Registry if it exists
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MyScreenSaver");

                if (key == null)
                    textLabel.Text = DateTime.Now.ToLongTimeString();
                else
                    textLabel.Text = (string)key.GetValue("text");

                moveTimer.Interval = 2000;
                moveTimer.Tick += new EventHandler(moveTimer_Tick);

                moveTimer.Start();
            };

            this.MouseMove += (s, e) => {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance. (5 px)
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }
                // Update current mouse location.
                mouseLocation = e.Location;

                if (previewMode == false)
                    Application.Exit();
            };

            this.MouseClick += (s, e) => AppExit();

            this.KeyPress += (s, e) => AppExit();
        }

        void AppExit()
        {
            Application.Exit();

            if (previewMode == false)
                Application.Exit();
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle):this()
        {
            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            // Make text smaller
            textLabel.Font = new System.Drawing.Font("Arial", 6);
            //pictureJack.Image.Width
            //panelJack.Width = Size.Width / 6;

            previewMode = true;
        }

        public ScreenSaverForm(Rectangle Bounds) : this()
        {
            this.Bounds = Bounds;
        }

        private void moveTimer_Tick(object sender, System.EventArgs e)
        {
            textLabel.Text = DateTime.Now.ToLongTimeString();

            // Move picture to new location
            panelJack.Left = rand.Next(Math.Max(1, Bounds.Width - panelJack.Width));
            panelJack.Top = rand.Next(Math.Max(1, Bounds.Height - panelJack.Height));

            // Move text to new location
            //textLabel.Left = pictureJack.Left + ((pictureJack.Width / 2) - (pictureJack.Width / 2)); 
            //textLabel.Top = pictureJack.Top + pictureJack.Height; 
            //textLabel.Visible = true;
        }

    }
}
