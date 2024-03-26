using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Value { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public Suit suit;
    public Value value;

    public Card(Suit suit, Value value)
    {
        this.suit = suit;
        this.value = value;
    } 
}
