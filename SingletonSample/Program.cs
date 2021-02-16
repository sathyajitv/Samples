using System;

namespace SingletonSample
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 2; i++)
            {
                BasicThreadSafeSingleton singleton = BasicThreadSafeSingleton.Instance;
            }

            for (int i = 0; i < 2; i++)
            {
                LazySingleton singleton = LazySingleton.Instance;
            }
        }
    }


    public sealed class BasicThreadSafeSingleton
    {
        private static BasicThreadSafeSingleton _instance;
        private static readonly object SyncObj = new object();

        private BasicThreadSafeSingleton()
        {
        }

        public static BasicThreadSafeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncObj)
                    {
                        _instance ??= new BasicThreadSafeSingleton();
                        Console.WriteLine("Instantiating threadsafe singleton");
                    }
                }

                Console.WriteLine("Returning existing threadsafe singleton instance");
                return _instance;
            }
        }
    }


    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> Item = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance
        {
            get
            {
                Console.WriteLine("Returning existing lazy singleton instance");
                return Item.Value;
            }
        }

        private LazySingleton()
        {
            Console.WriteLine("Instantiating lazy singleton");
        }
    }
}



#region Output 


//Instantiating threadsafe singleton
//Returning existing threadsafe singleton instance
//Returning existing threadsafe singleton instance
//Returning existing lazy singleton instance
//Instantiating lazy singleton
//Returning existing lazy singleton instance

// Note: for the lazy singleton, the instance is created only on referencing item.value 


#endregion
