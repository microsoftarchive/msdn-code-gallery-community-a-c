using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MinThantSin.OpenSourceGames
{    
    public static class GameSettings
    {
        public static readonly string BACKGROUND_PICTURE_NAME = "background_tile.bmp";

        public static readonly int MIN_PIECE_WIDTH = 50;    // Minimum width of jigsaw piece in pixels.
        public static readonly int MIN_PIECE_HEIGHT = 50;   // Minimum height of jigsaw piece in pixels.

        // It's recommended to set the number of rows and columns to be the same, otherwise,
        // the pieces may appear out of proportion.
        public static readonly int NUM_ROWS = 4;
        public static readonly int NUM_COLUMNS = 4;
        
        public static readonly int SNAP_TOLERANCE = 15;
        public static readonly byte GHOST_PICTURE_ALPHA = 127;
        
        public static readonly int PIECE_OUTLINE_WIDTH = 4;
        public static readonly bool DRAW_PIECE_OUTLINE = true;

        public static readonly int DROP_SHADOW_DEPTH = 3;
        public static readonly Color DROP_SHADOW_COLOR = Color.FromArgb(50, 50, 50);
    }
}
