namespace Test1ConsoleApp
{
    public static class InputValidator
    {
        public static bool Check(string userInput, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                errorMessage = "Ввод не может быть пустым! Попробуйте снова!";
                return false;
            }
            for (var i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] < 'a' || userInput[i] > 'z')
                {
                    errorMessage = "Допустимы только маленькие латинские буквы (a-z)! Попробуйте снова!";
                    return false;
                }
            }
            return true;
        }
    }
}
