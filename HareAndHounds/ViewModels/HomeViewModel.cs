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
using HareAndHounds.Helpers;
using HareAndHounds.Models;

namespace HareAndHounds.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Game Game;
        public HomeViewModel()
        {
            Game = GameHelper.NewGame();
        }
    }
}