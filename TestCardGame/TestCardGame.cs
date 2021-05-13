using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CardGame;
using System.Linq;

namespace TestCardGame
{
    [TestClass]
    public class TestCardGame
    {
        public sealed class TestPlayer { }
        public sealed class PlayerCollection : List<TestPlayer> { }
        public sealed class TestGamePlayer
        {
           public PlayerCollection Players { get; } = new PlayerCollection();
            public void Start()
            {
                if (Players.Count < 2)
                    throw new InvalidOperationException("...");
            }
        }
        [TestMethod]
        public void TestPlayerCreation()
        {
            var cardgame = new TestGamePlayer();
            cardgame.Players.Add(new TestPlayer());
           cardgame.Players.Add(new TestPlayer());
            
            cardgame.Start();
        }
        [TestMethod]
        public void TestDeckSize()
        {
            CardDeck playercarddeck = new CardDeck();
            //Total deck size
            Assert.AreEqual(40, playercarddeck.Cards.Count);
        }

        [TestMethod]
        public void TestShuffle()
        {
            CardDeck playercarddeck = new CardDeck();
           List<Card> Cards = new List<Card>();
           
            Cards.Add(new Card()
            {
                symbol = CardSuits.Clubs,
                Number = 1
            });
            Cards.Add(new Card()
            {
                symbol = CardSuits.Clubs,
                Number = 2
            });
            Cards.Add(new Card()
            {
                symbol = CardSuits.Hearts,
                Number = 1
            });
            Cards.Add(new Card()
            {
                symbol = CardSuits.Spades,
                Number = 6
            });
            Cards.Add(new Card()
            {
                symbol = CardSuits.Diamonds,
                Number = 10
            });
            Cards.Add(new Card()
            {
                symbol = CardSuits.Hearts,
                Number = 7
            });

            List<Card> temp = new List<Card>(Cards);
            
          
            playercarddeck.Shuffle(Cards);

            CollectionAssert.AreNotEqual(temp, Cards);
        }
        [TestMethod]
        public void TestEachDeckSize()
        {
            CardDeck playercarddeck = new CardDeck();
           
            //Each player beginning deck
            Assert.AreEqual(20, playercarddeck.PlayerDecksize(40, 2));

        }
        [TestMethod]
        public void TestAddplayerDeckwithDicard()
        {
            CardDeck carddeck = new CardDeck();
            List<Players> players = new List<Players>();

            players.Add(new Players()
            {
                Name = "Player",
                PlayersDeck = carddeck.Draw(10), // using 10 cards for test
                DiscardPile = new Stack<Card>()
            });
            // Move all cards from PlayersDeck to discardpile for testing
            carddeck.Cards = players[0].PlayersDeck;
            //Draw a card from the players deck
           List<Card> cards = new List<Card>();
            cards = carddeck.Draw(10);
            foreach (Card card in cards)
                players[0].DiscardPile.Push(card);
            
            players[0].PlayersDeckupdatefromDiscard();
            Assert.AreNotEqual(0, players[0].PlayersDeck);
        }


    }
}
