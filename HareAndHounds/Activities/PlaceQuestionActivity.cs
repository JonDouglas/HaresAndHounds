using System;
using Android.App;
using Android.OS;
using Android.Widget;
using HareAndHounds.Helpers;

namespace HareAndHounds.Activities
{
    [Activity(Label = "PlaceQuestionActivity")]
    public class PlaceQuestionActivity : Activity
    {
        private IMessageDialog messages;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            App.CurrentActivity = this;
            messages = ServiceContainer.Resolve<IMessageDialog>();
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
            //Finish();
            //OverridePendingTransition(Resource.Animation.slide_in_down, Resource.Animation.slide_in_down);

            messages.AskQuestions("Question:", PlaceActivity.ViewModel.Place.Question, (answer) =>
            {
                PlaceActivity.ViewModel.CheckAnswer(answer);
                //if (QuestActivity.ViewModel.QuestComplete)
                //{
                //    cancelButton.Visibility = ViewStates.Invisible;
                //    answerButton.SetText(Resource.String.continue_game);
                //    labelHint.SetText(Resource.String.continue_quest);
                //    labelAwesome.SetText(Resource.String.thats_it);
                //    labelCongrats.SetText(Resource.String.correct_answer);
                //    //Settings.QuestDone = true;
                //}
            });

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