using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIFromXamarin.Models;
using Xamarin.Forms;

namespace WebAPIFromXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var todo = GetAPIDataFromWeb();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private async Task<List<Todo>> GetAPIDataFromWeb()
        {
            List<Todo> todos = new List<Todo>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            if (response != null)
            {
                todos = JsonConvert.DeserializeObject<List<Todo>>(response);
                todoListView.ItemsSource = todos;
            }
            return todos;
        }
    }
}
