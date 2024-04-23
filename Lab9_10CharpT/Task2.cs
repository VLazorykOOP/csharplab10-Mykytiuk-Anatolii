using System;

namespace Task2
{
    delegate void StudentEventHandler(string message);

    class Student
    {
        public event StudentEventHandler StudyStarted;
        public event StudentEventHandler StudyFinished;
        public event StudentEventHandler GradeReceived;
        public event StudentEventHandler LectureAttended;

        private bool isStudying;

        public Student()
        {
            isStudying = false;
        }

        public void StartStudying()
        {
            if (!isStudying)
            {
                Console.WriteLine("Студент почав навчання");
                StudyStarted?.Invoke("Студент почав навчання");
                isStudying = true;
            }
            else
            {
                Console.WriteLine("Студент навчається");
            }
        }

        public void FinishStudying()
        {
            if (isStudying)
            {
                Console.WriteLine("Студент закінчив навчання");
                StudyFinished?.Invoke("Студент закінчив навчання");
                isStudying = false;
            }
            else
            {
                Console.WriteLine("Студент не навчається");
            }
        }

        public void ReceiveGrade(int grade)
        {
            Console.WriteLine($"Студент отримав оцінку: {grade}");
            GradeReceived?.Invoke($"Студент отримав оцінку: {grade}");
        }

        public void AttendLecture(string lectureName)
        {
            Console.WriteLine($"Student attended the lecture: {lectureName}");
            LectureAttended?.Invoke($"Student attended the lecture: {lectureName}");
        }
    }

    class Program
    {
        public static void Main_Task2()
        {
            Student student = new Student();

            student.StudyStarted += Student_StudyStarted;
            student.StudyFinished += Student_StudyFinished;
            student.GradeReceived += Student_GradeReceived;
            student.LectureAttended += Student_LectureAttended;

            bool isStudying = false;

            while (true)
            {
                Console.WriteLine("\n1. Початок навчання");
                Console.WriteLine("2. Закінчення навчання");
                Console.WriteLine("3. Отримав оцінку");
                Console.WriteLine("4. Відвідав лекцію");
                Console.WriteLine("5. Вихід\n");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Incorrect input. Please try again");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (!isStudying)
                        {
                            student.StartStudying();
                            isStudying = true;
                        }
                        else
                        {
                            Console.WriteLine("Студент зараз навчається");
                        }
                        break;

                    case 2:
                        if (isStudying)
                        {
                            student.FinishStudying();
                            isStudying = false;
                        }
                        else
                        {
                            Console.WriteLine("Студент не навчається");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Введіть оцінку: ");
                        int grade;
                        if (!int.TryParse(Console.ReadLine(), out grade))
                        {
                            Console.WriteLine("Incorrect input. Please try again");
                            break;
                        }
                        student.ReceiveGrade(grade);
                        break;

                    case 4:
                        Console.WriteLine("Введіть назву лекції: ");
                        string lectureName = Console.ReadLine();
                        student.AttendLecture(lectureName);
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void Student_StudyStarted(string message)
        {
            Console.WriteLine(message);
        }

        private static void Student_StudyFinished(string message)
        {
            Console.WriteLine(message);
        }

        private static void Student_GradeReceived(string message)
        {
            Console.WriteLine(message);
        }

        private static void Student_LectureAttended(string message)
        {
            Console.WriteLine(message);
        }
    }
}
