//
// Sensor.cs
//
// Created by Thomas Dubiel on 19.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
#if __IOS__
using UIKit;
#endif

#if __ANDROID__
using Android.Widget;
#endif

namespace MagnetFinder
{
	public class Sensor
	{
		double maxX = 0;
		double maxY = 0;
		double maxZ = 0;

		double minX = 0;
		double minY = 0;
		double minZ = 0;

#if __IOS__

		UIProgressView progressX;
		UIProgressView progressY;
		UIProgressView progressZ;

		public Sensor(UIProgressView progX, UIProgressView progY, UIProgressView progZ)
		{
			progressX = progX;
			progressY = progY;
			progressZ = progZ;
		}
#endif

#if __ANDROID__
		ProgressBar progressBarX;
		ProgressBar progressBarY;
		ProgressBar progressBarZ;

		public Sensor(ProgressBar progX, ProgressBar progY, ProgressBar progZ)
		{
			progressBarX = progX;
			progressBarY = progY;
			progressBarZ = progZ;
		}

#endif

		public void StartSensors()
		{
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer);
			CrossDeviceMotion.Current.SensorValueChanged += (sender, e) =>
			{
				switch (e.SensorType)
				{
					case MotionSensorType.Magnetometer:
						var values = (MotionVector)e.Value;
						LimitsTestFunction(values);

#if __IOS__
						progressX.Progress = (float)(values.X / 300.0);
						progressY.Progress = (float)(values.Y / 200.0);
						progressZ.Progress = (float)(values.Z / -1100.0);
#endif
#if __ANDROID__
						progressBarX.Progress = (int)values.X;
						progressBarY.Progress = -(int)values.Y;
						progressBarZ.Progress = -(int)values.Z;
#endif
						break;

					default:
						break;
				}
			};

		}

		void LimitsTestFunction(MotionVector a)
		{
			var valX = a.X;
			var valY = a.Y;
			var valZ = a.Z;

			if (valX > maxX)
			{
				maxX = valX;
				Console.WriteLine("X max: " + maxX);
			}
			if (valY > maxY)
			{
				maxY = valY;
				Console.WriteLine("Y max: " + maxY);
			}
			if (valZ > maxZ)
			{
				maxZ = valZ;
				Console.WriteLine("Z max: " + maxZ);
			}

			if (valX < minX)
			{
				minX = valX;
				Console.WriteLine("X min: " + minX);
			}
			if (valY < minY)
			{
				minY = valY;
				Console.WriteLine("Y min: " + minY);
			}
			if (valZ < minZ)
			{
				minZ = valZ;
				Console.WriteLine("Z min: " + minZ);
			}
		}

	}
}
