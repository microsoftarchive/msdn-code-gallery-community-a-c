using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Helpers
{
    public class Chess
    {
    }

    public class pieces
    {
        properties p = new properties();

        public properties rook
        {
            get
            {
                p.name = p.getName.rook;
                return p;
            }
        }

        public properties knight
        {
            get
            {
                p.name = p.getName.knight;
                return p;
            }
        }

        public properties bishop
        {
            get
            {
                p.name = p.getName.bishop;
                return p;
            }
        }

        public properties queen
        {
            get
            {
                p.name = p.getName.queen;
                return p;
            }
        }

        public properties king
        {
            get
            {
                p.name = p.getName.king;
                return p;
            }
        }

        public properties pawn
        {
            get
            {
                p.name = p.getName.pawn;
                return p;
            }
        }
    }

    public class properties
    {
        name n = new name();
        color c = new color();

        public name getName { get { return n; } }
        public String name { get; set; }
        public color getColor { get { return c; } }
        public String color { get; set; }
        public Int32 row { get; set; }
        public Int32 col { get; set; }
        public String id { get; set; }
        public Boolean isStart { get; set; }
    }

    public class color
    {
        public String black { get { return "Black"; } }
        public String white { get { return "White"; } }
    }

    public class name
    {
        public String rook { get { return "rook"; } }
        public String knight { get { return "knight"; } }
        public String bishop { get { return "bishop"; } }
        public String queen { get { return "queen"; } }
        public String king { get { return "king"; } }
        public String pawn { get { return "pawn"; } }
    }

    public class ColRowHistory {
        public String id { get; set; }
        public Int32 row { get; set; }
        public Int32 col { get; set; }
    }

    public class moveC
    {
        public String id { get; set; }
        public String target { get; set; }
        public Int32 row { get; set; }
        public Int32 col { get; set; }
    }
}