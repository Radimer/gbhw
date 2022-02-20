using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Date
    {
        public string Text { get; set; }

        /// <summary>
        /// Ответ на вопрос
        /// </summary>
        public string Birth { get; set; }

        public Date(string text, string Birth)
        {
            this.Text = text;
            this.Birth = Birth;
        }

        public Date() { }
    }
}
