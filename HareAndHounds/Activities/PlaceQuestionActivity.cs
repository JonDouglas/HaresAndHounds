using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HareAndHounds.Activities
{
    [Activity(Label = "PlaceQuestionActivity")]
    public class PlaceQuestionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Question);

            var cancelButton = FindViewById<Button>(Resource.Id.button_cancel);
            cancelButton.Click += CancelButtonOnClick;

            var answerButton = FindViewById<Button>(Resource.Id.button_answer);
            answerButton.Click += AnswerButtonOnClick;

            var labelHint = FindViewById<TextView>(Resource.Id.hint);
            var labelAwesome = FindViewById<TextView>(Resource.Id.awesome);

        }

        private void AnswerButtonOnClick(object sender, EventArgs eventArgs)
        {
            //if (PlaceActivity.ViewModel.PlaceComplete)
            //{
            //    //Place code below in here
            //}
            Finish();
            OverridePendingTransition(Resource.Animation.slide_in_down, Resource.Animation.slide_in_down);

            //Answer Question
            //PlaceActivity.ViewModel.CheckAnswer(answer);
        }

        private void CancelButtonOnClick(object sender, EventArgs eventArgs)
        {
            Finish();
            OverridePendingTransition(Resource.Animation.slide_in_down, Resource.Animation.slide_in_down);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            OverridePendingTransition(Resource.Animation.slide_in_down, Resource.Animation.slide_out_down);
        }
    }
}