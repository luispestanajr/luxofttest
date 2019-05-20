using System;
using System.Linq;

namespace luxofttest
{
    class Program
    {
        private static readonly string[] daysOfTheWeek = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        static void Main(string[] args)
        {
            // Here I am doing a test for all days of the week plus 0 to 100 days foward
            // I am only writting comments in this code for explanation, because I have in mind that
            // if you have a nice codification, it is not necessary to write comments
            for(int i = 0; i < daysOfTheWeek.Length; i++)
            {
                for (int z = 0; z <= 100; z++)
                {
                    Console.WriteLine($"The result of testing for the Day Of The Week >> {daysOfTheWeek[i]} + {z} << days is" +
                    	$" {GetNextDayOfTheWeekName(daysOfTheWeek[i], z)}.");
                }
            }

            Console.ReadKey();
        }

        private static string GetNextDayOfTheWeekName(string dayOfTheWeek, int daysFoward)
        {
            // I like to separate my code in simple and small functions. First because it will be more
            // testable. Also, because I follow the SOLID, in this case, the "S" for Single Responsability
            var result = "";

            var indexSearch = daysOfTheWeek.Select((day, index) => 
                new { day, index }).First(d => d.day.ToUpper() == dayOfTheWeek.ToUpper()).index;

            result = daysOfTheWeek[GetFormula(daysFoward, indexSearch)];

            return result;
        }

        private static int GetFormula(int daysFoward, int indexSearch)
        {
            // Why do I not return the function in one simple statment? Because in this way, it will 
            // be easy to debug
            var result = ((daysFoward + indexSearch) % (daysOfTheWeek.Length));

            return result;
        }
    }
}
