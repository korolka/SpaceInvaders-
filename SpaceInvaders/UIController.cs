using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UIController
    {
        public event EventHandler OnAPress;
        public event EventHandler OnDPress;
        public event EventHandler OnSpacePress;
        public event EventHandler OnPPress;

        public void StartListening()
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key.Equals(ConsoleKey.A))
                {
                    OnAPress?.Invoke(this, new EventArgs());
                }
                else if(key.Key.Equals(ConsoleKey.D))
                {
                    OnDPress?.Invoke(this, new EventArgs());
                }
                else if(key.Key.Equals(ConsoleKey.Spacebar))
                {
                    OnSpacePress?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.P))
                {
                    OnPPress?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
