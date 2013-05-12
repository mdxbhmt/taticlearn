using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;


namespace taticlearn
{
    class npcMenu : IGUImenu
    {
        menuItems menuindex = menuItems.EndTurn;
        gamemain game;
        public enum menuItems { EndTurn=1, Select, Move, Nothing };
        int menuMaxIndex;
                 
        Dictionary<menuItems, Action> executeMenuDic;
        public Dictionary<menuItems, String> menuitem = new Dictionary<menuItems, string> { { menuItems.Nothing, "Nothing" },
                                                                                            { menuItems.Move, "Move" },
                                                                                            { menuItems.Select, "Select" }, 
                                                                                            { menuItems.EndTurn, "End Turn" } };
        Dictionary<ConsoleKey, Action> keyMapping_;
        public Dictionary<ConsoleKey, Action> keyMapping() { return keyMapping_; }
        public npcMenu(gamemain parent)
        {
            game = parent;
            menuMaxIndex = Enum.GetValues(typeof(menuItems)).Length;
            keyMapping_ = new Dictionary<ConsoleKey, Action>() { { ConsoleKey.UpArrow  , () => this.Next()        },
                                                                 { ConsoleKey.DownArrow, () => this.Previous()    },
                                                                 { ConsoleKey.Enter    , () => this.executeMenu() } };
            
            executeMenuDic = new Dictionary<menuItems, Action>(){ {menuItems.EndTurn, () => game.runturn()},
                                                                  {menuItems.Move   , () => game.move()   }, 
                                                                  {menuItems.Select , () => game.select() } };

        }

        public void Next()
        {
            menuindex = ((menuItems)Math.Min((int)menuindex + 1, menuMaxIndex));
        }

        public void Previous()
        {
            menuindex = ((menuItems)Math.Max((int)menuindex - 1, 1));
        }

        public void executeMenu()
        {
            try
            { executeMenuDic[menuindex](); }
            catch (KeyNotFoundException b)
            { Console.WriteLine("Action Not implemented: {0}", b.Message); } 
            catch (Exception)
            { throw; }
        }

        public void print()
        {
            Console.WriteLine(String.Empty);
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
