using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace CheckBoxSample.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            CountryList = new List<Country>();
            CountryList.Add(new Country(){Name="Country1", IsSelected=true, IsVisible=true});
            CountryList.Add(new Country() { Name = "Country2", IsSelected = true, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country3", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country4", IsSelected = true, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country5", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country6", IsSelected = true, IsVisible = true });
        }

        public List<Country> CountryList { get; set; }
    }
}
