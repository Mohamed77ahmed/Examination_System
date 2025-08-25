using System.Transactions;
using static Examination_System.Question;

namespace Examination_System
{
    internal class Program
    {

        static Subject CreateSubject()
        {
            int sub_id;
            Console.WriteLine("Enter Subject Id");
            while (!int.TryParse(Console.ReadLine(), out sub_id))
            {
                Console.WriteLine("Invalid input! Please enter a valid number for Subject Id:");
            }

            Console.WriteLine("Enter Subject Name");
            string sub_name = Console.ReadLine() ?? "";
            Console.Clear();

            return new Subject(sub_id, sub_name);
        }



        static int ChooseExamType()
        {
            int exam_type;
            do
            {
                Console.WriteLine("1 for Practical Exam | 2 for Final Exam");
                while (!int.TryParse(Console.ReadLine(), out exam_type))
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2:");
                }
            } while (exam_type != 1 && exam_type != 2);

            return exam_type;
        }


        static int ChooseExamTime()
        {
            int time;
            Console.WriteLine("Choose time of exam ");
            while (!int.TryParse(Console.ReadLine(), out time) || time < 40 || time > 90)
            {
                Console.WriteLine("Invalid input! Please enter time between 40 and 90:");
            }
            return time;
        }

        
        static int ChooseNumberOfQuestions()
        {
            int numofquestion;
            do
            {
                Console.WriteLine("Enter number of questions");
                while (!int.TryParse(Console.ReadLine(), out numofquestion) || numofquestion <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number of questions:");
                }
            } while (numofquestion == 0);
            Console.Clear();
            return numofquestion;
        }

    
        static PracticalExam CreatePracticalExam(Subject subject, int time, int numofquestion)
        {
            PracticalExam practical = new PracticalExam(time, numofquestion);

            for (int i = 0; i < numofquestion; i++)
            {
                Console.WriteLine($"Enter body of question {i + 1}");
                string bodyofquestion = Console.ReadLine();

                int mark;
                Console.WriteLine($"Enter mark of question {i + 1}");
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid mark (number > 0):");
                }

                List<Answer> answer = new List<Answer>(3);
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Enter answer {j + 1} of question {i + 1}");
                    string answertxt = Console.ReadLine() ?? "";
                    answer.Add(new Answer(j + 1, answertxt));
                }

                int rightanswer_id;
                do
                {
                    Console.WriteLine("Enter right answer id (1-3):");
                    while (!int.TryParse(Console.ReadLine(), out rightanswer_id) || rightanswer_id < 1 || rightanswer_id > 3)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid right answer id (1-3):");
                    }
                } while (rightanswer_id == 0);

                McqQuestion mcq = new McqQuestion(bodyofquestion, mark, answer, rightanswer_id);
                practical.Questions.Add(mcq);

                Console.Clear();
                subject.CreateExam(practical);
            }
            return practical;
        }

        static FinalEXam CreateFinalExam(Subject subject, int time, int numofquestion)
        {
            FinalEXam final = new FinalEXam(time, numofquestion);

            for (int i = 0; i < numofquestion; i++)
            {
                int question_type;
                do
                {
                    Console.WriteLine("Enter type of question : 1 for MCQ | 2 for T/F");
                    while (!int.TryParse(Console.ReadLine(), out question_type) || (question_type != 1 && question_type != 2))
                    {
                        Console.WriteLine("Invalid input! Please enter 1 for MCQ or 2 for T/F:");
                    }
                } while (question_type == 0);

                Console.Clear();

                if (question_type == 1)
                {
                    final.Questions.Add(CreateMcqQuestion(i));
                }
                else if (question_type == 2)
                {
                    final.Questions.Add(CreateTFQuestion(i));
                }

                Console.Clear();
                subject.CreateExam(final);
            }

            return final;
        }

        static McqQuestion CreateMcqQuestion(int index)
        {
            Console.WriteLine($"Enter body of question {index + 1}");
            string bodyofquestion = Console.ReadLine();

            int mark;
            Console.WriteLine($"Enter mark of question {index + 1}");
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a valid mark (number > 0):");
            }

            List<Answer> answer = new List<Answer>(3);
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Enter answer {j + 1} of question {index + 1}");
                string answertxt = Console.ReadLine() ?? "";
                answer.Add(new Answer(j + 1, answertxt));
            }

            int rightanswer_id;
            do
            {
                Console.WriteLine("Enter right answer id (1-3):");
                while (!int.TryParse(Console.ReadLine(), out rightanswer_id) || rightanswer_id < 1 || rightanswer_id > 3)
                {
                    Console.WriteLine("Invalid input! Please enter a valid right answer id (1-3):");
                }
            } while (rightanswer_id == 0);

            return new McqQuestion(bodyofquestion, mark, answer, rightanswer_id);
        }

        static TFQuestion CreateTFQuestion(int index)
        {
            Console.WriteLine($"Enter body of question {index + 1}");
            string bodyofquestion = Console.ReadLine();

            int mark;
            Console.WriteLine($"Enter mark of question {index + 1}");
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a valid mark (number > 0):");
            }

            List<Answer> answer = new List<Answer>(2);
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine($"Enter answer {j + 1} of question {index + 1}");
                string answertxt = Console.ReadLine() ?? "";
                answer.Add(new Answer(j + 1, answertxt));
            }

            int rightanswer_id;
            do
            {
                Console.WriteLine("Enter right answer id (1-2):");
                while (!int.TryParse(Console.ReadLine(), out rightanswer_id) || rightanswer_id < 1 || rightanswer_id > 2)
                {
                    Console.WriteLine("Invalid input! Please enter a valid right answer id (1-2):");
                }
            } while (rightanswer_id == 0);

            return new TFQuestion(bodyofquestion, mark, answer, rightanswer_id);
        }

        static void StartExam(Exam exam)
        {
            Console.Clear();
            char start;
            Console.WriteLine("Do you want start (Y|N)");
            start = Char.Parse(Console.ReadLine());
            Console.Clear();
            if (start == 'Y' || start == 'y') exam.ShowExam();
            else Console.WriteLine($"{exam.GetType().Name} has been created");
        }






        static void Main(string[] args)
        {
            Subject subject = CreateSubject();
            int exam_type = ChooseExamType();
            int time = ChooseExamTime();
            int numofquestion = ChooseNumberOfQuestions();

            if (exam_type == 1)
            {
                PracticalExam practical = CreatePracticalExam(subject, time, numofquestion);
                StartExam(practical);
            }
            else if (exam_type == 2)
            {
                FinalEXam final = CreateFinalExam(subject, time, numofquestion);
                StartExam(final);
            }
        }

       
       

       
    }
}
