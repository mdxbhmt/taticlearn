using System;

namespace taticlearn
{
    class gridcell
    {

        class cell
        {
            internal Igameobject cellObject_;
            internal ConsoleColor cellColor_;
            public cell(Igameobject a, ConsoleColor b)
            {
                this.cellObject_ = a;
                this.cellColor_ = b;
            }
        }
        cell cell_;
        public gridcell(Igameobject cellobject) { cell_ = new cell(cellobject, ConsoleColor.Green); }
        public Igameobject cellObject() { return cell_.cellObject_; }
        public ConsoleColor cellColor() { return cell_.cellColor_; }
    }
}
