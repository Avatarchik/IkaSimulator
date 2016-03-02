using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.MainWeapons.Shooters
{
    public abstract class Shooter : MainWeapon
    {
        public int Range { get; set; }
        public int Power { get; set; }
        public int Rapid { get; set; }
        public int StandardFinalized { get; set; }

        public static List<Shooter> ShooterList = new List<Shooter>
        {
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter(),
            new WakabaShooter()
        };
    }
}
