using System;
using System.IO;

namespace CardManager.Tests {
    public static class DeckTests {
        public static void test() {
            Deck deck1 = new Deck(enumShuffled.Shuffle);
            Deck deck2 = new Deck(enumShuffled.SortBySuit);
            Deck deck3 = new Deck(enumShuffled.SortByValue);

            Console.WriteLine("Shuffled");
            for (int i = 0; i < 14; i++) {
                Console.WriteLine(deck1.DealOne().ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Sorted by Suit");
            for (int i = 0; i < 14; i++) {
                Console.WriteLine(deck2.DealOne().ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Sorted by Value");
            for (int i = 0; i < 14; i++) {
                Console.WriteLine(deck3.DealOne().ToString());
            }
        }

        public static void RecycleTest() {
            CardGame cm = new CardGame();
            Player player = cm.players.Add("player");
            cm.deck.SortDeckByValue();

            Console.WriteLine("Your Hand");

            for (int i = 0; i < 10; i++) {
                Card c = cm.deck.DealOne();
                player.AddCard(c);
                Console.WriteLine(c.ToString());
            }

            // Simulate Played cards
            for (int i = 0; i < 10; i++) {
                Card c = cm.deck.DealOne();
            }

            Console.WriteLine();

            // Recycle deck
            cm.deck.RecycleDiscarded();

            // Sort it
            cm.deck.SortDeckByValue();

            Console.WriteLine("Recycled cards (should not have any that are in your hand)");

            for (int i = 0; i < 10; i++) {
                Card c = cm.deck.DealOne();
                Console.WriteLine(c.ToString());
            }
        }

        public static void ShowIndexes() {
            Deck newDeck = new Deck(enumShuffled.SortByIndex);
            newDeck.All.ForEach(s => Console.WriteLine($"Index = {s.index}, {s.ToString()}") );
        }
    }
}
