
module MainWindow

open System 
open System.Windows 
open System.IO
open System.Windows.Markup
open Utilities

open System.Windows.Controls 

open System.Reflection

let mutable this : Window = Utilities.contentAsXamlObjectFromAssembly(Assembly.GetExecutingAssembly().FullName,"MainWindow.xaml"):?> Window // Load XAML

//Find ShowImage and setup parameter WindowMain <- this
//let mutable ShowImage : MyUserControl.ShowImage = this?ShowImage 

[<STAThread>] 
[<EntryPoint>]

do (new Application()).Run(this) |> ignore


 

