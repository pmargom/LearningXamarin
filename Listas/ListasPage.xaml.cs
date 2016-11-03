using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Listas
{
	public partial class ListasPage : ContentPage
	{
		private string ApiURL = "https://icangopmg-develop.azurewebsites.net/api/v1/users";
		private HttpClient _client = new HttpClient();

		public ListasPage()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			LoadUsers();
		}

		private async void LoadUsers()
		{
			try
			{
				// Tratamos de consumir el API y traer la lista de usuarios
				var contentJSON = await _client.GetStringAsync(ApiURL);

				// Mapeamos la respuesta para poder manipularla
				var response = JsonConvert.DeserializeObject<Response>(contentJSON);
				var users = new ObservableCollection<User>(response.data);

				// Mostramos los datos en un ListView
				userList.ItemsSource = users;
			}
			catch (System.Exception ex)
			{
				// aquí gestionamos el error
				var error = ex.Message;
				await DisplayAlert("Error", string.Format("Error: {0}", error), "OK");
			}
			finally
			{
				
			}


		}
	}
}
