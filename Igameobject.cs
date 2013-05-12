using System;

namespace taticlearn
{
    interface Igameobject
    {
        String representation();
        IGUImenu menu();
        bool Update(TimeSpan deltaT);
    }
}
