using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using HareAndHounds.ViewModels;

namespace HareAndHounds.Activities
{
    [Activity(Label = "HareAndHounds", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private HareAndHoundsMapView map;
        private LockableScrollView scrollView;
        private HomeViewModel viewModel;
        private ImageView background;
        private Button buttonPlay;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            viewModel = new HomeViewModel();

            buttonPlay = FindViewById<Button>(Resource.Id.button_play);
            buttonPlay.Click += ButtonPlayOnClick;
            background = FindViewById<ImageView>(Resource.Id.background);
            map = FindViewById<HareAndHoundsMapView>(Resource.Id.map);
            scrollView = FindViewById<LockableScrollView>(Resource.Id.map_scroll);

            scrollView.SmoothScrollingEnabled = true;

            map.SetPins(new[]
                {
                    MapPinPosition.Center,
                    MapPinPosition.Right,
                    MapPinPosition.Left,
                    MapPinPosition.Center,
                    MapPinPosition.Left,
                    MapPinPosition.Center,
                    MapPinPosition.Right,
                    MapPinPosition.Left,
                    MapPinPosition.Right,
                    MapPinPosition.Center,
                    MapPinPosition.Left,
                    MapPinPosition.Center
                });

            // Get our button from the layout resource,
            // and attach an event to it
        }

        private void ButtonPlayOnClick(object sender, EventArgs eventArgs)
        {
            if (viewModel.Game.Started)
            {
                GoToGame();
                return;
            }
        }

        private void GoToGame()
        {
            var intent = new Intent(this, typeof (PlaceActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_left, Resource.Animation.slide_in_left);
        }

        protected override void OnStart()
        {
            base.OnStart();
            SetMap();
        }

        /// <summary>
        /// DO THIS SOON
        /// </summary>
        private void SetMap()
        {
            var places = 11.0;
            var currentPlace = 1;
            if (viewModel.Game != null)
                places = (double)viewModel.Game.Places.Count - 1;
            map.CurrentPin = currentPlace;

            if (places <= 0.0)
                return;

            var percent = ((double)currentPlace / places);

            if (percent > 1)
                percent = 1;

            if (percent <= 0.0)
                background.SetImageResource(Resource.Drawable.place_map1);
            else if (percent < .2)
                background.SetImageResource(Resource.Drawable.place_map2);
            else if (percent < .45)
                background.SetImageResource(Resource.Drawable.place_map3);
            else if (percent < .6)
                background.SetImageResource(Resource.Drawable.place_map4);
            else if (percent < 1)
                background.SetImageResource(Resource.Drawable.place_map5);
            else
                background.SetImageResource(Resource.Drawable.place_map6);

            scrollView.PostDelayed(() =>
            {
                var y = (map.Height - DipToPixels(this, 448)) * percent;
                scrollView.SmoothScrollTo(scrollView.ScrollX, (int)y);
            }, 1000);
        }

        public static float DipToPixels(Context context, float dipValue)
        {
            var metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dipValue, metrics);
        }
    }
}

