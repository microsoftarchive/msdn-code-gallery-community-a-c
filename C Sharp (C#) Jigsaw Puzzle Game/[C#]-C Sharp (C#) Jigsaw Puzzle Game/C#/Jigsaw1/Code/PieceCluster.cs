using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MinThantSin.OpenSourceGames
{
    /// <summary>
    /// Represents a jigsaw piece or group of jigsaw pieces combined together.
    /// </summary>
    public class PieceCluster
    {
        public int ID { get; set; }

        // =========================================
        // The following properties are similar to those in "Piece" class.
        // Their values may change when the pieces are snapped and 
        // combined together.
        // =========================================
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle BoardLocation { get; set; }        
        public Rectangle SourcePictureLocation { get; set; }
        public GraphicsPath MovableFigure { get; set; }
        public GraphicsPath StaticFigure { get; set; }
        public Bitmap Picture { get; set; }
        // =========================================

        /// <summary>
        /// Stores inidividual jigsaw pieces.
        /// </summary>
        public List<Piece> Pieces { get; set; }        
    }
}
