
using System;
using System.Windows.Forms;
using ChessEngine.Engine;

namespace Chess.Forms
{
    public partial class MainForm : Form
    {
        private TimeSpan blackTime;
        private DateTime turnTick;
        private TimeSpan whiteTime;
        public ChessPieceColor WhosMove;

     
        public MainForm()
        {
            InitializeComponent();          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            turnTick = DateTime.Now;
            blackTime = TimeSpan.Zero;
            whiteTime = TimeSpan.Zero;
            TurnTimer.Enabled = true;           
           
            Opacity = 1;            
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            chessBoard.Refresh();
        }

        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            if (WhosMove == ChessPieceColor.White)
            {
                whiteTime = whiteTime.Add(DateTime.Now - turnTick);
            }
            else if (WhosMove == ChessPieceColor.Black)
            {
                blackTime = blackTime.Add(DateTime.Now - turnTick);
            }

            //lblTotalTime.Text = "Total Time: " + (TotalTime.ToString()).Substring(0, 8);
            lblWhiteTime.Text = "White: " + (whiteTime.ToString()).Substring(0, 8);
            lblBlackTime.Text = "Black: " + (blackTime.ToString()).Substring(0, 8);

            turnTick = DateTime.Now;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void mnuAboutItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
            aboutForm.BringToFront();
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            chessBoard.NewGame();
            
            turnTick = DateTime.Now;
            blackTime = TimeSpan.Zero;
            whiteTime = TimeSpan.Zero;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chessBoard_TurnChanged(ChessPieceColor whosMove)
        {
            if (whosMove == ChessPieceColor.White)
            {
                //notifyIcon.Visible = false;
                lblTurn.Text = @"White's Turn";

                WhosMove = ChessPieceColor.White;
                notifyIcon.Text = @"White's Turn";
                notifyIcon.ShowBalloonTip(1000, @"White's Turn", @"White's Turn", ToolTipIcon.Info);

                notifyIcon.Visible = true;
            }
            if (whosMove == ChessPieceColor.Black)
            {
                //notifyIcon.Visible = false;
                lblTurn.Text = @"Black's Turn";

                WhosMove = ChessPieceColor.Black;
                notifyIcon.Text = @"Black's Turn";
                notifyIcon.ShowBalloonTip(1000, @"Black's Turn", @"Black's Turn", ToolTipIcon.Info);

                notifyIcon.Visible = true;
            }
        }

    }
}
