using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        int need;
        System.Collections.Generic.Stack<string> Stack = new Stack<string>();


        public static int MinSteps(int need)
        {
            int steps = 0;
            while (need > 0)
            {
                if (need%2 == 1)
                {
                    steps++;
                    need--;
                }
                else
                {
                    steps++;
                    need = need / 2;
                }
            }
            return steps;
        }
        public Form1()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            lblSteps.Text = "0";
            lblNeedNumber.Text = "0";
            lblNeedSteps.Text = "0";
            this.Text = "Удвоитель";
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            Stack.Push(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblSteps.Text = (int.Parse(lblSteps.Text) + 1).ToString();
            if (lblNumber.Text == lblNeedNumber.Text && lblSteps.Text == lblNeedSteps.Text) MessageBox.Show("ПОЗДРАВЛЯЮ ВЫ ПОБЕДИЛИ!");
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            Stack.Push(lblNumber.Text);
            if (lblNumber.Text != "0") lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            if (lblSteps.Text != "0")  lblSteps.Text = (int.Parse(lblSteps.Text) + 1).ToString();
            if (lblNumber.Text == lblNeedNumber.Text && lblSteps.Text == lblNeedSteps.Text) MessageBox.Show("ПОЗДРАВЛЯЮ ВЫ ПОБЕДИЛИ!");
        }

        private void btnCommand3_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSteps.Text) > 0) lblSteps.Text = (int.Parse(lblSteps.Text) - 1).ToString();
            if (int.Parse(lblNumber.Text) > 0) lblNumber.Text = Stack.Pop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            lblSteps.Text = "0";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stack.Push(lblNumber.Text);
            Random random = new Random();
            need = random.Next(0,100);
            lblNeedNumber.Text = need.ToString();
            string needSteps = MinSteps(need).ToString();
            lblNeedSteps.Text = needSteps;
            MessageBox.Show($"Вам требуеться набрать {need} за {needSteps} шагов");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\ninstruction\n" +
                            "\nДля начала новой игры выберите в меню game->new game\n" +
                            "\nВ первом ряду отображаются текушее число и количество ходов\n" +
                            "\nВо втором ряду отображаются требуемое число и минимальное количество шагов\n" +
                            "\nКнопка +1 увеличивает текущее число на 1 и увеличивает количество шагов на 1\n" +
                            "\nКнопка x2 увеличивает текущее число в 2 раза и увеличивает количество шагов на 1\n" +
                            "\nКнопка return откатывает состояние текущих числа и шагов к предыдущему\n" +
                            "\nКнопка reset сбрасывает текущие число и шаги в 0\n" +
                            "\nДля победы добейтесь совпадения текущих и требующихся чисел\n" +
                            "\nДля выхода выберите в меню exit\n"
                            );
        }
    }
}
