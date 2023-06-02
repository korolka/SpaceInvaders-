using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MusikController
    {
        static GameSettings gameSettings =new GameSettings();
        static GameEngine gameEngine = GameEngine.GetGameEngine(gameSettings);
        public void PlayBackgroundMusik()
        {
           while(gameEngine.IsNotOver)
            {
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(250, 500);
                Thread.Sleep(50);
                Console.Beep(350, 250);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(250, 500);
                Thread.Sleep(50);
                Console.Beep(350, 250);
                Console.Beep(300, 500);
                Thread.Sleep(50);
            }
        }
    }
}
