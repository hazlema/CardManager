﻿using System;
using System.Collections.Generic;

namespace CardManager.Tests {
    public static class PlayersTests {
        public static void test() {
            Players Players = new Players();
            Players.Add("Player 1");

            Player dealer = Players.Add("Dealer");
            dealer.isDealer = true;

            Console.WriteLine(Players.ToString());
            Console.WriteLine(Players.Dealer().Name);

            Player player1 = Players.FindByName("Player 1");
            player1.isDealer = true;

            Console.WriteLine(Players.Dealer().Name);

            // Should return null
            Players.FindByName("Player 1").isDealer = false;
            Console.WriteLine(Players.Dealer());

            dealer.AddCard(new Card(4, enumSuit.Clubs));
            dealer.AddCard(new Card(3, enumSuit.Clubs));
            dealer.AddCard(new Card(2, enumSuit.Clubs));
            dealer.AddCard(new Card(1, enumSuit.Clubs));

            List<Card> all = Players.AllPlayerCards();
            all.ForEach(s => Console.WriteLine(s.ToString()));

            Console.WriteLine(Players.ToString());

            Players.RemoveByName("Player 1");
            Console.WriteLine(Players.ToString());

            Players.Remove(dealer);
            Console.WriteLine(Players.ToString());
        }
    }
}
