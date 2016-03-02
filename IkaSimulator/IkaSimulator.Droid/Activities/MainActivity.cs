using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using IkaSimulator.Droid.Models;
using Android.Support.V4.View;

namespace IkaSimulator.Droid.Activities
{
    [Activity(Label = "IkaSimulator.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private Toolbar Toolbar;
        private DrawerLayout Drawer;
        private NavigationView NavigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            Drawer = FindViewById<DrawerLayout>(Resource.Id.drawer);
            NavigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);


            InitView();

            // Get our button from the layout resource,
            // and attach an event to it
            /*Button button = FindViewById<Button> (Resource.Id.myButton);
			
            button.Click += delegate {
                button.Text = string.Format ("{0} clicks!", count++);
            };*/
        }

        private void InitView()
        {
            SetSupportActionBar(Toolbar);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this,
                Drawer, Toolbar, Resource.String.open, Resource.String.close);
            Drawer.SetDrawerListener(toggle);
            toggle.SyncState();
            NavigationView.SetNavigationItemSelectedListener(this);
            NavigationView.SetCheckedItem(Resource.Id.nav_all_sessions);
        }

        private void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            fragmentTransaction.SetCustomAnimations(Resource.Animation.fragment_fade_enter, Resource.Animation.fragment_fade_exit);
            fragmentTransaction.Replace(Resource.Id.content_view, fragment, fragment.Class.SimpleName);
            fragmentTransaction.Commit();
            // currentFragment = fragment;
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            Drawer.CloseDrawer(GravityCompat.Start);

            Page page = Page.ForMenuId(menuItem);
            ChangePage(page.TitleResourceId, page.CreateFragment());

            return true;
        }

        private void ToggleToolbarElevation(bool enable)
        {
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            {
                float elevation = enable ? Resources.GetDimension(Resource.Dimension.elevation) : 0;
                Toolbar.TranslationZ = elevation; // toolbar.setElevation(elevation);
            }
        }

        private void ChangePage(int titleResourceId, Android.Support.V4.App.Fragment fragment)
        {
            new Handler().PostDelayed(() =>
            {
                Toolbar.SetTitle(titleResourceId);
                ReplaceFragment(fragment);
            }, 300);
        }

        public override void Finish()
        {
            base.Finish();
            OverridePendingTransition(Resource.Animation.activity_fade_enter, Resource.Animation.activity_fade_exit);
        }
    }
}


