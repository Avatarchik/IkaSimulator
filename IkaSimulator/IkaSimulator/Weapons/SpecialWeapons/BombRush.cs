using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.SpecialWeapons
{
    class BombRush : SpecialWeapon
    {
        public BombRush()
        {
            Name = "ボムラッシュ";
            NeedPaintingPoint = 180;
            Damage = 0;
            Duration = 6;
            FileName = "item_img_special01";
        }
    }
}
