//
// ViewController.cs
//
// Created by Thomas Dubiel on 19.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;
using UIKit;

namespace MagnetFinder.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			new Sensor(progressX, progressY, progressZ).StartSensors();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
