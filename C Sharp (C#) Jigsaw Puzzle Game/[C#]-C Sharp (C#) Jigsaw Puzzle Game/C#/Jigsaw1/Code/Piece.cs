using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MinThantSin.OpenSourceGames
{
    /// <summary>
    /// Represents a jigsaw piece.
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// The ID of an individual jigsaw piece.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Keeps track of the cluster ID so that we know which cluster this piece belongs to.
        /// </summary>
        public int ClusterID { get; set; }

        /// <summary>
        /// Used in determining adjacent pieces to snap and combine.
        /// </summary>
        public List<int> AdjacentPieceIDs { get; set; }

        /// <summary>
        /// The width of the rectangular bounds of the StaticFigure.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the rectangular bounds of the StaticFigure.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The location of the piece on the game board.
        /// </summary>
        public Rectangle BoardLocation { get; set; }

        /// <summary>
        /// The location of the source picture from which the piece image is drawn.
        /// </summary>
        public Rectangle SourcePictureLocation { get; set; }

        /// <summary>
        /// The figure which is moved around the board when moving a jigsaw piece/cluster.
        /// </summary>
        public GraphicsPath MovableFigure { get; set; }

        /// <summary>
        /// The figure whose location is based on the source picture's dimensions.
        /// This is used to construct "irregular" jigsaw piece.
        /// </summary>
        public GraphicsPath StaticFigure { get; set; }

        /// <summary>
        /// After constructing the picture for the jigsaw piece, it is stored here.
        /// </summary>
        public Bitmap Picture { get; set; }                          
    }
}
