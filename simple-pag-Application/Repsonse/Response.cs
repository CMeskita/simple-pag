using System;

namespace simple_pag_Application.Repsonse
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
    public class AuthResponse 
    {
        public bool IsAuthorized { get; set; }
    }
    public class TokenResponse : Response
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
