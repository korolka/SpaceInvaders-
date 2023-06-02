﻿namespace SpaceInvaders
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectPlace objectPlace);
        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }

    }
}
