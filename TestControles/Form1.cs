using NuevosComponentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            //e.Graphics.DrawString("Prueba de escrituta", this.Font, Brushes.BlueViolet, 10, 10);

            //e.Graphics.DrawLine(new Pen(Color.Green), 10, 10, 100, 100);
            
        }

        private void etiquetaAviso1_ClickEnMarca(object sender, EventArgs e)
        {
            Console.WriteLine("EVENTO!!!");
        }
        private void dibujoAhorcado1_CambiaError(object sender, EventArgs e)
        {
            Console.WriteLine("Error lanzado!");
        }

        private void dibujoAhorcado1_Ahorcado(object sender, EventArgs e)
        {
            Console.WriteLine("Evento ahorcado!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dibujoAhorcado1.Errores += 1;
        }

        private void validateTextBox1_TxtTextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("lanzado!");
        }
    }
}
