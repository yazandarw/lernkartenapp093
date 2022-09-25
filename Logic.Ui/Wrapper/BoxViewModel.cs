using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp093.Business.Model.BusinessObjects;

namespace De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper
{
    public class BoxViewModel : ObservableCollection<CardViewModel>
    {
        public Box myBox;
        private bool syncDisabled;

        public string Name
        {
            get
            {
                return myBox.Name;
            }
            set
            {
                myBox.Name = value;
            }
        }
        public string Category
        {
            get
            {
                return myBox.Category;
            }
            set
            {
                myBox.Category = value;
            }
        }
        public BoxViewModel()
        {
            myBox = new Box();
            myBox.CollectionChanged += BoxModel_CollectionChanged;
            this.CollectionChanged += BoxViewModel_CollectionChanged;
        }
        public BoxViewModel(Box box)
        {
            myBox = box;
            myBox.CollectionChanged += BoxModel_CollectionChanged;
            this.CollectionChanged += BoxViewModel_CollectionChanged;
        }
        private void BoxModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var card in e.NewItems.OfType<Card>())
                        Add(new CardViewModel(card));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var card in e.OldItems.OfType<Card>())
                        Remove(GetViewModelOfModel(card));
                    break;
                case NotifyCollectionChangedAction.Reset:
                        Clear();
                    break;
            }
            syncDisabled = false;
        }
        private void BoxViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var card in e.NewItems.OfType<CardViewModel>().Select(c => c.myCard).OfType<Card>())
                        myBox.Add(card);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var card in e.OldItems.OfType<CardViewModel>().Select(c => c.myCard).OfType<Card>())
                        myBox.Remove(card);
                    break;
                case NotifyCollectionChangedAction.Reset:
                        myBox.Clear();
                    break;
            }
            syncDisabled = false;
        }

        private CardViewModel GetViewModelOfModel(Card card)
        {
            foreach (CardViewModel cvm in this)
            {
                if (cvm.myCard.Equals(card)) return cvm;
            }
            return null;
        }
    }
}
