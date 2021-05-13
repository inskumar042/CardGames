using System.Collections.Generic;

namespace CardGame
{
    class Players
    {
        public string Name { get; set; }
        public List<Card> PlayersDeck { get; set; }
        public Stack<Card> DiscardPile { get; set; }
      

    }
}
