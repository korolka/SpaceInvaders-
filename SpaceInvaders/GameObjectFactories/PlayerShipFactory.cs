namespace SpaceInvaders
{
    internal class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject gameObject = new PlayerShip() { Figure = GameSettings.PlayerShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.PlayerShip };

            return gameObject;
        }

        public GameObject GetGameObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordination = GameSettings.PlayerShipStartXCoordinate, YCoordination = GameSettings.PlayerShipStartYCoordinate };
            GameObject gameObject = GetGameObject(place);
            return gameObject;
        }
    }
}
