public class GamePile
{
    private List<Card> pile = new List<Card>();

    // Adds a card to the pile
    public void AddCard(Card card)
    {
        pile.Add(card);
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

    // You might want more methods here, depending on game rules.
}
