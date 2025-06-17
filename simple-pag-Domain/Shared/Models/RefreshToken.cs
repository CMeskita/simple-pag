namespace simple_pag_Domain.Shared.Models
{
    public class RefreshToken
    {       
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
