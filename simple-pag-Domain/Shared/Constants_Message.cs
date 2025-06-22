

namespace simple_pag_Domain.Shared
{
    public static class Constants_Message
    {
        public const string STATUS_CODE_SUCCESS = "Operação realizada com sucesso";                                         //200 OK - Estas requisição foi bem sucedida.O significado do sucesso varia de acordo com o método HTTP:
        public const string STATUS_CODE_CREATED = "Registro criado com sucesso";                                            //201 Created - A requisição foi bem sucedida e um novo recurso foi criado como resultado.Esta é uma tipica resposta enviada após uma requisição POST.
        public const string STATUS_CODE_BADREQUEST = "Problema ao tentar processa a requisição";                            //400 Bad Request - Essa resposta significa que o servidor não entendeu a requisição pois está com uma sintaxe inválida.
        public const string STATUS_CODE_FORBIDEN = "Permissão para operação negada";                                        //403 Forbidden - O cliente não tem direitos de acesso ao conteúdo portanto o servidor está rejeitando dar a resposta.Diferente do código 401, aqui a identidade do cliente é conhecida.
        public const string STATUS_CODE_NOTFOUND = "Recurso solicitado não encotrado";                                      //404 Not Found - O servidor não pode encontrar o recurso solicitado. Este código de resposta talvez seja o mais famoso devido à frequência com que acontece na web.
        public const string STATUS_CODE_INTERNAL_SERVER_ERROR = "Erro interno, entre em contato com o suporte";             //500 Internal Server Error - O servidor encontrou uma situação com a qual não sabe lidar.
        public const string STATUS_CODE_NOTIMPLEMENTED = "Não implementada";
    }
    public static class Constants_Code
    {
        public const int STATUS_CODE_SUCCESS = 200;                 //200 OK - Estas requisição foi bem sucedida.O significado do sucesso varia de acordo com o método HTTP:
        public const int STATUS_CODE_CREATED = 201;                 //201 Created - A requisição foi bem sucedida e um novo recurso foi criado como resultado.Esta é uma tipica resposta enviada após uma requisição POST.
        public const int STATUS_CODE_BADREQUEST = 400;              //400 Bad Request - Essa resposta significa que o servidor não entendeu a requisição pois está com uma sintaxe inválida.
        public const int STATUS_CODE_FORBIDEN = 403;                //403 Forbidden - O cliente não tem direitos de acesso ao conteúdo portanto o servidor está rejeitando dar a resposta.Diferente do código 401, aqui a identidade do cliente é conhecida.
        public const int STATUS_CODE_NOTFOUND = 404;                //404 Not Found - O servidor não pode encontrar o recurso solicitado. Este código de resposta talvez seja o mais famoso devido à frequência com que acontece na web.
        public const int STATUS_CODE_INTERNAL_SERVER_ERROR = 500;   //500 Internal Server Error - O servidor encontrou uma situação com a qual não sabe lidar.
        public const int STATUS_CODE_NOTIMPLEMENTED = 501;          //501 Not Implemented - O método da requisição não é suportado pelo servidor e não pode ser manipulado.Os únicos métodos exigidos que servidores suportem (e portanto não devem retornar este código) são GET e HEAD.
    }
}
