// Card Object
//
namespace CardManager {
    public class Card {
        public int value { get; set; }
        public enumSuit suit { get; set; }

        // Constructor
        public Card(enumSuit suit, int value) {
            this.value = value;
            this.suit = suit;
        }

        // Returns the human readable value of the card
        public string FaceValue { 
            get {
                string valueStr = value.ToString();

                switch (value) {
                    case 11: valueStr = "Jack"; break;
                    case 12: valueStr = "Queen"; break;
                    case 13: valueStr = "King"; break;
                    case 14: valueStr = "Ace"; break;
                }

                return valueStr;
            }
        }

        // Display the card as text
        public override string ToString() {
            return string.Format("{0} of {1}", FaceValue, suit.ToString());
        }
    }
}
