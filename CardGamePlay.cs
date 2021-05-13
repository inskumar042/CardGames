using System;
using System.Collections.Generic;
using System.Linq;

 namespace CardGame
{
  public  class CardGamePlay
    {
        private const string strNothing = "";

        
        static void Main(string[] args)
        {
            //CardDeck with 40 cards
            CardDeck carddeck = new CardDeck();

            List<Card> cards;

            List<Players> player;

            /// Number of Players to play the game 
            Console.WriteLine("Please Enter Number of Players to play the Game(Must be 2 or More):");
            int playercount = Convert.ToInt32(Console.ReadLine());
            if(playercount < 2)
            {
                Console.WriteLine("Please enter a Number of  2 or more for players to play the Game. Please :");
                 playercount = Convert.ToInt32(Console.ReadLine());
            }
            int cardscount = carddeck.Cards.Count;
            ///Get the number to divide the cards equally among the players 
            int playercarddeck = carddeck.PlayerDecksize(cardscount,playercount);
            

            ///Shuffle the cards
            ///The Shuffle method uses Fisher-Yates Shuffle Algorithm
            carddeck.Shuffle(carddeck.Cards);
            player = new List<Players>();

            int max_cardvalue = 0;
            string winner = strNothing;
            Stack<Card> DiscardedCards = new Stack<Card>();

            ///Create as many number of players as Entered to play the game 
            ///Each player with a carddeck(Number of cards for each player = ) to draw from
            /// Split up the Deck(Deck that each player would draw from) for each player to use in the beginning of the game
            for (int i = 0; i < playercount; i++)
            {
                cards = new List<Card>();
                cards = carddeck.Cards;
                int j = i + 1;
                player.Add(new Players()
                {
                    Name = "Player" + j,
                    PlayersDeck = carddeck.Draw(playercarddeck),
                    DiscardPile = new Stack<Card>()
                });

            }

            /// Start the Game!
            /// Draw a card from the player's deck for each player
            /// Get the highest value Card and the player with the highest value in the Drawncard wins the round
            /// continue the game till any player is left with no cards in the players deck
            while (!player.Any(x => !x.PlayersDeck.Any()))
            {
                foreach (Players players in player)
                {
                    cards = new List<Card>();
                    CardDeck carddecks = new CardDeck();
                    carddeck.Cards = players.PlayersDeck;
                    //Draw a card from the players deck
                    cards = carddeck.Draw(1);
                    //Check if Players card value is the highest
                    int point = cards[0].Number;
                    if (point > max_cardvalue)
                    {
                        max_cardvalue = point;

                    }
                    //Push the Drawn card into DiscardPile and in a discarded cards stack
                    players.DiscardPile.Push(cards[0]);
                    // if(players.DiscardPile == null)

                    int playerdeckcount = players.PlayersDeck.Count + players.DiscardPile.Count;
                    DiscardedCards.Push(cards[0]);

                    Console.WriteLine(players.Name + "(" + playerdeckcount + ") : " + cards[0].Number + " Of " + cards[0].symbol);
                }
                int winnercount = 0;
                ///Foreach players check who has the highest card value 
                /// if the highest card value is shared by more than 1 player(this will be a draw)
                foreach (Players players in player)
                {
                    int high_cardvalue = -1;

                    if (players.DiscardPile.Count > 0)
                    {
                        Card discardedcard = players.DiscardPile.Pop();
                        high_cardvalue = discardedcard.Number;

                    }

                    if (high_cardvalue == max_cardvalue)
                    {
                        winnercount++;
                        winner = players.Name;
                    }


                }
                if ((winnercount == 0) || (winnercount > 1)) // check if highest card is not drawn or if drawn by more than 1 player(draw)
                    winner = strNothing;

                max_cardvalue = 0;
                //Add to the player who wins the round all the cards that were drawn in the round and any left in the discardpile(in case of a draw in earlier round)
                if (winner != strNothing)
                {
                    Console.WriteLine("\n" + winner + " wins this round\n");

                    foreach (Players players in player)
                    {
                        if (players.Name == winner)
                        {
                            while (DiscardedCards.Count > 0)
                            {
                                Card temp = DiscardedCards.Pop();

                                players.DiscardPile.Push(temp);

                            }



                        }
                        if (players.PlayersDeck.Count == 0)
                        {
                            if (players.DiscardPile.Count != 0)
                            {
                                foreach (Card card in players.DiscardPile)
                                    players.PlayersDeck.Add(card);
                                players.DiscardPile.Clear();
                                carddeck.Shuffle(players.PlayersDeck);
                            }
                        }

                    }
                }
                else
                { Console.WriteLine("No Winner in this round"); }

            }
            //After the Game is Over Display the player with maximum cards in players deck as the winner of the Game
            int max = 0;
            foreach (Players players in player)
            {

                if ((players.PlayersDeck.Count + players.DiscardPile.Count) > max)
                {

                    max = (players.PlayersDeck.Count + players.DiscardPile.Count);
                    winner = players.Name;
                }
            }
            Console.WriteLine(winner + "wins the game!");
        }
    }



}





