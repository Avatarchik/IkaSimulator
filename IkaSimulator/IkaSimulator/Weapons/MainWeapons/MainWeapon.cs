using IkaSimulator.Weapons.SpecialWeapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkaSimulator.Weapons.MainWeapons
{
    public abstract class MainWeapon
    {
        public String Name { get; set; }
        public int Price { get; set; }
        public SubWeapon SubWeapon { get; set; }
        public SpecialWeapon SpecialWeapon { get; set; }
        public String HowToGet { get; set; }
        public String FileName { get; set; }

        public static List<string> MainWeaponNameList = new List<string>
        {
            "ブラスター",
            "フデ",
            "チャージャー",
            "ローラー",
            "シューター",
            "スロッシャー",
            "スピナー"
        };
    }
}
