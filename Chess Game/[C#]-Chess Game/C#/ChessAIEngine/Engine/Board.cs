using System;

namespace ChessEngine.Engine
{
    internal sealed class Board
    {
      
        internal Square[] Squares;
              
        internal bool InsufficientMaterial;

        internal int Score;

        internal ulong ZobristHash;
       
        //Game Over Flags
        internal bool BlackCheck;
        internal bool BlackMate;
        internal bool WhiteCheck;
        internal bool WhiteMate;
        internal bool StaleMate;

        internal byte FiftyMove;
        internal byte RepeatedMove;

        internal bool BlackCastled;
        internal bool WhiteCastled;

        internal bool EndGamePhase;

        internal MoveContent LastMove;

        
        //Who initated En Passant
        internal ChessPieceColor EnPassantColor;
        //Positions liable to En Passant
        internal byte EnPassantPosition;

        internal ChessPieceColor WhoseMove;
        
        internal int MoveCount;

        #region Constructors

        //Default Constructor

        internal Board(string fen) : this()
        {
            byte index = 0;
            byte spc = 0;

            WhiteCastled = true;
            BlackCastled = true;
            byte spacers = 0;

            WhoseMove = ChessPieceColor.White;

            if (fen.Contains("a3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 40;
            }
            else if (fen.Contains("b3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 41;
            }
            else if (fen.Contains("c3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 42;
            }
            else if (fen.Contains("d3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 43;
            }
            else if (fen.Contains("e3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 44;
            }
            else if (fen.Contains("f3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 45;
            }
            else if (fen.Contains("g3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 46;
            }
            else if (fen.Contains("h3"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 47;
            }


            if (fen.Contains("a6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 16;
            }
            else if (fen.Contains("b6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 17;
            }
            else if (fen.Contains("c6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition =18;
            }
            else if (fen.Contains("d6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 19;
            }
            else if (fen.Contains("e6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 20;
            }
            else if (fen.Contains("f6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 21;
            }
            else if (fen.Contains("g6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 22;
            }
            else if (fen.Contains("h6"))
            {
                EnPassantColor = ChessPieceColor.White;
                EnPassantPosition = 23;
            }

            foreach (char c in fen)
            {

                if (index < 64 && spc == 0)
                {
                    if (c == '1' && index < 63)
                    {
                        index++;
                    }
                    else if (c == '2' && index < 62)
                    {
                        index += 2;
                    }
                    else if (c == '3' && index < 61)
                    {
                        index += 3;
                    }
                    else if (c == '4' && index < 60)
                    {
                        index += 4;
                    }
                    else if (c == '5' && index < 59)
                    {
                        index += 5;
                    }
                    else if (c == '6' && index < 58)
                    {
                        index += 6;
                    }
                    else if (c == '7' && index < 57)
                    {
                        index += 7;
                    }
                    else if (c == '8' && index < 56)
                    {
                        index += 8;
                    }
                    else if (c == 'P')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'N')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'B')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'R')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'Q')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Queen, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'K')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.King, ChessPieceColor.White);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'p')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Pawn, ChessPieceColor.Black);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'n')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Knight, ChessPieceColor.Black);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'b')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Bishop, ChessPieceColor.Black);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'r')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Rook, ChessPieceColor.Black);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'q')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.Queen, ChessPieceColor.Black);
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == 'k')
                    {
                        Squares[index].Piece = new Piece(ChessPieceType.King, ChessPieceColor.Black);      
                        Squares[index].Piece.Moved = true;
                        index++;
                    }
                    else if (c == '/')
                    {
                        continue;
                    }
                    else if (c == ' ')
                    {
                        spc++;
                    }
                }
                else
                {
                    if (c == 'w')
                    {
                        WhoseMove = ChessPieceColor.White;
                    }
                    else if (c == 'b')
                    {
                        WhoseMove = ChessPieceColor.Black;
                    }
                    else if (c == 'K')
                    {
                        if (Squares[60].Piece != null)
                        {
                            if (Squares[60].Piece.PieceType == ChessPieceType.King)
                            {
                                Squares[60].Piece.Moved = false;
                            }
                        }

                        if (Squares[63].Piece != null)
                        {
                            if (Squares[63].Piece.PieceType == ChessPieceType.Rook)
                            {
                                Squares[63].Piece.Moved = false;
                            }
                        }

                        WhiteCastled = false;
                    }
                    else if (c == 'Q')
                    {
                        if (Squares[60].Piece != null)
                        {
                            if (Squares[60].Piece.PieceType == ChessPieceType.King)
                            {
                                Squares[60].Piece.Moved = false;
                            }
                        }

                        if (Squares[56].Piece != null)
                        {
                            if (Squares[56].Piece.PieceType == ChessPieceType.Rook)
                            {
                                Squares[56].Piece.Moved = false;
                            }
                        }

                        WhiteCastled = false;
                    }
                    else if (c == 'k')
                    {
                        if (Squares[4].Piece != null)
                        {
                            if (Squares[4].Piece.PieceType == ChessPieceType.King)
                            {
                                Squares[4].Piece.Moved = false;
                            }
                        }

                        if (Squares[7].Piece != null)
                        {
                            if (Squares[7].Piece.PieceType == ChessPieceType.Rook)
                            {
                                Squares[7].Piece.Moved = false;
                            }
                        }

                        BlackCastled = false;
                    }
                    else if (c == 'q')
                    {
                        if (Squares[4].Piece != null)
                        {
                            if (Squares[4].Piece.PieceType == ChessPieceType.King)
                            {
                                Squares[4].Piece.Moved = false;
                            }
                        }

                        if (Squares[0].Piece != null)
                        {
                            if (Squares[0].Piece.PieceType == ChessPieceType.Rook)
                            {
                                Squares[0].Piece.Moved = false;
                            }
                        }

                        BlackCastled = false;
                    }
                    else if (c == ' ')
                    {
                        spacers++;
                    }
                    else if (c == '1' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 1);
                    }
                    else if (c == '2' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 2);
                    }
                    else if (c == '3' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 3);
                    }
                    else if (c == '4' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 4);
                    }
                    else if (c == '5' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 5);
                    }
                    else if (c == '6' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 6);
                    }
                    else if (c == '7' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 7);
                    }
                    else if (c == '8' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 8);
                    }
                    else if (c == '9' && spacers == 4)
                    {
                        FiftyMove = (byte)((FiftyMove * 10) + 9);
                    }
                    else if (c == '0' && spacers == 4)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 0);
                    }
                    else if (c == '1' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 1);
                    }
                    else if (c == '2' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 2);
                    }
                    else if (c == '3' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 3);
                    }
                    else if (c == '4' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 4);
                    }
                    else if (c == '5' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 5);
                    }
                    else if (c == '6' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 6);
                    }
                    else if (c == '7' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 7);
                    }
                    else if (c == '8' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 8);
                    }
                    else if (c == '9' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 9);
                    }
                    else if (c == '0' && spacers == 5)
                    {
                        MoveCount = (byte)((MoveCount * 10) + 0);
                    }

                }
            }
        }

        internal Board()
        {
            Squares = new Square[64];

            for (byte i = 0; i < 64; i++)
            {
                Squares[i] = new Square();
            }

            LastMove = new MoveContent();
        }

        private Board(Square[] squares)
        {
            Squares = new Square[64];

            for (byte x = 0; x < 64; x++)
            {
                if (squares[x].Piece != null)
                {
                    Squares[x].Piece = new Piece(squares[x].Piece);
                }
            } 
        }

        //Constructor
        internal Board(int score) : this()
        {
            Score = score;
        }

        //Copy Constructor
        internal Board(Board board)
        {
            Squares = new Square[64];

            for (byte x = 0; x < 64; x++)
            {
                if (board.Squares[x].Piece != null)
                {
                    Squares[x] = new Square(board.Squares[x].Piece);
                }
            }
            EndGamePhase = board.EndGamePhase;

            FiftyMove = board.FiftyMove;
            RepeatedMove = board.RepeatedMove;
           
            WhiteCastled = board.WhiteCastled;
            BlackCastled = board.BlackCastled;

            BlackCheck = board.BlackCheck;
            WhiteCheck = board.WhiteCheck;
            StaleMate = board.StaleMate;
            WhiteMate = board.WhiteMate;
            BlackMate = board.BlackMate;
            WhoseMove = board.WhoseMove;
            EnPassantPosition = board.EnPassantPosition;
            EnPassantColor = board.EnPassantColor;

            ZobristHash = board.ZobristHash;

            Score = board.Score;

            LastMove = new MoveContent(board.LastMove);

            MoveCount = board.MoveCount;
        }

        #endregion

        #region PrivateMethods

        private static bool PromotePawns(Board board, Piece piece, byte dstPosition, ChessPieceType promoteToPiece)
        {
            if (piece.PieceType == ChessPieceType.Pawn)
            {
                if (dstPosition < 8)
                {
                    board.Squares[dstPosition].Piece.PieceType = promoteToPiece;
                    return true;
                }
                if (dstPosition > 55)
                {
                    board.Squares[dstPosition].Piece.PieceType = promoteToPiece;
                    return true;
                }
            }

            return false;
        }

        private static void RecordEnPassant(ChessPieceColor pcColor, ChessPieceType pcType, Board board, byte srcPosition, byte dstPosition)
        {
            //Record En Passant if Pawn Moving
            if (pcType == ChessPieceType.Pawn)
            {
                //Reset FiftyMoveCount if pawn moved
                board.FiftyMove = 0;

                int difference = srcPosition - dstPosition; 

                if (difference == 16 || difference == -16)
                {
                    board.EnPassantPosition = (byte)(dstPosition + (difference / 2));
                    board.EnPassantColor = pcColor;
                }
            }
        }

        private static bool SetEnpassantMove(Board board, byte dstPosition, ChessPieceColor pcColor)
        {
            //En Passant
            if (board.EnPassantPosition == dstPosition)
            {
                //We have an En Passant Possible
                if (pcColor != board.EnPassantColor)
                {
                    int pieceLocationOffset = 8;

                    if (board.EnPassantColor == ChessPieceColor.White)
                    {
                        pieceLocationOffset = -8;
                    }

                    dstPosition = (byte)(dstPosition + pieceLocationOffset);

                    Square sqr = board.Squares[dstPosition];

                    board.LastMove.TakenPiece = new PieceTaken(sqr.Piece.PieceColor, sqr.Piece.PieceType, sqr.Piece.Moved, dstPosition);

                    board.Squares[dstPosition].Piece = null;
                    
                    //Reset FiftyMoveCount if capture
                    board.FiftyMove = 0;

                    return true;
                }
            }

            return false;
        }

        private static void KingCastle(Board board, Piece piece, byte srcPosition, byte dstPosition)
        {
            if (piece.PieceType != ChessPieceType.King)
            {
                return;
            }

            //Lets see if this is a casteling move.
            if (piece.PieceColor == ChessPieceColor.White && srcPosition == 60)
            {
                //Castle Right
                if (dstPosition == 62)
                {
                    //Ok we are casteling we need to move the Rook
                    if (board.Squares[63].Piece != null)
                    {
                        board.Squares[61].Piece = board.Squares[63].Piece;
                        board.Squares[63].Piece = null;
                        board.WhiteCastled = true;
                        board.LastMove.MovingPieceSecondary = new PieceMoving(board.Squares[61].Piece.PieceColor, board.Squares[61].Piece.PieceType, board.Squares[61].Piece.Moved, 63, 61);
                        board.Squares[61].Piece.Moved = true;
                        return;
                    }
                }
                //Castle Left
                else if (dstPosition == 58)
                {   
                    //Ok we are casteling we need to move the Rook
                    if (board.Squares[56].Piece != null)
                    {
                        board.Squares[59].Piece = board.Squares[56].Piece;
                        board.Squares[56].Piece = null;
                        board.WhiteCastled = true;
                        board.LastMove.MovingPieceSecondary = new PieceMoving(board.Squares[59].Piece.PieceColor, board.Squares[59].Piece.PieceType, board.Squares[59].Piece.Moved, 56, 59);
                        board.Squares[59].Piece.Moved = true;
                        return;
                    }
                }
            }
            else if (piece.PieceColor == ChessPieceColor.Black && srcPosition == 4)
            {
                if (dstPosition == 6)
                {
                    //Ok we are casteling we need to move the Rook
                    if (board.Squares[7].Piece != null)
                    {
                        board.Squares[5].Piece = board.Squares[7].Piece;
                        board.Squares[7].Piece = null;
                        board.BlackCastled = true;
                        board.LastMove.MovingPieceSecondary = new PieceMoving(board.Squares[5].Piece.PieceColor, board.Squares[5].Piece.PieceType, board.Squares[5].Piece.Moved, 7, 5);
                        board.Squares[5].Piece.Moved = true;
                        return;
                    }
                }
                    //Castle Left
                else if (dstPosition == 2)
                {
                    //Ok we are casteling we need to move the Rook
                    if (board.Squares[0].Piece != null)
                    {
                        board.Squares[3].Piece = board.Squares[0].Piece;
                        board.Squares[0].Piece = null;
                        board.BlackCastled = true;
                        board.LastMove.MovingPieceSecondary = new PieceMoving(board.Squares[3].Piece.PieceColor, board.Squares[3].Piece.PieceType, board.Squares[3].Piece.Moved, 0, 3);
                        board.Squares[3].Piece.Moved = true;
                        return;
                    }
                }
            }

            return;
        }

        #endregion

        #region InternalMethods

        //Fast Copy
        internal Board FastCopy()
        {
            Board clonedBoard = new Board(Squares);

            clonedBoard.EndGamePhase = EndGamePhase;
            clonedBoard.WhoseMove = WhoseMove;
            clonedBoard.MoveCount = MoveCount;
            clonedBoard.FiftyMove = FiftyMove;
            clonedBoard.ZobristHash = ZobristHash;
            clonedBoard.BlackCastled = BlackCastled;
            clonedBoard.WhiteCastled = WhiteCastled;
            return clonedBoard;
        }

        internal static MoveContent MovePiece(Board board, byte srcPosition, byte dstPosition, ChessPieceType promoteToPiece)
        {
            Piece piece = board.Squares[srcPosition].Piece;

            //Record my last move
            board.LastMove = new MoveContent();

            //Add One to FiftyMoveCount to check for tie.
            board.FiftyMove++;

            if (piece.PieceColor == ChessPieceColor.Black)
            {
                board.MoveCount++;
            }

            //En Passant
            if (board.EnPassantPosition > 0)
            {
                board.LastMove.EnPassantOccured = SetEnpassantMove(board, dstPosition, piece.PieceColor);
            }

            if (!board.LastMove.EnPassantOccured)
            {
                Square sqr = board.Squares[dstPosition];

                if (sqr.Piece != null)
                {
                    board.LastMove.TakenPiece = new PieceTaken(sqr.Piece.PieceColor, sqr.Piece.PieceType,
                                                               sqr.Piece.Moved, dstPosition);
                    board.FiftyMove = 0;
                }
                else
                {
                    board.LastMove.TakenPiece = new PieceTaken(ChessPieceColor.White, ChessPieceType.None, false,
                                                               dstPosition);
                    
                }
            }

            board.LastMove.MovingPiecePrimary = new PieceMoving(piece.PieceColor, piece.PieceType, piece.Moved, srcPosition, dstPosition);

            //Delete the piece in its source position
            board.Squares[srcPosition].Piece = null;
      
            //Add the piece to its new position
            piece.Moved = true;
            piece.Selected = false;
            board.Squares[dstPosition].Piece = piece;

            //Reset EnPassantPosition
            board.EnPassantPosition = 0;
          
            //Record En Passant if Pawn Moving
            if (piece.PieceType == ChessPieceType.Pawn)
            {
               board.FiftyMove = 0;
               RecordEnPassant(piece.PieceColor, piece.PieceType, board, srcPosition, dstPosition);
            }

            board.WhoseMove = board.WhoseMove == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;

            KingCastle(board, piece, srcPosition, dstPosition);

            //Promote Pawns 
            if (PromotePawns(board, piece, dstPosition, promoteToPiece))
            {
                board.LastMove.PawnPromoted = true;
            }
            else
            {
                board.LastMove.PawnPromoted = false;
            }

            if ( board.FiftyMove >= 50)
            {
                board.StaleMate = true;
            }

            return board.LastMove;
        }

        private static string GetColumnFromByte(byte column)
        {
            switch (column)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                default:
                    return "a";
            }
        }

        internal static string Fen(bool boardOnly, Board board)
        {
            string output = String.Empty;
            byte blankSquares = 0;

            for (byte x = 0; x < 64; x++)
            {
                byte index = x;

                if (board.Squares[index].Piece != null)
                {
                    if (blankSquares > 0)
                    {
                        output += blankSquares.ToString();
                        blankSquares = 0;
                    }

                    if (board.Squares[index].Piece.PieceColor == ChessPieceColor.Black)
                    {
                        output += Piece.GetPieceTypeShort(board.Squares[index].Piece.PieceType).ToLower();
                    }
                    else
                    {
                        output += Piece.GetPieceTypeShort(board.Squares[index].Piece.PieceType);
                    }
                }
                else
                {
                    blankSquares++;
                }

                if (x % 8 == 7)
                {
                    if (blankSquares > 0)
                    {
                        output += blankSquares.ToString();
                        output += "/";
                        blankSquares = 0;
                    }
                    else
                    {
                        if (x > 0 && x != 63)
                        {
                            output += "/";
                        }
                    }
                }
            }

            if (board.WhoseMove == ChessPieceColor.White)
            {
                output += " w ";
            }
            else
            {
                output += " b ";
            }

            string spacer = "";

            if (board.WhiteCastled == false)
            {
                if (board.Squares[60].Piece != null)
                {
                    if (board.Squares[60].Piece.Moved == false)
                    {
                        if (board.Squares[63].Piece != null)
                        {
                            if (board.Squares[63].Piece.Moved == false)
                            {
                                output += "K";
                                spacer = " ";
                            }
                        }
                        if (board.Squares[56].Piece != null)
                        {
                            if (board.Squares[56].Piece.Moved == false)
                            {
                                output += "Q";
                                spacer = " ";
                            }
                        }
                    }
                }
            }

            if (board.BlackCastled == false)
            {
                if (board.Squares[4].Piece != null)
                {
                    if (board.Squares[4].Piece.Moved == false)
                    {
                        if (board.Squares[7].Piece != null)
                        {
                            if (board.Squares[7].Piece.Moved == false)
                            {
                                output += "k";
                                spacer = " ";
                            }
                        }
                        if (board.Squares[0].Piece != null)
                        {
                            if (board.Squares[0].Piece.Moved == false)
                            {
                                output += "q";
                                spacer = " ";
                            }
                        }
                    }
                }

                
            }

            if (output.EndsWith("/"))
            {
                output.TrimEnd('/');
            }


            if (board.EnPassantPosition != 0)
            {
                output += spacer + GetColumnFromByte((byte)(board.EnPassantPosition % 8)) + "" + (byte)(8 - (byte)(board.EnPassantPosition / 8)) + " ";
            }
            else
            {
                output += spacer + "- ";
            }

            if (!boardOnly)
            {
                output += board.FiftyMove + " ";
                output += board.MoveCount + 1;
            }
            return output.Trim();
        }

        #endregion
    }
}
