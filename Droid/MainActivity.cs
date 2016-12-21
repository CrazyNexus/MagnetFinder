using Android.App;
using Android.Widget;
using Android.OS;

namespace MagnetFinder.Droid
{
	[Activity(Label = "Magnet Finder", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var progressBarX = FindViewById<ProgressBar>(Resource.Id.progressBarX);
			var progressBarY = FindViewById<ProgressBar>(Resource.Id.progressBarY);
			var progressBarZ = FindViewById<ProgressBar>(Resource.Id.progressBarZ);

			var sensor = new Sensor(progressBarX, progressBarY, progressBarZ);
			sensor.StartSensors();
		}


	}
}

