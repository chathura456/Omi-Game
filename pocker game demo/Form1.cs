using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pocker_game_demo
{
    public partial class Form1 : Form
    {

        private PictureBox[] pictures;
        //public const string imagePath = @"D:\Campus\Year 02 Semester 02\Business Processes and ERP\C# Assignment - Omi Game\pocker game demo\pocker game demo\Assets\";
        public string[] cardName = { "7C", "7D", "7H", "7S", "8C", "8D", "8H", "8S", "9C", "9D", "9H", "9S", "TC", "TD", "TH", "TS", "JC", "JD", "JH", "JS", "QC", "QD", "QH", "QS", "KC", "KD", "KH", "KS", "AC", "AD", "AH", "AS" };
        public Form1()
        {
            InitializeComponent();
            pictures = new PictureBox[32];
            this.SetBounds(1, 1, 1800, 1800);
            
            // set the start position of the form to the center of the screen.  

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Visible = false;
            CreateControlls();
            ShuffleCards();
            DisplayControls0();
            button1.Visible = false;
            label2.Visible = true;
            
        }
        private void DisposeControls()
        {
            foreach (var c in pictures)
                c.Dispose();
        }
        private void CreateControlls()
        {
           if (pictures[0]!=null)
                DisposeControls();
           
            for (var i = 0; i < 32; i++)
            {
                var newpicturebox = new PictureBox();
                newpicturebox.Width = 75;
                newpicturebox.Height = 100;
                newpicturebox.BorderStyle = BorderStyle.Fixed3D;
                newpicturebox.Name = $"{cardName[i]}";
                pictures[i] = Sizeimage(newpicturebox, i + 1);
                ;
                
            }

        }
        
        private PictureBox Sizeimage(PictureBox pb, int i)
        {
            //Image img = Image.FromFile(imagePath+ i.ToString()+ ".png");
            var rm = Properties.Resources.ResourceManager.GetObject("1");
          string resourceName = $"{i}";


           
            string resourceName1 = $"{cardName[i-1]}";
            //string path1 = rm.GetString(resourceName);
            //var img = Image.FromFile(rm);
            //Image img1 = Properties.Resources.QD;
            Image img1 = (Image)Properties.Resources.ResourceManager.GetObject(resourceName1);
            img1.Tag = $"{cardName[i - 1]}";
            pb.Image = img1;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += delegate (object sender, EventArgs e) { PictureClickAsync(sender, e, i); };

            return pb;
        }

        private void DisplayControls0()
        {//bottom
            for (var i = 7; i > 3; i--)
            {
                pictures[i].Left = (i * 50) + 500;
                pictures[i].Top = 500;
                this.Controls.Add(pictures[i]);
                
            }
            

        }

        

        private void DisplayControls()
        {
            //left
            for (var i = 31; i > 27; i--)
            {
               
                pictures[i].Left = 50;
                pictures[i].Top = (i * 30) -550;
                this.Controls.Add(pictures[i]);        
            }
            
            //right
            for (var i = 23; i > 19; i--)
            {
                pictures[i].Left = 1210;
                pictures[i].Top = (i * 30) -300;
                this.Controls.Add(pictures[i]);
            }

            //top
            for (var i=15; i > 11; i--)
            {
                pictures[i].Left = (i * 50) + 100;
                pictures[i].Top = 50 ;
                this.Controls.Add(pictures[i]);
                
            }
            
            

            
        }

        private void DisplayControls2()
        {
            //LEFT2
            for (var i = 27; i > 23; i--)
            {

                pictures[i].Left = 50;
                pictures[i].Top = (i * 30) - 550;
                this.Controls.Add(pictures[i]);

            }

            //RIGHT2
            for (var i = 19; i > 15; i--)
            {
                pictures[i].Left = 1210;
                pictures[i].Top = (i * 30) - 300;
                this.Controls.Add(pictures[i]);
            }

            //TOP2
            for (var i = 11; i > 7; i--)
            {
                pictures[i].Left = (i * 50) + 100;
                pictures[i].Top = 50;
                this.Controls.Add(pictures[i]);

            }

            //BOTTOM2
            for (var i = 3; i > -1; i--)
            {
                pictures[i].Left = (i * 50) + 500;
                pictures[i].Top = 500;
                this.Controls.Add(pictures[i]);

            }
        }

       
        private void ShuffleCards()
        {
            Random random = new Random();
            for(var i=0;i<1000;i++)
            {
                int firstCard = random.Next(0,32);
                int secondCard = random.Next(0, 32  );
                if(firstCard != secondCard)
                {
                    var temp = pictures[firstCard];
                    pictures[firstCard] = pictures[secondCard];
                    pictures[secondCard] = temp;
                }
            }
        }

        async Task PictureClickAsync(Object sender, EventArgs e, int i)
        {
            
            label2.Visible = false;
            string suit = $"{cardName[i - 1]}";
            label1.Text = Char.ToString(suit[1]);
            
            if (label1.Text == "C")
            {
                Image img1 = (Image)Properties.Resources.ResourceManager.GetObject("Clubs");
                pictureBox1.Image = img1;
            }else if (label1.Text == "D")
            {
                Image img1 = (Image)Properties.Resources.ResourceManager.GetObject("Diamonds");
                pictureBox1.Image = img1;
            }
            else if (label1.Text == "H")
            {
                Image img1 = (Image)Properties.Resources.ResourceManager.GetObject("Hearts");
                pictureBox1.Image = img1;
            }
            else if (label1.Text == "S")
            {
                Image img1 = (Image)Properties.Resources.ResourceManager.GetObject("Spades");
                pictureBox1.Image = img1;

            }
            else
            {
                pictureBox1.Image = null;
            }
            pictureBox1.Visible = true;
                await Task.Delay(1000);
            DisplayControls();
            await Task.Delay(2000);
            DisplayControls2();
            button1.Text = "Restart";
            button1.Top = 50;
            button1.Left = 50;
            button1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
