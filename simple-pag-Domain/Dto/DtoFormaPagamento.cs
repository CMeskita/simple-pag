using simple_pag_Domain.Entity;
namespace simple_pag_Domain.Dto
{
    public class DtoFormaPagamento
    {
        public string Nome { get; set; }
        public int CodFinalizadora {  get; set; }
        public string Sigla {  get; set; }

        public static implicit operator FormaPagamento(DtoFormaPagamento formpag)
            => new FormaPagamento(formpag.Nome, formpag.CodFinalizadora, formpag.Sigla);
    }
}
