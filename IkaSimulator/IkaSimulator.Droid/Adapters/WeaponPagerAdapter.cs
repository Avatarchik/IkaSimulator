using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using IkaSimulator.Droid.Fragments;
using Android.Graphics;
using IkaSimulator.Weapons.MainWeapons;
using IkaSimulator.Weapons.MainWeapons.Shooters;

namespace IkaSimulator.Droid.Adapters
{
    class WeaponPagerAdapter : FragmentPagerAdapter
    {

        private Context context { get; set; }
        private FragmentManager fragmentManager { get; set; }
        private List<String> weaponNames { get; set; }

        public WeaponPagerAdapter(FragmentManager fragmentManager, Context context)
            : base(fragmentManager)
        {
            this.fragmentManager = fragmentManager;
            this.context = context;
            this.weaponNames = MainWeapon.MainWeaponNameList;
        }

        public override Fragment GetItem(int position)
        {
            WeaponsFragment fragment;

            switch (position)
            {
                case 0:
                    fragment = new WeaponsFragment() { MainWeaponList = Shooter.ShooterList.ConvertAll(v => (MainWeapon)v) };
                    break;
                case 1:
                    fragment = new WeaponsFragment() { };
                    break;
                case 2:
                    fragment = new WeaponsFragment() { };
                    break;
                case 3:
                    fragment = new WeaponsFragment() { };
                    break;
                case 4:
                    fragment = new WeaponsFragment() { };
                    break;
                case 5:
                    fragment = new WeaponsFragment() { };
                    break;
                case 6:
                    fragment = new WeaponsFragment() { };
                    break;
                case 7:
                    fragment = new WeaponsFragment() { };
                    break;
                default:
                    fragment = null;
                    break;
            }

            return fragment;
        }

        public override int Count
        {
            get { return weaponNames.Count; }
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(weaponNames[position]);
        }
    }
}