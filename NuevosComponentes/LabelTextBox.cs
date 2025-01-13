﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class LabelTextBox : UserControl
    {
        public enum EPosicion
        {
            IZQUIERDA, DERECHA
        }

        public LabelTextBox()
        {

            InitializeComponent();
            this.Refresh();
        }

        private EPosicion posicion = EPosicion.IZQUIERDA;
        [Category("Mis Propiedades")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]
        public EPosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(EPosicion), value))
                {
                    posicion = value;
                    this.Refresh();
                    //PosicionChanged(this, EventArgs.Empty);
                    OnPosicionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }


        private int separacion = 0;
        [Category("Mis Propiedades")] // O se puede meter en categoría Design.
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    this.Refresh();
                    OnSeparacionChanged(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }


        [Category("Mis Propiedades")] // O se puede meter en categoría Appearance.
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                this.Refresh();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Mis Propiedades")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
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

        private void recolocar()
        {
            switch (posicion)
            {
                case EPosicion.IZQUIERDA:
                    // Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    // Establecemos ancho del LabelTextBox
                    this.Width = txt.Width + lbl.Width + Separacion;
                    // Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case EPosicion.DERECHA:
                    // Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    // Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    // Establecemos ancho del LabelTextBox
                    this.Width = txt.Width + lbl.Width + Separacion;
                    // Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }
        // Esta función has de enlazarla con el evento SizeChanged.
        // Sería necesario también tener en cuenta otros eventos como FontChanged
        // que aquí nos saltamos.
        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            //  recolocar();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event EventHandler PosicionChanged;

        protected virtual void OnPosicionChanged(EventArgs e)
        {
            if (PosicionChanged != null)
            {
                PosicionChanged(this, e);
            }
        }

        [Category("La separacion cambió")]
        [Description("Se lanza cuando la propiedad separacion cambia")]
        public event EventHandler SeparacionChanged;

        protected virtual void OnSeparacionChanged(EventArgs e)
        {
            SeparacionChanged?.Invoke(this, e);
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }


        [Category("txt cambió")]
        [Description("Se lanza cuando txt cambia")]
        public event EventHandler TxtChanged;

        protected virtual void OnTxtChanged(EventArgs e)
        {
            TxtChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.OnTxtChanged(e);
        }


        private string pswChr = "";
        [Category("Mis Propiedades")] 
        [Description("Caracter de contraseña")]

        public string PswChr
        {
            set
            {
                if (value == "")
                {
                    pswChr = value;
                } else
                {
                    pswChr = value;
                    txt.PasswordChar = char.Parse(pswChr);
                }
                
                
            }

            get
            {
                return pswChr;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            recolocar();
            e.Graphics.DrawLine(new Pen(Color.Violet),
            lbl.Left, this.Height - 1,
            lbl.Left + lbl.Width, this.Height - 1);
        }
    }

    
}
