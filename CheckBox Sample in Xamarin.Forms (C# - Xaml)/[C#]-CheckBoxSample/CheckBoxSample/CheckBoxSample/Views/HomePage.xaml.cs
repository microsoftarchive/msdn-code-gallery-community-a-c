using System;
using System.Collections.Generic;
using CheckBoxSample.Controls;
using CheckBoxSample.ViewModels;
using Xamarin.Forms;

namespace CheckBoxSample.Views
{
    public partial class HomePage : ContentPage
    {
        HomeViewModel _homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext= _homeViewModel = new HomeViewModel();
            CreateCheckBox();
            CheckBoxBinding();
        }

        /// <summary>
        /// Creating checkbox with assigned values (Bg, border, title, selection)
        /// </summary>
        void CreateCheckBox()
        {
            CheckBox checkbox = new CheckBox();
            checkbox.IsChecked = true;
            checkbox.IsVisible = true;
            checkbox.Title = "Japan";
            checkbox.BorderImageSource = "checkborder";
            checkbox.CheckedBackgroundImageSource = "checkcheckedbg";
            checkbox.CheckmarkImageSource = "checkcheckmark";
            stackPanel.Children.Add(checkbox);
        }

        /// <summary>
        /// Checkbox binding with homeViewModel
        /// </summary>
        void CheckBoxBinding(){
            Country country = new Country();
            country.Name = "Singapore";
            country.IsSelected = false;
            country.IsVisible = true;

            CheckBox checkbox = new CheckBox();
            checkbox.BindingContext = country;
            checkbox.SetBinding(CheckBox.IsCheckedProperty, "IsSelected", BindingMode.TwoWay);
            checkbox.SetBinding(CheckBox.IsVisibleProperty, "IsVisible");
            checkbox.SetBinding(CheckBox.TitleProperty, "Name");
            checkbox.BorderImageSource = "checkborder";
            checkbox.CheckedBackgroundImageSource = "checkcheckedbg";
            checkbox.CheckmarkImageSource = "checkcheckmark";
            stackPanel.Children.Add(checkbox);
        }
    }
}
