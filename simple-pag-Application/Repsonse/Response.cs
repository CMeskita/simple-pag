using simple_pag_Domain.Shared;
using System;

namespace simple_pag_Application.Repsonse
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
    public class Response<T> : Response
    {
        public T? Data { get; set; }

        public static Response<T> Ok(T data)
        {
            return new Response<T>
            {
                StatusCode = Constants_Code.STATUS_CODE_SUCCESS,
                Message = Constants_Message.STATUS_CODE_SUCCESS,
                Data = data
            };
        }

        public static Response<T> Fail(string message, int code = 400)
        {
            return new Response<T>
            {
                StatusCode = code,
                Message = message,
                Data = default
            };
        }

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
