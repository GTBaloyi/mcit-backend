using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Commons
{
    public class CommonMethods
    {
        //TODO: write a test
        public string generateCode(int numberOfCharacters)
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_?-@";
            string result = "";
            var random = new Random();
            for (int i = 0; i < numberOfCharacters; i++)
            {
                result = result + characters[random.Next(characters.Length)];
            }

            return result;
        }
    }
}
