using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

namespace SpaceInvaders
{
    class GameEngine
    {
        private GameSettings gameSettings;
        private SceneRender sceneRender;
        private Scene scene;
        private bool isNotOver;
        private static GameEngine gameEngine;

        public bool IsNotOver { get { return isNotOver; } }
        private GameEngine() { }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (gameEngine == null)
                gameEngine = new GameEngine(gameSettings);

            return gameEngine;
        }

        private GameEngine(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            isNotOver = true;
            scene = Scene.GetScene(gameSettings);
            sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int playerMissileCounter = 0;
            int swarmMoveCounter = 0;
            int allienShipMissile = 0;
            do
            {
                sceneRender.Render(scene);
                Thread.Sleep(gameSettings.GameSpeed);
                sceneRender.ClearScreen();

                if (Console.KeyAvailable)
                {
                    GamePause();
                }

                if (swarmMoveCounter == gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                if (allienShipMissile == gameSettings.AllienMissileSpeed)
                {
                    CalculateMissileMoveForAllien();
                    allienShipMissile = 0;
                }

                if (playerMissileCounter == gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMoveForPlayer();
                    playerMissileCounter = 0;
                }

                PlayerMissileTouchAllienMissile();

                playerMissileCounter++;
                swarmMoveCounter++;
                allienShipMissile++;

            }
            while (isNotOver);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 25);
            sceneRender.RenderGameOver(scene);
            Console.ForegroundColor = default;

        }

        public void CalculateMovePlayerShipLeft()
        {
            if (scene.playerShip.GameObjectPlace.XCoordination > 1)
            {
                scene.playerShip.GameObjectPlace.XCoordination--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (scene.playerShip.GameObjectPlace.XCoordination < gameSettings.ConsoleWidht)
            {
                scene.playerShip.GameObjectPlace.XCoordination++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < scene.swarm.Count; i++)
            {
                GameObject alienShip = scene.swarm[i];

                alienShip.GameObjectPlace.YCoordination++;
                if (alienShip.GameObjectPlace.YCoordination == scene.playerShip.GameObjectPlace.YCoordination)
                {
                    isNotOver = false;
                }
            }
        }

        public void PlayerShot()
        {
            PlayerShipMissileFactory playerShipMissileFactory = new PlayerShipMissileFactory(gameSettings);

            GameObject missile = playerShipMissileFactory.GetGameObject(scene.playerShip.GameObjectPlace);

            scene.playerShipMissile.Add(missile);

            Console.Beep(1000, 100);
        }

        public void AllienShot()
        {
            GameObject missile;

            while (true)
            {
                AllienMissileFactory allienMissileFactory = new AllienMissileFactory(gameSettings);
                try
                {
                    missile = allienMissileFactory.GetGameObject(scene.swarm[new Random().Next(59, 120)]?.GameObjectPlace);

                    scene.allienShipMissile.Add(missile);
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void CalculateMissileMoveForAllien()
        {
            if (scene.allienShipMissile.Count == 0)
            {
                return;
            }
            for (int x = 0; x < scene.allienShipMissile.Count; x++)
            {
                GameObject playership = scene.playerShip;
                GameObject missile = scene.allienShipMissile[x];
                if (missile.GameObjectPlace.YCoordination == 29)
                {
                    scene.allienShipMissile.RemoveAt(x);
                }
                if (missile.GameObjectPlace.Equals(playership.GameObjectPlace))
                {
                    isNotOver = false;
                    break;
                }
                missile.GameObjectPlace.YCoordination++;

                for (int i = 0; i < scene.ground.Count; i++)
                {
                    GameObject ground = scene.ground[i];
                    if (missile.GameObjectPlace.Equals(ground.GameObjectPlace))
                    {
                        scene.ground.RemoveAt(i);

                        scene.allienShipMissile.RemoveAt(x);
                        break;
                    }
                }
            }
        }

        public void CalculateMissileMoveForPlayer()
        {
            if (scene.playerShipMissile.Count == 0)
            {
                return;
            }
            for (int x = 0; x < scene.playerShipMissile.Count; x++)
            {
                GameObject missile = scene.playerShipMissile[x];
                if (missile.GameObjectPlace.YCoordination == 1)
                {
                    scene.playerShipMissile.RemoveAt(x);
                }
                missile.GameObjectPlace.YCoordination--;

                for (int i = 0; i < scene.swarm.Count; i++)
                {
                    GameObject allienShip = scene.swarm[i];
                    if (missile.GameObjectPlace.Equals(allienShip.GameObjectPlace))
                    {
                        scene.swarm.RemoveAt(i);

                        scene.playerShipMissile.RemoveAt(x);
                        break;
                    }
                }
            }

        }
        public void PlayerMissileTouchAllienMissile()
        {
            for (int i = 0; i < scene.playerShipMissile.Count; i++)
            {
                GameObject playerMissile = scene.playerShipMissile[i];
                for (int j = 0; j < scene.allienShipMissile.Count; j++)
                {
                    GameObject allienMissile = scene.allienShipMissile[j];
                    if (playerMissile.GameObjectPlace.Equals(allienMissile.GameObjectPlace))
                    {
                        Console.Beep(10000, 250);
                        scene.allienShipMissile.RemoveAt(j);
                        scene.playerShipMissile.RemoveAt(i);
                    }
                }
            }

        }

        public void GamePause()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Game was paused");
            Console.WriteLine("Press P to continue");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.P)
                return;
            else
            {
                GamePause();
            }
        }
    }
}
