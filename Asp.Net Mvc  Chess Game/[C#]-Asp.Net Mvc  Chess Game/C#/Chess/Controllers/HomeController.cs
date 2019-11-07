using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chess.Helpers;
using Chess.Models;

namespace Chess.Controllers
{
    public class HomeController : Controller
    {
        public static chessModel listPieces = new chessModel();
        public static List<ColRowHistory> coorhistory = new List<ColRowHistory>();

        public class cor
        {
            public int col { get; set; }
            public int row { get; set; }
        }

        public ActionResult Index()
        {
            //ilk önce siyah taşları diz
            listPieces.pieces.Clear();
            int x1 = 2, x2 = 1;//black pieces
            String color = "Black";

            for (int j = 0; j < 2; j++)
            {
                if (j == 1)// ikinci olarak beyaz taşları diz
                {
                    x1 = 7;//7.satıra taşları diz
                    x2 = 8;//8.satra taşları diz
                    color = "White";
                }

                for (int i = 1; i <= 8; i++)
                {
                    pieces Pieces = new pieces();//pawn
                    Pieces.pawn.col = i;
                    Pieces.pawn.id = i.ToString() + color + Pieces.pawn.name;
                    Pieces.pawn.row = x1;
                    Pieces.pawn.color = color;
                    listPieces.pieces.Add(Pieces.pawn);

                    switch (i)
                    {
                        case 1://rook
                            {
                                Pieces = new pieces();
                                Pieces.rook.id = i.ToString() + color + Pieces.rook.name;
                                Pieces.rook.col = i;
                                Pieces.rook.row = x2;
                                Pieces.rook.color = color;
                                listPieces.pieces.Add(Pieces.rook);
                                break;
                            }
                        case 2://knight
                            {
                                Pieces = new pieces();
                                Pieces.knight.id = i.ToString() + color + Pieces.knight.name;
                                Pieces.knight.col = i;
                                Pieces.knight.row = x2;
                                Pieces.knight.color = color;
                                listPieces.pieces.Add(Pieces.knight); break;
                            }
                        case 3://bishop
                            {
                                Pieces = new pieces();
                                Pieces.bishop.id = i.ToString() + color + Pieces.bishop.name;
                                Pieces.bishop.col = i;
                                Pieces.bishop.row = x2;
                                Pieces.bishop.color = color;
                                listPieces.pieces.Add(Pieces.bishop); break;
                            }
                        case 4://queen
                            {
                                Pieces = new pieces();
                                Pieces.queen.id = i.ToString() + color + Pieces.queen.name;
                                Pieces.queen.col = i;
                                Pieces.queen.row = x2;
                                Pieces.queen.color = color;
                                listPieces.pieces.Add(Pieces.queen); break;
                            }
                        case 5://king
                            {
                                Pieces = new pieces();
                                Pieces.king.id = i.ToString() + color + Pieces.king.name;
                                Pieces.king.col = i;
                                Pieces.king.row = x2;
                                Pieces.king.color = color;
                                listPieces.pieces.Add(Pieces.king); break;
                            }
                        case 6://bishop
                            {
                                Pieces = new pieces();
                                Pieces.bishop.id = i.ToString() + color + Pieces.bishop.name;
                                Pieces.bishop.col = i;
                                Pieces.bishop.row = x2;
                                Pieces.bishop.color = color;
                                listPieces.pieces.Add(Pieces.bishop); break;
                            }
                        case 7://knight
                            {
                                Pieces = new pieces();
                                Pieces.knight.id = i.ToString() + color + Pieces.knight.name;
                                Pieces.knight.col = i;
                                Pieces.knight.row = x2;
                                Pieces.knight.color = color;
                                listPieces.pieces.Add(Pieces.knight); break;
                            }
                        case 8://rook
                            {
                                Pieces = new pieces();
                                Pieces.rook.id = i.ToString() + color + Pieces.rook.name;
                                Pieces.rook.col = i;
                                Pieces.rook.row = x2;
                                Pieces.rook.color = color;
                                listPieces.pieces.Add(Pieces.rook); break;
                            }
                    }
                }
            }

            //foreach (var pieces in listPieces.pieces)
            //{
            //    coorhistory.Add(new ColRowHistory
            //    {
            //        id = pieces.id,
            //        col = pieces.col,
            //        row = pieces.row
            //    });
            //}

            return View(listPieces);
        }
        
        public String OControl(moveC move, properties piece, Int32? stepSize, String Direction)
        {
            String removeID = "";//silinecek taşın id si
            Boolean isMoveable = false;//taş hareket edebilirmi
            List<cor> se = new List<cor>();
            List<properties> ps = new List<properties>();
            var item = new cor();
            int x = piece.row;
            int y = piece.col;

            switch (Direction)
            {
                case "direct":
                    {
                        if (piece.row != move.row && piece.col != move.col) break;

                        if (stepSize == null)//adım sayısı null ise sınır yoktur
                        {
                            stepSize = Math.Abs(move.col - piece.col) != 0 ? Math.Abs(move.col - piece.col) : Math.Abs(move.row - piece.row);
                        }
                        else
                        {
                            if (Math.Abs(piece.row - move.row) == stepSize || Math.Abs(piece.row - move.row) == 1)//adım sayısı belirtilir
                            {
                                stepSize = Math.Abs(piece.row - move.row);
                            }
                            else if (Math.Abs(piece.col - move.col) == stepSize || Math.Abs(piece.col - move.col) == 1)
                            {
                                stepSize = Math.Abs(piece.col - move.col);
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int i = 1; i <= stepSize; i++)//hareket ettiği ekseni bul
                        {
                            if (move.row >= piece.row && x + i <= 8 && piece.col == move.col)//x+ 
                            {
                                se.Add(new cor() { col = y, row = x + i });
                            }
                            if (move.row < piece.row && x - i >= 1 && piece.col == move.col)//x-
                            {
                                se.Add(new cor() { col = y, row = x - i });
                            }
                            if (move.col >= piece.col && y + i <= 8 && piece.row == move.row)//y+
                            {
                                se.Add(new cor() { col = y + i, row = x });
                            }
                            if (move.col <= piece.col && y - i >= 1 && piece.row == move.row)//y-
                            {
                                se.Add(new cor() { col = y - i, row = x });
                            }
                        }

                        break;
                    }
                case "cross":
                    {
                        if (piece.row == move.row || piece.col == move.col) break;

                        if (stepSize == null)
                        {
                            stepSize = Math.Abs(move.col - piece.col);
                        }
                        else
                        {
                            if (Math.Abs(piece.row - move.row) != 1 || Math.Abs(piece.col - move.col) != 1)
                            {
                                break;
                            }
                        }

                        for (int i = 1; i <= stepSize; i++)
                        {
                            if (move.row > piece.row && move.col > piece.col && x + i <= 8 && y + i <= 8)//x+ y+
                            {
                                se.Add(new cor() { col = y + i, row = x + i });
                            }
                            if (move.row < piece.row && move.col < piece.col && x - i >= 1 && y - i >= 1)//x- y-
                            {
                                se.Add(new cor() { col = y - i, row = x - i });
                            }
                            if (move.row > piece.row && move.col < piece.col && x + i <= 8 && y - i >= 1)//x+ y-
                            {
                                se.Add(new cor() { col = y - i, row = x + i });
                            }
                            if (move.row < piece.row && move.col > piece.col && x - i >= 1 && y + i <= 8)//x- y+
                            {
                                se.Add(new cor() { col = y + i, row = x - i });
                            }
                        }
                        break;
                    }
                case "L":
                    {
                        if (move.col == y + 1 && move.row == x + 2 && x + 2 <= 8 && y + 1 <= 8)//y+1 x+2
                        {
                            se.Add(new cor() { col = y + 1, row = x + 2 });
                        }
                        if (move.col == y + 1 && move.row == x - 2 && x - 2 >= 1 && y + 1 <= 8)//y+1 x-2
                        {
                            se.Add(new cor() { col = y + 1, row = x - 2 });
                        }

                        if (move.col == y + 2 && move.row == x + 1 && x + 1 <= 8 && y + 2 <= 8)//y+2 x+1
                        {
                            se.Add(new cor() { col = y + 2, row = x + 1 });
                        }
                        if (move.col == y + 2 && move.row == x - 1 && x - 1 >= 1 && y + 2 <= 8)//y+2 x-1
                        {
                            se.Add(new cor() { col = y + 2, row = x - 1 });
                        }

                        if (move.col == y - 1 && move.row == x + 2 && x + 2 <= 8 && y - 1 >= 1)//y-1 x+2
                        {
                            se.Add(new cor() { col = y - 1, row = x + 2 });
                        }
                        if (move.col == y - 1 && move.row == x - 2 && x - 2 >= 1 && y - 1 >= 1)//y-1 x-2
                        {
                            se.Add(new cor() { col = y - 1, row = x - 2 });
                        }

                        if (move.col == y - 2 && move.row == x + 1 && x + 1 <= 8 && y - 2 <= 8)//y-2 x+1
                        {
                            se.Add(new cor() { col = y - 2, row = x + 1 });
                        }
                        if (move.col == y - 2 && move.row == x - 1 && x - 1 >= 1 && y - 2 <= 8)//y-2 x-1
                        {
                            se.Add(new cor() { col = y - 2, row = x - 1 });
                        }
                        break;
                    }
                default:
                    break;
            }

            foreach (var direct in se)//hareket ettiği eksende hangi taşlar var
            {
                foreach (var pc in listPieces.pieces)
                {
                    if (direct.row == pc.row && direct.col == pc.col)
                    {
                        ps.Add(pc);
                    }
                }
            }

            if (se.Count > 0)
            {
                if (ps.Count == 0)//önünde taş yoksa hareket edebilir
                {
                    if (Direction == "cross" && piece.name == piece.getName.pawn)
                    { }
                    else
                    {
                        isMoveable = true;
                    }
                }

                if (ps.Count == 1 && ps[0].color != piece.color)//önünde karşı takımın taşı varsa yenebilirmi
                {
                    if (Direction == "direct" && piece.name == piece.getName.pawn)
                    { }
                    else
                    {
                        listPieces.pieces.RemoveAll(a => a.id == ps[0].id);//listeden yenen elemanı çıkartıyoruz
                        removeID = ps[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
                        isMoveable = true;
                    }
                }

                if (isMoveable == true)//hareket kabul edildiyse
                {
                    piece.col = move.col;//kalenin yeni sutun değerini güncelle
                    piece.row = move.row;//kalenin yeni satır değeri güncelle
                    piece.isStart = true;// ilk hareket aktif et
                }
            }

            return isMoveable + ";" + removeID;
        }
        
        public JsonResult moveControl(moveC move)
        {
            var piece = (from pc in listPieces.pieces where pc.id == move.id select pc).FirstOrDefault();
            string result = "", Direction = "";

            Direction = (piece.row == move.row || piece.col == move.col) ? "direct" : "cross";

            switch (piece.name)
            {
                case "pawn"://
                    {
                        int stepSize = piece.isStart == true ? 1 : 2;//ilk hareketinde 2 tane adım atabilir
                        Boolean backControl = piece.color == piece.getColor.black ? (piece.row - move.row > 0 ? false : true)
                                                                                  : (piece.row - move.row < 0 ? false : true); //geriye gidebilirmi?
                        result = backControl == true ? OControl(move, piece, stepSize, Direction) : "false;";//geriye gidebilirmi?                                               
                        break;
                    }
                case "rook"://sadece x-y ekseninde hareket edebilir
                    {
                        result = OControl(move, piece, null, "direct");
                        break;
                    }
                case "knight"://L iki ileri-geri  bir sağa-sola hareket edebilir
                    {
                        result = OControl(move, piece, null, "L");
                        break;
                    }
                case "bishop"://sadece çapraz hareket edebilir
                    {
                        result = OControl(move, piece, null, "cross");
                        break;
                    }
                case "queen"://her yöne hareket edebilir
                    {
                        result = OControl(move, piece, null, Direction);
                        break;
                    }
                case "king"://heryöne hareket edebilir
                    {
                        result = OControl(move, piece, 1, Direction);
                        break;
                    }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}