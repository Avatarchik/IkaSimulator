using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using IkaSimulator.Droid.Adapters;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Graphics;

namespace IkaSimulator.Droid.Fragments
{
    public class WeaponsTabFragment : Fragment
    {
        private WeaponPagerAdapter Adapter { get; set; }
        private ViewPager ViewPager { get; set; }
        private TabLayout TabLayout { get; set; }

        public static WeaponsTabFragment NewInstance()
        {
            return new WeaponsTabFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_tab, container, false);
            ViewPager = view.FindViewById<ViewPager>(Resource.Id.view_pager);
            TabLayout = view.FindViewById<TabLayout>(Resource.Id.tab_layout);

            InitLayout();

            return view;
        }

        private void InitLayout()
        {
            Adapter = new WeaponPagerAdapter(this.FragmentManager, this.Context);
            ViewPager.Adapter = Adapter;
            TabLayout.SetupWithViewPager(ViewPager);
            SetTabTypeFace();
        }

        private void SetTabTypeFace()
        {
            Typeface typeFace = Typeface.CreateFromAsset(this.Context.Assets, "ikamodoki1_0.ttf");
            ViewGroup viewGroup = (ViewGroup)TabLayout.GetChildAt(0);

            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                ViewGroup childViewGroup = (ViewGroup)viewGroup.GetChildAt(i);

                for (int j = 0; j < childViewGroup.ChildCount; j++)
                {
                    View tabViewChild = childViewGroup.GetChildAt(j);
                    if (tabViewChild is TextView)
                    {
                        ((TextView)tabViewChild).Typeface = typeFace;
                    }
                }
            }
        }
    }
}