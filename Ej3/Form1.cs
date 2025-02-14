using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej3
{
    public partial class Form1 : Form
    {
        List<string> imagenes = new List<string>();
        bool flag = false;
        int intervalo = 3;
        int numeroImagen = 0;

        public Form1()
        {
            InitializeComponent();
            iniciarComboBox();
        }

        public void iniciarComboBox()
        {
            for (int i = 0; i < 20; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
            comboBox1.SelectedIndex = 2;
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    imagenes.Clear();
                    string[] archivos = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories);

                    foreach (string archivo in archivos)
                    {
                        if (archivo.EndsWith(".png") || archivo.EndsWith(".jpg"))
                        {
                            imagenes.Add(archivo);
                        }
                    }

                    if (imagenes.Count>0)
                    {
                        lblInfo.Text = "Imagenes cargadas correctamente!";
                    } else
                    {
                        lblInfo.Text = "No se encontraron imagenes!";
                    }
                }
            }


        }

        public void visualizarImagenes()
        {

            if (imagenes.Count != 0)
            {
                if (numeroImagen >= imagenes.Count)
                {
                    numeroImagen = 0;
                }

                pictureBox1.ImageLocation = imagenes[numeroImagen];
                try
                {
                    pictureBox1.Load();
                }
                catch (ArgumentException)
                {
                   
                }

            }        
        }

        private void playPause1_DesbordaTiempo(object sender, EventArgs e)
        {
            playPause1.MM += 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            playPause1.SS += 1;
            intervalo--;

            if (intervalo == 0)
            {
                intervalo = comboBox1.SelectedIndex + 1;
                numeroImagen++;
                visualizarImagenes();
            }
        }

        private void playPause1_PlayClick(object sender, EventArgs e)
        {
            if (imagenes.Count!=0)
            {
                if (flag)
                {
                    flag = false;
                    timer1.Stop();
                }
                else
                {
                    flag = true;
                    timer1.Start();
                    visualizarImagenes();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            intervalo = comboBox1.SelectedIndex + 1;
        }
    }
}
