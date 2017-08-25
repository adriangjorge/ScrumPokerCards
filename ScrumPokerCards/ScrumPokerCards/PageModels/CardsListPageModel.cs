using FreshMvvm;
using ScrumPokerCards.Models;
using ScrumPokerCards.Services;
using System;
using System.Collections.Generic;

namespace ScrumPokerCards.PageModels
{
    public class CardsListPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        // Services
        private readonly ICardsService _cardsService;

        private IList<Card> _cards;

        /* Constructors */

        public CardsListPageModel()
        {
            _cardsService = FreshIOC.Container.Resolve<ICardsService>();
            
            _cards = _cardsService.get();
        }

        /* Properties */

        public IList<Card> Cards
        {
            get { return _cards; }
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

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            RaisePropertyChanged(nameof(SelectedCard));
        }
    }
}
