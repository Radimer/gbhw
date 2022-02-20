using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {
        private Calendar database;
        public Form1()
        {
            InitializeComponent();
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            button1.Text = "Записать";

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            for (int i = 0; i < database.Count; i++)
            {
                if (database[i].Birth == monthCalendar1.SelectionRange.Start.ToString())
                {
                    textBox1.Text = database[i].Text;
                }
                else textBox1.Text = null;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new Calendar(dlg.FileName);
                database.Add("Махатма Ганди", "02/03/2022");
                database.Add("Махатма Ганди", "02/03/2022");
                database.Save();
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new Calendar(dlg.FileName);
                database.Load();
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                database.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                database.fileName = saveFileDialog1.FileName;
                database.Save();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (database == null) MessageBox.Show("База не создана");
            else
            {
                for (int i = 0; i < database.Count; i++)
                {
                    if (database[i].Birth == monthCalendar1.SelectionRange.Start.ToString())
                    {
                        database[i].Text = textBox1.Text;
                    }
                    else
                    {
                        database.Add(textBox1.Text, monthCalendar1.SelectionRange.Start.ToString());
                    }
                }
            }
        }
    }
}
