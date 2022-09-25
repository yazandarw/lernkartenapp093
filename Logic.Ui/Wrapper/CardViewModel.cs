using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.ClientApp093.Business.Model.BusinessObjects;

namespace De.HsFlensburg.ClientApp093.Logic.Ui.Wrapper
{
    public class CardViewModel
    {
        public Card myCard;
        public string Name
        {
            get
            {
                return myCard.Name;
            }
            set
            {
                myCard.Name = value;
            }
        }
        public string Title
        {
            get
            {
                return myCard.Title;
            }
            set
            {
                myCard.Title = value;
            }
        }
        public string Content
        {
            get
            {
                return myCard.Content;
            }
            set
            {
                myCard.Content = value;
            }
        }
        public bool Learned
        {
            get
            {
                return myCard.Learned;
            }
            set
            {
                myCard.Learned = value;
            }
        }
        public bool IsSelected
        {
            get
            {
                return myCard.IsSelected;
            }
            set
            {
                myCard.IsSelected = value;
            }
        }
        public CardViewModel()
        {
            myCard = new Card();
        }
        public CardViewModel(Card card)
        {
            myCard = card;
        }
    }
}
