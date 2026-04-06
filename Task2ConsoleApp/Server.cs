namespace Task2ConsoleApp
{
    public static class Server
    {
        private static int count;
        public static int Count
        {
            get => count;
            set
            {
                count = value;
            }
        }
        public static int GetCount()
        {
            return count;
        }
        public static void AddToCount(int value)
        {
            count += value;
        }
    }
}
