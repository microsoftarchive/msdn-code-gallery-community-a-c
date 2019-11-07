namespace MyUserControl

open System.IO
open System.Xaml
open System.Windows.Markup
open System.Reflection
open Utilities 

open System.Windows.Controls
open System

type Calculator() as this  = 
    inherit UserControl() 
        
    do this.Content <- contentAsXamlObject("Calculator.xaml"):?> UserControl  // Load XAML -  XAML - MUST be Embedded Resource  ("use just xaml file name")  
    
    // FIND ALL OBJECTS IN THIS.CONTENT - like partition class

    let mutable txtResult : TextBlock = (this.Content)?txtResult  
    let mutable txtHelper : TextBlock = (this.Content)?txtHelper                
    let mutable btnMC : Button = (this.Content)?btnMC         // MC = Memory Clear sets the memory to 0      
    let mutable btnMR : Button = (this.Content)?btnMR         // MR = Memory Recall uses the number in memory 
    let mutable btnMS : Button = (this.Content)?btnMS         // MS = Memory Store puts the number on the display into the memory 
    let mutable btnMPlus  : Button = (this.Content)?btnMPlus  // M+ = Adds the number shown on the display to the number stored in the memory      
    let mutable btnMMinus : Button = (this.Content)?btnMMinus // M- = Subtracts the number shown on the display to the number stored in the memory. 
    let mutable btnBack   : Button = (this.Content)?btnBack       
    let mutable btnCE : Button = (this.Content)?btnCE       
    let mutable btnC  : Button = (this.Content)?btnC  
    let mutable btnPM : Button = (this.Content)?btnPM         // Change sign +/-
    let mutable btnSqRt   : Button = (this.Content)?btnSqRt   // SQRT      
    let mutable btnDiv     : Button = (this.Content)?btnDiv  
    let mutable btnPercent : Button = (this.Content)?btnPercent  // %       
    let mutable btnMult  : Button = (this.Content)?btnMult       
    let mutable btnReciproc: Button = (this.Content)?btnReciproc // 1/x 
    let mutable btnMinus : Button = (this.Content)?btnMinus 
    let mutable btnEqual : Button = (this.Content)?btnEqual       
    let mutable btnPlus  : Button = (this.Content)?btnPlus  
    let mutable btn7 : Button = (this.Content)?btn7       
    let mutable btn8 : Button = (this.Content)?btn8       
    let mutable btn9 : Button = (this.Content)?btn9  
    let mutable btn4 : Button = (this.Content)?btn4 
    let mutable btn5 : Button = (this.Content)?btn5       
    let mutable btn6 : Button = (this.Content)?btn6  
    let mutable btn1 : Button = (this.Content)?btn1      
    let mutable btn2 : Button = (this.Content)?btn2 
    let mutable btn3 : Button = (this.Content)?btn3       
    let mutable btn0 : Button = (this.Content)?btn0  
    let mutable btnDot : Button = (this.Content)?btnDot       
    let mutable txtMemo : TextBlock = (this.Content)?txtMemo  

   
    do txtResult.Text <- "0"
       txtHelper.Text <- ""
       txtMemo.Text <- ""    //  "M" or "" (Blank)
 
    // ADD CLICK EVENT TO EACH BUTTON ...   

    // MEMORY COMMAND
    let memoCommand (oper : string) = 
        match txtResult.Text with
        | "NaN" | "∞"-> ignore()    
        | _ ->    match oper with
                  | "MS" -> Perform.memo <- txtResult.Text    // Memory Store puts the number on the display into the memory 
                            txtMemo.Text <- "M"
                  | "MR" -> txtResult.Text <- Perform.memo    // Memory Recall uses the number in memory
                            Perform.memo <- "0.0"
                            txtMemo.Text <- ""
                  | "MC" -> Perform.memo <- "0.0"             // Memory Clear
                            txtMemo.Text <- ""
                  | "M+" -> Perform.memo <- (Double.Parse(Perform.memo) + Double.Parse(txtResult.Text)).ToString()
                            txtMemo.Text <- "M"
                  | "M-" -> Perform.memo <- (Double.Parse(Perform.memo) - Double.Parse(txtResult.Text)).ToString() 
                            txtMemo.Text <- "M"
                  | _    -> Perform.memo <- ("0")
                            txtMemo.Text <- ""
                  Perform.blnCommand <- true
                  txtMemo.ToolTip <- Perform.memo
            
    do btnMS.Click.Add(fun _ -> memoCommand("MS"))
       btnMR.Click.Add(fun _ -> memoCommand("MR"))
       btnMC.Click.Add(fun _ ->  memoCommand("MC"))  
       btnMPlus.Click.Add(fun _ -> memoCommand("M+"))
       btnMMinus.Click.Add(fun _ -> memoCommand("M-"))
    
    // COMMANDS { = + - / * % 1/x SqRt }
    let clickCommand(oper:string) = match txtResult.Text with
                                    | "NaN" | "∞"-> ignore() 
                                    | _ ->  Perform.perform(txtResult.Text, txtHelper.Text, oper )  // update Perform.hr
                                            txtResult.Text <- fst(Perform.rh)                        
                                            txtHelper.Text <-snd(Perform.rh)                                

    do btnEqual.Click.Add(fun _ -> clickCommand("="))
       btnPlus.Click.Add (fun _ -> clickCommand("+"))
       btnMinus.Click.Add(fun _ -> clickCommand("-"))
       btnDiv.Click.Add(fun _ -> clickCommand("/"))
       btnMult.Click.Add(fun _ -> clickCommand("*")) 
       btnPercent.Click.Add(fun _ -> clickCommand("%"))
       btnReciproc.Click.Add(fun _ -> clickCommand("1/x"))
       btnSqRt.Click.Add(fun _ -> clickCommand("SqRt"))
       btnPM.Click.Add(fun _ -> clickCommand("+-"))

    // CLICK NUMBER 
    let clickNumPad(numChar:string) =  match txtResult.Text with
                                       | "NaN" | "∞"-> ignore() 
                                       | "0" -> txtResult.Text <- numChar 
                                       | _ when Perform.blnCommand -> txtResult.Text <- numChar                                                                                        
                                       | _ -> txtResult.Text <- txtResult.Text + numChar
                                       Perform.blnCommand <- false

    do btn0.Click.Add(fun _ -> clickNumPad("0"))
       btn1.Click.Add(fun _ -> clickNumPad("1"))
       btn2.Click.Add(fun _ -> clickNumPad("2"))
       btn3.Click.Add(fun _ -> clickNumPad("3"))
       btn4.Click.Add(fun _ -> clickNumPad("4"))
       btn5.Click.Add(fun _ -> clickNumPad("5"))
       btn6.Click.Add(fun _ -> clickNumPad("6"))
       btn7.Click.Add(fun _ -> clickNumPad("7"))
       btn8.Click.Add(fun _ -> clickNumPad("8"))
       btn9.Click.Add(fun _ -> clickNumPad("9"))

    
    // SPECIAL COMMAND   | "NaN" | "Infinity" | "Error" | "∞" -> rh <- (result,helper)

    do btnBack.Click.Add(fun _ -> match txtResult.Text with
                                  | "NaN" | "∞"-> ignore() 
                                  | _ -> match txtResult.Text.Length with 
                                         | 1 -> txtResult.Text <- "0"
                                         | _ -> txtResult.Text <- txtResult.Text.Substring(0, txtResult.Text.Length - 1)
                                         Perform.blnCommand <- false )

    do btnDot.Click.Add(fun _ -> match txtResult.Text with
                                  | "NaN" | "∞"-> ignore() 
                                  | _ -> if txtResult.Text.IndexOf(".") = -1 then
                                             txtResult.Text <- txtResult.Text + "."
                                         Perform.blnCommand <- false )

    do btnC.Click.Add(fun _ -> txtResult.Text <- "0"
                               Perform.blnCommand <- false
                               txtHelper.Text <- ""
                               txtMemo.Text <- ""
                               Perform.memo <- "0.0"
                               Perform.prevResult <- 0.0
                               Perform.prevOper <- ""
                               txtMemo.ToolTip <- "0" )

    do btnCE.Click.Add(fun _ -> txtResult.Text <- "0"
                                if txtHelper.Text = "" then Perform.prevResult <- 0.0
                                Perform.blnCommand <- false)


