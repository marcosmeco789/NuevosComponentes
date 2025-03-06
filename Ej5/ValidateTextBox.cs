using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ej5
{
    public partial class ValidateTextBox : UserControl
    {
        public ValidateTextBox()
        {
            InitializeComponent();
            IniciarTextBox();
            
        }

        private void IniciarTextBox()
        {
            txt.Location = new Point(10, 10);
            this.Height = txt.Height + 20;
            txt.Width = this.Width - 20;

        }
        

        [Category("Appearance")]
        [Description("blabla")]

        public string TxtText
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }


        [Category("Appearance")]
        [Description("blabla")]
        public bool txtMultiline
        {
            set
            {
                txt.Multiline = value;
            }
            get
            {
                return txt.Multiline;
            }
        }

        public enum eTipo
        {
            Numerico,
            Textual
        }

        private eTipo tipo;
        [Category("Appearance")]
        [Description("enum")]
        public eTipo Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            IniciarTextBox();
            string cadena = txt.Text.Trim();
            char[] enteros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] cadenaArray = cadena.ToCharArray();
            bool error = false;
            Color color;

            if (tipo == eTipo.Numerico)
            {
                if (cadena.Length == 0)
                {
                    error = true;
                }
                else
                {
                    foreach (char numero in cadenaArray)
                    {
                        bool esNumero = false;
                        foreach (char numerosComprobar in enteros)
                        {
                            if (numero == numerosComprobar)
                            {
                                esNumero = true;
                                break;
                            }
                        }
                        if (!esNumero)
                        {
                            error = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (cadena.Length == 0)
                {
                    error = true;
                }
                else
                {
                    foreach (char caracter in cadenaArray)
                    {
                        if (!Char.IsLetter(caracter))
                        {
                            if (caracter != ' ')
                            {
                                error = true;
                                break;
                            }
                        }
                    }
                }
            }


            if (error)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.Green;
            }

            using (Pen lapiz = new Pen(color))
            {
                Rectangle r = new Rectangle(5, 5, this.Width - 10, this.Height - 10);
                e.Graphics.DrawRectangle(lapiz, r);
            }
        }


        [Category("test")]
        [Description("Se lanza cuando cambia el texto del TextBox interno")]
        public event EventHandler TxtChanged;

        protected virtual void OnTxtChanged( EventArgs e)
        {
            TxtChanged?.Invoke(this, e);
        }



        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.OnTxtChanged(e);
            this.Invalidate();
        }



    }
}
