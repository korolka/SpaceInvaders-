namespace SpaceInvaders.GameObjectFactories
{
    class AllienShipFactory : GameObjectFactory
    {
        public AllienShipFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject allienShip = new AllienShip() { Figure = GameSettings.AllienShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.AllienShip };

            return allienShip;
        }

        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();
            int startX = GameSettings.SwarmStartXCoordinate;
            int startY = GameSettings.SwarmStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfSwarmRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfSwarmColls; x++)
                {

                    GameObjectPlace gameObjectPlace = new GameObjectPlace() { XCoordination = startX + x, YCoordination = startY + y };
                    GameObject allienShip = GetGameObject(gameObjectPlace);
                    swarm.Add(allienShip);
                }
            }
            return swarm;
        }
    }
}
