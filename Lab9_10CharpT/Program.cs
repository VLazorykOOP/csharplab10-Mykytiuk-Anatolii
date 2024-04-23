using System.Threading.Tasks;
using Task1;
using Task2;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelect the task number(1 or 2) or #3 for exit : ");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Task1.Program.Main_Task1();
                    break;

                case 2:
                   Task2.Program.Main_Task2();
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}