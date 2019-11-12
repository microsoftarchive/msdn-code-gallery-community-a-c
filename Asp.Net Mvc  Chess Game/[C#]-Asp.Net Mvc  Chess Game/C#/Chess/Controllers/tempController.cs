using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chess.Controllers
{
    public class tempController : Controller
    {
        //
        // GET: /temp/

        public ActionResult Index()
        {
            return View();
        }

    }
}

//        public String crossMove(moveC move, properties piece, Int32? stepSize)
//        {
//            String removeID = "";//silinecek taşın id si
//            Boolean isMoveable = false;//taş hareket edebilirmi

//            List<cor> se = new List<cor>();
//            List<properties> ps = new List<properties>();
//            var item = new cor();
//            int x = piece.row;
//            int y = piece.col;

//            if (piece.row != move.row && piece.col != move.col)
//            {
//                if (stepSize == null)
//                {
//                    stepSize = Math.Abs(move.col - piece.col);
//                }
//                else
//                {
//                    if (Math.Abs(piece.row - move.row) != 1 || Math.Abs(piece.col - move.col) != 1)
//                    {
//                        stepSize = 0;
//                    }
//                }
//                if (stepSize != 0)
//                {
//                    for (int i = 1; i <= stepSize; i++)
//                    {
//                        if (move.row > piece.row && move.col > piece.col && x + i <= 8 && y + i <= 8)//x+ y+
//                        {
//                            se.Add(new cor() { col = y + i, row = x + i });
//                        }
//                        if (move.row < piece.row && move.col < piece.col && x - i >= 1 && y - i >= 1)//x- y-
//                        {
//                            se.Add(new cor() { col = y - i, row = x - i });
//                        }
//                        if (move.row > piece.row && move.col < piece.col && x + i <= 8 && y - i >= 1)//x+ y-
//                        {
//                            se.Add(new cor() { col = y - i, row = x + i });
//                        }
//                        if (move.row < piece.row && move.col > piece.col && x - i >= 1 && y + i <= 8)//x- y+
//                        {
//                            se.Add(new cor() { col = y + i, row = x - i });
//                        }
//                    }

//                    foreach (var cross in se)
//                    {
//                        foreach (var pc in listPieces.pieces)
//                        {
//                            if (cross.row == pc.row && cross.col == pc.col)
//                            {
//                                ps.Add(pc);
//                            }
//                        }
//                    }

//                    if (ps.Count == 0 && piece.name != piece.getName.pawn)
//                    {
//                        isMoveable = true;
//                    }

//                    if (ps.Count == 1 && ps[0].color != piece.color)
//                    {
//                        listPieces.pieces.RemoveAll(a => a.id == ps[0].id);//listeden yenen elemanı çıkartıyoruz
//                        removeID = ps[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//                        isMoveable = true;
//                    }

//                    if (isMoveable == true)//hareket kabul edildiyse
//                    {
//                        piece.col = move.col;//kalenin yeni sutun değerini güncelle
//                        piece.row = move.row;//kalenin yeni satır değeri güncelle
//                        piece.isStart = true;// ilk hareket aktif et
//                    }
//                }
//            }
//            return isMoveable + ";" + removeID;
//        }

//        public String directMove(moveC move, properties piece, Int32? stepSize)
//        {
//            String removeID = "";//silinecek taşın id si
//            Boolean isMoveable = false;//taş hareket edebilirmi

//            List<cor> se = new List<cor>();
//            List<properties> ps = new List<properties>();
//            var item = new cor();
//            int x = piece.row;
//            int y = piece.col;

//            if (piece.row == move.row || piece.col == move.col)
//            {
//                if (stepSize == null)//adım sayısı null ise sınır yoktur
//                {
//                    stepSize = Math.Abs(move.col - piece.col) != 0 ? Math.Abs(move.col - piece.col) : Math.Abs(move.row - piece.row);
//                }
//                else
//                {
//                    if (Math.Abs(piece.row - move.row) == stepSize || Math.Abs(piece.row - move.row) == 1)//adım sayısı belirtilir
//                    {
//                        stepSize = Math.Abs(piece.row - move.row);
//                    }
//                    else if (Math.Abs(piece.col - move.col) == stepSize || Math.Abs(piece.col - move.col) == 1) { }
//                    else
//                    {
//                        stepSize = 0;//adımsayısı belirtilen sınırın dışındaysa işlem yapma
//                    }
//                }
//                if (stepSize != 0)
//                {
//                    for (int i = 1; i <= stepSize; i++)//hareket ettiği ekseni bul
//                    {
//                        if (move.row >= piece.row && x + i <= 8 && piece.col == move.col)//x+ 
//                        {
//                            se.Add(new cor() { col = y, row = x + i });
//                        }
//                        if (move.row < piece.row && x - i >= 1 && piece.col == move.col)//x-
//                        {
//                            se.Add(new cor() { col = y, row = x - i });
//                        }
//                        if (move.col >= piece.col && y + i <= 8 && piece.row == move.row)//y+
//                        {
//                            se.Add(new cor() { col = y + i, row = x });
//                        }
//                        if (move.col <= piece.col && y - i >= 1 && piece.row == move.row)//y-
//                        {
//                            se.Add(new cor() { col = y - i, row = x });
//                        }
//                    }

//                    foreach (var direct in se)//hareket ettiği eksende hangi taşlar var
//                    {
//                        foreach (var pc in listPieces.pieces)
//                        {
//                            if (direct.row == pc.row && direct.col == pc.col)
//                            {
//                                ps.Add(pc);
//                            }
//                        }
//                    }

//                    if (ps.Count == 0)//önünde taş yoksa hareket edebilir
//                    {
//                        isMoveable = true;
//                    }

//                    if (ps.Count == 1 && ps[0].color != piece.color && piece.name != piece.getName.pawn)//önünde karşı takımın taşı varsa yenebilirmi
//                    {
//                        listPieces.pieces.RemoveAll(a => a.id == ps[0].id);//listeden yenen elemanı çıkartıyoruz
//                        removeID = ps[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//                        isMoveable = true;
//                    }

//                    if (isMoveable == true)//hareket kabul edildiyse
//                    {
//                        piece.col = move.col;//kalenin yeni sutun değerini güncelle
//                        piece.row = move.row;//kalenin yeni satır değeri güncelle
//                        piece.isStart = true;// ilk hareket aktif et
//                    }
//                }
//            }
//            return isMoveable + ";" + removeID;
//        }
//public String DirectionControl(moveC move, properties piece, Int32? stepSize)
//        {
//            String result = "";

//            if (piece.row == move.row || piece.col == move.col)
//            {
//                result = directMove(move, piece, stepSize);
//            }
//            else
//            {
//                result = crossMove(move, piece, stepSize);
//            }

//            return result;
//        }
//        public String knightControl(moveC move, properties piece, Int32? stepSize)
//        {
//            String removeID = "";//silinecek taşın id si
//            Boolean isMoveable = false;//taş hareket edebilirmi
//            List<cor> se = new List<cor>();
//            List<properties> ps = new List<properties>();
//            var item = new cor();
//            int x = piece.row;
//            int y = piece.col;

//            if (move.col == y + 1 && move.row == x + 2 && x + 2 <= 8 && y + 1 <= 8)//y+1 x+2
//            {
//                se.Add(new cor() { col = y + 1, row = x + 2 });
//            }
//            if (move.col == y + 1 && move.row == x - 2 && x - 2 >= 1 && y + 1 <= 8)//y+1 x-2
//            {
//                se.Add(new cor() { col = y + 1, row = x - 2 });
//            }

//            if (move.col == y + 2 && move.row == x + 1 && x + 1 <= 8 && y + 2 <= 8)//y+2 x+1
//            {
//                se.Add(new cor() { col = y + 2, row = x + 1 });
//            }
//            if (move.col == y + 2 && move.row == x - 1 && x - 1 >= 1 && y + 2 <= 8)//y+2 x-1
//            {
//                se.Add(new cor() { col = y + 2, row = x - 1 });
//            }

//            if (move.col == y - 1 && move.row == x + 2 && x + 2 <= 8 && y - 1 >= 1)//y-1 x+2
//            {
//                se.Add(new cor() { col = y - 1, row = x + 2 });
//            }
//            if (move.col == y - 1 && move.row == x - 2 && x - 2 >= 1 && y - 1 >= 1)//y-1 x-2
//            {
//                se.Add(new cor() { col = y - 1, row = x - 2 });
//            }

//            if (move.col == y - 2 && move.row == x + 1 && x + 1 <= 8 && y - 2 <= 8)//y-2 x+1
//            {
//                se.Add(new cor() { col = y - 2, row = x + 1 });
//            }
//            if (move.col == y - 2 && move.row == x - 1 && x - 1 >= 1 && y - 2 <= 8)//y-2 x-1
//            {
//                se.Add(new cor() { col = y - 2, row = x - 1 });
//            }

//            if (se.Count > 0)
//            {
//                foreach (var Lmove in se)
//                {
//                    foreach (var pc in listPieces.pieces)
//                    {
//                        if (Lmove.row == pc.row && Lmove.col == pc.col)
//                        {
//                            ps.Add(pc);
//                        }
//                    }
//                }

//                if (ps.Count == 0)
//                {
//                    isMoveable = true;
//                }

//                if (ps.Count == 1 && ps[0].color != piece.color)
//                {
//                    listPieces.pieces.RemoveAll(a => a.id == ps[0].id);//listeden yenen elemanı çıkartıyoruz
//                    removeID = ps[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//                    isMoveable = true;
//                }

//                if (isMoveable == true)//hareket kabul edildiyse
//                {
//                    piece.col = move.col;//kalenin yeni sutun değerini güncelle
//                    piece.row = move.row;//kalenin yeni satır değeri güncelle
//                    piece.isStart = true;// ilk hareket aktif et
//                }
//            }
//            return isMoveable + ";" + removeID;
//        }


//public String knightControl(moveC move, properties knight)
//{
//    return "";
//}

//public String spawnControl(moveC move, properties pawn)
//{
//    String result = "";
//    int stepSize = pawn.isStart == true ? 1 : 2;//ilk hareketinde 2 tane adım atabilir
//    Boolean backControl = pawn.color == pawn.getColor.black ? (pawn.row - move.row > 0 ? false : true) : (pawn.row - move.row < 0 ? false : true); //geriye gidebilirmi?
//    result = backControl == true ? DirectionControl(move, pawn, stepSize) : "false;";//geriye gidebilirmi?
//    return result;
//}

//public String rookControl(moveC move, properties rook)
//{
//    String result = "";
//    result = directMove(move, rook, null);
//    return result;
//}

//public String bishopControl(moveC move, properties bishop)
//{
//    String result = "";
//    result = crossMove(move, bishop, null);
//    return result;
//}

//public String queenControl(moveC move, properties queen)
//{
//    String result = "";
//    result = DirectionControl(move, queen, null);
//    return result;
//}

//public String kingControl(moveC move, properties king)
//{
//    String result = "";
//    result = DirectionControl(move, king, 1);
//    return result;
//}


//String removeID = "";//silinecek taşın id si
//Boolean isMoveable = false;//taş hareket edebilirmi
//Boolean isDirection = false;//taş hareket edebilirmi sadece x yada sadece y ekseni hareket kabiliyeti

//var checkXY = listPieces.pieces.Where(pc => (Math.Abs(king.col - move.col) == 0 &&
//                                               Math.Abs(king.row - move.row) == 1 &&
//                                               move.col == pc.col &&
//                                             ((move.row - king.row) > 0 ? (king.row + 1 == pc.row) : (king.row - 1 == pc.row))) ||

//                                            (Math.Abs(king.col - move.col) == 1 &&
//                                               Math.Abs(king.row - move.row) == 0 &&
//                                               move.row == pc.row &&
//                                             ((move.col - king.col) > 0 ? (king.col + 1 == pc.col) : (king.col - 1 == pc.col))) ||

//                                            (Math.Abs(king.col - move.col) == 1 &&
//                                               Math.Abs(king.row - move.row) == 1 &&
//                                               ((move.col - king.col) > 0 ? (king.col + 1 == pc.col) && ((king.row + 1 == pc.row) || (king.row - 1 == pc.row)) :
//                                                                            (king.col - 1 == pc.col) && ((king.row - 1 == pc.row) || (king.row + 1 == pc.row))) &&
//                                               ((move.row - king.row) > 0 ? (king.row + 1 == pc.row) && ((king.col + 1 == pc.col) || (king.col - 1 == pc.col)) :
//                                                                            (king.row - 1 == pc.row) && ((king.col - 1 == pc.col) || (king.col + 1 == pc.col))))

//    ).ToList();

//if (checkXY.Count == 0 && ((Math.Abs(move.col - king.col) == 1 && Math.Abs(move.row - king.row) == 0) ||
//                             (Math.Abs(move.col - king.col) == 0 && Math.Abs(move.row - king.row) == 1) ||
//                             (Math.Abs(move.col - king.col) == 1 && Math.Abs(move.row - king.row) == 1)))
//{
//    isMoveable = true;
//}
//if (checkXY.Count == 1 && king.color != checkXY[0].color)//eğer kalenin önünde diğer oyuncunun taşı varsa yiyebilir
//{
//    listPieces.pieces.RemoveAll(a => a.id == checkXY[0].id);//listeden yenen elemanı çıkartıyoruz
//    removeID = checkXY[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//    isMoveable = true;
//}
//if (isMoveable == true)//hareket kabul edildiyse
//{
//    king.col = move.col;//kalenin yeni sutun değerini güncelle
//    king.row = move.row;//kalenin yeni satır değeri güncelle
//    king.isStart = true;// ilk hareket aktif et
//}


//return isMoveable + ";" + removeID;






//String removeID = "";//silinecek taşın id si
//Boolean isMoveable = false;//taş hareket edebilirmi
//Boolean isDirection = false;//taş hareket edebilirmi sadece x yada sadece y ekseni hareket kabiliyeti

//var checkXY = listPieces.pieces.Where(pc => (pc.row == rook.row || pc.col == rook.col) &&
//                                          (((move.col - rook.col) > 0 ? (rook.col < pc.col && pc.col <= move.col) : (rook.col > pc.col && pc.col >= move.col)) ||
//                                           ((move.row - rook.row) > 0 ? (rook.row < pc.row && pc.row <= move.row) : (rook.row > pc.row && pc.row >= move.row)))).ToList();

//if (rook.row == move.row || rook.col == move.col) isDirection = true;//x eksenindemi hareket ediyor y eksenindemi hareket ediyor

//if (isDirection == true)//eğer sadece x yada sadece y ekseninde hareket ediyorsa
//{
//    if (checkXY.Count == 0)// kalenin önünde taş yoksa hareket edebilir
//    {
//        isMoveable = true;
//    }
//    if (checkXY.Count == 1 && rook.color != checkXY[0].color)//eğer kalenin önünde diğer oyuncunun taşı varsa yiyebilir
//    {
//        listPieces.pieces.RemoveAll(a => a.id == checkXY[0].id);//listeden yenen elemanı çıkartıyoruz
//        removeID = checkXY[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//        isMoveable = true;
//    }
//    if (isMoveable == true)//hareket kabul edildiyse
//    {
//        rook.col = move.col;//kalenin yeni sutun değerini güncelle
//        rook.row = move.row;//kalenin yeni satır değeri güncelle
//        rook.isStart = true;// ilk hareket aktif et
//    }
//}

//return isMoveable + ";" + removeID;



//String removeID = "";//silinecek taşın id si
//          Boolean isMoveable = false;//taş hareket edebilirmi

//          int rowDiff = move.row - pawn.row;
//          int rowDiffAbs = Math.Abs(pawn.row - move.row);
//          int colDiffAbs = Math.Abs(pawn.col - move.col);


//          Boolean checkFirst = (pawn.isStart == false && rowDiffAbs == 2 && colDiffAbs == 0);//first move  control
//          Boolean checkStep = (rowDiffAbs == 1 && colDiffAbs == 0);//move  control max step size 1 step
//          Boolean checkBack = ((pawn.color == pawn.getColor.black && (rowDiff < 0)) ||
//                              (pawn.color == pawn.getColor.white && (rowDiff > 0)));//move back control
//          Boolean checkFront = ((from pawns in listPieces.pieces select pawns).Where(pwn => pwn.row == move.row &&
//                                                                                           pwn.col == move.col).FirstOrDefault() != null);//önünde taş varsa gidemez
//          var checkCross = (from pawns in listPieces.pieces select pawns).Where(pwn => ((pwn.row == pawn.row - 1) || (pwn.row == pawn.row + 1)) &&
//                                                                                       ((pwn.col == pawn.col - 1) || (pwn.col == pawn.col + 1)) &&
//                                                                                        (pwn.col == move.col && pwn.row == move.row) &&
//                                                                                        (pwn.color != pawn.color)).FirstOrDefault();//çaprazında taş varsa yiyebilir

//          Boolean checkX = ((pawn.col < move.col || pawn.col > move.col) && pawn.row == move.row);//check if the columns is moving
//          Boolean checkY = ((pawn.row < move.row || pawn.row > move.row) && pawn.col == move.col);//check if the rows is moving


//          if (checkY)//eğer hareket sadece sütünda oluyarsa
//          {
//              if (checkBack)//geriye gidemez
//              {
//                  isMoveable = false;
//              }
//              else if (checkFront)//önünde taşvarsa gidemez
//              {
//                  isMoveable = false;
//              }
//              else if (checkFirst) //taşın ilk hareketimi(ilk hareketi ise 2 adım atabilir)
//              {
//                  isMoveable = true;
//              }
//              else if (checkStep) // adım sayısı 1 olabilir
//              {
//                  isMoveable = true;
//              }
//          }
//          else if (checkX)//eğer hareket sadece satırda oluyorsa
//          {
//          }
//          else//eğer hareket hem sütünda hemde satırda oluyorsa
//          {
//              if (checkBack)//geriye gidemez
//              {
//                  isMoveable = false;
//              }
//              else if (checkCross != null) // move  control && checkCross.col == move.col && checkCross.row == move.row && checkCross.color != pawn.color
//              {
//                  listPieces.pieces.RemoveAll(a => a.id == checkCross.id);//listeden yenen elemanı çıkartıyoruz
//                  removeID = checkCross.id;//client tarafta silinecek olan taşın id  sini gönderiyoruz
//                  isMoveable = true;
//              }
//          }

//          if (isMoveable == true)
//          {
//              pawn.col = move.col;
//              pawn.row = move.row;
//              pawn.isStart = true;//ilk hareket aktif et
//          }
//          return isMoveable + ";" + removeID;


//var checkXY = listPieces.pieces.Where(pc => ((pc.row == queen.row || pc.col == queen.col) &&
//                                             (((move.col - queen.col) > 0 ? (queen.col < pc.col && pc.col <= move.col) : (queen.col > pc.col && pc.col >= move.col)) ||
//                                             ((move.row - queen.row) > 0 ? (queen.row < pc.row && pc.row <= move.row) : (queen.row > pc.row && pc.row >= move.row)))) ||

//                                            ((pc.row == queen.row++ && pc.col == queen.col++) &&
//                                             (((move.col - queen.col) > 0 ? (queen.col < pc.col && pc.col <= move.col) : (queen.col > pc.col && pc.col >= move.col)) ||
//                                             ((move.row - queen.row) > 0 ? (queen.row < pc.row && pc.row <= move.row) : (queen.row > pc.row && pc.row >= move.row))))

//    ).ToList();
//(pc.row == queen.row-- && pc.col == queen.col++) ||
//                                             (pc.row == queen.row++ && pc.col == queen.col--) ||
//                                             (pc.row == queen.row-- && pc.col == queen.col--)


//if (checkXY.Count == 0)
//{
//    isMoveable = true;
//}
//if (checkXY.Count == 1 && queen.color != checkXY[0].color)//eğer kalenin önünde diğer oyuncunun taşı varsa yiyebilir
//{
//    listPieces.pieces.RemoveAll(a => a.id == checkXY[0].id);//listeden yenen elemanı çıkartıyoruz
//    removeID = checkXY[0].id;//client tarafta silinecek olan taşın id  sini gönderiyoruz     
//    isMoveable = true;
//}


//var checkCross = listPieces.pieces.Where(pc => Math.Abs(king.col - move.col) == 1 &&
//                                               Math.Abs(king.row - move.row) == 1 &&
//                                           ((move.col - king.col) > 0 ? (king.col + 1 == pc.col) && ((king.row + 1 == pc.row) || (king.row - 1 == pc.row)) : (king.col - 1 == pc.col) && ((king.row - 1 == pc.row) || (king.row + 1 == pc.row))) &&
//                                           ((move.row - king.row) > 0 ? (king.row + 1 == pc.row) && ((king.col + 1 == pc.col) || (king.col - 1 == pc.col)) : (king.row - 1 == pc.row) && ((king.col - 1 == pc.col) || (king.col + 1 == pc.col))))
//    ).ToList();

//var checkY = listPieces.pieces.Where(pc => Math.Abs(king.col - move.col) == 0 &&
//                                             Math.Abs(king.row - move.row) == 1 &&
//                                             move.col == pc.col &&
//                                             ((move.row - king.row) > 0 ? (king.row + 1 == pc.row) : (king.row - 1 == pc.row))
//                                             ).ToList();

//var checkX = listPieces.pieces.Where(pc => Math.Abs(king.col - move.col) == 1 &&
//                                           Math.Abs(king.row - move.row) == 0 &&
//                                           move.row == pc.row &&
//                                          ((move.col - king.col) > 0 ? (king.col + 1 == pc.col) : (king.col - 1 == pc.col))
//                                             ).ToList();




//var checkX = (from pc in listPieces.pieces where pc.row == rook.row select pc).Where(pc => (move.col - rook.col) > 0 ? (rook.col < pc.col && pc.col <= move.col) : (rook.col > pc.col && pc.col >= move.col)).ToList();
//var checkY = (from pc in listPieces.pieces where pc.col == rook.col select pc).Where(pc => (move.row - rook.row) > 0 ? (rook.row < pc.row && pc.row <= move.row) : (rook.row > pc.row && pc.row >= move.row)).ToList();
//var checkY = (from pc in listPieces.pieces select pc).Where(pc => (pc.col == rook.col)).ToList();//y cor taşlar 
//var checkEnemy = (from pc in listPieces.pieces select pc).Where(pc => (pc.col == move.col) && (pc.row == move.row)).FirstOrDefault();//eğer hareket edilen yerde taşvarsa  rengi


//if (checkEnemy != null)
//{
//    if (checkEnemy.color != rook.color)
//    {
//        if (rook.col == move.col)
//        {
//            if (move.row - rook.row > 0)
//            {
//                for (int i = rook.row + 1; i < move.row; i++)
//                {
//                    foreach (var item in checkY)
//                    {
//                        if (item.row == i)
//                        {
//                            isMoveable = false;
//                            isbreak = true;
//                            break;
//                        }
//                    }
//                    if (isbreak = true)
//                    {
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                for (int i = rook.row - 1; i >= move.row; i--)
//                {
//                    foreach (var item in checkY)
//                    {
//                        if (item.row == i)
//                        {
//                            isMoveable = false;
//                            isbreak = true;
//                            break;
//                        }
//                    }
//                    if (isbreak = true)
//                    {
//                        break;
//                    }
//                }
//            }

//        }
//        if (rook.row == move.row)
//        {
//            if (move.col - rook.col > 0)
//            {
//                for (int i = rook.col + 1; i <= move.col; i++)
//                {
//                    foreach (var item in checkX)
//                    {
//                        if (item.col == i)
//                        {
//                            isMoveable = false;
//                            isbreak = true;
//                            break;
//                        }
//                    }
//                    if (isbreak == true)
//                    {
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                for (int i = rook.col - 1; i >= move.col; i--)
//                {
//                    foreach (var item in checkX)
//                    {
//                        if (item.col == i)
//                        {
//                            isMoveable = false;
//                            isbreak = true;
//                            break;
//                        }
//                    }
//                    if (isbreak = true)
//                    {
//                        break;
//                    }
//                }
//            }
//        }
//    }
//}



//Boolean checkX = ((pawn.col < move.col || pawn.col > move.col) && pawn.row == move.row);//check if the columns is moving
//Boolean checkY = ((pawn.row < move.row || pawn.row > move.row) && pawn.col == move.col);//check if the rows is moving


//if (checkY)//eğer hareket sadece sütünda oluyarsa
//{
//    if (checkFront)//önünde taşvarsa gidemez
//    {
//        isMoveable = false;
//    }
//}
//else if (checkX)//eğer hareket sadece satırda oluyorsa
//{

//}
//else//eğer hareket hem sütünda hemde satırda oluyorsa
//{
//    if (checkBack)//geriye gidemez
//    {
//        isMoveable = false;
//    }
//    else if (checkCross != null) // move  control && checkCross.col == move.col && checkCross.row == move.row && checkCross.color != pawn.color
//    {
//        listPieces.pieces.RemoveAll(a => a.id == checkCross.id);//listeden yenen elemanı çıkartıyoruz
//        removeID = checkCross.id;//client tarafta silinecek olan taşın id  sini gönderiyoruz
//        isMoveable = true;
//    }
//}