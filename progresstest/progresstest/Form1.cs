using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progresstest
{
    public partial class Form1 : Form
    {
        Form2 form2;
        int min, max, value;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();

            min = 0;
            max = 100;
            value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();

            form2.progressBar1.Minimum = min;
            form2.progressBar1.Maximum = max;

            for(int i = 1;i <= 10; i++)
            {
                System.Threading.Thread.Sleep(1000);

                form2.progressBar1.Value = i * 10;
               
            }

            System.Threading.Thread.Sleep(5000);
            form2.Close();
            form2.Dispose();
        }



    }
}
