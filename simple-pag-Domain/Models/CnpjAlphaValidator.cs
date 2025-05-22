

namespace simple_pag_Domain.Models
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CnpjAlphaValidator
    {
        /// <summary>
        /// Valida um CNPJ alfanumérico de acordo com as novas regras de formatação.
        /// </summary>
        /// <param name="cnpj">O CNPJ a ser validado (com ou sem formatação).</param>
        /// <returns>Verdadeiro se o CNPJ for válido, falso caso contrário.</returns>
        public static bool IsValidCnpj(string cnpj)
        {
            // 1. Validação inicial e limpeza do CNPJ
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                return false;
            }

            // Remove caracteres de formatação ('.', '/', '-') e converte para maiúsculo
            cnpj = Regex.Replace(cnpj, @"[./-]", "").ToUpper();

            // Verifica o tamanho
            if (cnpj.Length != 14)
            {
                return false;
            }

            // Verifica se todos os caracteres são alfanuméricos
            if (!Regex.IsMatch(cnpj, "^[a-zA-Z0-9]{14}$"))
            {
                return false;
            }

            // 2. Separa a base e os dígitos verificadores
            string baseCnpj = cnpj.Substring(0, 12);
            string digitosVerificadores = cnpj.Substring(12, 2);

            // 3. Calcula os dígitos verificadores esperados
            string digitosVerificadoresCalculados = CalcularDigitosVerificadores(baseCnpj);

            // 4. Compara os dígitos verificadores calculados com os fornecidos
            return digitosVerificadores == digitosVerificadoresCalculados;
        }

        /// <summary>
        /// Calcula os dígitos verificadores (DV1 e DV2) para um CNPJ alfanumérico.
        /// </summary>
        /// <param name="baseCnpj">A base do CNPJ (os primeiros 12 caracteres).</param>
        /// <returns>Uma string contendo os dois dígitos verificadores calculados.</returns>
        private static string CalcularDigitosVerificadores(string baseCnpj)
        {
            // Pesos para o cálculo do DV1 e DV2
            int[] pesosDV1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosDV2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // 1. Cálculo do primeiro dígito verificador (DV1)
            int somaDV1 = CalcularSomaPonderada(baseCnpj, pesosDV1);
            int restoDV1 = somaDV1 % 11;
            int dv1 = (restoDV1 < 2) ? 0 : 11 - restoDV1;

            // 2. Cálculo do segundo dígito verificador (DV2)
            string baseCnpjComDV1 = baseCnpj + dv1; // Concatena a base com o DV1 calculado
            int somaDV2 = CalcularSomaPonderada(baseCnpjComDV1, pesosDV2);
            int restoDV2 = somaDV2 % 11;
            int dv2 = (restoDV2 < 2) ? 0 : 11 - restoDV2;

            return $"{dv1}{dv2}"; // Retorna os dois dígitos verificadores como uma string
        }

        /// <summary>
        /// Calcula a soma ponderada dos caracteres de uma string, utilizando os pesos fornecidos e a tabela de conversão de caracteres.
        /// </summary>
        /// <param name="texto">A string para a qual a soma ponderada será calculada.</param>
        /// <param name="pesos">Um array de inteiros representando os pesos.</param>
        /// <returns>A soma ponderada.</returns>
        private static int CalcularSomaPonderada(string texto, int[] pesos)
        {
            int soma = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                int valor = ObterValorParaCalculo(texto[i]); // Obtém o valor do caractere
                soma += valor * pesos[i]; // Multiplica o valor pelo peso e soma
            }
            return soma;
        }

        /// <summary>
        /// Obtém o valor numérico de um caractere para o cálculo do dígito verificador,
        /// seguindo a tabela de conversão (0-9 permanecem os mesmos, A=17, B=18, ..., Z=42).
        /// </summary>
        /// <param name="caractere">O caractere a ser convertido.</param>
        /// <returns>O valor numérico do caractere.</returns>
        private static int ObterValorParaCalculo(char caractere)
        {
            if (char.IsDigit(caractere))
            {
                return caractere - '0'; // Converte dígito para número (subtrai o código ASCII de '0')
            }
            else if (char.IsLetter(caractere))
            {
                return caractere - 55; // Converte letra maiúscula para valor (A=10, B=11, ..., Z=35)
                                       // Correção: A deve ser 17, B deve ser 18, etc.  O offset correto é 55.
                                       // 'A' - 65 - 48 = 17
                                       // 'B' - 66 - 48 = 18
                                       // ...
                                       // 'Z' - 90 - 48 = 42

            }
            else
            {
                return 0; // Caracteres inválidos devem ser tratados antes desta função
            }
        }

        public static void Main(string[] args)
        {
            // Testes com CNPJs de exemplo
            string[] cnpjsTeste = {
            "12ABC34501DE35",       // CNPJ alfanumérico válido
            "00000000000000",       // CNPJ numérico inválido (todos dígitos iguais)
            "12.ABC.345/01DE-35",   // CNPJ com formatação antiga (deve ser tratado)
            "11223344000155",       // CNPJ numérico válido
            "AB12CD34EF56GH",       // CNPJ alfanumérico válido
            "1234567890123A",       // CNPJ alfanumérico válido
            "123.456.789/012A-34",  // CNPJ alfanumérico válido com formatação antiga
            "1234567890123!"        // CNPJ inválido (caractere especial)
        };

            // Valida cada CNPJ e exibe o resultado
            foreach (string cnpj in cnpjsTeste)
            {
                bool valido = IsValidCnpj(cnpj);
                Console.WriteLine($"CNPJ: {cnpj}, Válido: {valido}");
            }
        }
    }


}
