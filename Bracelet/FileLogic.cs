using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Bracelet
{
    static class FileLogic
    {
        static public (string leftArm, string rightArm) getArms(int count, bool isRight)
        {
            List<string> bracelets = read(ConfigurationManager.AppSettings["path"]);
            var answer = generate(bracelets, count, isRight);

            return answer;
        }

        static private List<string> read(string path)
        {
            List<string> answer = new List<string>();

            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    string str = reader.ReadLine();
                    if (!str.StartsWith("//"))
                    {
                        answer.Add(str);
                    }
                }
            }

            return answer;
        }

        static private (string, string) generate(List<string> bracelets, int count, bool isRight)
        {
            string leftArm = "";
            string rightArm = "";

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int number = rnd.Next(0, bracelets.Count);

                string bracelet = bracelets[number];
                bracelets.RemoveAt(number);

                if (!isRight || rnd.Next(0, 4) > 0)
                {
                    leftArm += bracelet + "\n";
                }
                else
                {
                    rightArm += bracelet + "\n";
                }
            }

            return (leftArm, rightArm);
        }
    }
}
