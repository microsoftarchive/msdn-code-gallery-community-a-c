namespace SweNug.SignalR.Server
{
    public class TicTacToe
    {
        public bool IsGameOver { get; private set; }

        public bool IsDraw { get; private set; }

        public Client Player1 { get; set; }

        public Client Player2 { get; set; }

        private readonly int[] field = new int[9];
        private int movesLeft = 9;

        public TicTacToe()
        {
            // Reset game
            for (var i = 0; i < field.Length; i++)
            {
                field[i] = -1;
            }
        }

        /// <summary>
        /// Insert a marker at a given position for a given player
        /// </summary>
        /// <param name="player">The player number should be 0 or 1</param>
        /// <param name="position">The position where to place the marker, should be between 0 and 9</param>
        /// <returns>True if a winner was found</returns>
        public bool Play(int player, int position)
        {
            if (IsGameOver)
                return false;

            PlaceMarker(player, position);

            return CheckWinner();
        }

        /// <summary>
        /// Checks each different combination of marker placements and looks for a winner
        /// Each position is marked with an initial -1 which means no marker has yet been placed
        /// </summary>
        /// <returns>True if there is a winner</returns>
        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (
                    ((field[i * 3] != -1 && field[(i * 3)] == field[(i * 3) + 1] && field[(i * 3)] == field[(i * 3) + 2]) ||
                     (field[i] != -1 && field[i] == field[i + 3] && field[i] == field[i + 6])))
                {
                    IsGameOver = true;
                    return true;
                }
            }

            if ((field[0] != -1 && field[0] == field[4] && field[0] == field[8]) || (field[2] != -1 && field[2] == field[4] && field[2] == field[6]))
            {
                IsGameOver = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Places a marker at the given position for the given player as long as the position is marked as -1
        /// </summary>
        /// <param name="player">The player number should be 0 or 1</param>
        /// <param name="position">The position where to place the marker, should be between 0 and 9</param>
        /// <returns>True if the marker position was not already taken</returns>
        private bool PlaceMarker(int player, int position)
        {
            movesLeft -= 1;

            if (movesLeft <= 0)
            {
                IsGameOver = true;
                IsDraw = true;
                return false;
            }

            if (position > field.Length)
                return false;
            if (field[position] != -1)
                return false;

            field[position] = player;

            return true;
        }
    }
}