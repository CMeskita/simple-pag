
namespace simple_pag_Domain.Models
{
    using System.Text.RegularExpressions;

    public static class CNPJ
    {
        private const int TamanhoCNPJSemDV = 12;
        private static readonly Regex RegexCNPJSemDV = new Regex(@"^([A-Z\d]){12}$");
        private static readonly Regex RegexCNPJ = new Regex(@"^([A-Z\d]){12}(\d){2}$");
        private static readonly Regex RegexCaracteresMascara = new Regex(@"[./-]");
        private static readonly Regex RegexCaracteresNaoPermitidos = new Regex(@"[^A-Z\d./-]", RegexOptions.IgnoreCase);
        private const int ValorBase = (int)'0';
        private static readonly int[] PesosDV = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private const string CnpjZerado = "00000000000000";

        public static bool IsValid(string cnpj)
        {
            if (!RegexCaracteresNaoPermitidos.IsMatch(cnpj))
            {
                string cnpjSemMascara = RemoveMascaraCNPJ(cnpj);
                if (RegexCNPJ.IsMatch(cnpjSemMascara) && cnpjSemMascara != CnpjZerado)
                {
                    string dvInformado = cnpjSemMascara.Substring(TamanhoCNPJSemDV);
                    string dvCalculado = CalculaDV(cnpjSemMascara.Substring(0, TamanhoCNPJSemDV));
                    return dvInformado == dvCalculado;
                }
            }
            return false;
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
                        int asciiDigito = (int)cnpjSemMascara[i] - ValorBase;
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
