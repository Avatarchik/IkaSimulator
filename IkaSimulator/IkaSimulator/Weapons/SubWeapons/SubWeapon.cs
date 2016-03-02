using IkaSimulator.Weapons.MainWeapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons
{
    public abstract class SubWeapon
    {
        public String Name { get; set; }
        public int InkConsumption { get; set; }
        public int Damage { get; set; }
        public String Characteristics { get; set; }
        public String FileName { get; set; }
    }
}
