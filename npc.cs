using System;
namespace taticlearn
{
    class npc : Igameobject
    {
        String representation_ = "n";
        IGUImenu mymenu;
        public npc(gamemain parent) { mymenu = new npcMenu(parent); }
        public IGUImenu menu() { return mymenu; }
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
