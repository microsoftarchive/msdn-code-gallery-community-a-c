/*
 * Copyright © 2017 E-Troy電腦神手吳子陵 Incorporated. All rights reserved.
 * Created by SharpDevelop.
 * User: E-Troy電腦神手吳子陵
 * Date: 2017/8/19
 * Time: 下午 05:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
namespace MainForm
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	public partial class MainForm : Form
	{
		//按扭
		//Button
		public Button button1 = new Button();
		//顯示結果的Label
		//The label that displays the result
		public Label resultLabel =new Label();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			InitializeComponent();
			
			//初始化介面的高度，這樣才不會太短，等一下要顯示結果用。
			//Initialize the height of the interface, so that it will not be too short, wait for the results to be used.
			
			this.Height=400;
			
			//初始化一個按扭
			//Initialize a button
			this.button1.Location = new System.Drawing.Point(82, 20);
            this.button1.Name = "btn";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Do CSV To JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.click);
            
            //初始化一個Label，等一下用來顯示結果用的
            //Initialize a Label, wait for the results used to show
			this.Controls.Add(this.button1);
			this.resultLabel.Location = new System.Drawing.Point(10, 60);
			this.resultLabel.Name = "label1";
			this.resultLabel.Text = "";
			this.resultLabel.AutoSize = true;
			this.Controls.Add(this.resultLabel);
			
		}
		
		//寫一個按扭監聽的事件
		//Write a button to listen to the event
		private void click(object sender, EventArgs e)
	    {
			//讀取csv檔，然後透過System.IO.File.ReadAllLines來讀取每一行的JSON String的格式
			//Read the csv file, and then use System.IO.File.ReadAllLines to read the JSON String format for each line
			string[] lines = System.IO.File.ReadAllLines(@"csvfile.csv");
			
			//在這邊透過foreach把一行的JSON取出
			//Here through the foreach to get each line of JSON
			foreach (string line in lines) 
			{
				Console.WriteLine("JSON String：{0}", line);
				this.resultLabel.Text += line+"\n\n";
				
				//轉換成JSON Object的格式
				//Convert to JSON Object format
				Player pj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Player>(line);
				
				//將Object裡的值取出來用，在Label上面編排結果
				//The value of the Object to take out, in the Label above the results of the arrangement
				this.resultLabel.Text += "JSON Object Id Value："+pj.Id.ToString()+"\n\n";
				this.resultLabel.Text += "JSON Object HP Value："+pj.HP.ToString()+"\n\n";
				this.resultLabel.Text += "JSON Object MP Value："+pj.MP.ToString()+"\n\n";
				this.resultLabel.Text += "JSON Object Skill Value："+pj.Skill.ToString()+"\n\n\n";
				Console.WriteLine("JSON Object Id Value：{0}", pj.Id);
				Console.WriteLine("JSON Object HP Value：{0}", pj.HP);
				Console.WriteLine("JSON Object MP Value：{0}", pj.MP);
				Console.WriteLine("JSON Object Skill Value：{0}", pj.Skill);
	
			}
		}
	}
	
	//建立一個Player的Class物件
	//Create a Player Class object
	public class Player
    {
		//下面的變數，就是對應從csvfile.csv裡的JSON格式字串，裡面有Id、HP、MP、Skill。
		//The following variable is the corresponding from the csvfile.csv JSON format string, which has Id, HP, MP, Skill.
        //角色Id
        //Role Id
		public int Id { get; set; }
		//角色HP
		//Role HP
        public int HP { get; set; }
        //角色MP
        //Role MP
        public string MP { get; set; }
        //角色SKill
        //Role MP
        public string Skill { get; set; }
    }
}
