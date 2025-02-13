using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponenteEj3
{
    public partial class PlayPause : UserControl
    {
        public string[] tiempoSplit;
        
        public PlayPause()
        {
            InitializeComponent();
        }



        [Category("Appearance")]
        [Description("Se lanza al hacer click en el boton")]
        public event EventHandler PlayClick;
        protected virtual void OnPlayClick(EventArgs e)
        {
            PlayClick?.Invoke(this, e);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "|>")
            {
                btnPlay.Text = "||";
                
            } else
            {
                btnPlay.Text = "|>";
            }
            OnPlayClick(e);
        }


        [Category("Appearance")]
        [Description("Se lanza cuando label sobrepasa los 59")]
        public event EventHandler DesbordaTiempo;
        protected virtual void OnDesbordaTiempo(EventArgs e)
        {
            DesbordaTiempo?.Invoke(this, e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
             tiempoSplit = lblTimer.Text.Split(':');

            if (int.Parse(tiempoSplit[1]) > 59)
            {
                tiempoSplit[1] = 00.ToString();
                OnDesbordaTiempo(e);
            }

            if (int.Parse(tiempoSplit[0]) > 59)
            {
                tiempoSplit[0] = 00.ToString();
            }
            if (int.Parse(tiempoSplit[0]) < 0 || int.Parse(tiempoSplit[1]) < 0)
            {
                throw new ArgumentException("El tiempo no puede ser negativo.");
            }


        }

    }
}
