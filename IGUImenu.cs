﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
