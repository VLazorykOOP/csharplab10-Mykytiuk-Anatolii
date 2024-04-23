using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{

    class EmployeeException : Exception
    {
        public EmployeeException(string message) : base(message) { }
    }

    class ArrayTypeMismatchException : EmployeeException
    {
        public ArrayTypeMismatchException(string message) : base(message) { }
    }

    class DivideByZeroException : EmployeeException
    {
        public DivideByZeroException(string message) : base(message) { }
    }

    class IndexOutOfRangeException : EmployeeException
    {
        public IndexOutOfRangeException(string message) : base(message) { }
    }

    class InvalidCastException : EmployeeException
    {
        public InvalidCastException(string message) : base(message) { }
    }

    class OutOfMemoryException : EmployeeException
    {
        public OutOfMemoryException(string message) : base(message) { }
    }

    class OverflowException : EmployeeException
    {
        public OverflowException(string message) : base(message) { }
    }

    class StackOverflowException : EmployeeException
    {
        public StackOverflowException(string message) : base(message) { }
    }

    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {MiddleName}, {Gender}, {Age}, {Salary}";
        }
    }

    class Program
    {
        public static void Main_Task1()
        {
            try
            {
                // Читаємо дані з файлу і зберігаємо їх у списку співробітників
                List<Employee> employees = new List<Employee>();
                using (StreamReader sr = new StreamReader("C:\\Users\\Anatoha\\github-classroom\\VLazorykOOP\\csharplab10-Mykytiuk-Anatolii\\Lab9_10CharpT\\employees.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split(',');
                        if (data.Length == 6)
                        {
                            Employee emp = new Employee
                            {
                                LastName = data[0],
                                FirstName = data[1],
                                MiddleName = data[2],
                                Age = int.Parse(data[4]),
                                Salary = double.Parse(data[5])
                            };

                            // Отримуємо перший символ рядка та перетворюємо його у символ для статі співробітника
                            char gender;
                            if (char.TryParse(data[3].Substring(0, 1), out gender))
                            {
                                emp.Gender = gender;
                            }
                            else
                            {
                                throw new InvalidCastException($"Incorrect gender format for employee: {emp.LastName}, {emp.FirstName}, {emp.MiddleName}");
                            }

                            employees.Add(emp);
                        }
                        else
                        {
                            throw new IndexOutOfRangeException($"Incorrect data format for employee: {string.Join(",", data)}");
                        }
                    }
                }

                // Розділяємо співробітників на дві групи: зарплата < 10000 та зарплата >= 10000
                Queue<Employee> lowSalaryEmployees = new Queue<Employee>();
                Queue<Employee> highSalaryEmployees = new Queue<Employee>();
                foreach (Employee emp in employees)
                {
                    if (emp.Salary < 10000)
                        lowSalaryEmployees.Enqueue(emp);
                    else
                        highSalaryEmployees.Enqueue(emp);
                }

                // Друкуємо спочатку співробітників з низькою зарплатою, потім з високою
                Console.WriteLine("Employees with salary < 10000:");
                while (lowSalaryEmployees.Count > 0)
                {
                    Console.WriteLine(lowSalaryEmployees.Dequeue());
                }

                Console.WriteLine("\nEmployees with salary >= 10000:");
                while (highSalaryEmployees.Count > 0)
                {
                    Console.WriteLine(highSalaryEmployees.Dequeue());
                }
            }
            catch (ArrayTypeMismatchException ex)
            {
                Console.WriteLine($"ArrayTypeMismatchException: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"DivideByZeroException: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"IndexOutOfRangeException: {ex.Message}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"InvalidCastException: {ex.Message}");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"OutOfMemoryException: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OverflowException: {ex.Message}");
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine($"StackOverflowException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Стандартний виняток: {ex.Message}");
            }
        }
    }
}