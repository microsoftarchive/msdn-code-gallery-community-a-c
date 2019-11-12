using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Chess.Properties;
using Chess.Source;
using ChessEngine.Engine;

namespace Chess.Components
{
    public partial class ChessBoard : UserControl
    {
        #region Internal

        #region Nested type: Selection

        internal class Selection
        {
            public byte Column;
            public byte Row;
            public bool Selected;
        }

        #endregion

        

        #endregion

        #region Enumerators

        #region Column enum

        public enum Column
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            Unknown
        }

        #endregion

        #region DisplayChessPieceType enum

        public enum DisplayChessPieceType
        {
            ClassicHiRes,
            Classic,
            EnchancedClassic
        }

        #endregion

        #endregion

        #region Delegates

        public delegate void TurnChangedHandler(ChessPieceColor whosMove);

        #endregion

        #region PrivateMembers

        private Selection currentDestination;
        private Selection currentSource;

        private Engine engine;
        private int boxHeight;
        private int maxHeight;
        #endregion

        #region PublicMembers

        public event TurnChangedHandler TurnChanged;
       
       
        #endregion

        #region Constructors

        public ChessBoard()
        {
            InitializeComponent();

            NewGame();           
        }

        public void NewGame()
        {
            //ChessEngine 
            engine = new Engine();
      
            currentSource = new Selection();
            currentDestination = new Selection();

            if (engine.HumanPlayer != engine.WhoseMove)
            {
                EngineMove();
            }

            Refresh(); 

        }

        #endregion

        #region PublicMethods

        private void EngineMove()
        {
            
            if (engine.GetPieceTypeAt(currentSource.Column, currentSource.Row) == ChessPieceType.None)
            {
                currentDestination.Selected = false;
                currentSource.Selected = false;
                return;
            }

            //Check if this is infact a valid move

            bool valid = engine.IsValidMove(currentSource.Column, currentSource.Row, currentDestination.Column, currentDestination.Row);

            if (valid == false)
            {
                currentDestination.Selected = false;
                currentSource.Selected = false;
                return;
            }

            engine.MovePiece(currentSource.Column, currentSource.Row, currentDestination.Column, currentDestination.Row);

            if (TurnChanged != null)
            {
                TurnChanged(engine.WhoseMove);
            }

            //Clear Source for next Selection             
            currentSource.Selected = false;

            Refresh();
        }

        public static Column GetColumnFromInt(int column)
        {
            Column retColumnt;

            switch (column)
            {
                case 1:
                    retColumnt = Column.A;
                    break;
                case 2:
                    retColumnt = Column.B;
                    break;
                case 3:
                    retColumnt = Column.C;
                    break;
                case 4:
                    retColumnt = Column.D;
                    break;
                case 5:
                    retColumnt = Column.E;
                    break;
                case 6:
                    retColumnt = Column.F;
                    break;
                case 7:
                    retColumnt = Column.G;
                    break;
                case 8:
                    retColumnt = Column.H;
                    break;
                default:
                    retColumnt = Column.Unknown;
                    break;
            }

            return retColumnt;
        }

        #endregion

        #region Events

        private void ChessBoard_Paint(object sender, PaintEventArgs e)
        {
            GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
            graphicsBuffer.CreateGraphicsBuffer(e.Graphics, Width, Height);

            Graphics g = graphicsBuffer.Graphics;
           
            SolidBrush solidWhiteBrush = new SolidBrush(Color.White);
            SolidBrush solidBlackBrush = new SolidBrush(Color.Black);
         
            Pen penBlack = new Pen(Color.Black, 1);
 
            Pen penHightlight = new Pen(Color.Black, 2);
            Pen penDestination = new Pen(Color.Yellow, 2);
            Pen penValidMove = new Pen(Color.Black, 2);
            Pen penEnPassant = new Pen(Color.DeepPink, 1);

            const int buffer = 10;

            if (Width < Height)
            {
                maxHeight = Width - 5 - buffer;
                boxHeight = maxHeight/8;
            }
            else
            {
                maxHeight = Height - 5 - buffer;
                boxHeight = maxHeight/8;
            }

            g.Clear(BackColor);

            try
            {
                int selectedX;
                int selectedY;

                //Draw Chess Board
                for (byte y = 0; y < 8; y++)
                {
                    for (byte x = 0; x < 8; x++)
                    {
                        if ((x + y)%2 == 0)
                        {
                            g.FillRectangle(solidWhiteBrush, (x * boxHeight) + buffer, (y * boxHeight) , boxHeight, boxHeight);
                        }
                        else
                        {
                            Rectangle drawArea1 = new Rectangle((x * boxHeight) + buffer, (y * boxHeight), boxHeight, boxHeight);
                            LinearGradientBrush linearBrush = new LinearGradientBrush(
                                        drawArea1, Color.Gainsboro, Color.Silver, LinearGradientMode.ForwardDiagonal );
                            g.FillRectangle(linearBrush, (x * boxHeight) + buffer, (y * boxHeight), boxHeight, boxHeight);
                        }

                        g.DrawRectangle(penBlack, (x * boxHeight) + buffer, (y * boxHeight) , boxHeight, boxHeight);
                    }
                    
                }
                for (byte i = 0; i < 8; i++)
                {
                    g.DrawString((8 - i).ToString(), new Font("Verdana", 8), solidBlackBrush, 0, (i * boxHeight)+ buffer);
                    g.DrawString(GetColumnFromInt(i + 1).ToString(), new Font("Verdana", 8), solidBlackBrush, (i * boxHeight) + (boxHeight/2) + 3, maxHeight - 1);
                }
                //Draw Pieces

                for (byte column = 0; column < 8; column++)
                {
                    for (byte row = 0; row < 8; row++)
                    {
                        ChessPieceType chessPieceType = engine.GetPieceTypeAt(column, row);
                        
                        if (chessPieceType != ChessPieceType.None)
                        {
                            ChessPieceColor chessPieceColor = engine.GetPieceColorAt(column, row);
                            bool selected = engine.GetChessPieceSelected(column, row);

                         
                            int x = (column) * boxHeight;                          
                            int y = (row) * boxHeight;

                            if (chessPieceColor == ChessPieceColor.White)
                            {
                                if (chessPieceType == ChessPieceType.Pawn)
                                {
                                    g.DrawImage(Resources.WPawn, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Rook)
                                {
                                    g.DrawImage(Resources.WRook, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Knight)
                                {
                                    g.DrawImage(Resources.WKnight, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Bishop)
                                {
                                    g.DrawImage(Resources.WBishop, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Queen)
                                {
                                    g.DrawImage(Resources.WQueen, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.King)
                                {
                                    g.DrawImage(Resources.WKing, x + buffer, y, boxHeight, boxHeight);
                                }
                            }
                            else
                            {
                                if (chessPieceType == ChessPieceType.Pawn)
                                {
                                    g.DrawImage(Resources.BPawn, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Rook)
                                {
                                    g.DrawImage(Resources.BRook, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Knight)
                                {
                                    g.DrawImage(Resources.BKnight, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Bishop)
                                {
                                    g.DrawImage(Resources.BBishop, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.Queen)
                                {
                                    g.DrawImage(Resources.BQueen, x + buffer, y, boxHeight, boxHeight);
                                }
                                else if (chessPieceType == ChessPieceType.King)
                                {
                                    g.DrawImage(Resources.BKing, x + buffer, y, boxHeight, boxHeight);
                                }
                            }

                            if (selected)
                            {
                                selectedX = ((column)*boxHeight) + buffer;
                                //selectedY = (8 - row - 1)*boxHeight;

                                //selectedX = ((8-column-1) * boxHeight) + buffer;
                                selectedY = (row) * boxHeight;

                                g.DrawRectangle(penHightlight, selectedX, selectedY, boxHeight - 1, boxHeight - 1);


                                //Draw Valid Moves
                                if (engine.GetValidMoves(column, row) != null)
                                {
                                    foreach (byte[] sqr in engine.GetValidMoves(column, row))
                                    {
                                        int moveY = (sqr[1]) * boxHeight;
                                       

                                        int moveX = (sqr[0] * boxHeight) + buffer;
                                        
                                        g.DrawRectangle(penValidMove, moveX, moveY, boxHeight - 1, boxHeight - 1);
                                    }
                                }
                            }
                            if (engine.GetEnPassantMoves()[0] > 0)
                            {
                                int moveY = (engine.GetEnPassantMoves()[1]) * boxHeight;

                                int moveX = (engine.GetEnPassantMoves()[0] * boxHeight) + buffer;
                                
                                g.DrawRectangle(penEnPassant, moveX, moveY, boxHeight - 1, boxHeight - 1);
                            }

                        }
                    }
                }

                if (currentDestination.Selected)
                {
                    selectedY = (currentDestination.Row ) * boxHeight;
                    selectedX = ((currentDestination.Column) * boxHeight) + buffer;
                    
                    g.DrawRectangle(penDestination, selectedX, selectedY, boxHeight - 1, boxHeight - 1);
                }
         

                graphicsBuffer.Render(CreateGraphics());

                g.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Drawing Chess Board", MessageBoxButtons.OK);
            }

        }

        private void ChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            byte column = 0;
            byte row = 0;

            try
            {
                //Get Column
                for (int i = 0; i < 8; i++)
                {
                    if (((i * boxHeight) + 10) < e.Location.X)
                    {
                        column++;
                    }
                    else
                    {
                        break;
                    }
                }

                //Get Row
                for (int i = 0; i < 8; i++)
                {
                    if (i*boxHeight < e.Location.Y)
                    {
                        row++;
                    }
                    else
                    {
                        break;
                    }
                }
                column--;

                row--;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Calculating Selected Column and Row", MessageBoxButtons.OK);
            }

            //Check if row and column are within bounds
            if (column > 7 || column < 0)
            {
                return;
            }
            if (row > 7 || row < 0)
            {
                return;
            }

            try
            {
                if (currentSource.Column == column && currentSource.Row == row && currentSource.Selected)
                {
                    //Unselect current Selection
                    currentSource.Selected = false;
                    currentDestination.Selected = false;

                    if (engine.GetPieceTypeAt(column, row) != ChessPieceType.None)
                    {
                        engine.SetChessPieceSelection(column, row, false);
                    }
                }
                else if ((currentSource.Column != column || currentSource.Row != row) && currentSource.Selected)
                {
                    //Make Move
                    currentDestination.Selected = true;
                    currentDestination.Column = column;
                    currentDestination.Row = row;

                    EngineMove();
                }
                else
                {
                    if (engine.GetPieceTypeAt(column, row) != ChessPieceType.None)
                    {        
                        if (engine.GetPieceColorAt(column, row) != engine.WhoseMove)
                        {
                            engine.SetChessPieceSelection(currentDestination.Column, currentDestination.Row, false);

                            currentSource.Selected = false;
                            currentDestination.Selected = false;
                            return;
                        }
                        engine.SetChessPieceSelection(column, row, true);
                    }
                    else
                    {
                        engine.SetChessPieceSelection(currentDestination.Column, currentDestination.Row, false);

                        currentSource.Selected = false;
                        currentDestination.Selected = false;
                        return;
                    }

                    //Select Source
                    currentDestination.Selected = false;
                  
                    currentSource.Column = column;
                    currentSource.Row = row;
                    currentSource.Selected = true;

                    
                }

               

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Selecting Chess Piece", MessageBoxButtons.OK);
            }
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {
            if (TurnChanged != null)
            {
                TurnChanged(engine.WhoseMove);
            }            
        }

        private void ChessBoard_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        #endregion
       
    }
}