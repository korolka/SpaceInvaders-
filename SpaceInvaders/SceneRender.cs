using System.Text;

namespace SpaceInvaders
{
    class SceneRender
    {
        int screenWidth;
        int screenHeight;
        GameSettings gameSettings;

        char[,] screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            screenWidth = gameSettings.ConsoleWidht;
            screenHeight = gameSettings.ConsoleHeight;
            screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidht];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidht;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            ClearScreen();
            Console.SetCursorPosition(0, 0);
            AddListForRendering(scene.swarm);
            AddListForRendering(scene.ground);
            AddListForRendering(scene.playerShipMissile);
            AddListForRendering(scene.allienShipMissile);

            AddGameObjectForRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    stringBuilder.Append(screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.YCoordination < screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCoordination < screenMatrix.GetLength(1))
            {
                screenMatrix[gameObject.GameObjectPlace.YCoordination, gameObject.GameObjectPlace.XCoordination] = gameObject.Figure;
            }

        }

        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    screenMatrix[y, x] = ' ';
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public void RenderGameOver(Scene scene)
        {
            int destroyedGround = gameSettings.NumberOfGroundColls - scene.ground.Count;
            int destroyedAllienShip = (gameSettings.NumberOfSwarmColls * gameSettings.NumberOfSwarmRows) - scene.swarm.Count;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Game    Over!!!\n");
            stringBuilder.Append($"Allien ships destroyed: {destroyedAllienShip}\n");
            stringBuilder.Append($"Gronds destroyed: {destroyedGround}");
            Console.WriteLine(stringBuilder);
        }
    }
}
