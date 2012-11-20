using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class npc : gameobject
    {
        TimeSpan deltaTacc = new TimeSpan();
        String representation_ = "n";
        public String representation()
        {
            return representation_;
        }
        public bool Update(TimeSpan deltaT)
        {
            deltaTacc = deltaTacc.Add(deltaT);
            if (deltaTacc.TotalSeconds >= 10)
            {
                deltaTacc = new TimeSpan();
                if (representation_.Equals("n"))
                    representation_ = "N";
                else
                    representation_ = "n";
                return true;
            }
            return false;
        }
    }
}
