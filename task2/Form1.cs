namespace task2
{
    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "������� ����� ����";
            button1.Text = "������ �����";
            button2.Text = "����� ����";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.target = Program.random.Next(0, 100);
            label3.Text = "������� ������ �����";
            label1.Text = "0";
            label2.Text = "0";
            Program.insertNumber = 0;
            Program.steps = 0;
        }
    }
}