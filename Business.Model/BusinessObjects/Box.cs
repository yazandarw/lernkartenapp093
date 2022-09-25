using System.Collections.ObjectModel;

namespace De.HsFlensburg.ClientApp093.Business.Model.BusinessObjects
{
    public class Box : ObservableCollection<Card>
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Box()
        {

        }

    }
}


