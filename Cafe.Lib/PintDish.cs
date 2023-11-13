namespace Cafe.Lib
{
    public delegate void PintStartedHandler(object sender, EventArgs e);
    public delegate void PintCompletedHandler(object sender, PintCompletedEventArgs e);
    public delegate void DishHalfwayHandler(object sender, EventArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;
        public event DishHalfwayHandler DishHalfway;

        public int PintCount { get; private set; }
        public int MaxPints { get; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }

        public void AddPint()
        {
            if (PintCount >= MaxPints)
            {
                throw new Exception("Pint dish is full");
            }

            PintStarted?.Invoke(this, EventArgs.Empty);
            // We tappen het pintje
            PintCount++;
            PintCompleted?.Invoke(this, new PintCompletedEventArgs());

            int halfWayPoint = MaxPints %2 == 0 ? MaxPints / 2 : (MaxPints + 1) / 2;
            if(PintCount == halfWayPoint)
            {
                DishHalfway?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public class PintCompletedEventArgs: EventArgs
    {
        private static string[] Brands = { "Cara Pils", "Jupiler", "Stella Artois", "Bavik" };
        private static string[] Waiters = { "Jeff", "Carine", "Billy" };

        public static Random random= new Random();

        public string Brand { get; }
        public string Waiter { get; set; }

        public PintCompletedEventArgs()
        {
            Brand = Brands[random.Next(0, Brands.Length)];
            Waiter = Waiters[random.Next(0, Waiters.Length)];
        }
    }

}