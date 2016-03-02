using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;
using IkaSimulator.Droid.Fragments;
using Android.Support.V4.App;

namespace IkaSimulator.Droid.Models
{
    public abstract class Page
    {
        public static List<Page> Pages = new List<Page>
        {
            new WeaponPage(Resource.Id.nav_all_sessions, Resource.String.all_sessions, false),
            new GearPage(Resource.Id.nav_my_schedule, Resource.String.my_schedule, false),
            new SimulationPage(Resource.Id.nav_about, Resource.String.about, true)
        };

        public int MenuId { get; set; }
        public int TitleResourceId { get; set; }
        private bool ToggleToolbar { get; set; }
        public abstract Android.Support.V4.App.Fragment CreateFragment();

        Page(int menuId, int titleResourceId, bool toggleToolbar)
        {
            this.MenuId = menuId;
            this.TitleResourceId = titleResourceId;
            this.ToggleToolbar = toggleToolbar;
        }

        public static Page ForMenuId(IMenuItem item)
        {
            int id = item.ItemId;
            foreach (Page page in Pages)
            {
                if (page.MenuId == id)
                {
                    return page;
                }
            }

            return null;
        }

        private class WeaponPage : Page
        {
            public WeaponPage(int menuId, int titleResourceId, bool toggleToolbar)
                : base(menuId, titleResourceId, toggleToolbar)
            {
            }

            public override Fragment CreateFragment()
            {
                return WeaponsTabFragment.NewInstance();
            }
        }

        private class GearPage : Page
        {
            public GearPage(int menuId, int titleResourceId, bool toggleToolbar)
                : base(menuId, titleResourceId, toggleToolbar)
            {
            }

            public override Fragment CreateFragment()
            {
                return GearTabFragment.NewInstance();
            }
        }

        private class SimulationPage : Page
        {
            public SimulationPage(int menuId, int titleResourceId, bool toggleToolbar)
                : base(menuId, titleResourceId, toggleToolbar)
            {
            }

            public override Fragment CreateFragment()
            {
                return SimulationFragment.NewInstance();
            } 
        }
    }
}