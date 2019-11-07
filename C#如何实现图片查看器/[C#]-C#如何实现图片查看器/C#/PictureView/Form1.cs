using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace 图片查看器
{
    public partial class Form1 : Form
    {
        // 保存打开图片的路径
        string imgPath = null;
        Image newbitmap = null;
        // 打开图片的目录
        string directory = null;

        // 目录下的图片集合
        List<string> imgArray = null;
        bool isRotate = false;

        public Form1()
        {
            InitializeComponent();

            // 必须先打开图片，旋转按钮才可以用
            btnClockwiseRotate.Visible = false;
            btncounterclockwiseRotate.Visible = false;
            btnPre.Visible = false;
            btnNext.Visible = false;
        }

        // 打开图片
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "图片文件(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png|(All file(*.*)|*.*";
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    picBoxView.SizeMode = PictureBoxSizeMode.Zoom;
                    imgPath = fileDialog.FileName;
                    // 初始化图片集合
                    directory = Path.GetDirectoryName(imgPath);
                    imgArray = ImageManager.GetImgCollection(directory);

                    newbitmap=(Bitmap)Image.FromFile(imgPath);
                    picBoxView.Image =newbitmap ;
                }

                btnClockwiseRotate.Visible = true;
                btncounterclockwiseRotate.Visible = true;
                btnPre.Visible = true;
                btnNext.Visible = true;
            }
        }

        // 顺时针旋转90度旋转图片
        private void btnRotate_Click(object sender, EventArgs e)
        {
            picBoxView.SizeMode = PictureBoxSizeMode.Zoom;
                       
            // 顺时针旋转90度的另外一种实现
            newbitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picBoxView.Image = newbitmap;
            isRotate = true;
            //newbitmap = (Image)ImageManager.RotateImg(bitmap, 90f, Color.Transparent); ;
            //picBoxView.Image = newbitmap;
        }
       
        // 关闭窗体后保存旋转后的图片到文件中
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgPath == null || isRotate == false)
            {
                return;
            }

            switch (Path.GetExtension(imgPath).ToLower())
            {
                case ".png":          
                    newbitmap.Save(imgPath, ImageFormat.Png);
                    newbitmap.Dispose();
                    break;
                case ".jpg":
                    newbitmap.Save(imgPath, ImageFormat.Jpeg);
                    newbitmap.Dispose();
                    break;
                default:
                    newbitmap.Save(imgPath, ImageFormat.Bmp);
                    newbitmap.Dispose();
                    break;
            }
        }

        // 逆时针旋转90度
        private void btncounterclockwiseRotate_Click(object sender, EventArgs e)
        {
            picBoxView.SizeMode = PictureBoxSizeMode.Zoom;

            // 逆时针旋转90度的另外实现
            newbitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            picBoxView.Image = newbitmap;
            isRotate = true;
            //newbitmap = (Image)ImageManager.RotateImg(bitmap, 360f-90f, Color.Transparent); 
            //picBoxView.Image = newbitmap;
        }

        // 上一张图片
        private void btnPre_Click(object sender, EventArgs e)
        {
            int index = GetIndex(imgPath);
            // 释放上一张图片的资源，避免保存的时候出现ExternalException异常
            newbitmap.Dispose();
            if (index == 0)
            {
                SwitchImg(imgArray.Count - 1);
            }
            else
            {
                SwitchImg(index - 1);
            }
        }

        // 下一张图片
        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = GetIndex(imgPath);
            // 释放上一张图片的资源，避免保存的时候出现ExternalException异常
            newbitmap.Dispose();
            if (index != imgArray.Count - 1)
            {
                SwitchImg(index + 1);
            }
            else
            {
                SwitchImg(0);
            }
        }

        // 获得打开图片在图片集合中的索引
        private int GetIndex(string imagepath)
        {
            int index = 0;    
            for (int i = 0; i < imgArray.Count; i++)
            {
                if (imgArray[i].Equals(imagepath))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        // 切换图片的方法
        private void SwitchImg(int index)
        {       
            newbitmap = Image.FromFile(imgArray[index]);
            picBoxView.Image = newbitmap;
            imgPath = imgArray[index];
        }
    }
}
