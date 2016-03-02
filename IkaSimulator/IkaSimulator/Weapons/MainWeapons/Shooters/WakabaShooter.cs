using IkaSimulator.Weapons.SpecialWeapons;
using IkaSimulator.Weapons.SubWeapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.MainWeapons.Shooters
{
    public class WakabaShooter : Shooter
    {
        public WakabaShooter()
        {
            Name = "わかばシューター";
            Price = 0;
            Range = 32;
            Power = 28;
            Rapid = 75;
            StandardFinalized = 4;
            SubWeapon = new SplashBomb();
            SpecialWeapon = new BombRush();
            FileName = "item_img_main01";
        }
    }
}
