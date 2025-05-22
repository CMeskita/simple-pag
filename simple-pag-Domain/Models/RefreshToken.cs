
namespace simple_pag_Domain.Models
{
    public class RefreshToken
    {       
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
