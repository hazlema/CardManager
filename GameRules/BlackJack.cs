namespace CardManager.GameRules {
    public static class BlackJack {
        // Very UGLY function
        static public int CardSum(Player p) {
            int total = 0, aces = 0;

            for (int i = 0; i < p.CardsCount; i++) {
                Card card = p.Card(i);
                
                switch (card.value) {
                    case 11: 
                    case 12:
                    case 13:
                        total += 10;
                        break;
                    case 14:
                        aces += 1;
                        break;
                    default:
                        total += card.value;
                        break;
                }
            }
            
            // If there are no aces skip this step
            if (aces > 0) {
                // If the total of the cards is already over 11
                // Add the aces to the hand as a value of 1
                if (total > 11) { 
                    total += aces;
                } else { 
                    // Add all the aces but 1 as a value of 1 (can't have two aces at 11)
                    total += aces - 1;
                    
                    // If the total is under 11 add the final ace as 11
                    if (total < 11) { 
                        total += 11;
                    } else {
                        // Add the final ace as value of 1
                        total += 1;
                    }
                }
            }

            return total;
        }

        // If Dealers hand is below 17 keep drawing
        static public void DealerDraw(Player p, Deck deck) {
            int total = CardSum(p);

            while (total < 17) {
                p.AddCard( deck.DealOne() );
                total = CardSum(p);
            }
        }
    }
}
