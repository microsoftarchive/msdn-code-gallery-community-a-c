using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculadora_polinomio
{
   public class Polinomio
    {
       
       //variables públicas
        public int grado;
        public double[] coeficiente;
        
//-------------------------------------------------------------------------------------------
                                        //Constructores
       
       //Constructor sin argumentos;
        public Polinomio()
        {
            double[] gpdefec = new double[0];//gpdefec variable que guarda el grado del polinomio  por defecto 
            grado = 0;
            coeficiente = gpdefec;
        }

        //Constructor que especifica el grado del polinomio
        public Polinomio(int numgrado)
        {
            grado = numgrado;
            coeficiente = new double[grado + 1];
            
        }

        //Constructor de la clase Polinomio que permite especificar los coeficientes
        public Polinomio(double[] nuevocoefs)
        {
            coeficiente = nuevocoefs;
            grado = nuevocoefs.Length - 1;


            for (int i = nuevocoefs.Length - 1; i > 0; i--)
                {
                    if (nuevocoefs[i] == 0)
                    {
                        grado--;
                    }
                    else
                    {
                        break;
                    }
                }
               
        }

       

//----------------------------------------------------------------------------------------------
                                    //Operadores

        //Operador que permite multiplicar polinomios
        public static Polinomio operator *(Polinomio pol1, Polinomio pol2)
        {
            double[] a = new double[(pol1.grado + pol2.grado) + 1];
            for (int i = 0; i <= pol1.grado; i++)
            {
                for (int j = 0; j <= pol2.grado; j++)
                {
                    a[i + j] += pol1.coeficiente[i] * pol2.coeficiente[j];
                }
            }
            Polinomio nuevo = new Polinomio(a);
            return nuevo;
        }


        //Operador que permite multiplicar un escalar por un polinomio
        public static Polinomio operator *(double escalar, Polinomio poli)
        {
            double[] temp = new double[poli.coeficiente.Length];
            for (int i = 0; i < poli.coeficiente.Length; i++)
            {
                temp[i] = escalar * poli.coeficiente[i];
            }
            return new Polinomio(temp);
        }


        //Operador que permite multiplicar un polinomio por un escalar
        public static Polinomio operator *(Polinomio poli, double escalar)
        {
            return escalar * poli;
        }

        //Operador que permite sumar un polinomio y un escalar
        public static Polinomio operator +(double escalar, Polinomio poli)
        {
            double[] temp = new double[1];
            temp[0] = escalar;
            return new Polinomio(temp) + poli;
        }

        //Operador que permite sumar un escalar y un polinomio
        public static Polinomio operator +(Polinomio poli, double escalar)
        {
            return escalar + poli;
        }


        //Operador que permite sumar polinomios
        public static Polinomio operator +(Polinomio p1,Polinomio p2)
        {
            Polinomio s;
            Polinomio t = new Polinomio(p1.grado);
            Polinomio q = new Polinomio(p2.grado);
            if (p1.grado >= p2.grado)
            {
            
                for (int i = 0; i <= p1.grado; i++)
                {
                    if (p2.grado == 0) {
                        double[] arr = new double[p1.coeficiente.Length];

                        for ( i = 0; i < p1.coeficiente.Length; i++)
                        {
                        arr[i]=p1.coeficiente[i];
                        }
                        arr[0] += p2.coeficiente[0];

                        t.coeficiente = arr;
                    }else
               
                    if (i <= p2.coeficiente.Length)
                    {
                      t.coeficiente[i]=  (p1.coeficiente[i] + p2.coeficiente[i]);

                    }
                    
                }
                s = new Polinomio(t.coeficiente);
            }
            else
            {
                
                for (int i = 0; i <= p2.grado; i++)
                {
                    ////////////////
                    if (p1.grado == 0)
                    {
                        double[] arr = new double[p2.coeficiente.Length];

                        for ( i = 0; i < p2.coeficiente.Length; i++)
                        {
                            arr[i] = p2.coeficiente[i];
                        }
                        arr[0] += p1.coeficiente[0];
                        q.coeficiente = arr;
                    }
                    else
                    ////////////////
                    if (i <= p1.coeficiente.Length)
                    {
                        q.coeficiente[i] = (p2.coeficiente[i] + p1.coeficiente[i]);
                    }
                }
               
                s = new Polinomio(q.coeficiente);
            }
        return s;
       }


        //Operador que permite restar dos polinomios
        public static Polinomio operator -(Polinomio pol1, Polinomio pol2)
        {
            Polinomio temp = new Polinomio(pol2.grado);
            for (int i = 0; i <=pol2.grado; i++)
            {
                temp.coeficiente[i]=pol2.coeficiente[i] * -1;
            }
            return pol1 + temp;
        }

        //Operador que permite restar un escalar y un polinomio
        public static Polinomio operator -(double escalar, Polinomio poli)
        {
            double[] temp = new double[poli.coeficiente.Length];
            temp[0] = escalar;
            Polinomio aux1 = new Polinomio(temp);
            return aux1 - poli;
        }

        //Operador que permite restar un polinomio  y un escalar
        public static Polinomio operator -(Polinomio poli, double escalar)
        {
            double[] temp = new double[poli.coeficiente.Length];
            temp[0] = escalar;
            Polinomio aux1 = new Polinomio(temp);
           
           return poli-aux1;
        }

       

//----------------------------------------------------------------------------------------------      
        //Validaciones para escribirlos en la consola 
        public override string ToString()
        {
            string polinomio = "";
            for (int i = this.grado; i >= 0; i--)
            {
                string grado = i.ToString();
                string signo = "+";
                string x = "x^";
                string coeficiente = this.coeficiente[i].ToString();

                //Validacion para 0x^n
                if (this.coeficiente[i] == 0)
                {
                    signo= "";
                    x = "";
                    grado = "";
                    coeficiente = "";
                }


                //Validacion para 1x
                if (this.coeficiente[i] == 1)
                    {
                        coeficiente = ""; 
                    }

                //Validacion para el -x;
                if (this.coeficiente[i] == -1)
                {
                    //coeficiente = ""; 
                    x = "x^";
                }


                //Validacion para el +-x
                 if (this.coeficiente[i] < 0)
                    {
                        signo = "";
                    }


                //Validacion para x^2-1
                if (i == this.grado)
                {
                    signo = "";
                }

                //Validacion para  x^1
                if ((i == 1) && (this.coeficiente[i] != 0))
                {
                    x = "x";
                    grado = "";
                }
                //Validacion para los terminos independientes
                if (i == 0)
                {
                    grado = "";
                    x = "";
                }

                if ((i == 0)  &&  (this.coeficiente[i] == 1))
                {
                    grado = "";
                    x = "1";
                }


                polinomio += signo + coeficiente + x + grado;
            }
            if (polinomio == "")
            {
                return "0";
            }
            else
            {

                return polinomio;
            }
        }
    }
}
