using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.SubWeapons
{
    class SplashBomb : SubWeapon
    {
        public SplashBomb()
        {
            Name = "スプラッシュボム";
            InkConsumption = 70;
            Damage = 180;
            Characteristics = "約3秒間地面に付くと爆発するボム．\n地面などに転がせる．";
            FileName = "item_img_sub01";
        }
    }
}
