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
    public partial class ValidateTextBox: UserControl
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
            using (Pen lapiz = new Pen(Color.Red))
            {
                Rectangle r = new Rectangle(5, 5, this.Width - 10, this.Height - 10);
                e.Graphics.DrawRectangle(lapiz, r);
            }
        }


    }
}
