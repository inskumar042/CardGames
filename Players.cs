using System.Collections.Generic;

namespace CardGame
{
    class Players
    {
        public string Name { get; set; }
        public List<Card> PlayersDeck { get; set; }
        public Stack<Card> DiscardPile { get; set; }
        public void PlayersDeckupdatefromDiscard()
        {
            CardDeck carddeck = new CardDeck();
            if (PlayersDeck.Count == 0)
            {
                if (DiscardPile.Count != 0)
                {
                    foreach (Card card in DiscardPile)
                       PlayersDeck.Add(card);
                       DiscardPile.Clear();
                    carddeck.Shuffle(PlayersDeck);
                }
            }
        }

    }
}
