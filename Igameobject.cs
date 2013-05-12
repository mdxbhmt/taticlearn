using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    interface Igameobject
    {
        String representation();
        IGUImenu menu();
        bool Update(TimeSpan deltaT);
    }
}
