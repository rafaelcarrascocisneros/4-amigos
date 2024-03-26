using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public DeckScript deck;
    public GamePile gamePile = new GamePile();
    public DiscardPile discardPile = new DiscardPile();
    public int currentPlayerIndex = 0;

    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        // Initialize the deck
        deck = GetComponent<DeckScript>(); // Assuming DeckScript is attached to the same GameObject
        deck.CreateDeck();
        // deck.ShuffleDeck(); // Might not need this if we random draw instead

        // Deal cards to players
        DealCards();
        
        // Players set their face-up cards
        PlayersSetFaceUpCards();

        // Set starting player
        SetStartingPlayer();

        // Start the first turn
        PlayTurn();
    }

    void PlayTurn()
    {
        // Example: Get current player and have them play a card
        Player currentPlayer = players[currentPlayerIndex];
        // Here, you would implement logic for the player to select a card to play.
        // This is simplified; in a real game, you would handle player input to select the card.

        // After the player plays a card, manage the turn transition and game state
        // This is also simplified for demonstration purposes
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        // Check for game end conditions here

        // Continue to next turn
        PlayTurn(); // This recursive call is for demonstration. You would typically use event-driven logic in a real game.
    }

    void DealCards()
    {
              // Distribute cards to players
        foreach (Player player in players)
        {
            // Set 4 face down cards for each player
            for (int i = 0; i < 4; i++)
            {
                Card card = deck.DrawCard();
                player.AddCardToFaceDown(card);
            }
            // Example: Give each player 7 cards to start with
            for (int i = 0; i < 7; i++)
            {
                Card card = deck.DrawCard();
                player.AddCardToHand(card);
            }
        }
    }

    void PlayersSetFaceUpCards()
    {
        // Players set their starting cards face up
        // This can be automatic for now but could be a game state before starting the game to allow players to strategize
        foreach (Player player in players)
        {
            for (int i = 0; i < 4; i++)
            {
                // Player selects best cards from hand starting with 2s, 10s, and Aces
                // then continue on from their highest value cards(K, Q, J, 9, 8, 7, 6, 5, 4, 3) in order.
                
                // Check if player has a card with value 2 and set it face up if true
                if (player.hand.Contains(player.hand.Find(card => card.value == Card.Value.Two)))
                {
                    player.AddCardToFaceUp(player.hand.Find(card => card.value == Card.Value.Two));
                    player.RemoveCardFromHand(player.hand.Find(card => card.value == Card.Value.Two));
                }
                // Else check if player has a card with value 10 and set it face up if true
                else if (player.hand.Contains(player.hand.Find(card => card.value == Card.Value.Ten)))
                {
                    player.AddCardToFaceUp(player.hand.Find(card => card.value == Card.Value.Ten));
                    player.RemoveCardFromHand(player.hand.Find(card => card.value == Card.Value.Ten));
                }
                // Else check if player has a card with value Ace and set it face up if true
                else if (player.hand.Contains(player.hand.Find(card => card.value == Card.Value.Ace)))
                {
                    player.AddCardToFaceUp(player.hand.Find(card => card.value == Card.Value.Ace));
                    player.RemoveCardFromHand(player.hand.Find(card => card.value == Card.Value.Ace));
                }
                // Else play card with highest value
                else
                {
                    // Sort player's hand by card value in descending order
                    player.hand.Sort((x, y) => y.value.CompareTo(x.value));
                    player.AddCardToFaceUp(player.hand[0]);
                    player.RemoveCardFromHand(player.hand[0]);
                }
            }
        }
    }

    void SetStartingPlayer()
    {
        // Player with lowest value card (starting with 3s) in their hand starts first
        // If both players have the same value card then the player with the lowest suit value starts first

        // Hands are already sorted by card value in descending order so we can check each player's lowest value card by checking the highest index in the player's hand
        if (players[0].hand[players[0].hand.Count - 1].value > players[1].hand[players[1].hand.Count - 1].value)
        {
          currentPlayerIndex = 1;
        }
        else
        {
          if (players[0].hand[players[0].hand.Count - 1].suit > players[1].hand[players[1].hand.Count - 1].suit)
          {
            currentPlayerIndex = 0;
          }
          else
          {
            currentPlayerIndex = 1;
          }
        }
    }

    // Additional methods to handle game logic, such as responding to special cards, handling the discard pile, etc.

    // Method to add players to the game, if needed
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
}
