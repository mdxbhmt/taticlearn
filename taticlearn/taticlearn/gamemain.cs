using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class gamemain
    {
        public int turn { get { return turn_; } }
        grid agrid;
        int turn_;
        GUImenu menu;
        List<gameobject> objects;
        Dictionary<ConsoleKey, Action> keyMapping;


        bool needsUpdate = true;

        public gamemain()
        {
            agrid = new grid(10, 10);
            objects = new List<gameobject>();

            insertObject(new npc());

            menu = new mainmenu(this);
            keyMapping = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow, () => this.menu.Next() }, { ConsoleKey.DownArrow, () => this.menu.Previous() }, { ConsoleKey.Enter, () => this.menu.executeMenu() } };
        }

        private void insertObject(gameobject tresum)
        {
            objects.Add(tresum);
            agrid.insertgrid(tresum);
        }

        public void runturn()
        {
            turn_++;

        }

        public void Update(TimeSpan deltaT)
        {
            foreach (gameobject a in objects)
            {
                needsUpdate = a.Update(deltaT) | needsUpdate;
            }
        }
        internal void PrintGame()
        {
            if (needsUpdate)
            {
                Console.Clear();
                Console.WriteLine("still running at {0}", turn);

                agrid.print();
                menu.print();
                needsUpdate = false;
            }
        }

        internal void keyInput(ConsoleKey a)
        {
            try
            { keyMapping[a](); needsUpdate = true; }
            catch (KeyNotFoundException)
            { }
            catch (Exception)
            { throw; }
        }
    }
}
