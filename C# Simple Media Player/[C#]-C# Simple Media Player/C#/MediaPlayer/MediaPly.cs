using System;
using System.Collections.Generic;
using System.Text;
using QuartzTypeLib;
using System.Windows.Forms;

namespace MediaPlayer
{
    
    class MediaPly
    {
        internal const int
  WS_CHILD = 0x40000000,
  WS_VISIBLE = 0x10000000,
  LBS_NOTIFY = 0x00000001,
  HOST_ID = 0x00000002,
  LISTBOX_ID = 0x00000001,
  WS_VSCROLL = 0x00200000,
  WS_BORDER = 0x00800000;

        private FilgraphManagerClass graphManager = new QuartzTypeLib.FilgraphManagerClass();
        private IMediaControl mControl;
        private IMediaPosition mPosition;
        private IVideoWindow mWindow;
        public MediaPly()
        {
        }
        public bool LoadFile(string sfile, Panel parentHandler)
        {
            graphManager.RenderFile(sfile);
            mControl = graphManager;
            mPosition = graphManager;
            mWindow = graphManager;
            mWindow.Owner = parentHandler.Handle.ToInt32();
            mWindow.WindowStyle = WS_CHILD;
            mWindow.SetWindowPosition(parentHandler.ClientRectangle.Left,
                parentHandler.ClientRectangle.Top,
                parentHandler.ClientRectangle.Width,
                parentHandler.ClientRectangle.Height);
            graphManager.Run();
            return true;
        }
    }
}