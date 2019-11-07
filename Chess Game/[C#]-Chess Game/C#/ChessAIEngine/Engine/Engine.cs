using System;
using System.Collections.Generic;

[assembly: CLSCompliant(true)]

namespace ChessEngine.Engine
{
    public sealed class Engine
    {
        internal Board ChessBoard;
        internal Board PreviousChessBoard;

        public ChessPieceColor HumanPlayer;

        public ChessPieceColor WhoseMove
        {
            get { return ChessBoard.WhoseMove; }
            set { ChessBoard.WhoseMove = value; }
        }

        public Engine()
        {           
            InitiateBoard("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        }

        public Engine(string fen)
        {
            InitiateBoard(fen);
        }

        private void InitiateBoard(string fen)
        {
            HumanPlayer = ChessPieceColor.White;    
            ChessBoard = new Board(fen);
            ChessBoard.WhoseMove = ChessPieceColor.White;
            PieceMoves.InitiateChessPieceMotion();
            GenerateValidMoves();           
        }

        public byte[] GetEnPassantMoves()
        {
            if (ChessBoard == null)
            {
                return null;
            }

            var returnArray = new byte[2];

            returnArray[0] = (byte)(ChessBoard.EnPassantPosition % 8);
            returnArray[1] = (byte)(ChessBoard.EnPassantPosition / 8);

            return returnArray;
        }

        public bool IsValidMove(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
        {
            if (ChessBoard == null)
            {
                return false;
            }

            if (ChessBoard.Squares == null)
            {
                return false;
            }

            byte index = GetBoardIndex(sourceColumn, sourceRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return false;
            }

            foreach (byte bs in ChessBoard.Squares[index].Piece.ValidMoves)
            {
                if (bs % 8 == destinationColumn)
                {
                    if ((byte)(bs / 8) == destinationRow)
                    {
                        return true;
                    }
                }
            }

            index = GetBoardIndex(destinationColumn, destinationRow);

            if (index == ChessBoard.EnPassantPosition)
            {
                return true;
            }

            return false;
        }

        public ChessPieceType GetPieceTypeAt(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceType.None;
            }

            return ChessBoard.Squares[index].Piece.PieceType;
        }

        public ChessPieceType GetPieceTypeAt(byte index)
        {
            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceType.None;
            }

            return ChessBoard.Squares[index].Piece.PieceType;
        }

        public ChessPieceColor GetPieceColorAt(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceColor.White;
            }
            return ChessBoard.Squares[index].Piece.PieceColor;
        }

        public ChessPieceColor GetPieceColorAt(byte index)
        {
            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceColor.White;
            }
            return ChessBoard.Squares[index].Piece.PieceColor;
        }

        public bool GetChessPieceSelected(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return false;
            }

            return ChessBoard.Squares[index].Piece.Selected;
        }

        public byte[][] GetValidMoves(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece ==
                null)
            {
                return null;
            }

            var returnArray = new byte[ChessBoard.Squares[index].Piece.ValidMoves.Count][];
            int counter = 0;

            foreach (byte square in ChessBoard.Squares[index].Piece.ValidMoves)
            {
                returnArray[counter] = new byte[2];
                returnArray[counter][0] = (byte)(square % 8);
                returnArray[counter][1] = (byte)(square / 8);
                counter++;
            }

            return returnArray;
        }

        public void SetChessPieceSelection(byte boardColumn, byte boardRow,
                                          bool selection)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return;
            }
            //if (ChessBoard.Squares[index].Piece.PieceColor != HumanPlayer)
            //{
            //    return;
            //}
            if (ChessBoard.Squares[index].Piece.PieceColor != WhoseMove)
            {
                return;
            }
            ChessBoard.Squares[index].Piece.Selected = selection;
        }

        public bool MovePiece(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
        {
            byte srcPosition = (byte)(sourceColumn + (sourceRow * 8));
            byte dstPosition = (byte)(destinationColumn + (destinationRow * 8));

            Piece piece = ChessBoard.Squares[srcPosition].Piece;

            PreviousChessBoard = new Board(ChessBoard);
            

            Board.MovePiece(ChessBoard, srcPosition, dstPosition, ChessPieceType.Queen);

            PieceValidMoves.GenerateValidMoves(ChessBoard);
           

            //If there is a check in place, check if this is still true;
            if (piece.PieceColor == ChessPieceColor.White)
            {
                if (ChessBoard.WhiteCheck)
                {
                    //Invalid Move
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }
            else if (piece.PieceColor == ChessPieceColor.Black)
            {
                if (ChessBoard.BlackCheck)
                {
                    //Invalid Move
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }

            return true;

        }

        private void GenerateValidMoves()
        {
            PieceValidMoves.GenerateValidMoves(ChessBoard);
        }

        private static byte GetBoardIndex(byte BoardColumn, byte BoardRow)
        {
            return (byte)(BoardColumn + (BoardRow * 8));
        }

   
    }
}