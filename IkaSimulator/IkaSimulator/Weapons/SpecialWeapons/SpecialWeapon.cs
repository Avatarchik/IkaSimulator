using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.SpecialWeapons
{
    public abstract class SpecialWeapon
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public int NeedPaintingPoint { get; set; }
        public int Damage { get; set; }
        public int Duration { get; set; }
        public String FileName { get; set; }
    }
}
