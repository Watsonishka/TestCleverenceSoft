using System;
using System.Collections.Generic;
using System.Text;

namespace Task3ConsoleApp
{
    public static class ProblemsRepository
    {
        private const string problemsFilePath = "problems.txt";
        static ProblemsRepository()
        {
            if (!File.Exists(problemsFilePath))
            {
                var problems = "";
                FileManager.AppendToTextFile(problemsFilePath, problems);
            }
            else
            {
                var problems = GetAll();
            }
        }
        public static List<string> GetAll()
        {
            var problems = new List<string>();
            var lines = FileManager.ReadTextFile(problemsFilePath);
            foreach (var line in lines)
            {
                problems.Add(line);
            }
            return problems;
        }
        public static void AddToFile(string problem)
        {
            var result = $"{problem}#";
            FileManager.AppendToTextFile(problemsFilePath, result);
        }
    }
}

