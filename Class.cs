using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {

		private int answer_Id;
        private string? answer_Text;

        public Answer(int answer_Id, string? answer_Text)
        {
            Answer_Id = answer_Id;
            Answer_Text = answer_Text;
        }

        public int Answer_Id
		{
			get { return answer_Id; }
			set { answer_Id = value; }
		}


		public string? Answer_Text
        {
			get { return answer_Text; }
			set { answer_Text = value; }
		}



	}





	public class Subject
	{

		private int subject_Id;
        private string? subject_Name;

        public Subject(int subject_Id, string? subject_Name)
        {
            Subject_Id = subject_Id;
            Subject_Name = subject_Name;
        }

        public Exam? ExamOfSubject { get; set; }

        public int Subject_Id
        {
			get { return subject_Id; }
			set { subject_Id = value; }
		}

		public string ?Subject_Name
        {
			get { return subject_Name; }
			set { subject_Name = value; }
		}

		
	
        public void CreateExam( Exam exam)
        {
		    ExamOfSubject= exam;
            Console.WriteLine($"Exam for subject {Subject_Name} has been created.");

        }


    }
}
