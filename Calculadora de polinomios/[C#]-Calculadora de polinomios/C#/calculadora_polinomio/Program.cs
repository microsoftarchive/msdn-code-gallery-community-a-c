using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciloci.Flee;


namespace calculadora_polinomio
{
    
    class Program
    {
        static void Main(string[] args)
        {

      Console.WriteLine("     Calculadora realizada por Jose Mendez Perez");
      Console.WriteLine("     Para obtener ayuda teclee ayuda o ? (signo de interrogacion)");
      Console.WriteLine();
            
 //-------------------------------------------------------------------------------------------- 

          ExpressionContext cont=new ExpressionContext();
          cont.Imports.AddType(typeof(Polinomio));
          cont.Imports.AddType(typeof(Math));
         
 //--------------------------------------------------------------------------------------------           
           // variables
          string p = ">";
          string entrada = "";


 //ciclo para repetir el proceso hasta que el usuario ponga quit para salir
          while (entrada != "quit")
            {
                Console.Write(p);
                entrada = Console.ReadLine();

                if ((entrada == "AYUDA") || (entrada == "ayuda") || (entrada == "?"))
                {
                    Console.Write("Las variables se declaran de la siguiente forma:\n");
                    Console.Write("nombre_de_la_variable:=numero  <<-para guardar numeros \n");
                    Console.Write("nombre_de_la_variable:=(1 2 3) <<-para los polinomios \n");
                    Console.Write("en el caso de los polinomios solo se especifican los coeficientes\n");
                    Console.Write("del polinomio \n");
                    Console.Write("el polinomio (1 2 3) es x^2+2x+3 \n");
                    Console.Write("Para visualizar el contenido de una variable previamente declarada\n");
                    Console.Write("teclee el nombre \n");
                    Console.Write("de la variable multiplicada por 1 ej: >a*1 \n");
                    Console.Write("Para salir de la aplicacion tecle la palabra quit \n");
                    Console.Write("\n");
                }
                else 
                {
                   if (entrada == "quit")
                   { break; }
                
//---------------------------------------------------------------------
                 else{
                   if (definicion_de_variable(entrada))
                    {
                        asignacion_de_variables(cont, entrada);
                    }
                    else
                    {
 //-------------------------------------------------------------------
                        try
                        {
                            IDynamicExpression IDE = cont.CompileDynamic(entrada);
                            Console.WriteLine(IDE.Evaluate());
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine("No se pudo evaluar la exprecion.");
                        }
                    }
                }
            }
       
            }
                
        }

//-------------------------------------------------------------------------
//-------------------------------------------------------------------------
        static bool definicion_de_variable(string var) 
        { 
            if (var.Contains(":=")) 
            { 
                return true; 
            }
            
            return false; 
        }


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
        static void asignacion_de_variables(ExpressionContext contenido, string v) 
        { 
            int var1 = 0;
            
            if (v.Contains("("))
            {
                string[] temp = v.Split(new Char[] { ':', '=','(' ,' ' ,')' });

                while (temp[var1].Trim() == "")
                { var1++; }

            int var2 = var1 + 1;
            while (temp[var2].Trim() == "")
                { var2++; }

            double[] arr = new double[temp.Length - var2 - 1];
            for (int i = temp.Length - 2; i >= var2; i--)
                {
                    arr[(temp.Length - 2) - i] = double.Parse(temp[i]);
                }
                Polinomio poly = new Polinomio(arr);
                contenido.Variables[temp[var1]] = poly;
            }
            else//-----------------------------------------------
            {
                string[] arreglo = v.Split(new Char[] { ' ', '=', ':' });
                while (arreglo[var1].Trim() == "")
                { var1++; }
                int var2 = var1 + 1;
                while (arreglo[var2].Trim() == "")
                { var2++; }
                contenido.Variables[arreglo[var1]] = double.Parse(arreglo[var2]);
                
            }
        }  
    }
}
