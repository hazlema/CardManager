// Deck Object
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardManager {
    public class Deck {
        public delegate void DeckChange(enumOnDeckChange reason, Deck sender);  // Event Decelerations
        public event DeckChange onDeckChange;

        internal Players LinkPlayers { get; set; }                              // Link to Players Object

        private List<Card> _cards = new List<Card>();                           // Cards in this deck

        // Constructor
        public Deck(enumShuffled? Shuffle = enumShuffled.Shuffle) {
            _cards = GenerateDeck();

            switch (Shuffle) {
                case enumShuffled.Shuffle:      ShuffleDeck();      break;
                case enumShuffled.SortBySuit:   SortDeckBySuit();   break;
                case enumShuffled.SortByValue:  SortDeckByValue();  break;
            }
        }

        // Create a deck
        private List<Card> GenerateDeck() {
            List<Card> newDeck = new List<Card>();
            for (int v = 2; v <= 14; v++) {
                for (int s = 0; s <= 3; s++) {
                    enumSuit suit = (enumSuit)s;
                    Card c = new Card(suit, v);
                    newDeck.Add(c);
                }
            }
            return newDeck;
        }

        // Sorting stuff
        public void ShuffleDeck() {
            Random r = new Random();
            _cards = _cards.OrderBy(s => r.Next(0, 1000000)).ToList();
        }

        public void SortDeckBySuit() {
            _cards = _cards.OrderBy(s => s.value).OrderBy(s => s.suit).ToList();
        }

        public void SortDeckByValue() {
            _cards = _cards.OrderBy(s => s.suit).OrderBy(s => s.value).ToList();
        }

        public List<Card> All {
            get { return _cards.ToList(); }
        }
        
        // How many cards?
        public int Count {
            get { return _cards.Count; }
        }

        // Deal One Card
        public Card DealOne() {
            if (this.Count == 0) {
                onDeckChange?.Invoke(enumOnDeckChange.OutOfCards, this);        // Trigger event
                RecycleDiscarded();
            }

            Card c = _cards.First();
            _cards.Remove(c);
            return c;
        }

        // Deal XX cards to all players
        public void DealPlayers(int cards, enumStartHand? resetCards = enumStartHand.DoNothing) {
            if (resetCards == enumStartHand.ClearAllPlayersCardsFirst)
                LinkPlayers.ClearPlayersHands();

            for (int i = 0; i < cards; i++)
                LinkPlayers.All.ForEach(s => s.AddCard(this.DealOne()));
        }

        // Reshuffle discards into the deck
        public void RecycleDiscarded() {
            onDeckChange?.Invoke(enumOnDeckChange.BeforeRecyclingDeck, this);   // Trigger event
            _cards = GenerateDeck();                                            // Generate a new deck.
            List<Card> playersHave = LinkPlayers.AllPlayerCards();              // Get all the players cards. 

            // Remove them from the newly created deck.
            playersHave.ForEach(s => {
                _cards.Remove( 
                    _cards.Where(c => c.ToString() == s.ToString()).First() 
                );
            });

            ShuffleDeck();
            onDeckChange?.Invoke(enumOnDeckChange.AfterRecyclingDeck, this);    // Trigger event
        }
    }
}
