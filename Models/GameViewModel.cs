using blackjack.Models;
namespace blackjack.Models
{

public class GameViewModel
{
    public List<Card> dealerhand = new List<Card>();
    public List<Card> playerhand = new List<Card>();
    public int dealerval = 0;
    public int playerval = 0;

    public GameViewModel(List<Card> dealer, List<Card>player, int d, int p) { 
        this.dealerhand = dealer;
        this.playerhand = player;
        this.dealerval = d; 
        this.playerval = p; 
    }
}
}
