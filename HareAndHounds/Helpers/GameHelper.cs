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
using HareAndHounds.Models;

namespace HareAndHounds.Helpers
{
    public static class GameHelper
    {
        public static Game NewGame()
        {
            Game game = new Game();
            List<Place> places = new List<Place>();
#region Place1

            Place place1 = new Place();
            Clue place1Clue = new Clue
            {
                Image = "http://cdn.wonderfulengineering.com/wp-content/uploads/2014/06/galaxy-wallpapers-20.jpg", 
                Message = "Look to the stars, what do you see?"
            };

            Question place1Question = new Question()
            {
                Text = "My Very Educated Mother Just Served Us Noodles.",
                Answers = new List<Answer>()
                {
                    new Answer() {IsAnswer = true, Text = "Clark Planetarium"},
                    new Answer() {IsAnswer = false, Text = "Challenger School"},
                    new Answer() {IsAnswer = false, Text = "Your Mother's House"},
                    new Answer() {IsAnswer = false, Text = "Megaplex"}
                }
            };

            place1.Id = 1;
            place1.Clue = place1Clue;
            place1.Question = place1Question;

#endregion

            #region Place2

            Place place2 = new Place();
            Clue place2Clue = new Clue
            {
                Image = "http://img1.wikia.nocookie.net/__cb20131005020134/disney/images/3/31/Air_Bud_Header.jpg",
                Message = "Ain't no rules says a dog can't play basketball."
            };

            Question place2Question = new Question()
            {
                Text = "Now basketball is my favorite sport, I like the way they dribble up and down the court",
                Answers = new List<Answer>()
                {
                    new Answer() {IsAnswer = false, Text = "Dick's Sporting Goods"},
                    new Answer() {IsAnswer = false, Text = "Foot Locker"},
                    new Answer() {IsAnswer = true, Text = "Energy Solutions Arena"},
                    new Answer() {IsAnswer = false, Text = "Fanzz"}
                }
            };

            place2.Id = 2;
            place2.Clue = place2Clue;
            place2.Question = place2Question;

            places.Add(place1);
            places.Add(place2);

            game.Places = places;
            game.Started = true;

            #endregion
            return game;
        }
    }
}