using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using Xamarin.Forms.Xaml;
using App1.ViewModel;
using App1.View;
using App1.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Xml.Xsl;
using System.Reflection;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        List<Employ> userList=new List<Employ>();
        public MainPage()
        {
            InitializeComponent();
            getjsonasync();
          


        }
        public async Task getjsonasync()
        {
            var uri = new Uri("https://reqres.in/api/users");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonobject=JObject.Parse(json);
                var status = jsonobject["status"];
                var message =jsonobject["message"];
                var data = jsonobject["data"];
                var jsonArray = JArray.Parse(data.ToString());
                foreach(var token in jsonArray)
                {
                    Employ employ = new Employ();
                    string id = token["id"].ToString();
                    string email = token["email"].ToString();
                    string first_name = token["first_name"].ToString();
                    string last_name = token["last_name"].ToString();
                    string avatar = token["avatar"].ToString();
                    employ.id = id;
                    employ.email = email;
                    employ.first_name = first_name;
                    employ.last_name = last_name;
                    employ.avatar = avatar;
                    userList.Add(employ);

                }
                
            }
            userListView.ItemsSource = userList;


        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Employ;
            await Navigation.PushModalAsync(new MyListPageDetail(details.id, details.email,details.first_name,details.last_name, details.avatar));

        }

    }
}