using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosGeneticos
{
    /// <summary>
    /// Descripción breve de Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuSalir;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbAlto;
		private System.Windows.Forms.RadioButton rbMedio;
		private System.Windows.Forms.RadioButton rbBajo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbRojo;
		private System.Windows.Forms.RadioButton rbAzul;
		private System.Windows.Forms.RadioButton rbAmarillo;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbPequeno;
		private System.Windows.Forms.RadioButton rbNormal;
		private System.Windows.Forms.RadioButton rbGrande;
		private System.ComponentModel.IContainer components;

		// Arreglo de flores
		public Flores[] poblacion=new Flores[10];
		private System.Windows.Forms.Label lblGeneracion;
		private int generacion=0;
		private int iPadreA,iPadreB;

		public Form1()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//

			Random random=new Random(unchecked((int)DateTime.Now.Ticks));
			for(int n=0;n<10;n++)
			{
				Flores temp=new Flores();
				poblacion[n]=temp;
				poblacion[n].CoordX=n*80+40;
				
				// Inicializamos el cromosoma con valores al azar
				
				// La altura va de 10 a 300
				poblacion[n].cromosoma[0]=random.Next(10,300);

				// El color de la flor. 0-rojo, 1-azul, 2-amarillo
				poblacion[n].cromosoma[1]=random.Next(0,3);

				// El color del tallo. Diferentes tonos de verde
				poblacion[n].cromosoma[2]=random.Next(0,3);

				// El ancho del tallo. De 5 a 15
				poblacion[n].cromosoma[3]=random.Next(5,15);

				// El tamano de la flor. De 20 a 80
				poblacion[n].cromosoma[4]=random.Next(20,80);

				// El tamano del centro de la flor. De 5 a 15
				poblacion[n].cromosoma[5]=random.Next(5,15);
			}

		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBajo = new System.Windows.Forms.RadioButton();
            this.rbMedio = new System.Windows.Forms.RadioButton();
            this.rbAlto = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbAmarillo = new System.Windows.Forms.RadioButton();
            this.rbAzul = new System.Windows.Forms.RadioButton();
            this.rbRojo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbGrande = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbPequeno = new System.Windows.Forms.RadioButton();
            this.lblGeneracion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSalir});
            this.menuItem1.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Index = 0;
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4});
            this.menuItem2.Text = "Aplicacion";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Inicio";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Paro";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBajo);
            this.groupBox1.Controls.Add(this.rbMedio);
            this.groupBox1.Controls.Add(this.rbAlto);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Altura";
            // 
            // rbBajo
            // 
            this.rbBajo.Location = new System.Drawing.Point(16, 64);
            this.rbBajo.Name = "rbBajo";
            this.rbBajo.Size = new System.Drawing.Size(104, 24);
            this.rbBajo.TabIndex = 2;
            this.rbBajo.Text = "Bajo";
            // 
            // rbMedio
            // 
            this.rbMedio.Checked = true;
            this.rbMedio.Location = new System.Drawing.Point(16, 40);
            this.rbMedio.Name = "rbMedio";
            this.rbMedio.Size = new System.Drawing.Size(104, 24);
            this.rbMedio.TabIndex = 1;
            this.rbMedio.TabStop = true;
            this.rbMedio.Text = "Medio";
            // 
            // rbAlto
            // 
            this.rbAlto.Location = new System.Drawing.Point(16, 16);
            this.rbAlto.Name = "rbAlto";
            this.rbAlto.Size = new System.Drawing.Size(104, 24);
            this.rbAlto.TabIndex = 0;
            this.rbAlto.Text = "Alto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAmarillo);
            this.groupBox2.Controls.Add(this.rbAzul);
            this.groupBox2.Controls.Add(this.rbRojo);
            this.groupBox2.Location = new System.Drawing.Point(160, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color de flor";
            // 
            // rbAmarillo
            // 
            this.rbAmarillo.Location = new System.Drawing.Point(16, 64);
            this.rbAmarillo.Name = "rbAmarillo";
            this.rbAmarillo.Size = new System.Drawing.Size(104, 24);
            this.rbAmarillo.TabIndex = 2;
            this.rbAmarillo.Text = "Amarillo";
            // 
            // rbAzul
            // 
            this.rbAzul.Location = new System.Drawing.Point(16, 40);
            this.rbAzul.Name = "rbAzul";
            this.rbAzul.Size = new System.Drawing.Size(104, 24);
            this.rbAzul.TabIndex = 1;
            this.rbAzul.Text = "Azul";
            // 
            // rbRojo
            // 
            this.rbRojo.Checked = true;
            this.rbRojo.Location = new System.Drawing.Point(16, 16);
            this.rbRojo.Name = "rbRojo";
            this.rbRojo.Size = new System.Drawing.Size(104, 24);
            this.rbRojo.TabIndex = 0;
            this.rbRojo.TabStop = true;
            this.rbRojo.Text = "Rojo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbGrande);
            this.groupBox3.Controls.Add(this.rbNormal);
            this.groupBox3.Controls.Add(this.rbPequeno);
            this.groupBox3.Location = new System.Drawing.Point(296, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tamaño de Flor";
            // 
            // rbGrande
            // 
            this.rbGrande.Location = new System.Drawing.Point(16, 64);
            this.rbGrande.Name = "rbGrande";
            this.rbGrande.Size = new System.Drawing.Size(104, 24);
            this.rbGrande.TabIndex = 2;
            this.rbGrande.Text = "Grande";
            // 
            // rbNormal
            // 
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(16, 40);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(104, 24);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            // 
            // rbPequeno
            // 
            this.rbPequeno.Location = new System.Drawing.Point(16, 16);
            this.rbPequeno.Name = "rbPequeno";
            this.rbPequeno.Size = new System.Drawing.Size(104, 24);
            this.rbPequeno.TabIndex = 0;
            this.rbPequeno.Text = "Pequeño";
            // 
            // lblGeneracion
            // 
            this.lblGeneracion.Location = new System.Drawing.Point(16, 112);
            this.lblGeneracion.Name = "lblGeneracion";
            this.lblGeneracion.Size = new System.Drawing.Size(100, 23);
            this.lblGeneracion.TabIndex = 3;
            this.lblGeneracion.Text = "Generacion:";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 571);
            this.Controls.Add(this.lblGeneracion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos Geneticos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void mnuSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			timer1.Enabled=true;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			timer1.Enabled=false;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// Calculamos la adaptacion
			CalculaAdaptacion();

			// Seleccionamos a los padres
			SeleccionaPadres();

			// Hacemos el crossover y la mutacion
			Crossover();

			// Acutalizamos la generacion
			generacion++;

			// Redibujamos la ventana
			this.Invalidate();
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Pintamos un suelo
			e.Graphics.FillRectangle(Brushes.DarkGreen,0,550,800,50);

			// Pintamos las flores
			for(int n=0;n<10;n++)
			{
				// 0-Altura
				// 1-Color de la flor
				// 2-Color del tallo
				// 3-Ancho del tallo
				// 4-Tamaño de la flor
				// 5-Tamaño del centro de la flor

				// pintamos el tallo
						
				// vemos el color del tallo
				if(poblacion[n].cromosoma[2]==0)
					e.Graphics.FillRectangle(Brushes.DarkGreen,
						poblacion[n].CoordX,550-poblacion[n].cromosoma[0],
						poblacion[n].cromosoma[3],poblacion[n].cromosoma[0]);
				else if(poblacion[n].cromosoma[2]==1)
					e.Graphics.FillRectangle(Brushes.Green,
						poblacion[n].CoordX,550-poblacion[n].cromosoma[0],
						poblacion[n].cromosoma[3],poblacion[n].cromosoma[0]);
				else if(poblacion[n].cromosoma[2]==2)
					e.Graphics.FillRectangle(Brushes.LightGreen,
						poblacion[n].CoordX,550-poblacion[n].cromosoma[0],
						poblacion[n].cromosoma[3],poblacion[n].cromosoma[0]);

				// Pintamos la flor
				//Color cflor=new Color();
				Color cflor=new Color(); 
				
				if(poblacion[n].cromosoma[1]==0)
					cflor=Color.Red;
				else if(poblacion[n].cromosoma[1]==1)
					cflor=Color.Blue;
				else if(poblacion[n].cromosoma[1]==2)
					cflor=Color.Yellow;

				e.Graphics.FillEllipse(new SolidBrush(cflor),
					poblacion[n].CoordX+poblacion[n].cromosoma[3]/2-poblacion[n].cromosoma[4]/2,
					550-poblacion[n].cromosoma[0]-poblacion[n].cromosoma[4]/2,
					poblacion[n].cromosoma[4],poblacion[n].cromosoma[4]);

				//Pintamos el centro de la flor
				e.Graphics.FillEllipse(Brushes.DarkOrange,
					poblacion[n].CoordX+poblacion[n].cromosoma[3]/2-poblacion[n].cromosoma[5]/2,
					550-poblacion[n].cromosoma[0]-poblacion[n].cromosoma[5]/2,
					poblacion[n].cromosoma[5],poblacion[n].cromosoma[5]);
			}

			lblGeneracion.Text="Generacion: "+generacion.ToString();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

			
		}

		private void CalculaAdaptacion()
		{
			// Variables para las opciones del usuario
			int altura,color,tamano;
			altura=color=tamano=0;

			// Variables necesarias para el calculo
			double Aaltura,Acolor,Atamano;
			Aaltura=Acolor=Atamano=0.0;

			// Obtnemos la altura deseada por el usuario
			if(rbBajo.Checked==true)
				altura=0;
			else if(rbMedio.Checked==true)
				altura=1;
			else if(rbAlto.Checked==true)
				altura=2;

			// Obtenemos el color deseado por el usuario
			if(rbRojo.Checked==true)
				color=0;
			else if(rbAzul.Checked==true)
				color=1;
			else if(rbAmarillo.Checked==true)
				color=2;

			// Obtenemos el tamano de la flor deseado por el usuario
			if(rbPequeno.Checked==true)
				tamano=0;
			else if(rbNormal.Checked==true)
				tamano=1;
			else if(rbGrande.Checked==true)
				tamano=2;


			// Recorremos toda la poblacion para encontrar su adaptacion
			for(int n=0;n<10;n++)
			{
				// Checamos el nivel de adaptacion para la altura
				if(altura==0) // rango 10 a 100
					Aaltura=poblacion[n].cromosoma[0]/100;
				else if(altura==1) // rango 100 a 200
					Aaltura=poblacion[n].cromosoma[0]/200;
				else if(altura==2) // rango 200 a 300
					Aaltura=poblacion[n].cromosoma[0]/300;

				if(Aaltura>1.0)
					Aaltura=1/Aaltura;

				// Checamos el nivel de adaptacon del color
				if(color==poblacion[n].cromosoma[1])
					Acolor=1.0;
				else
					Acolor=0.0;

				// Checamos el nivel de adaptacion del tamano de la flor
				if(tamano==0) // rango 20 a 40
					Atamano=poblacion[n].cromosoma[4]/40;
				else if(tamano==1) // rango 40 a 60
					Atamano=poblacion[n].cromosoma[4]/60;
				else if(tamano==2) // rango 60 a 80
					Atamano=poblacion[n].cromosoma[4]/80;

				if(Atamano>1.0)
					Atamano=1/Atamano;

				// Calculamos el valor final de adaptacion
				poblacion[n].Adaptacion=(Aaltura+Acolor+Atamano)/3.0;

			}

		}

		
private void SeleccionaPadres()
		{
			// Seleccionamos los dos mejores
			// Modelo elitista
			
			iPadreA=iPadreB=0;

			// Encontramos el padre A
			for(int n=0;n<10;n++)
			{
				if(poblacion[n].Adaptacion>poblacion[iPadreA].Adaptacion)
					iPadreA=n;
			}

			// Encontramos el padre B
			for(int n=0;n<10;n++)
			{
				if(poblacion[n].Adaptacion>poblacion[iPadreB].Adaptacion && iPadreA!=n)
					iPadreB=n;
			}

		}
		private void Crossover()
		{
			// Llevamos a cabo el cross over

			// Copiamos los padres, ya que todo el arreglo sera
			// llenado nuevamente con hijos

			Flores PadreA=new Flores();
			Flores PadreB=new Flores();

			// Copiamos los padres
			for(int n=0;n<6;n++)
			{
				PadreA.cromosoma[n]=poblacion[iPadreA].cromosoma[n];
				PadreB.cromosoma[n]=poblacion[iPadreB].cromosoma[n];

			}

			// Creamos la siguiente generacion
			
			Random random=new Random(unchecked((int)DateTime.Now.Ticks));
			

			for(int n=0;n<10;n++)
			{
			
				int desde=random.Next(0,5);
				int hasta=random.Next(desde,6);

				for(int c=desde;c<hasta;c++)
				{
					// Si el random es 0, se copia el gen de PadreA
					// si el random es 1, se copia el gen de PadreB
					if(random.Next(0,2)==0)
						poblacion[n].cromosoma[c]=PadreA.cromosoma[c];
					else
						poblacion[n].cromosoma[c]=PadreB.cromosoma[c];

					// incluimos la mutacion
					if(random.Next(0,100)<=5)
					{

						if(c==0)
							poblacion[n].cromosoma[0]=random.Next(10,300);

						if(c==1)
							poblacion[n].cromosoma[1]=random.Next(0,3);

						if(c==2)
							poblacion[n].cromosoma[2]=random.Next(0,3);

						if(c==3)
							poblacion[n].cromosoma[3]=random.Next(5,15);

						if(c==4)
							poblacion[n].cromosoma[4]=random.Next(20,80);

						if(c==5)
							poblacion[n].cromosoma[5]=random.Next(5,15);

					}

				}

			}


		}
	}
}
