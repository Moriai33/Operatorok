using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Operátorok
{
    class Program
    {
        static void Main(string[] args)
        {
            var equations = OpenFile(@".\src\kifejezesek.txt");


            Console.WriteLine("2. Feladat!");
            Console.WriteLine(equations.Count());

            Console.WriteLine("3. Feladat!");
            Console.WriteLine(equations.Where(x=>x.Operator=="mod").Count());

            Console.WriteLine("4. Feladat!");
            if (equations.First(x => x.FirstValue % 10==0 && x.SecondValue % 10 == 0)!=null) Console.WriteLine("Van ilyen kifejezés");

            Console.WriteLine("5. Feladat!");
            Console.WriteLine("\tmod \t-> " + equations.Where(x => x.Operator == "mod").Count());
            Console.WriteLine("\t/ \t-> " + equations.Where(x => x.Operator == "/").Count());
            Console.WriteLine("\tdiv \t-> " + equations.Where(x => x.Operator == "div").Count());
            Console.WriteLine("\t- \t-> " + equations.Where(x => x.Operator == "-").Count());
            Console.WriteLine("\t* \t-> " + equations.Where(x => x.Operator == "*").Count());
            Console.WriteLine("\t+ \t-> " + equations.Where(x => x.Operator == "+").Count());

            Console.WriteLine("7. Feladat!");
            while (true)
            {
                var inpute = Console.ReadLine();
                if (inpute=="vége")
                {
                    break;
                }
                var separatedLine = inpute.Split(" ");
                if (separatedLine.Length==3)
                {
                    Console.WriteLine(SolveEquation(int.Parse(separatedLine[0]), separatedLine[1], int.Parse(separatedLine[2])));
                }
                else
                {
                    Console.WriteLine("Nem megfelelő bemeneti adat!");
                }
            }

            Console.WriteLine("8. Feladat!");
            SaveFile(equations, @".\src\eredmények.txt");
            Console.WriteLine("eredmények.txt");
        }
        public static void SaveFile(List<Equation> equations, string path)
        {
            var writer = new StreamWriter(path);
            equations.ForEach(x => writer.WriteLine(x.FirstValue + " " + x.Operator + " " + x.SecondValue + " = " + x.Result));
        }
        public static List<Equation> OpenFile(string path)
        {
            var equations = new List<Equation>();
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var separatedLine = line.Split(" ");
                var equation = new Equation(int.Parse(separatedLine[0]), separatedLine[1], int.Parse(separatedLine[2]), SolveEquation(int.Parse(separatedLine[0]), separatedLine[1], int.Parse(separatedLine[2])));
                equations.Add(equation);
            }

            return equations;
        }
        public static string SolveEquation(double firstValue, string @operator, double secondValue)
        {
            switch (@operator)
            {
                case "+":
                    return (firstValue + secondValue).ToString();
                case "-":
                    return (firstValue - secondValue).ToString();
                case "*":
                    return (firstValue * secondValue).ToString();
                case "/":
                    if (secondValue == 0) return "Egyéb hiba!";
                    return (firstValue / secondValue).ToString();
                case "mod":
                    if (secondValue == 0) return "Egyéb hiba!";
                    return (firstValue % secondValue).ToString();
                case "div":
                    if (secondValue == 0) return "Egyéb hiba!";
                    return Convert.ToInt16(firstValue / secondValue).ToString();
                default:
                    return "Hibás Operátor";
            }
        }
    }
}
