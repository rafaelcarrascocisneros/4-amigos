using System.Collections.Generic;
using UnityEngine;

public class DiscardPile
{
    private List<Card> discardedCards = new List<Card>();

    // Adds cards to the discard pile
    public void AddCards(List<Card> cards)
    {
        discardedCards.AddRange(cards);
    }

    // Clears the discard pile, possibly at the end of a round or game
    public void ClearPile()
    {
        discardedCards.Clear();
    }

    // Additional functionality as needed for your game's logic
}
