using System.Text.Json.Serialization.Metadata;

namespace blackjackgame.Models
{
    public class Game
    {

        public List<Card> deck = new List<Card>();
        public List<Card> player = new List<Card>();
        public List<Card> dealer = new List<Card>();
        public Game() {
            deck = new
           List<Card>{
            new Card(CardNames.MA, "MA.png", 11),
            new Card(CardNames.MK, "MK.png", 10),
            new Card(CardNames.MQ, "MQ.png", 10),
            new Card(CardNames.MJ, "MJ.png", 10),
            new Card(CardNames.M10, "M10.png", 10),
            new Card(CardNames.M9, "M9.png", 9),
            new Card(CardNames.M8, "M8.png", 8),
            new Card(CardNames.M7, "M7.png", 7),
            new Card(CardNames.M6, "M6.png", 6),
            new Card(CardNames.M5, "M5.png", 5),
            new Card(CardNames.M4, "M4.png", 4),
            new Card(CardNames.M3, "M3.png", 3),
            new Card(CardNames.M2, "M2.png", 2),

            new Card(CardNames.FA, "FA.png", 11),
            new Card(CardNames.FK, "FK.png", 10),
            new Card(CardNames.FQ, "FQ.png", 10),
            new Card(CardNames.FJ, "FJ.png", 10),
            new Card(CardNames.F10, "F10.png", 10),
            new Card(CardNames.F9, "F9.png", 9),
            new Card(CardNames.F8, "F8.png", 8),
            new Card(CardNames.F7, "F7.png", 7),
            new Card(CardNames.F6, "F6.png", 6),
            new Card(CardNames.F5, "F5.png", 5),
            new Card(CardNames.F4, "F4.png", 4),
            new Card(CardNames.F3, "F3.png", 3),
            new Card(CardNames.F2, "F2.png", 2),

            new Card(CardNames.CA, "CA.png", 11),
            new Card(CardNames.CK, "CK.png", 10),
            new Card(CardNames.CQ, "CQ.png", 10),
            new Card(CardNames.CJ, "CJ.png", 10),
            new Card(CardNames.C10, "C10.png", 10),
            new Card(CardNames.C9, "C9.png", 9),
            new Card(CardNames.C8, "C8.png", 8),
            new Card(CardNames.C7, "C7.png", 7),
            new Card(CardNames.C6, "C6.png", 6),
            new Card(CardNames.C5, "C5.png", 5),
            new Card(CardNames.C4, "C4.png", 4),
            new Card(CardNames.C3, "C3.png", 3),
            new Card(CardNames.C2, "C2.png", 2),

            new Card(CardNames.LA, "LA.png", 11),
            new Card(CardNames.LK, "LK.png", 10),
            new Card(CardNames.LQ, "LQ.png", 10),
            new Card(CardNames.LJ, "LJ.png", 10),
            new Card(CardNames.L10, "L10.png", 10),
            new Card(CardNames.L9, "L9.png", 9),
            new Card(CardNames.L8, "L8.png", 8),
            new Card(CardNames.L7, "L7.png", 7),
            new Card(CardNames.L6, "L6.png", 6),
            new Card(CardNames.L5, "L5.png", 5),
            new Card(CardNames.L4, "L4.png", 4),
            new Card(CardNames.L3, "L3.png", 3),
            new Card(CardNames.L2, "L2.png", 2),
            };
        }

        // draw a random card from the deck and then remove it from the list 
        // returns the drawn card
        public Card drawCard()
        {
            Random random = new Random();
            int index = random.Next(deck.Count);
            Card pickedCard = deck[index];
            deck.Remove(pickedCard);
            return (pickedCard);
        }

        // calculate the total value of a list of cards
        // return the total
       public int calculateTotal(List<Card> hand)
        {
            int score = 0;
            List<Card> sorted = hand.OrderBy(card => card.value).ToList<Card>();
            foreach(Card current in sorted)
            {
                if (current.value == 11)
                {
                    if (21 - score >= 11)
                    {
                        score += 11;
                    }
                    else { score += 1; }
                }
                else
                {
                    score += current.value;
                }
            }
            Console.WriteLine(score);
            return score;

        }

        
        

        // play a game of blackjack
        public void play()
        {
            
            //game start
            //draw two cards for the dealer - only display one,and hide total
            dealer.Add(drawCard());
            dealer.Add(drawCard());
            //draw two cards for the player
            player.Add(drawCard());
            player.Add(drawCard());

            int playerval = calculateTotal(player);
            int dealerval = calculateTotal(dealer);

            var viewmodel = new GameViewModel(dealer, player, dealerval, playerval);

            //if either pulls 21, end game
            if (playerval == 21 || dealerval == 21) { return; }

            //if not, continue:
            //player select "hit" or "stand"
            // if hit, deal and update

            //if dealer total < 17
            if(dealerval < 17) { dealer.Add(drawCard()); };
            

        }
    }

}
