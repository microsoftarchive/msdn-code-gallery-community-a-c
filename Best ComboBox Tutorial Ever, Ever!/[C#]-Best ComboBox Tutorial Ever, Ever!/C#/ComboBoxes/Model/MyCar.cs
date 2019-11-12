using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComboBoxes.Model
{
    public class MyCar : PropertyChangedBase
    {
        public string Model { get; set; }
        public string Registration { get; set; }

        string _PartId;
        public string PartId
        {
            get
            {
                return _PartId;
            }
            set
            {
                if (_PartId != value)
                {
                    _PartId = value;
                    RaisePropertyChanged("PartId");
                }
            }
        }

    }
}
