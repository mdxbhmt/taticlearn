using System;

namespace taticlearn
{
    interface gameobject
    {
        String representation();
        GUImenu menu();
        bool Update(TimeSpan deltaT);
    }
}
