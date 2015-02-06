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

namespace HareAndHounds.Models
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
    }
}