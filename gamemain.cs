using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class gamemain
    {
        public int turn { get { return turn_; } }
        public Tuple<int, int> selectedindex { get; set; }
        grid agrid;
        int turn_;
        GUImenu menu;
        List<gameobject> objects;
        Dictionary<ConsoleKey, Action> keyMapping;
        Dictionary<ConsoleKey, Action> menuMapping;
        Dictionary<ConsoleKey, Action> gridMapping;
        internal TimeSpan GameTime = new TimeSpan(); //Internal for debugging purposes
      
        bool needsUpdate = true;
        private gameobject ActiveNpc;

        public gamemain()
        {
            agrid = new grid(10, 10, this);
            gridMapping = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow, () => this.agrid.Up()  }, { ConsoleKey.DownArrow, () => this.agrid.Down() }, 
                                                                 { ConsoleKey.RightArrow, () => this.agrid.Right() }, { ConsoleKey.LeftArrow, () => this.agrid.Left() },
                                                                 { ConsoleKey.Enter, () => this.agrid.exec() } };

            objects = new List<gameobject>();
            gameobject onenpc = new npc(this);
            insertObject(onenpc);
            setActive(onenpc);

            keyMapping = menuMapping;
        }

        private void setActive(gameobject onenpc)
        {
            ActiveNpc = onenpc;
            menu = ActiveNpc.menu();
            menuMapping = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow, () => this.menu.Next() }, { ConsoleKey.DownArrow, () => this.menu.Previous() },
                                                                 { ConsoleKey.Enter, () => this.menu.executeMenu() } };
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
            agrid.insertgrid(obj, 3, 1);
        }

        public void runturn()
        {
            turn_++;
        }

        public void Update(TimeSpan deltaT)
        {
            GameTime += deltaT;

            HudUpdate();
            foreach (gameobject a in objects)
            {
                needsUpdate = a.Update(GameTime) | needsUpdate;
            }
        }
        long lasttick = 0; //may overflow, can be changed for rem
        private void HudUpdate()
        {
            if (GameTime.Ticks / TimeSpan.TicksPerSecond > lasttick)
            {
                lasttick = (GameTime.Ticks / TimeSpan.TicksPerSecond);
                needsUpdate = true;
            }
        }

        internal void PrintGame()
        {
            if (needsUpdate)
            {
                Console.Clear();
                Console.WriteLine("Game time {0}", GameTime.TotalSeconds);
                Console.WriteLine("Turn {0}", turn);
                Console.WriteLine("Last Selected: {0}", selectedindex);
                agrid.print();
                menu.print();
                needsUpdate = false;
            }
        }

        internal void keyInput(ConsoleKey a)
        {
            try
            {
                keyMapping[a](); needsUpdate = true;
                //   RequestTrap();
            }
            catch (KeyNotFoundException)
            { }
            catch (NotImplementedException b)
            { Console.WriteLine("Not implemented: {0}", b.Message); }
            catch (Exception)
            { throw; }
        }

        private void RequestTrap()
        {
            throw new NotImplementedException("RequestTrap");
        }

        internal void deselect(Tuple<int, int> selected)
        {
            selectedindex = selected;
            keyMapping = menuMapping;
            agrid.selection = false;
            needsUpdate = true;
        }



        internal object move()
        {
            throw new NotImplementedException("move");
        }
    }
}
