namespace simple_pag_Application.Repsonse
{
   
    public class UsuarioResponse
    {
        public string Id { get;  set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime Registro { get;  set; }
        public bool Status { get;  set; }
    }
    public class UsuarioContatosResponse
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public DateTime Registro { get; set; }
        public bool Status { get; set; }
    }
}
