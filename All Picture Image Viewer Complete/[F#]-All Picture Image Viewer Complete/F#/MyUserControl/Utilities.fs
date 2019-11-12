
// This modul must be internal and must exist in all assemblies.

module Utilities

open System.Windows
open System.Windows.Controls
open System.Reflection

open System.IO
open System.Windows.Markup

// to bind to Xaml components in code-behind, see example below

let (?) (c:obj) (s:string) =
    match c with
    | :? ResourceDictionary as r ->  r.[s] :?> 'T
    | :? Control as c -> c.FindName(s) :?> 'T
    | _ -> failwith "dynamic lookup failed"

// strXamlName - MUST be Embedded Resource  - this function must be in same Assembly
// XAML - MUST be Embedded Resource  ("use just xaml file name" as parameter)  
let contentAsXamlObject (strXamlName : string) =   
    let res = Assembly.GetExecutingAssembly().GetManifestResourceNames() |> Array.filter(fun x -> x.ToLower().IndexOf(strXamlName.ToLower()) > -1)
    match res.Length = 1 with
    | true -> let mySr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(res.[0]))
              XamlReader.Load(mySr.BaseStream)
    | false -> null


// strXamlName - MUST be Embedded Resource  - this function must be in same Assembly
// XAML - MUST be Embedded Resource  ("use just xaml file name" as parameter)  
let contentAsXamlObjectFromAssembly (assemblyName : string, xamlFilelName : string) =   
    let assembly = Assembly.Load(assemblyName) 
    let res = assembly.GetManifestResourceNames() |> Array.filter(fun x -> x.ToLower().IndexOf(xamlFilelName.ToLower()) > -1)
    match res.Length = 1 with
    | true -> let mySr = new StreamReader(assembly.GetManifestResourceStream(res.[0]))
              XamlReader.Load(mySr.BaseStream)
    | false -> null


   // let mySr = new StreamReader(Assembly.Load("$safeprojectname$").GetManifestResourceStream("ShowData.xaml"))   // XAML - MUST be Embedded Resource 
   // do this.Content <- XamlReader.Load(mySr.BaseStream):?> UserControl  // Load XAML
     
    
     
                

        
