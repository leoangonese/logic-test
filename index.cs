using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tree
{
    public class Program
    {
        public static string Visualizer(int root, List<int> leftBranch, List<int> rightBranch)
        {
            string result = new string(' ', leftBranch.Count + 1) + root;
            int countTextRight = 0;

            for (int i = 0; i <= leftBranch.Count && i <= rightBranch.Count; i++)
            {
                string textRight = "";
                if (i == 0)
                {
                    textRight = " ";
                }
                else
                {
                    countTextRight += 2;
                    textRight = new string(' ', i + countTextRight);
                }
                string leftChar = i < leftBranch.Count ? leftBranch[i].ToString() : " ";
                string rightChar = i < rightBranch.Count ? rightBranch[i].ToString() : " ";

                int spacesCount = leftBranch.Count - i;
                if (spacesCount < 0) spacesCount = 0;
                result += "\n" + new string(' ', spacesCount) + leftChar + textRight + rightChar;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            List<int> sequence = new List<int> { 3, 2, 1, 6, 0, 5 };
            int bigger = 0;
            int index = 0;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] > bigger)
                {
                    bigger = sequence[i];
                    index = i + 1;
                }
            }

            right = sequence.Skip(index).Take(sequence.Count - index).OrderByDescending(x => x).ToList();
            left = sequence.Take(index - 1).OrderByDescending(x => x).ToList();

            Console.WriteLine("Array de Entrada: " + string.Join(", ", sequence));
            Console.WriteLine("Raiz: " + bigger);
            Console.WriteLine("Galhos da Esquerda: " + string.Join(", ", left));
            Console.WriteLine("Galhos da Direita: " + string.Join(", ", right));

            Console.WriteLine(Visualizer(bigger, left, right));
        }
    }
}