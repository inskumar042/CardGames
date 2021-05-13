namespace CardGame
{
    public enum CardSuits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public class Card
    {
        public CardSuits symbol { get; set; }
        public int Number { get; set; }
    }
}
