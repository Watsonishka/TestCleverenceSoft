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
                count += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        public static void Reset()
        {
            _lock.EnterWriteLock();
            try
            {
                count = 0;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}

