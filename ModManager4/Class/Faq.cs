using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Faq
    {
        public int id;
        public string question;
        public string answer;

        public Faq(int id, string question, string answer)
        {
            this.id = id;
            this.question = question;
            this.answer = answer;
        }
    }
}
