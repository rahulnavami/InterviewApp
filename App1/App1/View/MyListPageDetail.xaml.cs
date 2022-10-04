using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPageDetail : ContentPage
    {
        public MyListPageDetail()
        {
            InitializeComponent();
        }
       
        public MyListPageDetail(string id, string email, string first_name, string last_name ,string avatar)
        {

            InitializeComponent();

            Myid.Text = id;
            myname.Text = first_name;
            maylname.Text = last_name;
            myemail.Text = email;
            Myimage.Source = new UriImageSource()
            {
                Uri = new Uri(avatar)
            };
        }
    }
}