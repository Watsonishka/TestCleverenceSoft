namespace Task3ConsoleApp
{
    public static class ProblemsRepository
    {
        private const string problemsFilePath = "problems.txt";
        static ProblemsRepository()
        {
            if (!File.Exists(problemsFilePath))
            {
                File.Create(problemsFilePath).Close();
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
            FileManager.AppendToTextFile(problemsFilePath, problem);
        }

    }
}

