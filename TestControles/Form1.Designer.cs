using System.Drawing;

namespace TestControles
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.etiquetaAviso1 = new NuevosComponentes.EtiquetaAviso();
            this.labelTextBox1 = new NuevosComponentes.LabelTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dibujoAhorcado1 = new Ejercicio4.DibujoAhorcado();
            this.validateTextBox1 = new Ej5.ValidateTextBox();
            this.graficoDeBarras1 = new Ej6.GraficoDeBarras();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cambio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Separacion +1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.ColorFinal = System.Drawing.Color.Salmon;
            this.etiquetaAviso1.ColorInicial = System.Drawing.Color.LightGoldenrodYellow;
            this.etiquetaAviso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaAviso1.Gradiente = true;
            this.etiquetaAviso1.ImagenMarca = global::TestControles.Properties.Resources._360_LE_upscale_balanced_x4;
            this.etiquetaAviso1.Location = new System.Drawing.Point(53, 119);
            this.etiquetaAviso1.Marca = NuevosComponentes.EtiquetaAviso.EMarca.Cruz;
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(214, 62);
            this.etiquetaAviso1.TabIndex = 5;
            this.etiquetaAviso1.Text = "aaaaa";
            this.etiquetaAviso1.ClickEnMarca += new System.EventHandler(this.etiquetaAviso1_ClickEnMarca);
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.Location = new System.Drawing.Point(170, 70);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = NuevosComponentes.LabelTextBox.EPosicion.DERECHA;
            this.labelTextBox1.PswChr = 'a';
            this.labelTextBox1.Separacion = 30;
            this.labelTextBox1.Size = new System.Drawing.Size(165, 20);
            this.labelTextBox1.Subrayado = true;
            this.labelTextBox1.TabIndex = 4;
            this.labelTextBox1.TextLbl = "label1";
            this.labelTextBox1.TextTxt = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(677, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Sumar error";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dibujoAhorcado1
            // 
            this.dibujoAhorcado1.Errores = 0;
            this.dibujoAhorcado1.Location = new System.Drawing.Point(457, 119);
            this.dibujoAhorcado1.Name = "dibujoAhorcado1";
            this.dibujoAhorcado1.Size = new System.Drawing.Size(194, 202);
            this.dibujoAhorcado1.TabIndex = 2;
            this.dibujoAhorcado1.Text = "dibujoAhorcado1";
            this.dibujoAhorcado1.CambiaError += new System.EventHandler(this.dibujoAhorcado1_CambiaError);
            this.dibujoAhorcado1.Ahorcado += new System.EventHandler(this.dibujoAhorcado1_Ahorcado);
            // 
            // validateTextBox1
            // 
            this.validateTextBox1.Location = new System.Drawing.Point(285, 128);
            this.validateTextBox1.Name = "validateTextBox1";
            this.validateTextBox1.Size = new System.Drawing.Size(128, 40);
            this.validateTextBox1.TabIndex = 8;
            this.validateTextBox1.Tipo = Ej5.ValidateTextBox.eTipo.Numerico;
            this.validateTextBox1.txtMultiline = true;
            this.validateTextBox1.TxtText = "12";
            this.validateTextBox1.TxtChanged += new System.EventHandler(this.validateTextBox1_TxtTextChanged);
            // 
            // graficoDeBarras1
            // 
            this.graficoDeBarras1.Grafico = Ej6.GraficoDeBarras.eGrafico.LINEA;
            this.graficoDeBarras1.Location = new System.Drawing.Point(140, 87);
            this.graficoDeBarras1.Name = "graficoDeBarras1";
            this.graficoDeBarras1.Size = new System.Drawing.Size(389, 313);
            this.graficoDeBarras1.TabIndex = 9;
            this.graficoDeBarras1.TamañoEjes = Ej6.GraficoDeBarras.EtamañoEjes.Manual;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graficoDeBarras1);
            this.Controls.Add(this.validateTextBox1);
            this.Controls.Add(this.dibujoAhorcado1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.etiquetaAviso1);
            this.Controls.Add(this.labelTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private NuevosComponentes.LabelTextBox labelTextBox1;
        private NuevosComponentes.EtiquetaAviso etiquetaAviso1;
        private System.Windows.Forms.Button button3;
        private Ejercicio4.DibujoAhorcado dibujoAhorcado1;
        private Ej5.ValidateTextBox validateTextBox1;
        private Ej6.GraficoDeBarras graficoDeBarras1;
    }
}

