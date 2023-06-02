using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class AllienMissileFactory:GameObjectFactory
    {
        public AllienMissileFactory(GameSettings gameSettings) : base(gameSettings) { }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missileObjectPlace = new GameObjectPlace() { XCoordination = objectPlace.XCoordination, YCoordination = objectPlace.YCoordination + 1 };
            GameObject missile = new AllienShipMissile() { Figure = GameSettings.AllienMissile, GameObjectPlace = missileObjectPlace, GameObjectType = GameObjectType.AllienShipMissile };
            return missile;
        }


    }
}
