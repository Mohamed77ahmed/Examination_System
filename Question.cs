using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Question
    {
        public Question()
        {

        }

        public virtual string? HeaderOfQuestion { get; }
        private int mark;
        private string? bodyOfQuestion;
        public List<Answer>? answerlist { get; set; }
        public int RightAnswer_id { get; set; }
        public int StudentAnswerId { get; set; }   



        public string? BodyOfQuestion
        {
            get { return bodyOfQuestion; }


            set { bodyOfQuestion = value; }
        }

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public Question(string? bodyOfQuestion, int mark, List<Answer> answer, int rightanswer_id)
        {


            BodyOfQuestion = bodyOfQuestion;
            Mark = mark;
            answerlist = answer;
            RightAnswer_id = rightanswer_id;


        }
        public virtual void Display()
        {
            Console.WriteLine($"{HeaderOfQuestion} , mark : {mark} ");
            Console.WriteLine("");
            Console.WriteLine($"{bodyOfQuestion} ");

            if (answerlist != null)
            {
                foreach (var item in answerlist)
                    Console.WriteLine($"{item.Answer_Id}){item.Answer_Text}");


            }






        }



        public class McqQuestion : Question

        {
            public override string? HeaderOfQuestion => "MCQ question";
            public McqQuestion(string? bodyOfQuestion, int mark, List<Answer> answer, int answer_id) : base(bodyOfQuestion, mark, answer, answer_id)
            {

            }



        }




        public class TFQuestion : Question

        {
            public TFQuestion(string? bodyOfQuestion, int mark, List<Answer> answer, int answer_id) : base(bodyOfQuestion, mark, answer, answer_id)
            {
            }

            public override string? HeaderOfQuestion => "T/F Question";



        }

    }
}