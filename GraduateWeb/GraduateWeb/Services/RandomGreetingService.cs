using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateWeb.Services
{
    public class RandomGreetingService
    {
        private static Random r = new Random();

        private static string[] greetings = new[]
        {
            "Hi",
            "Hello",
            "Tjenatjena",
        };

        public string SayHi()
        {
            return greetings[r.Next(0, greetings.Length)];
        }
    }
}
