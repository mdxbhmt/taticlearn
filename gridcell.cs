using System;

namespace taticlearn
{
    class gridcell
    {

        class cell
        {
            internal gameobject cellObject_;
            internal ConsoleColor cellColor_;
            public cell(gameobject a, ConsoleColor b)
            {
                this.cellObject_ = a;
                this.cellColor_ = b;
            }
        }
        cell cell_;
        public gridcell(gameobject cellobject) { cell_ = new cell(cellobject, ConsoleColor.Green); }
        public gameobject cellObject() { return cell_.cellObject_; }
        public ConsoleColor cellColor() { return cell_.cellColor_; }
    }
}
