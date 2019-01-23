using System;

namespace CardManager.Tests {
    public static class CardTests {
        public static void test() {
            Card c = new Card(14, enumSuit.Clubs);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.FaceValue);
        }
    }
}