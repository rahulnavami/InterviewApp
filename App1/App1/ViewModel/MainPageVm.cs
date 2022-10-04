using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class MainPageVm : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public MainPageVm(INavigation _navigation)


        {
            Navigation = _navigation;
        }
        public async void GetEmployees()
        {
            using (var client = new HttpClient())
            {
               
                var uri = "https://reqres.in/api/users";
                var result = await client.GetStringAsync(uri);

               
                var EmployeeList = JsonConvert.DeserializeObject<List<Employ>>(result);

                Employees = new ObservableCollection<Employ>(EmployeeList);
                IsRefreshing = false;
            }
        }
        public Command RefreshData
        {
            get
            {
                return new Command(() =>
                {
                    GetEmployees();
                });
            }
        }
        bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        //Employee _selectedEmployee;
        //public Employee SelectedEmployee
        //{
        //    get
        //    {
        //        return _selectedEmployee;
        //    }
        //    set
        //    {
        //        _selectedEmployee = value;
        //        if (value != null)
        //        {
        //            Navigation.PushAsync(new AddEmployee(SelectedEmployee));
        //        }
        //        OnPropertyChanged();
        //    }
        //}

        ObservableCollection<Employ> _employees;
        public ObservableCollection<Employ> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}