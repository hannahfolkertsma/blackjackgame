namespace blackjackgame.Models
{
    public class Card
    {
        public CardNames name;
        public string image;
        public int value;
        public bool shown = true;

        public Card (CardNames name, string img, int value){
            this.name = name;
            this.image = img;
            this.value = value;
    }
        public void hide()
        {
            this.shown = false;
        }

        public void show()
        {
            this.shown = true;
        }
    }

    public enum CardNames
    {
        // suit - Mushroom
        MA,
        MK,
        MQ,
        MJ,
        M10,
        M9,
        M8,
        M7,
        M6,
        M5,
        M4,
        M3,
        M2,
        // suit - Frog
        FA,
        FK,
        FQ,
        FJ,
        F10,
        F9,
        F8,
        F7,
        F6,
        F5,
        F4,
        F3,
        F2,
        // suit - Cat
        CA,
        CK,
        CQ,
        CJ,
        C10,
        C9,
        C8,
        C7,
        C6,
        C5,
        C4,
        C3,
        C2,
        // suit - Leaf
        LA,
        LK,
        LQ,
        LJ,
        L10,
        L9,
        L8,
        L7,
        L6,
        L5,
        L4,
        L3,
        L2,
        BACK,
    }
}
