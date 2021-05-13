using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class CardDeck
    {
        public List<Card> Cards { get; set; }
        public CardDeck()
        {
            Cards = new List<Card>();

            foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits)))
            {
                for (int i = 1; i < 11; i++)
                {
                    Cards.Add(new Card()
                    {
                        symbol = suit,
                        Number = i
                    });
                }

            }

        }
        public int PlayerDecksize(int cardscount, int playercount)
        { return (cardscount / playercount); }
        public void Shuffle(List<Card> Cards)
        {
            Random r = new Random();
            //List<Card> cards = Cards;
            for (int n = Cards.Count - 1; n > 0; --n)
            {

                int k = r.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }

        }
        public List<Card> Draw(int count)
        {
            var drawnCards = Cards.Take(count).ToList();
            //Remove the drawn Cards
            Cards.RemoveAll(x => drawnCards.Contains(x));
            return drawnCards;
        }
    }

}
