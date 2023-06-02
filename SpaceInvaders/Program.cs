namespace SpaceInvaders
{
    class Program
    {
        static GameEngine gameEngine;
        static UIController uIController;
        static GameSettings gameSettings;
        static MusikController musikController;

        static void Main(string[] args)
        {
            Inititialize();
            gameEngine.Run();
        }

        public static void Inititialize()
        {
            musikController = new MusikController();

            gameSettings = new GameSettings();

            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnAPress += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnDPress += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePress += (obj, arg) => gameEngine.PlayerShot();
            uIController.OnPPress += (obj, arg) => gameEngine.GamePause();

            Thread currentThread = Thread.CurrentThread;
            Thread allienMissile = new Thread(gameEngine.AllienShot);
            allienMissile.Start();

            Thread uIThread = new Thread(uIController.StartListening);
            uIThread.Start();

            Thread musicThread = new Thread(musikController.PlayBackgroundMusik);
            musicThread.Start();

        }
    }
}