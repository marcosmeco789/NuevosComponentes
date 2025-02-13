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
        private int ss;
        private int mm;
        private string[] tiempoSplit;

        public PlayPause()
        {
            InitializeComponent();
            tiempoSplit = lblTimer.Text.Split(':');
            MM = int.Parse(tiempoSplit[0]);
            SS = int.Parse(tiempoSplit[1]);
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
            }
            else
            {
                btnPlay.Text = "|>";
            }
            OnPlayClick(e);
        }

        [Category("Appearance")]
        [Description("Se lanza cuando SS sobrepasa los 59")]
        public event EventHandler DesbordaTiempo;
        protected virtual void OnDesbordaTiempo(EventArgs e)
        {
            DesbordaTiempo?.Invoke(this, e);
        }

        public int SS
        {
            get { return ss; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El tiempo no puede ser negativo.");
                }
                if (value > 59)
                {
                    ss = value % 60;
                    OnDesbordaTiempo(EventArgs.Empty);
                }
                else
                {
                    ss = value;
                }
                UpdateLabel();
            }
        }

        public int MM
        {
            get { return mm; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El tiempo no puede ser negativo.");
                }
                if (value > 59)
                {
                    mm = 0;
                }
                else
                {
                    mm = value;
                }
                UpdateLabel();
            }
        }

        private void UpdateLabel()
        {
            lblTimer.Text = $"{MM:D2}:{SS:D2}";
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            tiempoSplit = lblTimer.Text.Split(':');
            MM = int.Parse(tiempoSplit[0]);
            SS = int.Parse(tiempoSplit[1]);
        }
    }
}
