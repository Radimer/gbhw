namespace task2
{
    internal static class Program
    {
        public static int insertNumber = 0;
        public static int steps = 0;
        public static int target = 0;

        public static void Compare(int insertNumber)
        {
            if (target < insertNumber)
            {
                steps++;
                Form1.label1.Text = steps.ToString();
                Form1.label2.Text = insertNumber.ToString();
                Form1.label3.Text = "Ваше число больше";
            }
            else if (target > insertNumber)
            {
                steps++;
                Form1.label1.Text = steps.ToString();
                Form1.label2.Text = insertNumber.ToString();
                Form1.label3.Text = "Ваше число меньше";
            }

            else 
            {
                steps++;
                Form1.label1.Text = steps.ToString();
                Form1.label2.Text = insertNumber.ToString();
                Form1.label3.Text = "Поздравляю вы угадали";
            }
            
        }

        public static Random random = new Random();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}