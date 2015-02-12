using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HareAndHounds.Helpers;
using HareAndHounds.Models;

namespace HareAndHounds.ViewModels
{
    public class PlaceViewModel : BaseViewModel
    {
        private IMessageDialog messages;
        private Game game;
        private Place place = null;

        private bool placeComplete;

        public bool PlaceComplete
        {
            get { return placeComplete; }
            set { SetProperty(ref placeComplete, value, "PlaceComplete"); }
        }

        public Place Place
        {
            get { return place; }
            private set { SetProperty(ref place, value, "Place"); }
        }

        public PlaceViewModel()
        {
            messages = ServiceContainer.Resolve<IMessageDialog>();
            game = GameHelper.NewGame();
            place = game.Places.FirstOrDefault();
        }

        private ICommand loadPlaceCommand;

        /// <summary>
        /// Will load the next or current phase
        /// </summary>
        //public ICommand LoadPlaceCommand
        //{
        //    get
        //    {
        //        return loadPlaceCommand ??
        //        (loadPlaceCommand = ExecuteLoadPlaceCommand());
        //    }
        //}

        //private async Task ExecuteLoadPlaceCommand()
        //{

        //}

        public void LoadNextLevel()
        {

        }

        public void CheckAnswer(int answer)
        {
            if (!place.Question.Answers[answer].IsAnswer)
            {
                messages.SendMessage("Wrong Answer", "Quick Hint: I Love you");
            }

            PlaceComplete = true;
        }
    }
}