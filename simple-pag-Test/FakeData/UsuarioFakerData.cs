using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using Microsoft.Win32;
using simple_pag_Domain.Entity;

namespace simple_pag_Test.FakeData
{
    public class UsuarioFakerData
    {
        //public string Nome { get; protected set; }
        //public string Email { get; protected set; }
        //public string ChavePrivada { get; protected set; }
        //public DateTime Registro { get; protected set; }
        //public bool Status { get; protected set; }
        public static IEnumerable<object[]> Scenarios
        {
            get
            {
                var faker = new Faker("pt_BR");

                yield return new object[]
                {
                    "Nome não informado", string.Empty, faker.Internet.Email(), faker.Internet.Password(),DateTime.UtcNow,true, false
                };
                yield return new object[]
                {
                    "Email não informado", faker.Name.FullName(), string.Empty, faker.Internet.Password(),DateTime.UtcNow,true, false
                };
                yield return new object[]
                {
                     "Senha não informado",faker.Name.FullName(), faker.Internet.Email(), string.Empty,DateTime.UtcNow,true, false
                };
                yield return new object[]
                {
                      "Senha não informado",faker.Name.FullName(), faker.Internet.Email(), string.Empty,DateTime.UtcNow,true, false
                };
                yield return new object[]
                {
                     "Usuário não Ativo", faker.Name.FullName(), faker.Internet.Email(), faker.Internet.Password(),DateTime.UtcNow,false, false
                };
                for (int i = 0; i < 3; i++)
                {
                    yield return new object[]
                   {
                        $"Account válido randomizado #{i + 1}", faker.Name.FullName(),faker.Internet.Email(), faker.Internet.Password(),DateTime.UtcNow,true,true
                   };
                }
            }
        }

        public static Faker<Usuario> CriarUsuarioValido()
        {
            return new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f =>
                {

                    var usuario = new Usuario(
                      
                        f.Name.FullName(),
                        f.Internet.Email(), 
                        f.Internet.Password()

                    );
                    return usuario;
                });
        }
        public static Usuario UsuarioCustumizado(string nome, string email, string chavePrivada)
        {
            return new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f =>
                {
                    var usuario = new Usuario(nome, email,chavePrivada);
                    return usuario;
                });
        }
        public static Faker<Usuario> UpdateUsuario(string id)
        {
            return new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f =>
                {
                    var usuario = new Usuario(
                        id,
                        f.Name.FullName(),
                        f.Internet.Email(),
                        f.Internet.Password(),
                        DateTime.UtcNow,
                        true
             
                    );
                    return usuario;
                });
        }
        public static Faker<Usuario> UpdateUsuarioCustumozado(string id, string nome, string email, string chavePrivada, DateTime date, bool status)
        {
            return new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f =>
                {
                    var acquirer = new Usuario(id, nome, email, chavePrivada,date, status);
                    return acquirer;
                });
        }
    }
}
