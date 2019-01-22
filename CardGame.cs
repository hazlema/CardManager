namespace CardManager {
    public class CardGame {
        public Players players = new Players();
        public Deck deck = new Deck();

        public CardGame() {
            players.LinkDeck = deck;
            deck.LinkPlayers = players;
        }
    }
}
