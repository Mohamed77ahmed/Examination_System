using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Exam
    {
		private int timeOfExam;
        private int numberOfQuestion;
        public List<Question>? Questions { get; set; }
        public int Grade { get; set; }

        public  virtual string TypeOfExam { get;  } 
        public int TimeOfExam
        {
            get { return timeOfExam; }
            set { timeOfExam = value; }
        }

        public int NumberOfQuestion

        {
            get { return numberOfQuestion; }
            set { numberOfQuestion = value; }
        }

        public Exam(int timeOfExam, int numberOfQuestion)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestion = numberOfQuestion;
			Questions= new List<Question>();
           
        }

      public void AddQuestion(Question q)
        { 
            if(Questions?.Count<numberOfQuestion)
                Questions.Add(q);
            else Console.WriteLine("you can't add more question ");
        
        
        }

	public virtual void ShowExam()
		{
            int student_answer ,counter=1;
            Console.WriteLine($"{TypeOfExam}           Duration:{TimeOfExam}");

            if(Questions is not null)
            foreach (var q in Questions)
            {
                    Console.WriteLine($"Question:{counter}");
                q.Display();

                   
                   
                    do
                    {
                        Console.WriteLine("enter your answer id");

                         student_answer = int.Parse(Console.ReadLine() ?? "0");
                
                    } while (student_answer==0);

                   q.StudentAnswerId = student_answer;

                    if (student_answer == q.RightAnswer_id) Grade += q.Mark;


                    Console.WriteLine("");

            }
		
		}

	}


    public class PracticalExam : Exam

    {

        public override string TypeOfExam => "PracticalExam";
        public PracticalExam(int timeOfExam, int numberOfQuestion) : base(timeOfExam, numberOfQuestion)
        {
        }

        public override void ShowExam()
        {
            base.ShowExam();
            Console.Clear();
            Console.WriteLine("correct answers");
            int counter = 1;
            if(Questions is not null)
            foreach (var q in Questions)
            {
                    Console.WriteLine($"Question {counter}   Question Type : {q.HeaderOfQuestion}, correct answer :{q.RightAnswer_id}  your answer {q.StudentAnswerId}");

             counter++;
            }

            Console.WriteLine($"Grade : {Grade}");

            Console.WriteLine("Thank You");


        }
 
    }






    public class FinalEXam : Exam
    {

        public override string TypeOfExam => "Final Exam";
        public FinalEXam(int timeOfExam, int numberOfQuestion) : base(timeOfExam, numberOfQuestion)
        {
        }


        public override void ShowExam()
        {
            int counter = 1;
            base.ShowExam();

            Console.Clear();
            Console.WriteLine("correct answer");

            

            if(Questions is not null) 
            foreach (var q in Questions)
            {
                    Console.WriteLine($"Question:{counter}");

                    q.Display();
                    Console.WriteLine($"your answer : {q.StudentAnswerId}");
                    Console.WriteLine($"correct answer : {q.RightAnswer_id}");
                   counter++;


            }


            Console.WriteLine($"Grade : {Grade}");

            Console.WriteLine("Thank You");

        }

    }
}
