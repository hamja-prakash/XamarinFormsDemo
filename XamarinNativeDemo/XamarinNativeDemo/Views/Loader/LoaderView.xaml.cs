﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNativeDemo.Views.Loader
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoaderView : ContentView
	{
		public LoaderView ()
		{
			InitializeComponent ();
		}
	}
}