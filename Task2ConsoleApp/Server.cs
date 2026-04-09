namespace Task2ConsoleApp
{
    public static class Server
    {
        private static int count;
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        static Server()
        {
            count = 0;
        }
        public static int GetCount()
        {
            _lock.EnterReadLock();

            try
            {
                return count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
        public static void AddToCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                if (value > 0 && count > int.MaxValue - value)
                {
                    throw new ArgumentOutOfRangeException($"Прибавление {value} вызовет переполнение значения! Максимум - {int.MaxValue}!");
                }
                if (value < 0 && count < int.MinValue - value)
                {
                    throw new ArgumentOutOfRangeException($"Прибавление {value} вызовет переполнение значения! Минимум -  {int.MinValue}!");
                }
                count += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}

