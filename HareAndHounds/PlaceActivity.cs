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
using HareAndHounds.ViewModels;

namespace HareAndHounds
{
    [Activity(Label = "PlaceActivity")]
    public class PlaceActivity : Activity
    {

        public static PlaceViewModel ViewModel { get; set; }

        private ImageView mainImage;
        private TextView mainText;
        private Button buttonContinue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ViewModel = new PlaceViewModel();

            SetContentView(Resource.Layout.Place);

            mainImage = FindViewById<ImageView>(Resource.Id.main_image);
            mainText = FindViewById<TextView>(Resource.Id.main_text);

            buttonContinue = FindViewById<Button>(Resource.Id.button_continue);
            buttonContinue.Click += ButtonContinueOnClick;
            buttonContinue.Visibility = ViewStates.Gone;
            // Create your application here
        }

        private void ButtonContinueOnClick(object sender, EventArgs eventArgs)
        {
            //if (ViewModel.GameComplete)
            //{
            //    GoToGameComplete();
            //    return;
            //}

            //Intent intent = new Intent(this, typeof(PlaceQuestionActivity));

            //StartActivity(intent);
            //OverridePendingTransition(Resource.Animation.slide_in_up, Resource.Animation.slide_out_up); 
        }

        private void GoToGameComplete()
        {
            var intent = new Intent(this, typeof(GameCompletedActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_left, Resource.Animation.slide_out_left);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            OverridePendingTransition(Resource.Animation.slide_in_right, Resource.Animation.slide_out_right);
        }
    }
}