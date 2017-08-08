using FreshMvvm;
using ScrumPokerCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumPokerCards.PageModels
{
    public class CardViewPageModel : FreshBasePageModel
    {
        /* Properties */

        private Card _card;
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
