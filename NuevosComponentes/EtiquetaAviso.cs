using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class EtiquetaAviso : Control
    {
        public enum EMarca
        {
            Nada,
            Cruz,
            Circulo,
            Imagen
        }

        public Rectangle rectImagen;


        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (Gradiente)
            {
                using (LinearGradientBrush lg = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), ColorInicial, ColorFinal))
                {
                    e.Graphics.FillRectangle(lg, this.ClientRectangle);
                }

            }
            else
            {
                g.Clear(this.BackColor);
            }

            int grosor = 0; //Grosor de las líneas de dibujo
            int offsetX = 0; //Desplazamiento a la derecha del texto
            int offsetY = 0; //Desplazamiento hacia abajo del texto
                             // Altura de fuente, usada como referencia en varias partes
            int h = this.Font.Height;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
            // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case EMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    h, h);
                    rectImagen = new Rectangle(grosor-FontHeight/2, grosor-FontHeight/2, FontHeight*2, FontHeight*2);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    
                    break;
                case EMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    rectImagen = new Rectangle(grosor, grosor, FontHeight, FontHeight);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;

                case EMarca.Imagen:
                    if (ImagenMarca != null)
                    {
                        grosor = 4;
                        g.DrawImage(ImagenMarca, new Rectangle(grosor, grosor, FontHeight, FontHeight));
                        rectImagen = new Rectangle(grosor, grosor, FontHeight, FontHeight);
                        offsetX = FontHeight + grosor;
                        offsetY = grosor;


                    }
                    break;
            }
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();
        }


        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        private EMarca marca = EMarca.Nada;
        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        public EMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }


        private bool gradiente;
        [Category("Appearance")]
        [Description("Activa o desactiva el fondo")]
        public bool Gradiente
        {
            get
            {
                return gradiente;
            }
            set
            {
                gradiente = value;
                this.Refresh();
            }
        }


        private Color colorInicial;
        [Category("Appearance")]
        [Description("Color inicial")]
        public Color ColorInicial
        {
            get
            {
                return colorInicial;
            }
            set
            {
                colorInicial = value;
                this.Refresh();
            }
        }


        private Color colorFinal;
        [Category("Appearance")]
        [Description("Color final")]
        public Color ColorFinal
        {
            get
            {
                return colorFinal;
            }
            set
            {
                colorFinal = value;
                this.Refresh();
            }
        }


        [Category("Appearance")]
        [Description("imagen a mostrar")]

        public Image ImagenMarca { set; get; }

        [Category("Appearance")]
        [Description("Se lanza al hacer click en la marca")]
        public event EventHandler ClickEnMarca;
        protected virtual void OnClickEnMarca(EventArgs e)
        {
            ClickEnMarca?.Invoke(this, e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);


            if (Marca != EMarca.Nada && rectImagen.Contains(e.Location))
            {
                OnClickEnMarca(EventArgs.Empty);
            }


        }










    }
}
