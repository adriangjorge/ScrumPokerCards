using FreshMvvm;
using ScrumPokerCards.Models;

namespace ScrumPokerCards.PageModels
{
    public class CardViewPageModel : FreshBasePageModel
    {
        /* Private Attributes */
        
        private Card _card;

        /* Properties */

        public Card Card
        {
            get { return _card; }
        }

        /* Override Methods */

        public override void Init(object initData)
        {
            base.Init(initData);
            _card = initData as Card;
        }
    }
}
