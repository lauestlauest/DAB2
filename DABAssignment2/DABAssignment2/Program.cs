using DABAssignment2.Data;

namespace DABAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AUCanteens();
            Console.WriteLine("Hello, World!");
        }
    }
}