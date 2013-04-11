﻿using System;
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
        long lasttick = 0;//mayoverflow
        public bool Update(TimeSpan GameTime)
        {
            if (GameTime.Ticks / (TimeSpan.TicksPerSecond * 10) > lasttick)
            {
                lasttick = GameTime.Ticks / (TimeSpan.TicksPerSecond * 10);
                flipRepresentation();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void flipRepresentation()
        {
            if (representation_.Equals("n"))
                representation_ = "N";
            else
                representation_ = "n";
        }
    }
}
