using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace simple_pag_Domain.Shared.Models
{
    public static class StringExtensions
    {
        private static readonly char[] CaracteresAlphaNumericos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly Random Random = new Random(); // Adiciona uma instância estática de Random

        public static string HashPassword(this string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GerarSiglaAsync(string entrada)
        {
            var tentativa = "";
            if (string.IsNullOrWhiteSpace(entrada))
                throw new ArgumentException("Entrada inválida");

            var letras = new string(entrada
                .Where(char.IsLetter)
                .Select(char.ToUpper)
                .ToArray());

            // 1. Tenta combinações de 2 letras
            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = i + 1; j < letras.Length; j++)
                {
                    tentativa = $"{letras[i]}{letras[j]}";
                    return tentativa;
                }
            }
            return tentativa; // Retorna vazio se não encontrar combinações de 2 letras
        }

        public static string GerarSiglarefresh(string entrada,int contador)
        {
            var teste=entrada.Remove(1, contador);
            var tentativa = "";
            var letras = new string(teste)
              .Where(char.IsLetter)
              .Select(char.ToUpper)
              .ToArray();


            // 1. Tenta combinações de 2 letras
            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = i + 1; j < letras.Length; j++)
                {
                     tentativa = $"{letras[i]}{letras[j]}";
                    return tentativa;
                }
            }
            return tentativa;
        }
        public static string RemoverAcentos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in textoNormalizado)
            {
                var unicode = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicode != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
