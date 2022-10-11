using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pocker_game_demo
{
    public partial class Form1 : Form
    {

        private PictureBox[] pictures;
        //public const string imagePath = @"D:\Campus\Year 02 Semester 02\Business Processes and ERP\C# Assignment - Omi Game\pocker game demo\pocker game demo\Assets\";
        
        public Form1()
        {
            InitializeComponent();
            pictures = new PictureBox[32];
            this.SetBounds(1, 1, 1800, 1800);

            // set the start position of the form to the center of the screen.  

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           /*pictures[0] = pictureBox1;
            pictures[1] = pictureBox2;
            pictures[2] = pictureBox3;
            pictures[3] = pictureBox4;
            pictures[4] = pictureBox5;
            pictures[5] = pictureBox6;
            pictures[6] = pictureBox7;
            pictures[7] = pictureBox8;*/
            
            CreateControlls();
            ShuffleCards();
            DisplayControls();
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
                pictures[i] = Sizeimage(newpicturebox, i + 1);
            }

        }

        private PictureBox Sizeimage(PictureBox pb, int i)
        {
            //Image img = Image.FromFile(imagePath+ i.ToString()+ ".png");
            var rm = Properties.Resources.ResourceManager.GetObject("1");
            string resourceName = $"{i}";
            //string path1 = rm.GetString(resourceName);
            //var img = Image.FromFile(rm);
            //Image img1 = Properties.Resources.QD;
            Image img1 = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);
            pb.Image = img1;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            return pb;
        }

        private void DisplayControls()
        {
            //left
            for (var i = 31; i > 23; i--)
            {
                pictures[i].Left = 50;
                 pictures[i].Top = (i * 30) -550;
                this.Controls.Add(pictures[i]);
            }

            //right
            for (var i = 23; i > 15; i--)
            {
                pictures[i].Left = 1210;
                pictures[i].Top = (i * 30) -300;
                this.Controls.Add(pictures[i]);
            }

            //top
            for (var i=15; i > 7; i--)
            {
                pictures[i].Left = (i * 50) + 100;
                pictures[i].Top = 50 ;
                this.Controls.Add(pictures[i]);
            }

            //bottom
            for (var i = 7; i >-1; i--)
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
                int secondCard = random.Next(0, 32);
                if(firstCard != secondCard)
                {
                    var temp = pictures[firstCard];
                    pictures[firstCard] = pictures[secondCard];
                    pictures[secondCard] = temp;
                }
            }
        }

        
    }
}
