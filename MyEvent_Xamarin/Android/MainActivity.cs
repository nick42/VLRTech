using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MyEvent_XAndroid
{
	[Activity(Label = "myEvent")]
	public class MainActivity : Android.App.Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			ActionBar.SetHomeButtonEnabled(true);

			SetContentView(Resource.Layout.Main);

			DoTest();
		}

		protected void DoTest()
		{
			AppData.Session oSession = new AppData.Session();
			oSession.m_sTitle = "Some Session";
			oSession.m_sDescription = "Important content.";

			string sSessionXML = DataAccessLayer.XML.Convert.ToXML(oSession);
		}
	}
}
