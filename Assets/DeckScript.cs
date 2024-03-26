using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    private List<Card> deck = new List<Card>();

    void Start()
    {
        CreateDeck();
        ShuffleDeck();
        // You can now deal cards, etc.
    }

    void CreateDeck()
    {
        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Value value in System.Enum.GetValues(typeof(Card.Value)))
            {
                deck.Add(new Card(suit, value));
            }
        }
    }

    void ShuffleDeck()
    {
        // Implement a shuffling algorithm here
        // A simple one is the Fisher-Yates shuffle
    }

    // Removes card at a random index from the deck and returns it
    Card DrawCard(Card card)
    {
        // Draw random card
        int randomIndex = Random.Range(0, deck.Count);
        Card drawnCard = deck[randomIndex];
        deck.RemoveAt(randomIndex);
        return drawnCard;
    }

    // Other deck management methods...
}
