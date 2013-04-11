using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taticlearn
{
    class npc : gameobject
    {
  
        String representation_ = "n";
        GUImenu mymenu;
        public npc(gamemain parent) { mymenu = new mainmenu(parent); }
        public GUImenu menu() { return mymenu; }
        public String representation()
        {
            return representation_;
        }
        long lasttick=0;//mayoverflow
        public bool Update(TimeSpan GameTime)
        {
            if (GameTime.Ticks / (TimeSpan.TicksPerSecond*10) > lasttick)
            {
                lasttick = GameTime.Ticks / (TimeSpan.TicksPerSecond * 10);

                if (representation_.Equals("n"))
                    representation_ = "N";
                else
                    representation_ = "n";
                return true;
            }
            else
            { }

            return false;
        }
    }
}
