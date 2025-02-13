using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iniciarComboBox();
        }


        public void iniciarComboBox()
        {
            for (int i = 0; i < 19; i++)
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

                }
            }
        }

        private void playPause1_DesbordaTiempo(object sender, EventArgs e)
        {
            playPause1.tiempoSplit[0] += 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            playPause1.tiempoSplit[1] += 1;
        }

       
    }
}
