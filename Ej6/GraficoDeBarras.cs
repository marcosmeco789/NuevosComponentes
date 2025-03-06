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
    public partial class GraficoDeBarras: UserControl
    {
        List<double> valores = new List<double> { 1,5,2,10,15,7,11,};

        public GraficoDeBarras()
        {
            InitializeComponent();
        }
    }
}
