using System.Text;
using System.Text.RegularExpressions;

namespace simple_pag_Domain.Models
{
    public static class CNPJGenerator
    {
        private const int TamanhoGrupoNumerico1 = 2;
        private const int TamanhoGrupoAlfa1 = 3;
        private const int TamanhoGrupoNumerico2 = 3;
        private const int TamanhoGrupoAlphaNumerico = 4; // Grupo 4 agora alfanumérico
        private const int TamanhoGrupoAlfa2 = 2;
        private const int TamanhoDV = 2;
        private const int TamanhoCNPJSemDV = TamanhoGrupoNumerico1 + TamanhoGrupoAlfa1 + TamanhoGrupoNumerico2 + TamanhoGrupoAlphaNumerico;

        private static readonly Regex RegexCNPJSemDV = new Regex(@"^([A-Z\d]){12}$");
        private static readonly Regex RegexCNPJSemDVFormato = new Regex($@"^(\d{{{TamanhoGrupoNumerico1}}})([A-Z]{{{TamanhoGrupoAlfa1}}})(\d{{{TamanhoGrupoNumerico2}}})/([A-Z\d]{{{TamanhoGrupoAlphaNumerico}}})-([A-Z]{{{TamanhoGrupoAlfa2}}})$");
        private static readonly Regex RegexCaracteresNaoPermitidos = new Regex(@"[^A-Z\d./-]", RegexOptions.IgnoreCase);
        private const int ValorBaseNumerico = (int)'0';
        private static readonly int[] PesosDV = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private const string CnpjZeradoSemMascara = "00AAA0000000BB";
        private const string CnpjZerado = "00000000000000";
        private static readonly Regex RegexCaracteresMascara = new Regex(@"[./-]");

        //private static readonly char[] CaracteresAlfa = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //private static readonly char[] CaracteresNumericos = "0123456789".ToCharArray();
        private static readonly char[] CaracteresAlphaNumericos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly Random Random = new Random();


        public static string GerarCNPJValidoAlphaNumeric()
        {
            StringBuilder sb = new StringBuilder();

            // Grupo 1: 2 dígitos numéricos
            for (int i = 0; i < TamanhoGrupoNumerico1; i++)
            {
                sb.Append(CaracteresAlphaNumericos[Random.Next(CaracteresAlphaNumericos.Length)]);
            }
            sb.Append(".");

            // Grupo 2: 3 letras maiúsculas
            for (int i = 0; i < TamanhoGrupoAlfa1; i++)
            {
                sb.Append(CaracteresAlphaNumericos[Random.Next(CaracteresAlphaNumericos.Length)]);
            }
            sb.Append(".");

            // Grupo 3: 3 dígitos numéricos
            for (int i = 0; i < TamanhoGrupoNumerico2; i++)
            {
                sb.Append(CaracteresAlphaNumericos[Random.Next(CaracteresAlphaNumericos.Length)]);
            }
            sb.Append("/");

            // Grupo 4: 4 caracteres alfanuméricos
            for (int i = 0; i < TamanhoGrupoAlphaNumerico; i++)
            {
                sb.Append(CaracteresAlphaNumericos[Random.Next(CaracteresAlphaNumericos.Length)]);
            }
            sb.Append("-");

            string cnpjBaseFormato = sb.ToString();
            string cnpjSemMascaraParaCalculo = RemoveMascaraCNPJ(cnpjBaseFormato);

            // Calcula os dígitos verificadores (usando a lógica numérica adaptada)
            //string digitosVerificadores = CalcularDigitosVerificadores(cnpjSemMascaraParaCalculo);
            string digitosVerificadores = CalculaDV(cnpjSemMascaraParaCalculo);



            // Insere os dígitos verificadores no formato
            var resultcnpj= cnpjBaseFormato.Substring(0, 16) + digitosVerificadores;
            return resultcnpj;
        }

      
        public static string CalculaDV(string cnpj)
        {
            if (!RegexCaracteresNaoPermitidos.IsMatch(cnpj))
            {
                string cnpjSemMascara = RemoveMascaraCNPJ(cnpj);
                if (RegexCNPJSemDV.IsMatch(cnpjSemMascara) && cnpjSemMascara != CnpjZerado.Substring(0, TamanhoCNPJSemDV))
                {
                    int somatorioDV1 = 0;
                    int somatorioDV2 = 0;
                    for (int i = 0; i < TamanhoCNPJSemDV; i++)
                    {
                        int asciiDigito = (int)cnpjSemMascara[i] - ValorBaseNumerico;
                        somatorioDV1 += asciiDigito * PesosDV[i + 1];
                        somatorioDV2 += asciiDigito * PesosDV[i];
                    }
                    int dv1 = somatorioDV1 % 11 < 2 ? 0 : 11 - (somatorioDV1 % 11);
                    somatorioDV2 += dv1 * PesosDV[TamanhoCNPJSemDV];
                    int dv2 = somatorioDV2 % 11 < 2 ? 0 : 11 - (somatorioDV2 % 11);
                    return $"{dv1}{dv2}";
                }
            }
            throw new ArgumentException("Não é possível calcular o DV pois o CNPJ fornecido é inválido");
        }
       
        public static string RemoveMascaraCNPJ(string cnpj)
        {
            return RegexCaracteresMascara.Replace(cnpj, "");
        }
    }
}
