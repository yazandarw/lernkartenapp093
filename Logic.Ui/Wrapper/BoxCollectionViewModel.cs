using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp093.Business.Model.BusinessObjects;

namespace De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper
{
    public class BoxCollectionViewModel : ObservableCollection<BoxViewModel>
    {
        public BoxCollection myBoxCollection;
        private bool syncDisabled;

        public BoxCollectionViewModel()
        {
            myBoxCollection = new BoxCollection();
            myBoxCollection.CollectionChanged += BoxColl_ModelCollectionChanged;
            this.CollectionChanged += BoxCollVM_ViewModelCollectionChanged;
        }
        private void BoxColl_ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var box in e.NewItems.OfType<Box>())
                        Add(new BoxViewModel(box));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var box in e.OldItems.OfType<Box>())
                        Remove(GetModelinViewModel(box));
                    break;
                case NotifyCollectionChangedAction.Reset:
                        Clear();
                    break;
            }
            syncDisabled = false;
        }
        private void BoxCollVM_ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch(e.Action) 
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var box in e.NewItems.OfType<BoxViewModel>().Select(b => b.myBox).OfType<Box>())
                       myBoxCollection.Add(box);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var box in e.OldItems.OfType<BoxViewModel>().Select(b => b.myBox).OfType<Box>())
                        myBoxCollection.Remove(box);
                    break;
                case NotifyCollectionChangedAction.Reset:
                        myBoxCollection.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private BoxViewModel GetModelinViewModel(Box box)
        {
            foreach (BoxViewModel cvm in this)
            {
                if (cvm.myBox.Equals(box)) return cvm;
            }
            return null;
        }
    }
}
