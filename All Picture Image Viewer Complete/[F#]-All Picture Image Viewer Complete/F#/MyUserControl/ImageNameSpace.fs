namespace ImageNameSpace

open System.Windows.Media.Imaging
open System.Drawing
open System
open System.IO
open System.Drawing.Imaging
open System.Windows
open System.Windows.Media
open System.Windows.Interop
open System.Runtime.InteropServices

/// Base on msdn project  https://code.msdn.microsoft.com/windowsdesktop/F-WPF-image-cropper-app-6febcce3

type ImgWrapper = { Bitmap : Bitmap ; BitmapImage : BitmapImage }

type Img ()  =       
    
    let mutable image : ImgWrapper = {Bitmap = null ; BitmapImage = null }
    
    let load path = 
        { Bitmap = Bitmap.FromFile(path) :?> Bitmap
          BitmapImage = BitmapImage(Uri(path)) }
   
    let save (path : string) = image.Bitmap.Save(path, image.Bitmap.RawFormat)   

    let imgWrapperBitmap ( newBmp : Bitmap) = 
        let newBmpImg = 
            use stream = new MemoryStream()
            newBmp.Save(stream, ImageFormat.Png)
            stream.Position <- 0L
            let result = BitmapImage()
            result.BeginInit()
            result.StreamSource <- stream
            result.CacheOption <- BitmapCacheOption.OnLoad
            result.EndInit()
            result
        { Bitmap = newBmp
          BitmapImage = newBmpImg }

    let imgWrapperBitmapImage (bitmapImage : BitmapImage) = 
        let newBitmapImage =  new Bitmap(bitmapImage.StreamSource)  
        { Bitmap = newBitmapImage
          BitmapImage = bitmapImage }   
   


    member z.Load (path) = load path
    member z.Save (path) = save (path) 

    member z.Image with get() = image and set(v) = image <- v   
    member z.ImgWrapperBitmap with get() = image.Bitmap and
                                   set(v) = image <- imgWrapperBitmap(v)
    member z.ImgWrapperBitmapImage with get() = image.BitmapImage and 
                                        set(v) = image <- imgWrapperBitmapImage (v)
      