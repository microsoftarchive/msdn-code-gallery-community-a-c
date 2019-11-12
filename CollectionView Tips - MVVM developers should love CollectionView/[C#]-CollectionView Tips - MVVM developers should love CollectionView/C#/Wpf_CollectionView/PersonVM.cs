using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using System.Windows.Data;
namespace Wpf_CollectionView
{
    class PersonVM : NotifyUIBase
    {
        public Person ThePerson { get; set; }
        public CollectionView CV { get; set; }
        public int RowNo
        {
            get
            {
                int row = -1;
                row = CV.IndexOf(this);
                return row + 1;
            }
        }
        
    }
}
