using System;

namespace CardManager.Tests {
    public static class CardTests {
        public static void test() {
            Card c = new Card(enumSuit.Clubs, 14);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.FaceValue);
        }
    }
}