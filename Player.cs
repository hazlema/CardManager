// Player Object
using System;
using System.Collections.Generic;

namespace CardManager {
    public class Player {
        List<Card> hand = new List<Card>();         // Cards the player holds

        private Players parent;                     // Players Object
        private bool _isDealer = false;             // Are they the dealer

        // Constructors
        public Player(Players p, string n) {
            this.parent = p;
            this.Name = n;
        }
        
        public string Name { get; set; }            // Name of player
        public bool isAI { get; set; } = false;     // Is the player an AI
        public List<Card> Cards => hand;            // Cards held
        public int CardsCount => hand.Count;        // Card count in hand

        // If they set the dealer unset all the other players marked as dealer
        public bool isDealer { 
            get { 
                return _isDealer; 
            } 

            set {
                if (value == true) {
                    parent.clearDealers(); 
                    _isDealer = value;
                } else {
                    _isDealer=false;
                }
            }
        }

        // Add card to hand
        public void AddCard(Card c) {
            hand.Add(c);
        }

        // Remove card from hand
        public void Discard(int c) {
            hand.RemoveAt(c);
        }

        // Remove card from hand
        public void RemoveCard(Card c) {
            hand.Remove(c);
        }

        // Remove card from hand
        public void RemoveAllCards() {
            hand.RemoveAll(s => true);
        }

        // Return a card object
        public Card Card(int ndx) {
            return hand[ndx];
        }
    }
}
