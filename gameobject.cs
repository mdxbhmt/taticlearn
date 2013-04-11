using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    interface gameobject
    {
        String representation();
        GUImenu menu();
        bool Update(TimeSpan deltaT);
    }
}
