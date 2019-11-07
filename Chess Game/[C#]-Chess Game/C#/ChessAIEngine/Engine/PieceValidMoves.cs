using System.Collections.Generic;

namespace ChessEngine.Engine
{
    internal static class PieceValidMoves
    {
        internal static bool[] BlackAttackBoard;
        private static byte blackKingPosition;

        internal static bool[] WhiteAttackBoard;
        private static byte whiteKingPosition;

        private static void AnalyzeMovePawn(Board board, byte dstPos, Piece pcMoving)
        {
            //Because Pawns only kill diagonaly we handle the En Passant scenario specialy
            if (board.EnPassantPosition > 0)
            {
                if (pcMoving.PieceColor != board.EnPassantColor)
                {
                    if (board.EnPassantPosition == dstPos)
                    {
                        //We have an En Passant Possible
                        pcMoving.ValidMoves.Push(dstPos);

                        if (pcMoving.PieceColor == ChessPieceColor.White)
                        {
                            WhiteAttackBoard[dstPos] = true;
                        }
                        else
                        {
                            BlackAttackBoard[dstPos] = true;
                        }
                    }
                }
            }

            Piece pcAttacked = board.Squares[dstPos].Piece;

            //If there no piece there I can potentialy kill
            if (pcAttacked == null)
                return;

            //Regardless of what is there I am attacking this square
            if (pcMoving.PieceColor == ChessPieceColor.White)
            {
                WhiteAttackBoard[dstPos] = true;

                //if that piece is the same color
                if (pcAttacked.PieceColor == pcMoving.PieceColor)
                {
                    pcAttacked.DefendedValue += pcMoving.PieceActionValue;
                    return;
                }

                pcAttacked.AttackedValue += pcMoving.PieceActionValue;

                //If this is a king set it in check                   
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    board.BlackCheck = true;
                }
                else
                {
                    //Add this as a valid move
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }
            else
            {
                BlackAttackBoard[dstPos] = true;

                //if that piece is the same color
                if (pcAttacked.PieceColor == pcMoving.PieceColor)
                {
                    pcAttacked.DefendedValue += pcMoving.PieceActionValue;
                    return;
                }

                pcAttacked.AttackedValue += pcMoving.PieceActionValue;

                //If this is a king set it in check                   
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    board.WhiteCheck = true;
                }
                else
                {
                    //Add this as a valid move
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }

            return;
        }

        private static bool AnalyzeMove(Board board, byte dstPos, Piece pcMoving)
        {
            //If I am not a pawn everywhere I move I can attack
            if (pcMoving.PieceColor == ChessPieceColor.White)
            {
                WhiteAttackBoard[dstPos] = true;
            }
            else
            {
                BlackAttackBoard[dstPos] = true;
            }

            //If there no piece there I can potentialy kill just add the move and exit
            if (board.Squares[dstPos].Piece == null)
            {
                pcMoving.ValidMoves.Push(dstPos);

                return true;
            }

            Piece pcAttacked = board.Squares[dstPos].Piece;

            //if that piece is a different color
            if (pcAttacked.PieceColor != pcMoving.PieceColor)
            {
                pcAttacked.AttackedValue += pcMoving.PieceActionValue;

                //If this is a king set it in check                   
                if (pcAttacked.PieceType == ChessPieceType.King)
                {
                    if (pcAttacked.PieceColor == ChessPieceColor.Black)
                    {
                        board.BlackCheck = true;
                    }
                    else
                    {
                        board.WhiteCheck = true;
                    }
                }
                else
                {
                    //Add this as a valid move
                    pcMoving.ValidMoves.Push(dstPos);
                }


                //We don't continue movement past this piece
                return false;
            }
            //Same Color I am defending
            pcAttacked.DefendedValue += pcMoving.PieceActionValue;

            //Since this piece is of my kind I can't move there
            return false;
        }

        private static void CheckValidMovesPawn(List<byte> moves, Piece pcMoving, byte srcPosition,
                                                Board board, byte count)
        {
            for (byte i = 0; i < count; i++)
            {
                byte dstPos = moves[i];

                if (dstPos%8 != srcPosition%8)
                {
                    //If there is a piece there I can potentialy kill
                    AnalyzeMovePawn(board, dstPos, pcMoving);

                    if (pcMoving.PieceColor == ChessPieceColor.White)
                    {
                        WhiteAttackBoard[dstPos] = true;
                    }
                    else
                    {
                        BlackAttackBoard[dstPos] = true;
                    }
                }
                    // if there is something if front pawns can't move there
                else if (board.Squares[dstPos].Piece != null)
                {
                    return;
                }
                    //if there is nothing in front of me (blocked == false)
                else
                {
                    pcMoving.ValidMoves.Push(dstPos);
                }
            }
        }

        private static void GenerateValidMovesKing(Piece piece, Board board, byte srcPosition)
        {
            if (piece == null)
            {
                return;
            }

            for (byte i = 0; i < MoveArrays.KingTotalMoves[srcPosition]; i++)
            {
                byte dstPos = MoveArrays.KingMoves[srcPosition].Moves[i];

                if (piece.PieceColor == ChessPieceColor.White)
                {
                    //I can't move where I am being attacked
                    if (BlackAttackBoard[dstPos])
                    {
                        WhiteAttackBoard[dstPos] = true;
                        continue;
                    }
                }
                else
                {
                    if (WhiteAttackBoard[dstPos])
                    {
                        BlackAttackBoard[dstPos] = true;
                        continue;
                    }
                }

                AnalyzeMove(board, dstPos, piece);
            }
        }

        private static void GenerateValidMovesKingCastle(Board board, Piece king)
        {
            if (king == null)
            {
                return;
            }

            if (king.Moved)
            {
                return;
            }
            if (king.PieceColor == ChessPieceColor.White &&
                board.WhiteCastled)
            {
                return;
            }
            if (king.PieceColor == ChessPieceColor.Black &&
                board.BlackCastled)
            {
                return;
            }
            if (king.PieceColor == ChessPieceColor.Black &&
                board.BlackCheck)
            {
                return;
            }
            if (king.PieceColor == ChessPieceColor.White &&
                board.WhiteCheck)
            {
                return;
            }


            //This code will add the castleling move to the pieces available moves
            if (king.PieceColor == ChessPieceColor.White)
            {
                if (board.WhiteCheck)
                {
                    return;
                }

                if (board.Squares[63].Piece != null)
                {
                    //Check if the Right Rook is still in the correct position
                    if (board.Squares[63].Piece.PieceType == ChessPieceType.Rook)
                    {
                        if (board.Squares[63].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty
                            if (board.Squares[62].Piece == null)
                            {
                                if (board.Squares[61].Piece == null)
                                {
                                    if (BlackAttackBoard[61] == false &&
                                        BlackAttackBoard[62] == false)
                                    {
                                        //Ok looks like move is valid lets add it
                                        king.ValidMoves.Push(62);
                                        WhiteAttackBoard[62] = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (board.Squares[56].Piece != null)
                {
                    //Check if the Left Rook is still in the correct position
                    if (board.Squares[56].Piece.PieceType == ChessPieceType.Rook)
                    {
                        if (board.Squares[56].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty
                            if (board.Squares[57].Piece == null)
                            {
                                if (board.Squares[58].Piece == null)
                                {
                                    if (board.Squares[59].Piece == null)
                                    {
                                        if (BlackAttackBoard[58] == false &&
                                            BlackAttackBoard[59] == false)
                                        {
                                            //Ok looks like move is valid lets add it
                                            king.ValidMoves.Push(58);
                                            WhiteAttackBoard[58] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (king.PieceColor == ChessPieceColor.Black)
            {
                if (board.BlackCheck)
                {
                    return;
                }

                //There are two ways to castle, scenario 1:
                if (board.Squares[7].Piece != null)
                {
                    //Check if the Right Rook is still in the correct position
                    if (board.Squares[7].Piece.PieceType == ChessPieceType.Rook
                        && !board.Squares[7].Piece.Moved)
                    {
                        if (board.Squares[7].Piece.PieceColor == king.PieceColor)
                        {
                            //Move one column to right see if its empty

                            if (board.Squares[6].Piece == null)
                            {
                                if (board.Squares[5].Piece == null)
                                {
                                    if (WhiteAttackBoard[5] == false && WhiteAttackBoard[6] == false)
                                    {
                                        //Ok looks like move is valid lets add it
                                        king.ValidMoves.Push(6);
                                        BlackAttackBoard[6] = true;
                                    }
                                }
                            }
                        }
                    }
                }
                //There are two ways to castle, scenario 2:
                if (board.Squares[0].Piece != null)
                {
                    //Check if the Left Rook is still in the correct position
                    if (board.Squares[0].Piece.PieceType == ChessPieceType.Rook &&
                        !board.Squares[0].Piece.Moved)
                    {
                        if (board.Squares[0].Piece.PieceColor ==
                            king.PieceColor)
                        {
                            //Move one column to right see if its empty
                            if (board.Squares[1].Piece == null)
                            {
                                if (board.Squares[2].Piece == null)
                                {
                                    if (board.Squares[3].Piece == null)
                                    {
                                        if (WhiteAttackBoard[2] == false &&
                                            WhiteAttackBoard[3] == false)
                                        {
                                            //Ok looks like move is valid lets add it
                                            king.ValidMoves.Push(2);
                                            BlackAttackBoard[2] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void GenerateValidMoves(Board board)
        {
            // Reset Board
            board.BlackCheck = false;
            board.WhiteCheck = false;

            WhiteAttackBoard = new bool[64];
            BlackAttackBoard = new bool[64];

            //Generate Moves
            for (byte x = 0; x < 64; x++)
            {
                Square sqr = board.Squares[x];

                if (sqr.Piece == null)
                    continue;

                sqr.Piece.ValidMoves = new Stack<byte>(sqr.Piece.LastValidMoveCount);

                switch (sqr.Piece.PieceType)
                {
                    case ChessPieceType.Pawn:
                        {
                            if (sqr.Piece.PieceColor == ChessPieceColor.White)
                            {
                                CheckValidMovesPawn(MoveArrays.WhitePawnMoves[x].Moves, sqr.Piece, x,
                                                    board,
                                                    MoveArrays.WhitePawnTotalMoves[x]);
                                break;
                            }
                            if (sqr.Piece.PieceColor == ChessPieceColor.Black)
                            {
                                CheckValidMovesPawn(MoveArrays.BlackPawnMoves[x].Moves, sqr.Piece, x,
                                                    board,
                                                    MoveArrays.BlackPawnTotalMoves[x]);
                                break;
                            }

                            break;
                        }
                    case ChessPieceType.Knight:
                        {
                            for (byte i = 0; i < MoveArrays.KnightTotalMoves[x]; i++)
                            {
                                AnalyzeMove(board, MoveArrays.KnightMoves[x].Moves[i], sqr.Piece);
                            }

                            break;
                        }
                    case ChessPieceType.Bishop:
                        {
                            for (byte i = 0; i < MoveArrays.BishopTotalMoves1[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.BishopMoves1[x].Moves[i],
                                                sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.BishopTotalMoves2[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.BishopMoves2[x].Moves[i],
                                                sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.BishopTotalMoves3[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.BishopMoves3[x].Moves[i],
                                                sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.BishopTotalMoves4[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.BishopMoves4[x].Moves[i],
                                                sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }

                            break;
                        }
                    case ChessPieceType.Rook:
                        {
                            for (byte i = 0; i < MoveArrays.RookTotalMoves1[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.RookMoves1[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.RookTotalMoves2[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.RookMoves2[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.RookTotalMoves3[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.RookMoves3[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.RookTotalMoves4[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.RookMoves4[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }

                            break;
                        }
                    case ChessPieceType.Queen:
                        {
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves1[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves1[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves2[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves2[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves3[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves3[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves4[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves4[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }

                            for (byte i = 0; i < MoveArrays.QueenTotalMoves5[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves5[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves6[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves6[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves7[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves7[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }
                            for (byte i = 0; i < MoveArrays.QueenTotalMoves8[x]; i++)
                            {
                                if (
                                    AnalyzeMove(board, MoveArrays.QueenMoves8[x].Moves[i], sqr.Piece) ==
                                    false)
                                {
                                    break;
                                }
                            }

                            break;
                        }
                    case ChessPieceType.King:
                        {
                            if (sqr.Piece.PieceColor == ChessPieceColor.White)
                            {
                                whiteKingPosition = x;
                            }
                            else
                            {
                                blackKingPosition = x;
                            }

                            break;
                        }
                }
            }


            if (board.WhoseMove == ChessPieceColor.White)
            {
                GenerateValidMovesKing(board.Squares[blackKingPosition].Piece, board,
                                       blackKingPosition);
                GenerateValidMovesKing(board.Squares[whiteKingPosition].Piece, board,
                                       whiteKingPosition);
            }
            else
            {
                GenerateValidMovesKing(board.Squares[whiteKingPosition].Piece, board,
                                       whiteKingPosition);
                GenerateValidMovesKing(board.Squares[blackKingPosition].Piece, board,
                                       blackKingPosition);
            }


            //Now that all the pieces were examined we know if the king is in check
            GenerateValidMovesKingCastle(board, board.Squares[whiteKingPosition].Piece);
            GenerateValidMovesKingCastle(board, board.Squares[blackKingPosition].Piece);
        }
    }
}
