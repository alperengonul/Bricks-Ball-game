using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace location_odev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dikeyYon = 3, yatayYon = 3, x, y;
        public int point = 0;
        List<PictureBox> elistesli = new List<PictureBox>();

        private bool CarpismaKontrol()
        {
            float mutlakX = Math.Abs((ftop.Left + (ftop.Width / 2)) - (pictureBox2.Left + (pictureBox2.Width / 2)));
            float mutlakY = Math.Abs((ftop.Top + (ftop.Height / 2)) - (pictureBox2.Top + (pictureBox2.Height / 2)));

            float farkGenislik = (ftop.Width / 2) + (pictureBox2.Width / 2);
            float farkYukselik = (ftop.Height / 2) + (pictureBox2.Height / 2);

            if ((farkGenislik > mutlakX) && (farkYukselik > mutlakY))
            {
                return true;
            }
            else
                return false;

        }
        
            
        

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //List
            timer1.Start();
            ftop.Top += dikeyYon;
            ftop.Left += yatayYon;
            foreach (Control item in panel1.Controls)
            {
                if (item.Tag != null && item.Tag.ToString() == "engel")
                {
                    elistesli.Add((PictureBox)item);

                }

            }

           
        }
        int i=5;
        private void timer1_Tick(object sender, EventArgs e)

        {
            

            CarpismaKontrol();
                           
            if ((ftop.Bottom >= panel1.Height) || ftop.Top <= 0) { 
                dikeyYon *= -1;

               
            }
            if ((ftop.Right >= panel1.Width) || ftop.Left <= 0) {
                yatayYon *= -1;
            }
            if (CarpismaKontrol() == true)
            {
                dikeyYon *= -1;
            }
            else if (CarpismaKontrol() == false)
            {
                goto A;
            }
            
            A:
            //if (CarpismaKontrol2() == true)
            //{
            //    engel.Visible = false;
            //}
            //else
            //{

            //}
           

                if (ftop.Location.Y > pictureBox2.Location.Y)
            {
                timer1.Stop();

                DialogResult dr = MessageBox.Show("tekrar oyna","tekrar oyna",  MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Application.Restart();
                    


                }
                else
                {
                    this.Close();
                }
            }
            ftop.Top += dikeyYon;
            ftop.Left += yatayYon;
            
            foreach (PictureBox item in elistesli)
            {

                float mutlakX = Math.Abs((ftop.Left + (ftop.Width / 2)) - (item.Left + (item.Width / 2)));
                float mutlakY = Math.Abs((ftop.Top + (ftop.Height / 2)) - (item.Top + (item.Height / 2)));

                float farkGenislik = (ftop.Width / 2) + (item.Width / 2);
                float farkYukselik = (ftop.Height / 2) + (item.Height / 2);

                if ((farkGenislik > mutlakX) && (farkYukselik > mutlakY))
                {

                    dikeyYon *= -1;

                    panel1.Controls.Remove(item);
                    elistesli.Remove(item);
                    int sayi1 = elistesli.Capacity, sayi;

                    sayi = elistesli.Count;
                    if (sayi < sayi1)
                    {
                        point++;
                        sayi1 = elistesli.Count;
                        label2.Text = point.ToString();
                    }

                    break;



                }

                
               
                

            }

            if (elistesli.Count==0)
            {
                MessageBox.Show("oyun bitti");
                timer1.Stop();
            }

            



        }
       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pictureBox2.Left < 610) 
            {

            
           
                if (e.KeyCode == Keys.Right)
                {
                    pictureBox2.Left += 10;
                

                }
            }
            else
            {

            }
            if (pictureBox2.Left >1)
            {
                if (e.KeyCode == Keys.Left)
            {
                pictureBox2.Left -= 10;
            }
            }
            else
            {

            }


        }
    }
}
