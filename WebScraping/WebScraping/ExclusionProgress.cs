using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraping
{
    public partial class ExclusionProgress : Form
    {
        public ExclusionProgress()
        {
            InitializeComponent();
        }

        public void SetProgress(int min, int max)
        {
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
        }
    }
}
