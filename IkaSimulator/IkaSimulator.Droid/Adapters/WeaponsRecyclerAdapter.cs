using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using IkaSimulator.Weapons.MainWeapons;
using IkaSimulator.Droid.Utils;
using Android.Graphics;
using IkaSimulator.Droid.Activities;

namespace IkaSimulator.Droid.Adapters
{
    class WeaponsRecyclerAdapter : RecyclerView.Adapter
    {

        private LayoutInflater Inflater { get; set; }
        private List<MainWeapon> MainWeapons { get; set; }
        private Context Context { get; set; }

        public WeaponsRecyclerAdapter(Context context, List<MainWeapon> mainWeapons)
        {
            this.Inflater = LayoutInflater.From(context);
            this.Context = context;
            this.MainWeapons = mainWeapons;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup viewGroup, int i)
        {
            return new WeaponsViewHolder(Inflater.Inflate(Resource.Layout.item_weapon, viewGroup, false));
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int i)
        {
            WeaponsViewHolder vh = viewHolder as WeaponsViewHolder;

            // データ表示
            if (MainWeapons != null && MainWeapons.Count > i && MainWeapons[i] != null)
            {
                vh.MainWeaponTextView.Text = this.MainWeapons[i].Name;
                vh.MainWeaponImageView.SetImageResource(
                    ResourceConverter.GetDrawableID(this.Context, MainWeapons[i].FileName));
                vh.SubWeaponImageView.SetImageResource(
                    ResourceConverter.GetDrawableID(this.Context, MainWeapons[i].SubWeapon.FileName));
                vh.SpecialWeaponImageView.SetImageResource(
                    ResourceConverter.GetDrawableID(this.Context, MainWeapons[i].SpecialWeapon.FileName));

                vh.MainWeaponImageView.Click += delegate
                {
                    WeaponDetailActivity.Start(this.Context, MainWeapons[i]);
                };
            }

            /* クリック処理
            viewHolder.ItemView.SetOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mListener.onRecyclerClicked(v, i);
                }
            });
            */
        }

        public override int ItemCount
        {
            get
            {
                if (MainWeapons != null)
                {
                    return MainWeapons.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

    }

    class WeaponsViewHolder : RecyclerView.ViewHolder
    {
        public ImageView MainWeaponImageView { get; set; }
        public TextView MainWeaponTextView { get; set; }
        public ImageView SubWeaponImageView { get; set; }
        public ImageView SpecialWeaponImageView { get; set; }

        public WeaponsViewHolder(View itemView)
            : base(itemView)
        {
            Typeface typeFace = Typeface.CreateFromAsset(itemView.Context.Assets, "ikamodoki1_0.ttf");

            MainWeaponImageView = itemView.FindViewById<ImageView>(Resource.Id.image_view_main);
            MainWeaponTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_main);
            MainWeaponTextView.Typeface = typeFace;

            SubWeaponImageView = itemView.FindViewById<ImageView>(Resource.Id.image_view_sub);

            SpecialWeaponImageView = itemView.FindViewById<ImageView>(Resource.Id.image_view_special);
        }
    }
}