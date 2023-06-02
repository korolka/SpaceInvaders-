namespace SpaceInvaders
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings) : base(gameSettings) { }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missileObjectPlace= new GameObjectPlace() { XCoordination = objectPlace.XCoordination, YCoordination= objectPlace.YCoordination -1};
            GameObject missile = new PlayerShipMissile() { Figure = GameSettings.PlayerMissile, GameObjectPlace = missileObjectPlace, GameObjectType = GameObjectType.PlayerShipMissile };
            return missile;
        }
    }
}
