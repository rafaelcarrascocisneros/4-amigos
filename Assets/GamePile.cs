using System.Collections.Generic;
using UnityEngine;

public class GamePile
{
    private List<Card> pile = new List<Card>();

    // Expose the pile field as a public property
    public List<Card> Cards => pile;

    // Adds a card to the pile
    public void AddCard(Card card)
    {
        pile.Add(card);
        CuatroAmigos();
    }

    // Clears the pile, usually after a "10" is played or when the pile is picked up by a player
    public void ClearPile()
    {
        pile.Clear();
    }

    // Gets the top card of the pile (for comparison purposes)
    public Card GetTopCard()
    {
        if (pile.Count > 0)
        {
            return pile[pile.Count - 1];
        }
        return null;
    }

    // Checks top 4 cards of the pile for repeated values, and if all 4 cards of the same value are together it clears the pile
    public void CuatroAmigos()
    {
        if (pile.Count >= 4)
        {
            Card topCard = pile[pile.Count - 1];
            if (topCard.value == pile[pile.Count - 2].value &&
                topCard.value == pile[pile.Count - 3].value &&
                topCard.value == pile[pile.Count - 4].value)
            {
                ClearPile();
            }
        }
    }

    // You might want more methods here, depending on game rules.
}
