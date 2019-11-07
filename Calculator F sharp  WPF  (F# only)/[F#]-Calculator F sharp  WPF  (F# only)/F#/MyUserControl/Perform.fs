module Perform

open System


// INIT
let mutable memo : string = "0.0" 
let mutable prevResult : float = 0.0   // previous result
let mutable rh  = "",""  // tuple for store (txtResult, txtHelper)
let mutable blnCommand = false
let mutable prevOper : String = ""

let rec calculate (result:string, helper:string, oper : string) = 
        match oper with
        | "+" -> match helper with
                 | "" -> prevResult <- Double.Parse(result)
                         (result, result + "+") 
                 | _ when prevOper = "+" ->  ((prevResult + Double.Parse(result)).ToString() ,helper + result + "+")
                 | _ ->  (fst(calculate (result, helper, prevOper)) ,helper + result  + "+")                                                 

        | "-" -> match helper with
                 | "" -> prevResult <- Double.Parse(result)
                         (result, result + "-")
                 | _ when prevOper = "-" ->  ((prevResult - Double.Parse(result)).ToString() ,helper + result + "-")
                 | _ ->  (fst(calculate (result, helper, prevOper)) ,helper + result  + "-")  
        | "/" -> match helper with
                 | "" -> (result, result + "/")
                 | _ when prevOper = "/" ->  ((prevResult / Double.Parse(result)).ToString() , helper + result + "/")
                 | _ ->  (fst(calculate (result, helper, prevOper)) ,"(" + helper + result + ")" + "/")
         
        | "*" -> match helper with
                 | "" -> (result, result + "/")
                 | _ when prevOper = "*" ->  ((prevResult * Double.Parse(result)).ToString() , helper + result + "*")
                 | _ ->  (fst(calculate (result, helper, prevOper)) ,"(" + helper + result + ")" + "*")
        | "=" -> if helper = "" then (result, helper) 
                                else rh <- calculate (result, helper, prevOper)
                                     (fst(rh),"")
        | _   ->  (result, helper)

let perform (result:string, helper:string, oper : string) = 
         match oper with
         | "="  -> rh <- calculate(result, helper, oper)
                   prevResult <- 0.0
                   prevOper <- oper
         | "+" | "-"  -> if prevOper = "=" then prevResult <- 0.0
                         if blnCommand then rh <- (result, (if helper = "" then result 
                                                                           else helper.[0..helper.Length - 2]) + oper) 
                                       else rh <- calculate(result, helper, oper)
                         prevResult <- Double.Parse(fst(rh)) 
                         prevOper <- oper
         | "/" | "*" -> if prevOper = "=" then prevResult <- 0.0
                        if blnCommand then rh <- (result, (if helper = "" then result 
                                                                          else helper.[0..helper.Length - 2]) + oper) 
                                      else rh <- calculate(result, helper, oper)
                        prevResult <- Double.Parse(fst(rh)) 
                        prevOper <- oper


         | "%"    -> rh <- ((prevResult / 100.0 * Double.Parse(result)).ToString() ,helper) // "result" as Percent from "previous result"                      
         | "1/x"  -> rh <- ((1.0 / Double.Parse(result)).ToString() ,helper)                // Error  catch automatically -> Example -> 1 / 0    -> Infinity
         | "SqRt" -> rh <- (Math.Sqrt(Double.Parse(result)).ToString(),helper)              // Error  catch automatically -> Example -> SqRt(-1) -> NaN        
         | "+-"   -> match result.[0] with
                     |'-' -> rh <- (result.[1..], helper)
                     | _  -> rh <- ("-" + result, helper) 
         | _      -> rh <- (result,helper)

         blnCommand <- true                  
        




     
        
    

        