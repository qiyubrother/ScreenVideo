using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenVideo
{
    public delegate void RecordingScreenEventHandler(Panel p, RecordingScreenEventArgs e);
    public partial class VideoSourcePanel : Panel
    {

        private Control targetControl = null;
        public RecordingScreenEventHandler RecordingScreen;
        public VideoSourcePanel()
        {
            InitializeComponent();
        }

        public VideoSourcePanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 启动录屏
        /// </summary>
        /// <param name="handle"></param>
        public void BeginRecordVideo(Control ctl, int interval = 50)
        {
            targetControl = ctl;
            tmr.Interval = interval;
            tmr.Start();
            tmr.Enabled = true;
        }
        /// <summary>
        /// 停止录屏
        /// </summary>
        public void StopRecordVideo()
        {
            tmr.Stop();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (targetControl != null)
            {
                var width = Width;
                var height = Height;

                var bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(PointToScreen(new Point(0, 0)), new Point(0, 0), new Size(Width, Height));
                RecordingScreen?.Invoke(this, new RecordingScreenEventArgs { Image = bitmap });
                var gt = targetControl.CreateGraphics();
                gt.DrawImage(bitmap, new Point(0, 0));
            }
        }
    }

    public class RecordingScreenEventArgs : EventArgs
    {
        public Bitmap Image { get; set; }
    }
}
