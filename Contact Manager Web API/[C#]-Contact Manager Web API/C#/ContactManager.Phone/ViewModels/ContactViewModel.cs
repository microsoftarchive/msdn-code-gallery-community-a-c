using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ContactManager.Models;

namespace ContactManager.Phone
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private Contact contact;
        private string address;

        public ContactViewModel(Contact contact)
        {
            this.contact = contact;
            this.address = String.Format("{0}, {1}, {2} {3}", contact.Address, contact.City, contact.State, contact.Zip);
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                return contact.Name;
            }
            set
            {
                if (value != contact.Name)
                {
                    contact.Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value != address)
                {
                    address = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Email
        {
            get
            {
                return contact.Email;
            }
            set
            {
                if (value != contact.Email)
                {
                    contact.Email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        public string Image
        {
            get
            {
                return "http://localhost:8081/" + contact.Self + ".png";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}