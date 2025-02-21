using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio4
{
    public partial class DibujoAhorcado : Control//TODO uso de goto case . Revisar valor anterior para lanzar evento.
    {
        public DibujoAhorcado()
        {
            InitializeComponent();
        }

        public void BaseAhorcadoEnEscala(PaintEventArgs e, int escalaX, int escalaY)
        {
            using (Pen lapiz = new Pen(Color.Red, 3)) // Crea un Pen rojo con un grosor de 3
            {
                lineaEnEscala(e, lapiz, 10, 230, 220, 230, escalaX, escalaY); // horizontal base
                lineaEnEscala(e, lapiz, 60, 10, 60, 230, escalaX, escalaY); // palo base
                lineaEnEscala(e, lapiz, 150, 10, 59, 10, escalaX, escalaY); // horizontal base cabeza
                lineaEnEscala(e, lapiz, 149, 10, 149, 50, escalaX, escalaY); // vertical base cabeza
            }
        }

        private void lineaEnEscala(PaintEventArgs e, Pen lapiz, int x1, int y1, int x2, int y2, int escalaX, int escalaY)
        {
            e.Graphics.DrawLine(lapiz, (x1 * escalaX) / 1000, (y1 * escalaY) / 1000, (x2 * escalaX) / 1000, (y2 * escalaY) / 1000);
        }

        private void circuloEnEscala(PaintEventArgs e, Pen lapiz, int x, int y, int ancho, int alto, int escalaX, int escalaY)
        {
            e.Graphics.DrawEllipse(lapiz, (x * escalaX) / 1000, (y * escalaY) / 1000, (ancho * escalaX) / 1000, (alto * escalaY) / 1000);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int escalaX = (this.Width * 1000) / 230;
            int escalaY = (this.Height * 1000) / 240;

            switch (errores)
            {
                case 0:
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    break;

                case 1: // cabeza
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3))
                    {
                        circuloEnEscala(e, lapiz, 132, 50, 35, 35, escalaX, escalaY);
                    }
                    break;

                case 2: // cuello
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3))
                    {
                        lineaEnEscala(e, lapiz, 149, 85, 149, 100, escalaX, escalaY); // cuello
                        goto case 1;
                    }

                case 3: // torso
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3)) 
                    {
                        lineaEnEscala(e, lapiz, 149, 100, 149, 150, escalaX, escalaY); // torso
                        goto case 2;
                    }
                  

                case 4: // brazo izq
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3)) 
                    {
                        lineaEnEscala(e, lapiz, 149, 100, 125, 120, escalaX, escalaY); // brazo izq
                        goto case 3;
                    }
                  

                case 5: // brazo derecho
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3)) 
                    {
                        lineaEnEscala(e, lapiz, 149, 100, 172, 120, escalaX, escalaY); // brazo derecho
                        goto case 4;
                    }
                  

                case 6: // pierna izq
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3)) 
                    {
                        lineaEnEscala(e, lapiz, 149, 150, 124, 180, escalaX, escalaY); // pierna izq
                        goto case 5;
                    }
                   

                case 7: // pierna derecha
                    BaseAhorcadoEnEscala(e, escalaX, escalaY);
                    using (Pen lapiz = new Pen(Color.Red, 3)) 
                    {
                        lineaEnEscala(e, lapiz, 149, 150, 173, 180, escalaX, escalaY); // pierna derecha
                        goto case 6;
                    }
                    

                default:
                    break;
            }
        }



        private int errores;
        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]

        public int Errores
        {
            set
            {
                if (value >= 0 && value <= 7)
                {
                    this.Refresh();
                    if (errores != value)
                    {
                        OnCambiaError(EventArgs.Empty);
                    }
                    errores = value;
                    
                    if (errores == 7)
                    {
                        OnAhorcado(EventArgs.Empty);
                    }
                }
            }

            get
            {
                return errores;
            }
        }

        [Category("Appearance")]
        [Description("Se lanza al cambiar el numero")]
        public event EventHandler CambiaError;

        protected virtual void OnCambiaError(EventArgs e)
        {
            CambiaError?.Invoke(this, e);
        }

        [Category("Appearance")]
        [Description("Se lanza al llegar a 7")]
        public event EventHandler Ahorcado;

        protected virtual void OnAhorcado(EventArgs e)
        {
            Ahorcado?.Invoke(this, e);
        }
    }
}
