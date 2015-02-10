using System;
using Android.App;
using HareAndHounds.Helpers;

namespace HareAndHounds
{
    #if DEBUG
    [Application(Theme = "@style/Theme.Quest", Debuggable = true)]
    #else
	[Application(Theme = "@style/Theme.Quest", Debuggable=false)]
	#endif
  public class App : Application
    {
    
        public static Activity CurrentActivity { get; set; }

        public App(IntPtr handle, global::Android.Runtime.JniHandleOwnership transer)
            : base(handle, transer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            ServiceContainer.Register<IMessageDialog>(new Messages());
        }
    }
}
