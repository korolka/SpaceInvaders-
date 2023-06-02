namespace SpaceInvaders
{
    class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject groundObject = new GroundObject() { Figure = GameSettings.Ground, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.GroundObject };

            return groundObject;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> grounds = new List<GameObject>();
            int startY = GameSettings.GroundStartYCoordinate;
            int startX = GameSettings.GroundStartXCoordinate;

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { YCoordination = startY+y, XCoordination = startX+x };
                    GameObject groundObj = GetGameObject(objectPlace);
                    grounds.Add(groundObj);
                }
            }
            return grounds;
        }


    }
}
