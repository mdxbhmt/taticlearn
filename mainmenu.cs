using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// lol, oi

namespace taticlearn
{
    class mainmenu : GUImenu
    {
        menuItems menuindex = menuItems.EndTurn;
        gamemain game;
        public enum menuItems { EndTurn, Select, Move, Nothing };

        Dictionary<menuItems, Action> executeMenuDic;
        public Dictionary<menuItems, String> menuitem = new Dictionary<menuItems, string> { { menuItems.Nothing, "Nothing" },{ menuItems.Move, "Move" } ,{ menuItems.Select, "Select" }, { menuItems.EndTurn, "End Turn" } };

        public mainmenu(gamemain parent)
        {
            game = parent;
            executeMenuDic = new Dictionary<menuItems, Action>(){{menuItems.EndTurn, () => game.runturn()},{menuItems.Move,()=>game.move()},{menuItems.Select,() => game.select()}};

        }

        public void Next()
        {
            menuindex = ((menuItems)Math.Min((int)menuindex + 1, menuitem.Count-1));
        }

        public void Previous()
        {
            menuindex = ((menuItems)Math.Max((int)menuindex - 1, 0));

        }

        public void executeMenu()
        {
            try
            { executeMenuDic[menuindex](); }
            catch (KeyNotFoundException)
            {  }
            catch (Exception)
            { throw; }
        }

        public void print()
        {
            foreach (KeyValuePair<menuItems, String> pair in menuitem)
            {
                if ((pair.Key) == menuindex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(pair.Value);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(pair.Value);
            }
        }
    }
}
