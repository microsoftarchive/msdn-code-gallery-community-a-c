using System.Collections.Generic;

namespace ChessEngine.Engine
{

    #region Enums

    #region ChessPieceColor enum

    public enum ChessPieceColor
    {
        White,
        Black
    }

    #endregion

    #region ChessPieceType enum

    public enum ChessPieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn,
        None
    }

    #endregion

    #endregion

    internal sealed class Piece
    {
        #region InternalMembers

        internal ChessPieceColor PieceColor;
        internal ChessPieceType PieceType;

        internal short PieceValue;
        internal short PieceActionValue;

        internal short AttackedValue;
        internal short DefendedValue;
        
        internal int LastValidMoveCount;
        internal bool Moved;

        internal bool Selected;

        internal Stack<byte> ValidMoves;

        #endregion

        #region Constructors

        internal Piece(Piece piece)
        {
            PieceColor = piece.PieceColor;
            PieceType = piece.PieceType;
            Moved = piece.Moved;
            PieceValue = piece.PieceValue;
            PieceActionValue = piece.PieceActionValue;
            
            if (piece.ValidMoves != null)
                LastValidMoveCount = piece.ValidMoves.Count;                      
        }

        internal Piece(ChessPieceType chessPiece, ChessPieceColor chessPieceColor)
        {
            PieceType = chessPiece;
            PieceColor = chessPieceColor;

            if (PieceType == ChessPieceType.Pawn || PieceType == ChessPieceType.Knight)
            {
                LastValidMoveCount = 2;
            }
            else
            {
                LastValidMoveCount = 0;
            }

            ValidMoves = new Stack<byte>(LastValidMoveCount);

            PieceValue = CalculatePieceValue(PieceType);
            PieceActionValue = CalculatePieceActionValue(PieceType);
        }

        #endregion

        #region InternalMembers

        internal static string GetPieceTypeShort (ChessPieceType pieceType)
        {
            switch (pieceType)
            {
                case ChessPieceType.Pawn:
                    {
                        return "P";
                    }
                case ChessPieceType.Knight:
                    {
                        return "N";
                    }
                case ChessPieceType.Bishop:
                    {
                        return "B";
                    }
                case ChessPieceType.Rook:
                    {
                        return "R";
                    }

                case ChessPieceType.Queen:
                    {
                        return "Q";
                    }

                case ChessPieceType.King:
                    {
                        return "K";
                    }
                default:
                    {
                        return "P";
                    }
            }
        }

        #endregion

        #region PrivateMethods

        private static short CalculatePieceValue(ChessPieceType pieceType)
        {
            switch (pieceType)
            {
                case ChessPieceType.Pawn:
                    {
                        return 100;
                        
                    }
                case ChessPieceType.Knight:
                    {
                        return 320;
                    }
                case ChessPieceType.Bishop:
                    {
                        return 325;
                    }
                case ChessPieceType.Rook:
                    {
                        return 500;
                    }

                case ChessPieceType.Queen:
                    {
                        return 975;
                    }

                case ChessPieceType.King:
                    {
                        return 32767;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }


        private static short CalculatePieceActionValue(ChessPieceType pieceType)
        {
            switch (pieceType)
            {
                case ChessPieceType.Pawn:
                    {
                        return 6;

                    }
                case ChessPieceType.Knight:
                    {
                        return 3;
                    }
                case ChessPieceType.Bishop:
                    {
                        return 3;
                    }
                case ChessPieceType.Rook:
                    {
                        return 2;
                    }

                case ChessPieceType.Queen:
                    {
                        return 1;
                    }

                case ChessPieceType.King:
                    {
                        return 1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        #endregion
    }
}
