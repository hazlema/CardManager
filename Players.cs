using System.Collections.Generic;
using System.Linq;

namespace CardManager {
    public class Players {
        internal Deck LinkDeck { get; set; }                              // Link to Deck

        private List<Player> _Players = new List<Player>();             // List of players

        public List<Player> All => _Players.ToList();                   // Return the list of players

        public int Count => _Players.Count();

        // Create a player & return it
        public Player Add(string PlayerName, bool? isDealer=false, bool? isAI=false) {
            Player newPlayer = new Player(this, PlayerName);
            newPlayer.isDealer = (bool)isDealer;
            newPlayer.isAI = (bool)isAI;

            _Players.Add(newPlayer);

            return newPlayer;
        }

        // Find a player
        public Player FindByName(string PlayerName) {
            return _Players.Where(s => s.Name == PlayerName).First();
        }

        // Return the list of players but remove the dealers
        public List<Player> AllNoDealer() {
            return _Players.Where(s => s.isDealer == false).ToList();
        }

        // Return the dealer
        public Player Dealer() {
            int count = _Players.Where(s => s.isDealer == true).Count();

            if (count == 1) {
                return _Players.Where(s => s.isDealer == true).First();
            } else return null;
        }

        // Clear the dealer flag from all players
        internal void clearDealers() {
            var Dealers = _Players.Where(s => s.isDealer == true).ToList();
            Dealers.ForEach(s => s.isDealer = false);
        }
        
        // Remove Player
        public void RemoveByName(string PlayerName) {
            var remove = _Players.Where(s => s.Name == PlayerName).ToList();
            remove.ForEach(s => _Players.Remove(s));
        }

        public void Remove(Player PlayerData) {
            _Players.Remove(PlayerData);
        }

        // Clear the cards in all player hands
        public void ClearPlayersHands() {
            _Players.ForEach(s => s.RemoveAllCards());
        }

        // Return a string representation of all players
        public override string ToString() {
            return string.Join(", ", _Players.Select(s => s.Name).ToArray());
        }

        // Generate new decks and use this to remove the active cards
        public List<Card> AllPlayerCards() {
            return _Players.SelectMany(s => s.Cards).ToList();
        }
    }
}
