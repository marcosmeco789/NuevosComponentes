using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej6
{
    public partial class GraficoDeBarras : UserControl//Dibujar ejes. Tamaños relativos. Revisar rojo en automatico. Propiedades de texto de ejes y colección . Revisar en general.
    {
        List<float> valores = new List<float> {23, 3, 5, 7, 10, 15, 7, 11 };

        public GraficoDeBarras()
        {
            InitializeComponent();
        }




        public void dibujarVerde(PaintEventArgs e, float x1, float y1, float x2, float y2)
        {
            using (Pen p = new Pen(Color.Green,5))
            {
                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        public void dibujarAzul(PaintEventArgs e, float x1, float y1, float x2, float y2)
        {
            using (Pen p = new Pen(Color.Blue,5))
            {
                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        public void dibujarAmarillo(PaintEventArgs e, float x1, float y1, float x2, float y2)
        {
            using (Pen p = new Pen(Color.Yellow,5))
            {
                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        public void dibujarRojo(PaintEventArgs e, float x1, float y1, float x2, float y2)
        {
            using (Pen p = new Pen(Color.Red,5))
            {
                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float maxY = 15;
            float x1 = 30;
            float y1 = 100;
            int barras = valores.Count;
            int aux = 0;

            if (Grafico == eGrafico.BARRAS)
            {
                if (tamañoEjes == EtamañoEjes.Automatico)
                {
                    float valorMaximo = valores.Max();

                    for (int i = 0; i < barras; i++)
                    {
                        float valor = valores[i];
                        float alturaBarra = (valor / valorMaximo) * maxY;

                        if (valor >= valorMaximo)
                        {
                            dibujarRojo(e, x1, y1, x1, y1 - alturaBarra);
                        }
                        else
                        {
                            aux++;
                            switch (aux)
                            {
                                case 1:
                                    dibujarVerde(e, x1, y1, x1, y1 - alturaBarra);
                                    break;

                                case 2:
                                    dibujarAzul(e, x1, y1, x1, y1 - alturaBarra);
                                    break;

                                case 3:
                                    dibujarAmarillo(e, x1, y1, x1, y1 - alturaBarra);
                                    aux = 0;
                                    break;

                                default:
                                    break;
                            }
                        }
                        x1 += 30;
                    }
                }
                else
                {
                    float maxYManual = 13;

                    for (int i = 0; i < barras; i++)
                    {
                        float valor = valores[i];
                        float alturaBarra = (valor / maxYManual) * maxY;

                        if (valor >= maxYManual)
                        {
                            dibujarRojo(e, x1, y1, x1, y1 - alturaBarra);
                        }
                        else
                        {
                            aux++;
                            switch (aux)
                            {
                                case 1:
                                    dibujarVerde(e, x1, y1, x1, y1 - alturaBarra);
                                    break;

                                case 2:
                                    dibujarAzul(e, x1, y1, x1, y1 - alturaBarra);
                                    break;

                                case 3:
                                    dibujarAmarillo(e, x1, y1, x1, y1 - alturaBarra);
                                    aux = 0;
                                    break;

                                default:
                                    break;
                            }
                        }
                        x1 += 30;
                    }
                }
            }
            else if (Grafico == eGrafico.LINEA)
            {
                using (Pen p = new Pen(this.ForeColor, 2))
                {
                    float valorMaximo = 13;
                    if (tamañoEjes == EtamañoEjes.Automatico)
                    {
                        valorMaximo = valores.Max();
                    }
                    PointF[] puntos = new PointF[barras];

                    for (int i = 0; i < barras; i++)
                    {
                        float valor = valores[i];
                        float alturaBarra = (valor / valorMaximo) * maxY;
                        puntos[i] = new PointF(x1, y1 - alturaBarra);
                        x1 += 30;
                    }

                    e.Graphics.DrawLines(p, puntos);
                }
            }

          
            string textoEjeX = "Eje X";
            Font fuente = new Font("Arial", 10);
            Brush pincel = Brushes.Black;
            e.Graphics.DrawString(textoEjeX, fuente, pincel, new PointF(this.Width / 2, this.Height - 20));

           
            string textoEjeY = "Eje Y";
            e.Graphics.TranslateTransform(10, this.Height / 2);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString(textoEjeY, fuente, pincel, new PointF(0, 0));
            e.Graphics.ResetTransform();
        }

        public enum EtamañoEjes
        {
            Manual,
            Automatico
        }

        private EtamañoEjes tamañoEjes;
        [Category("test")]
        [Description("prueba")]
        public EtamañoEjes TamañoEjes
        {
            set
            {
                tamañoEjes = value;
                this.Invalidate();
            }
            get
            {
                return tamañoEjes;
            }
        }

        public enum eGrafico
        {
            BARRAS,
            LINEA
        }

        private eGrafico grafico;
        [Category("test")]
        [Description("Tipo de gráfico")]
        public eGrafico Grafico
        {
            set
            {
                grafico = value;
                this.Invalidate();
            }
            get
            {
                return grafico;
            }
        }
    }
}