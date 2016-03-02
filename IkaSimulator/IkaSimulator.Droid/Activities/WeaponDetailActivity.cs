using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using IkaSimulator.Weapons.MainWeapons;
using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Graphics;
using Android.Widget;
using ServiceStack.Text;
using IkaSimulator.Droid.Utils;
using IkaSimulator.Weapons;

namespace IkaSimulator.Droid.Activities
{
    [Activity(Label = "WeaponDetailActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class WeaponDetailActivity : AppCompatActivity
    {
        public static void Start(Context context, MainWeapon weapon)
        {
            var intent = new Intent(context, typeof(WeaponDetailActivity));
            
            var bundle = new Bundle();
            bundle.PutString("weapon", JsonSerializer.SerializeToString<MainWeapon>(weapon));

            intent.PutExtras(bundle);

            context.StartActivity(intent);
        }

        private Android.Support.V7.Widget.Toolbar Toolbar { get; set; }
        private TextView TextViewMain { get; set; }
        private ImageView ImageViewMain { get; set; }
        private TextView TextViewSub { get; set; }
        private ImageView ImageViewSub { get; set; }
        private TextView TextViewSpecial { get; set; }
        private ImageView ImageViewSpecial { get; set; }

        private MainWeapon MainWeapon { get; set; }

        public CollapsingToolbarLayout CollapsingToolbarLayout { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var str = this.Intent.Extras.GetString("weapon");
            this.MainWeapon = JsonSerializer.DeserializeFromString<MainWeapon>(str);

            SetContentView(Resource.Layout.activity_weapon_detail);

            InitViews();

            InitToolbar(null);
        }

        private void InitViews()
        {
            Typeface typeFace = Typeface.CreateFromAsset(this.Assets, "ikamodoki1_0.ttf");

            TextViewMain = FindViewById<TextView>(Resource.Id.text_view_main);
            TextViewMain.Text = this.MainWeapon.Name;
            TextViewMain.Typeface = typeFace;

            ImageViewMain = FindViewById<ImageView>(Resource.Id.image_view_main);
            ImageViewMain.SetImageResource(
                ResourceConverter.GetDrawableID(this, this.MainWeapon.FileName));

            TextViewSub = FindViewById<TextView>(Resource.Id.text_view_sub);
            TextViewSub.Text = this.MainWeapon.SubWeapon.Name;
            TextViewSub.Typeface = typeFace;

            ImageViewSub = FindViewById<ImageView>(Resource.Id.image_view_sub);
            ImageViewSub.SetImageResource(
                ResourceConverter.GetDrawableID(this, this.MainWeapon.SubWeapon.FileName));

            TextViewSpecial = FindViewById<TextView>(Resource.Id.text_view_special);
            TextViewSpecial.Text = this.MainWeapon.SpecialWeapon.Name;
            TextViewSpecial.Typeface = typeFace;

            ImageViewSpecial = FindViewById<ImageView>(Resource.Id.image_view_special);
            ImageViewSpecial.SetImageResource(
                ResourceConverter.GetDrawableID(this, this.MainWeapon.SpecialWeapon.FileName));

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            CollapsingToolbarLayout = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
        }

        private void InitToolbar(MainWeapon weapon)
        {
            SetSupportActionBar(Toolbar);
            if (this.SupportActionBar != null)
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // TODO 変える
            CollapsingToolbarLayout.Title = "わかばシューター";
            Typeface typeFace = Typeface.CreateFromAsset(this.Assets, "ikamodoki1_0.ttf");
            CollapsingToolbarLayout.CollapsedTitleTypeface = typeFace;
            CollapsingToolbarLayout.ExpandedTitleTypeface = typeFace;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}