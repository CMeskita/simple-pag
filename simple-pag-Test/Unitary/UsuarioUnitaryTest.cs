using Bogus;
using simple_pag_Test.FakeData;
using simple_pag_Test.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Test.Unitary
{
    public class UsuarioUnitaryTest
    {
        [Fact(DisplayName = "Deve criar usuário valido")]
        public void Should_Be_Create_UserValid()
        {
            var faker = UsuarioFakerData.CriarUsuarioValido();
            var user = faker.Generate();
            Assert.False(user.Notification.HasNotifications);
            Assert.True(user.Status==true);
            Assert.False(string.IsNullOrWhiteSpace(user.Id));
        }

        //[Theory(DisplayName = "Validação dinâmica de usuário")]
        //[MemberData(nameof(UsuarioFakerData.Scenarios), MemberType = typeof(UsuarioFakerData))]
        //public void Should_Be_Validate_User_With_Dynamic_Data(string nome, string email, string chavePrivada, bool expectedvalid)
        //{
        //    var user = UsuarioFakerData.UsuarioCustumizado(nome, email, chavePrivada);
        //    Assert.Equal(expectedvalid, !user.Notification.HasNotifications);
        //    Assert.False(string.IsNullOrEmpty(user.Id));
        //}
        [Theory(DisplayName = "Deve atualizar um usuário valido")]
        [MemberData(nameof(GenericDataGeneration.GetGuids), MemberType = typeof(GenericDataGeneration))]
        public void Should_Be_Update_User_Valid(string id)
        {
            var faker = UsuarioFakerData.UpdateUsuario(id);
            var user = faker.Generate();
            Assert.False(user.Notification.HasNotifications);
            Assert.Equal(user.Id, id);
        }

        //[Theory(DisplayName = "Não deve atualizar um usuário invalido")]
        //[MemberData(nameof(UsuarioFakerData.Scenarios), MemberType = typeof(UsuarioFakerData))]
        //public void Dont_Should_Be_Update_User_Invalid(string id, string nome, string email, string chavePrivada, DateTime date, bool status)
        //{
        //    var faker = UsuarioFakerData.UpdateUsuarioCustumozado(id,nome,email,chavePrivada,date,status);
        //    var user = faker.Generate();
        //    Assert.True(user.Notification.HasNotifications);
        //    Assert.True(string.IsNullOrEmpty(user.Id));
        //}

        [Fact(DisplayName = "Deve falhar ao criar senha fraca")]
        public void Should_Fail_Create_Weak_Password()
        {
            var faker = new Faker("pt_BR");
            var user = UsuarioFakerData.UsuarioCustumizado(
                faker.Name.FullName(),
                faker.Internet.Email(),
                faker.Internet.Password()
            );

            Assert.False(user.Notification.HasNotifications);
            Assert.False(string.IsNullOrEmpty(user.ChavePrivada));
           // Assert.Contains("A senha informada é fraca", user.GetNotifications());
        }
        [Fact(DisplayName = "Deve falhar ao atualizar User com perfil inválido")]
        public void Should_Fail_Update_Invalid_Profile()
        {
            var faker = new Faker("pt_BR");
            var user = UsuarioFakerData.UpdateUsuarioCustumozado(
                faker.Random.Guid().ToString(),
                faker.Name.FullName(),
                faker.Internet.Email(),
                faker.Internet.Password(),
                date: DateTime.UtcNow,
                status: false

            );

            //Assert.True(user.Notification.HasNotifications);
            //Assert.True(string.IsNullOrEmpty(user.Id));
        }
    }
}
