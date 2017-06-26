
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
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V13.App;

namespace MyEvent_XAndroid
{
	[Activity(Label = "myEvent", MainLauncher = true)]			
	public class InteractWithEventActivity : Activity
	{
		private static readonly string[] arrMainNav =
			{
				"Event Selection", 
				"Sessions", 
				"Presenters", 
			};

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.InteractWithEvent);

			DrawerLayout oDrawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			ListView oDrawerList = oDrawerLayout.FindViewById<ListView>(Resource.Id.listViewMainNav);

			oDrawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.DrawerNav, arrMainNav);
		}
	}
}

