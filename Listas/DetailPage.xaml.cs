using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Listas
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException();
			}

			BindingContext = user;

			InitializeComponent();
		}
	}
}
