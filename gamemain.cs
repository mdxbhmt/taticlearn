using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;


namespace taticlearn
{
    class gamemain
    {
        public int turn { get { return turn_; } }
        public Tuple<int, int> selectedindex { get; set; }
        public Tuple<int, int> activeIndex { get; set; }
        grid agrid;
        int turn_;
        IGUImenu menu;
        List<Igameobject> objects;
        Dictionary<ConsoleKey, Action> keyMapping;

        internal TimeSpan GameTime = new TimeSpan(); //Internal for debugging purposes

        bool needsUpdate = true;
        private Igameobject ActiveNpc;
        void updateGUI(){ needsUpdate = true; }
        public gamemain()
        {
            agrid = new grid(10, 10, this);

            objects = new List<Igameobject>();
            Igameobject onenpc = new npc(this);
            insertObject(onenpc, 0, 0);
            activeIndex = Tuple.Create(0, 0);
            setActive(onenpc);
        }

        private void setActive(Igameobject onenpc)
        {
            ActiveNpc = onenpc;
            menu = ActiveNpc.menu();
            keyMapping = ActiveNpc.menu().keyMapping();
        }
        Action myaction;
        internal void select()
        {
            keyMapping = agrid.keyMapping;
            agrid.selection = true;
            myaction = () => { setActive(ActiveNpc); };
            agrid.SimpleEvent += agrid_SimpleEvent;
            updateGUI(); 
        }
        internal void move()
        {
            keyMapping = agrid.keyMapping;
            agrid.selection = true;
            myaction = () => { agrid.moveFromTo(activeIndex, selectedindex); activeIndex = selectedindex;  setActive(ActiveNpc); };
            agrid.SimpleEvent += agrid_SimpleEvent;
            updateGUI(); 
        }

        void agrid_SimpleEvent(object sender, grid.SomeEventArgs e)
        {
            selectedindex = e.arg;
            myaction();
            agrid.SimpleEvent -= agrid_SimpleEvent;
        }


        private void insertObject(Igameobject obj, int x, int y)
        {
            objects.Add(obj);
            agrid.insertgrid(obj, x, y);
        }

        public void runturn()
        {
            turn_++;
        }

        public void Update(TimeSpan deltaT)
        {
            GameTime += deltaT;
            //Linq ways of doing it
            //needsUpdate |= objects.Aggregate<gameobject, Boolean, Boolean>(HudUpdate(), (workingUpdate, next) =>
            //                                      next.Update(deltaT) | workingUpdate, x => x);
            //needsUpdate |= HudUpdate()|(from obj in objects
            //                select obj.Update(deltaT)).Aggregate(HudUpdate(), (workingUpdate, next) =>
            //                                     next | workingUpdate);

            needsUpdate |= HudUpdate();
            foreach (var a in objects)
                needsUpdate |= a.Update(deltaT);

        }
        long lasttick = 0; //may overflow, can be changed for rem
        private Boolean HudUpdate()
        {
            if (GameTime.Ticks / TimeSpan.TicksPerSecond > lasttick)
            {
                lasttick = (GameTime.Ticks / TimeSpan.TicksPerSecond);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void PrintGame()
        {
            if (needsUpdate)
            {
                Console.Clear();
                printHud();
                agrid.print();
                menu.print();
                needsUpdate = false;
            }
        }

        private void printHud()
        {
            Console.WriteLine("Game time {0}", GameTime.TotalSeconds);
            Console.WriteLine("Turn {0}", turn);
            Console.WriteLine("Last Selected: {0}", selectedindex);
        }

        internal void keyInput(ConsoleKey a)
        {
            try
            {
                keyMapping[a]();
                updateGUI();
                
            }
            catch (KeyNotFoundException)
            { }
            catch (NotImplementedException b)
            { Console.WriteLine("Not implemented: {0}", b.Message); }
            catch (Exception)
            { throw; }
        }



    }
}
