using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumPokerCards.Models
{
    public class CardGroup : List<Card>
    {
        public string Title { set; get; }

        public CardGroup(string title)
        {
            Title = title;
        }
    }
}
