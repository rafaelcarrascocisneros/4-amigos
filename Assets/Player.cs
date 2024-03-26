using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> hand = new List<Card>();
    public List<Card> faceUpCards = new List<Card>();
    public List<Card> faceDownCards = new List<Card>();

    // Adds a card to the player's hand
    public void AddCardToHand(Card card)
    {
        hand.Add(card);
    }

    // Removes a card from the player's hand
    public bool RemoveCardFromHand(Card card)
    {
        return hand.Remove(card);
    }

    // Plays a card from the hand
    public Card PlayCardFromHand(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < hand.Count)
        {
            Card cardToPlay = hand[cardIndex];
            hand.RemoveAt(cardIndex);
            return cardToPlay;
        }
        return null; // Return null if the index is invalid
    }

    // Adds a card to the player's face-up cards on the table
    public void AddCardToFaceUp(Card card)
    {
        faceUpCards.Add(card);
    }

    // Setup the initial face-down cards
    public void AddCardToFaceDown(Card card)
    {
        faceDownCards.Add(card);
    }

    // Other functionalities like displaying cards, selecting cards to play, etc., can be added here
}
