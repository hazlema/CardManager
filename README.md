# CardManager

```c#
    CardGame game = new CardGame();

    // Add Players
    Player Player1  = game.players.Add("Player 1");
    Player Computer = game.players.Add("Computer", true, true);
        
    // Shuffle deck
    game.deck.ShuffleDeck();

    // Listen for events
    game.deck.onDeckChange += Deck_onDeckChange;

    // Deal 2 cards to each player
    game.deck.DealPlayers(2, enumStartHand.ClearAllPlayersCardsFirst);

```

# CardManager.GameRules
```
(static) Blackjack.CardSum(Player)
(static) Blackjack.DealerDraw(Player, Deck)
```

## Todo:
- Splitting
- Multiple decks
- More game rules classes

## Sprite Indexes:
If you are using this module in a game, each < Card > has a property called index.  You can map this property to a corresponding element on your sprite sheet.
```
Index = 0, 2 of Clubs
Index = 1, 2 of Diamonds
Index = 2, 2 of Hearts
Index = 3, 2 of Spades
Index = 4, 3 of Clubs
Index = 5, 3 of Diamonds
Index = 6, 3 of Hearts
Index = 7, 3 of Spades
Index = 8, 4 of Clubs
Index = 9, 4 of Diamonds
Index = 10, 4 of Hearts
Index = 11, 4 of Spades
Index = 12, 5 of Clubs
Index = 13, 5 of Diamonds
Index = 14, 5 of Hearts
Index = 15, 5 of Spades
Index = 16, 6 of Clubs
Index = 17, 6 of Diamonds
Index = 18, 6 of Hearts
Index = 19, 6 of Spades
Index = 20, 7 of Clubs
Index = 21, 7 of Diamonds
Index = 22, 7 of Hearts
Index = 23, 7 of Spades
Index = 24, 8 of Clubs
Index = 25, 8 of Diamonds
Index = 26, 8 of Hearts
Index = 27, 8 of Spades
Index = 28, 9 of Clubs
Index = 29, 9 of Diamonds
Index = 30, 9 of Hearts
Index = 31, 9 of Spades
Index = 32, 10 of Clubs
Index = 33, 10 of Diamonds
Index = 34, 10 of Hearts
Index = 35, 10 of Spades
Index = 36, Jack of Clubs
Index = 37, Jack of Diamonds
Index = 38, Jack of Hearts
Index = 39, Jack of Spades
Index = 40, Queen of Clubs
Index = 41, Queen of Diamonds
Index = 42, Queen of Hearts
Index = 43, Queen of Spades
Index = 44, King of Clubs
Index = 45, King of Diamonds
Index = 46, King of Hearts
Index = 47, King of Spades
Index = 48, Ace of Clubs
Index = 49, Ace of Diamonds
Index = 50, Ace of Hearts
Index = 51, Ace of Spades
```
