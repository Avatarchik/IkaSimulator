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
using Android.Graphics;
using Android.Support.V7.Widget;
using IkaSimulator.Droid.Adapters;
using IkaSimulator.Weapons.MainWeapons;
using IkaSimulator.Droid.Widgets;

namespace IkaSimulator.Droid.Fragments
{
    public class WeaponsFragment : Fragment
    {
        private RecyclerView RecyclerView { get; set; }
        public List<MainWeapon> MainWeaponList { get; set; }
        private WeaponsRecyclerAdapter Adapter { get; set; }

        public static WeaponsFragment GetInstance()
        {
            return new WeaponsFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            // Test comment
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_tab_contents, container, false);

            RecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycler_view);

            int spacing = Resources.GetDimensionPixelSize(Resource.Dimension.spacing_xsmall);
            RecyclerView.AddItemDecoration(new SpaceItemDecoration(spacing));

            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Activity);
            layoutManager.Orientation = LinearLayoutManager.Vertical;
            RecyclerView.SetLayoutManager(layoutManager);

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            Adapter = new WeaponsRecyclerAdapter(this.Activity, MainWeaponList);
            RecyclerView.SetAdapter(Adapter);
        }
    }
}