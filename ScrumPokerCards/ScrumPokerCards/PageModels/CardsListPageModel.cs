using FreshMvvm;
using ScrumPokerCards.Models;
using ScrumPokerCards.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ScrumPokerCards.PageModels
{
    public class CardsListPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        // Services
        private readonly ICardsService _cardsService;

        private IList<Card> _cards;
        private Boolean _isBusy;

        /* Constructors */

        public CardsListPageModel()
        {
            _cardsService = FreshIOC.Container.Resolve<ICardsService>();
            
            _cards = _cardsService.get();
            IsBusy = true;
        }

        /* Properties */

        public IList<Card> Cards
        {
            get { return _cards; }
        }

        public Boolean IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        public Card SelectedCard
        {
            get { return null; }
            set {
                if(value != null)
                    CoreMethods.PushPageModel<CardViewPageModel>(value);
            }
        }

        /* Override Methods */

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            IsBusy = false;
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            IsBusy = true;
            base.ViewIsDisappearing(sender, e);
            RaisePropertyChanged("SelectedCard");
        }
    }
}
