
module MainWindow

open System 
open System.Windows 
open System.IO
open System.Windows.Markup

open System.Reflection

let mutable this : Window = Utilities.contentAsXamlObject("MainWindow.xaml"):?> Window  // Load XAML -  XAML - MUST be Embedded Resource  ("use just xaml file name")    

[<STAThread>] 
[<EntryPoint>]

do (new Application()).Run(this) |> ignore


 

