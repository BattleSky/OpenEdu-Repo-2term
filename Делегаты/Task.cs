using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    internal delegate bool TryGet<T1, T2> (string question, Action<string> tellUser, out int age);

    internal class Task
    {
        
        static void Main656()
        {
            Run(AskUser, Console.WriteLine);
        }

        static void Run(TryGet<string, int> askUser, Action<string> tellUser)
        {
            int age;
            if (askUser("What is your age?", tellUser, out age))
                tellUser("Age: " + age);
        }

        static bool AskUser(string questionText, Action<string> tellUser, out int age)
        {
            tellUser(questionText);
            var answer = Console.ReadLine();
            return int.TryParse(answer, out age);
        }
	}
}
