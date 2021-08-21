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
    public partial class setting : Form
    {
        public static string Output_Path;
            


        public setting()
        {
            InitializeComponent();
        }

        private void RefBtn_output_Click(object sender, EventArgs e)
        {
            if(OutFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                Output_Path = OutFolderBrowser.SelectedPath;
                OutFolderLabel.Text = OutFolderBrowser.SelectedPath;
            }
        }
    }
}
