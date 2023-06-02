using SpaceInvaders.GameObjectFactories;

namespace SpaceInvaders
{
    class Scene
    {
        private Scene() { }

        private Scene(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            swarm = new AllienShipFactory(this.gameSettings).GetSwarm();
            ground = new GroundFactory(this.gameSettings).GetGround();
            playerShip = new PlayerShipFactory(this.gameSettings).GetGameObject();
            playerShipMissile = new List<GameObject>();
            allienShipMissile= new List<GameObject>();
        }

        public GameSettings gameSettings;

        public List<GameObject> swarm;

        public GameObject playerShip;

        public List<GameObject> ground;

        public List<GameObject> playerShipMissile;

        public List<GameObject> allienShipMissile;

        private static Scene scene;

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (scene == null)
            {
                scene = new Scene(gameSettings);
            }
            return scene;
        }

    }
}
