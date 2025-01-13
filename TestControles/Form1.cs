using NuevosComponentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestControles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("holaaa");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (labelTextBox1.Posicion==LabelTextBox.EPosicion.DERECHA)
            {
                labelTextBox1.Posicion = LabelTextBox.EPosicion.IZQUIERDA;
                
            } else
            {
                labelTextBox1.Posicion = LabelTextBox.EPosicion.DERECHA;
               
            }


        }

        private void labelTextBox1_PosicionChanged(object sender, EventArgs e)
        {
            if (labelTextBox1.Posicion == LabelTextBox.EPosicion.DERECHA)
            {
                this.Text = LabelTextBox.EPosicion.IZQUIERDA.ToString();
            } else
            {
                this.Text = LabelTextBox.EPosicion.DERECHA.ToString();
            }
        }

        private void labelTextBox1_SeparacionChanged(object sender, EventArgs e)
        {
            this.Text = "La separacion ha cambiado";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelTextBox1.Separacion += 1;
        }

        private void labelTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Text = "El evento KeyUp de labelTextBox1 se ha activado!";
        }

        private void labelTextBox1_TxtChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("El evento TxtChanged de labelTextBox1 se ha activado!");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = !flag;
            this.Refresh();
        }
        bool flag = true;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (flag)
            {
                e.Graphics.DrawString("Prueba de escrituta", this.Font, Brushes.BlueViolet, 10, 10);

                e.Graphics.DrawLine(new Pen(Color.Green), 10, 10, 100, 100);

                Graphics gr = this.CreateGraphics();
              
                gr.DrawImage(new Bitmap(@"C:\Windows\Web\Wallpaper\Theme2\img7.jpg"), 10, 30);
            }
 

        }


    }
}
