namespace Special_Offer_Hunter.Models
{

    public class MoveProductToCart
    {
        public int ProductId { get; set; }
        public ShoppingCartType Type { get; set; }
        public ShoppingCartType MoveType { get; set; }
    }
}
