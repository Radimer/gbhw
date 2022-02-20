using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value = decimal.Parse(textBox1.Text);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
