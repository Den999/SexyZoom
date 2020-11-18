namespace SexyZoom
{
    /// <summary>
    /// Safe singleton implementation.
    /// </summary>
    public class Singleton<T>
        where T : new()
    {
        public static T Instance => _instance;
        
        private static T _instance;

        protected Singleton() { }

        static Singleton()
        {
            _instance = new T();
        }
    }
}