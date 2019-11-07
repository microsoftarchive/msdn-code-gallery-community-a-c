using System.Collections.Generic;

namespace ChessEngine.Engine
{
    internal struct PieceMoveSet
    {
        internal readonly List<byte> Moves;

        internal PieceMoveSet(List<byte> moves)
        {
            Moves = moves;
        }
    }

    internal struct MoveArrays
    {
        internal static PieceMoveSet[] BishopMoves1;
        internal static byte[] BishopTotalMoves1;
        
        internal static PieceMoveSet[] BishopMoves2;
        internal static byte[] BishopTotalMoves2;

        internal static PieceMoveSet[] BishopMoves3;
        internal static byte[] BishopTotalMoves3;

        internal static PieceMoveSet[] BishopMoves4;
        internal static byte[] BishopTotalMoves4;

        internal static PieceMoveSet[] BlackPawnMoves;
        internal static byte[] BlackPawnTotalMoves;

        internal static PieceMoveSet[] WhitePawnMoves;
        internal static byte[] WhitePawnTotalMoves;

        internal static PieceMoveSet[] KnightMoves;
        internal static byte[] KnightTotalMoves;

        internal static PieceMoveSet[] QueenMoves1;
        internal static byte[] QueenTotalMoves1;
        internal static PieceMoveSet[] QueenMoves2;
        internal static byte[] QueenTotalMoves2;
        internal static PieceMoveSet[] QueenMoves3;
        internal static byte[] QueenTotalMoves3;
        internal static PieceMoveSet[] QueenMoves4;
        internal static byte[] QueenTotalMoves4;
        internal static PieceMoveSet[] QueenMoves5;
        internal static byte[] QueenTotalMoves5;
        internal static PieceMoveSet[] QueenMoves6;
        internal static byte[] QueenTotalMoves6;
        internal static PieceMoveSet[] QueenMoves7;
        internal static byte[] QueenTotalMoves7;
        internal static PieceMoveSet[] QueenMoves8;
        internal static byte[] QueenTotalMoves8;

        internal static PieceMoveSet[] RookMoves1;
        internal static byte[] RookTotalMoves1;
        internal static PieceMoveSet[] RookMoves2;
        internal static byte[] RookTotalMoves2;
        internal static PieceMoveSet[] RookMoves3;
        internal static byte[] RookTotalMoves3;
        internal static PieceMoveSet[] RookMoves4;
        internal static byte[] RookTotalMoves4;

        internal static PieceMoveSet[] KingMoves;
        internal static byte[] KingTotalMoves;
    }

    internal static class PieceMoves
    {
        private static byte Position(byte col, byte row)
        {
            return (byte)(col + (row * 8));
        }

        #region IntitiateMotionMethods

        internal static void InitiateChessPieceMotion()
        {
            MoveArrays.WhitePawnMoves = new PieceMoveSet[64];
            MoveArrays.WhitePawnTotalMoves = new byte[64];

            MoveArrays.BlackPawnMoves = new PieceMoveSet[64];
            MoveArrays.BlackPawnTotalMoves = new byte[64];

            MoveArrays.KnightMoves = new PieceMoveSet[64];
            MoveArrays.KnightTotalMoves = new byte[64];

            MoveArrays.BishopMoves1 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves1 = new byte[64];

            MoveArrays.BishopMoves2 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves2 = new byte[64];

            MoveArrays.BishopMoves3 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves3 = new byte[64];

            MoveArrays.BishopMoves4 = new PieceMoveSet[64];
            MoveArrays.BishopTotalMoves4 = new byte[64];

            MoveArrays.RookMoves1 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves1 = new byte[64];

            MoveArrays.RookMoves2 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves2 = new byte[64];

            MoveArrays.RookMoves3 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves3 = new byte[64];

            MoveArrays.RookMoves4 = new PieceMoveSet[64];
            MoveArrays.RookTotalMoves4 = new byte[64];

            MoveArrays.QueenMoves1 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves1 = new byte[64];

            MoveArrays.QueenMoves2 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves2 = new byte[64];

            MoveArrays.QueenMoves3 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves3 = new byte[64];

            MoveArrays.QueenMoves4 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves4 = new byte[64];

            MoveArrays.QueenMoves5 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves5 = new byte[64];

            MoveArrays.QueenMoves6 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves6 = new byte[64];

            MoveArrays.QueenMoves7 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves7 = new byte[64];

            MoveArrays.QueenMoves8 = new PieceMoveSet[64];
            MoveArrays.QueenTotalMoves8 = new byte[64];

            MoveArrays.KingMoves = new PieceMoveSet[64];
            MoveArrays.KingTotalMoves = new byte[64];
            
            SetMovesWhitePawn();
            SetMovesBlackPawn();
            SetMovesKnight();
            SetMovesBishop();
            SetMovesRook();
            SetMovesQueen();
            SetMovesKing();
        }

        private static void SetMovesBlackPawn()
        {
            for (byte index = 8; index <= 55; index++)
            {
                var moveset = new PieceMoveSet(new List<byte>());
                
                byte x = (byte)(index % 8);
                byte y = (byte)((index / 8));
                
                //Diagonal Kill
                if (y < 7 && x < 7)
                {
                    moveset.Moves.Add((byte)(index + 8 + 1));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }
                if (x > 0 && y < 7)
                {
                    moveset.Moves.Add((byte)(index + 8 - 1));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }
                
                //One Forward
                moveset.Moves.Add((byte)(index + 8));
                MoveArrays.BlackPawnTotalMoves[index]++;

                //Starting Position we can jump 2
                if (y == 1)
                {
                    moveset.Moves.Add((byte)(index + 16));
                    MoveArrays.BlackPawnTotalMoves[index]++;
                }

                MoveArrays.BlackPawnMoves[index] = moveset;
            }
        }

        private static void SetMovesWhitePawn()
        {
            for (byte index = 8; index <= 55; index++)
            {
                byte x = (byte)(index % 8);
                byte y = (byte)((index / 8));

                var moveset = new PieceMoveSet(new List<byte>());
               
                //Diagonal Kill
                if (x < 7 && y > 0)
                {
                    moveset.Moves.Add((byte)(index - 8 + 1));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }
                if (x > 0 && y > 0)
                {
                    moveset.Moves.Add((byte)(index - 8 - 1));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }

                //One Forward
                moveset.Moves.Add((byte)(index - 8));
                MoveArrays.WhitePawnTotalMoves[index]++;

                //Starting Position we can jump 2
                if (y == 6)
                {
                    moveset.Moves.Add((byte)(index - 16));
                    MoveArrays.WhitePawnTotalMoves[index]++;
                }

                MoveArrays.WhitePawnMoves[index] = moveset;
            }
        }

        private static void SetMovesKnight()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));

                    var moveset = new PieceMoveSet(new List<byte>());
                    
                    byte move;

                    if (y < 6 && x > 0)
                    {
                        move = Position((byte)(y + 2), (byte)(x - 1));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y > 1 && x < 7)
                    {
                        move = Position((byte)(y - 2), (byte)(x + 1));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y > 1 && x > 0)
                    {
                        move = Position((byte)(y - 2), (byte)(x - 1));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y < 6 && x < 7)
                    {
                        move = Position((byte)(y + 2), (byte)(x + 1));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y > 0 && x < 6)
                    {
                        move = Position((byte)(y - 1), (byte)(x + 2));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y < 7 && x > 1)
                    {
                        move = Position((byte)(y + 1), (byte)(x - 2));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    if (y > 0 && x > 1)
                    {
                        move = Position((byte)(y - 1), (byte)(x - 2));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }
                    
                    if (y < 7 && x < 6)
                    {
                        move = Position((byte)(y + 1), (byte)(x + 2));

                        if (move < 64)
                        {
                            moveset.Moves.Add(move);
                            MoveArrays.KnightTotalMoves[index]++;
                        }
                    }

                    MoveArrays.KnightMoves[index] = moveset;
                }
            }
        }

        private static void SetMovesBishop()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));

                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;

                    byte row = x;
                    byte col = y;

                    while (row < 7 && col < 7)
                    {
                        row++;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves1[index]++;
                    }

                    MoveArrays.BishopMoves1[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());

                    row = x;
                    col = y;

                    while (row < 7 && col > 0)
                    {
                        row++;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves2[index]++;
                    }

                    MoveArrays.BishopMoves2[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());

                    row = x;
                    col = y;

                    while (row > 0 && col < 7)
                    {
                        row--;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves3[index]++;
                    }

                    MoveArrays.BishopMoves3[index] = moveset;
                    moveset = new PieceMoveSet(new List<byte>());

                    row = x;
                    col = y;

                    while (row > 0 && col > 0)
                    {
                        row--;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.BishopTotalMoves4[index]++;
                    }

                    MoveArrays.BishopMoves4[index] = moveset;
                }
            }
        }

        private static void SetMovesRook()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));

                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;

                    byte row = x;
                    byte col = y;

                    while (row < 7)
                    {
                        row++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves1[index]++;
                    }

                    MoveArrays.RookMoves1[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row > 0)
                    {
                        row--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves2[index]++;
                    }

                    MoveArrays.RookMoves2[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (col > 0)
                    {
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves3[index]++;
                    }

                    MoveArrays.RookMoves3[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (col < 7)
                    {
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.RookTotalMoves4[index]++;
                    }

                    MoveArrays.RookMoves4[index] = moveset;
                }
            }
        }

        private static void SetMovesQueen()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));

                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;

                    byte row = x;
                    byte col = y;

                    while (row < 7)
                    {
                        row++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves1[index]++;
                    }

                    MoveArrays.QueenMoves1[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row > 0)
                    {
                        row--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves2[index]++;
                    }

                    MoveArrays.QueenMoves2[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (col > 0)
                    {
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves3[index]++;
                    }

                    MoveArrays.QueenMoves3[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (col < 7)
                    {
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves4[index]++;
                    }

                    MoveArrays.QueenMoves4[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row < 7 && col < 7)
                    {
                        row++;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves5[index]++;
                    }

                    MoveArrays.QueenMoves5[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row < 7 && col > 0)
                    {
                        row++;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves6[index]++;
                    }

                    MoveArrays.QueenMoves6[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row > 0 && col < 7)
                    {
                        row--;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves7[index]++;
                    }

                    MoveArrays.QueenMoves7[index] = moveset;

                    moveset = new PieceMoveSet(new List<byte>());
                    row = x;
                    col = y;

                    while (row > 0 && col > 0)
                    {
                        row--;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.QueenTotalMoves8[index]++;
                    }

                    MoveArrays.QueenMoves8[index] = moveset;
                }
            }
        }

        private static void SetMovesKing()
        {
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 8; x++)
                {
                    byte index = (byte)(y + (x * 8));

                    var moveset = new PieceMoveSet(new List<byte>());
                    byte move;

                    byte row = x;
                    byte col = y;

                    if (row < 7)
                    {
                        row++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (row > 0)
                    {
                        row--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (col > 0)
                    {
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (col < 7)
                    {
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (row < 7 && col < 7)
                    {
                        row++;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (row < 7 && col > 0)
                    {
                        row++;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    row = x;
                    col = y;

                    if (row > 0 && col < 7)
                    {
                        row--;
                        col++;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }


                    row = x;
                    col = y;

                    if (row > 0 && col > 0)
                    {
                        row--;
                        col--;

                        move = Position(col, row);
                        moveset.Moves.Add(move);
                        MoveArrays.KingTotalMoves[index]++;
                    }

                    MoveArrays.KingMoves[index] = moveset;
                }
            }
        }

        #endregion
    }
}
