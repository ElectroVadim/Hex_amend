using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        static Parsing parsing = new Parsing();

        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
        }

        OpenFileDialog HEX = new OpenFileDialog();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HEX.Filter = "HEX|*.hex";
           if( HEX.ShowDialog()==DialogResult.OK)
           {
               textBox2.Text = HEX.FileName;
               parsing.adres(HEX.FileName);
               button1.Visible = true;
           }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            parsing.Text(textBox1.Text);
            parsing.rewrite();
            button1.Visible = false;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (textBox1.Text.Length > 8)
            e.Handled = true;
        }
       
    }
}
