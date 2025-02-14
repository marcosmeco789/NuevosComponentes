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
    public partial class DibujoAhorcado : Control
    {
        public DibujoAhorcado()
        {
            InitializeComponent();
        }

        public void baseAhorcado(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 3)) // Crea un Pen rojo con un grosor de 3
            {
                e.Graphics.DrawLine(pen, 10, 230, 220, 230); // horizontal base
                e.Graphics.DrawLine(pen, 60, 10, 60, 230); // palo base
                e.Graphics.DrawLine(pen, 150, 10, 59, 10); // horizontal base cabeza
                e.Graphics.DrawLine(pen, 149, 10, 149, 50); // vertical base cabeza
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (errores)
            {
                case 0:
                    baseAhorcado(e);
                    break;

                case 1: //cabeza
                    baseAhorcado(e);
                    using (Pen pen = new Pen(Color.Red, 3)) // Crea un Pen rojo con un grosor de 3
                    {
                        e.Graphics.DrawEllipse(pen, 132, 50, 35, 35); // Dibuja un círculo (cabeza)

                    }
                    break;

                case 2: //cuello
                    break;

                case 3: // torso
                    break;

                case 4: //brazo izq
                    break;

                case 5: // brazo derecho
                    break;

                case 6: // pierna izq
                    break;

                case 7: //pierna derecha
                    break;

                default:
                    break;
            }

        }

        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        private int errores;

        public int Errores
        {
            set
            {
                if (value >= 0 && value <= 7)
                {
                    errores = value;
                    this.Refresh();
                    OnCambiaError(EventArgs.Empty);
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
