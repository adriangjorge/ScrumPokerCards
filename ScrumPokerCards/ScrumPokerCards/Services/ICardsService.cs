using ScrumPokerCards.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScrumPokerCards.Services
{
    public interface ICardsService
    {
        List<Card> get();
    }
}
