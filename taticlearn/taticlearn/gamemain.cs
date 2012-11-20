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
        Dictionary<ConsoleKey, Action> menuMapping;
        Dictionary<ConsoleKey, Action> gridMapping;


        bool needsUpdate = true;

        public gamemain()
        {
            agrid = new grid(10, 10,this);
            objects = new List<gameobject>();

            insertObject(new npc());

            menu = new mainmenu(this);
            menuMapping = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow, () => this.menu.Next() }, { ConsoleKey.DownArrow, () => this.menu.Previous() }, { ConsoleKey.Enter, () => this.menu.executeMenu() } };
            gridMapping = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow, () => this.agrid.Up()  }, { ConsoleKey.DownArrow, () => this.agrid.Down() }, 
                                                                 { ConsoleKey.RightArrow, () => this.agrid.Right() }, { ConsoleKey.LeftArrow, () => this.agrid.Left() },{ ConsoleKey.Enter, () => this.agrid.exec() } };
            keyMapping = menuMapping;
        }
        internal void select()
        {
            keyMapping = gridMapping;
            agrid.selection = true;
            needsUpdate = true;
        }
        
        private void insertObject(gameobject obj)
        {
            objects.Add(obj);
            agrid.insertgrid(obj);
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

        internal void deselect()
        {
            keyMapping = menuMapping;
            agrid.selection = false;
            needsUpdate = true;
        }
    }
}
