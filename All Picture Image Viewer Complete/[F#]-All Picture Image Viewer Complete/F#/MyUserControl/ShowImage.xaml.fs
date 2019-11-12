namespace MyUserControl

open System
open System.Windows
open System.Windows.Controls
open System.IO
open System.Drawing
open System.Windows.Markup
open System.Reflection
open System.Windows.Media
open System.Windows.Media.Imaging

open ImageNameSpace
open Utilities 


type ShowImage() as this  = 
    inherit UserControl() 

    do this.Content <- Utilities.contentAsXamlObject("ShowImage.xaml"):?> UserControl // Load XAML

    // FIND ALL OBJECTS IN THIS.CONTENT 

    let mutable canvasMain : Canvas = (this.Content)?canvasMain  
    let mutable lblDrop : Label = (this.Content)?lblDrop   
    let mutable chkUniformToFill: CheckBox = (this.Content)?chkUniformToFill
    let mutable image : ImgWrapper = {Bitmap = null ; BitmapImage = null }
    let img = new Img()   // ImageNameSpace

    let openFiles(e : DragEventArgs) = let data = e.Data
                                       let files  = data.GetData(DataFormats.FileDrop) :?> string[] 
                                       match files.GetLength(0) with
                                       | 1 -> lblDrop.Content <- ""

                                              try do image <- img.Load(files.[0])
                                                  let mutable br = new ImageBrush(image.BitmapImage) 
                                                 
                                                  let testNull (x : _ Nullable) = if x.HasValue then x.Value else false
                                                 
                                                  match testNull(chkUniformToFill.IsChecked) with
                                                  | true  -> br.Stretch <- Stretch.UniformToFill
                                                  | false -> br.Stretch <- Stretch.Fill
                                                  
                                                  canvasMain.Background <- br :> Brush
 
                                              with | _ -> lblDrop.Content <- "IT IS NOT AN IMAGE"

                                       | _ -> lblDrop.Content <- "PLESE DROP ONLY ONE FILE" 

    
    let reLoadImage () = if (isNull image.BitmapImage) 
                         then ignore()
                         else
                             let mutable br = new ImageBrush(image.BitmapImage)                                           
                             let testNull (x : _ Nullable) = if x.HasValue then x.Value else false                                                
                             match testNull(chkUniformToFill.IsChecked) with
                             | true  -> br.Stretch <- Stretch.UniformToFill
                             | false -> br.Stretch <- Stretch.Fill                                                  
                             canvasMain.Background <- br :> Brush

                                                                  

    do chkUniformToFill.Click.Add(fun e ->reLoadImage ())
    do canvasMain.Drop.Add(fun e -> openFiles(e))  
 
                                





