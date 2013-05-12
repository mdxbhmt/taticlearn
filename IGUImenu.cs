using System;
using System.Collections.Generic;

namespace taticlearn
{
    interface IGUImenu
    {
        Dictionary<ConsoleKey, Action> keyMapping();
        void Next();
        void Previous();
        void executeMenu();
        void print();

    }
}
