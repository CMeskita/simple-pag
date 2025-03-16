namespace simple_pag_Application.Repsonse
{
    public class UsuarioResponse
    {
        public List<UsuarioResponseItem> Dados { get; set; }
    }
    public class UsuarioResponseItem
    {
        public string Id { get;  set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime Registro { get;  set; }
        public bool Status { get;  set; }
    }
}
