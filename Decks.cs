using System;
using System.Collections.Generic;
using System.Linq;

namespace CardManager {
    class Decks {
        private List<Deck> _decks = new List<Deck>();
        private List<Deck> _alldecks = new List<Deck>();

        public Decks() { }

        public List<Card> AllDecks => _decks.SelectMany(s => s.All).ToList();
        public List<Deck> Deck => _decks.ToList();
        
        public int Count => _decks.Count();
        
        public void AddDeck(enumShuffled DeckSort) {
            _decks.Add(new Deck(DeckSort));
        }

    }
}
