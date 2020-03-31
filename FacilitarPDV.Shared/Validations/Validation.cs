using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace FacilitarPDV.Shared.Validations
{
    public class Validation
    {
        [BsonIgnore]
        public List<string> Notifications = new List<string>();

        public void IsBetween(string text, int minLength, int maxLength)
        {
            if (!(text.Length >= minLength && text.Length <= maxLength))
                Notifications.Add($"o texto deve conter entre {minLength} e {maxLength} caracteres");
        }

        public void IsGreaterThanOrEqualTo(string text, int minLength)
        {
            if (text.Length < minLength)
                Notifications.Add($"o texto deve conter pelo menos {minLength} caracteres");
        }

        public void IsLowerThanOrEqualTo(string text, int maxLength)
        {
            if (text.Length > maxLength)
                Notifications.Add($"o texto deve conter nome máximo {maxLength} caracteres");
        }

        public void IsValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length == 11)
            {
                int[] cpfArray = cpf.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

                bool valid;
                int i = 0;

                do
                {
                    int digit, sum = 0;

                    for (int j = 0; j < 9 + i; j++)
                        sum += cpfArray[j] * (10 + i - j);

                    digit = sum % 11 >= 2 ? 11 - (sum % 11) : 0;

                    if (cpfArray[9 + i] == digit)
                    {
                        valid = true;
                        i++;
                    }
                    else
                        valid = false;
                }
                while (i < 2 && valid);

                if (!valid)
                    Notifications.Add("CPF inválido");

            }
            else
                Notifications.Add("CPF inválido");
        }

        public void IsValidCNPJ(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length == 14)
            {
                int[] cnpjArray = cnpj.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

                bool valid;
                int i = 0;

                do
                {
                    int digit, sum = 0, multiplier = i + 5;

                    for (int j = 0; j < 12 + i; j++)
                    {
                        sum += cnpjArray[j] * multiplier;
                        multiplier = multiplier > 2 ? multiplier - 1 : 9;
                    }

                    digit = sum % 11 >= 2 ? 11 - (sum % 11) : 0;

                    if (cnpjArray[12 + i] == digit)
                    {
                        valid = true;
                        i++;
                    }
                    else
                        valid = false;
                }
                while (i < 2 && valid);

                if (!valid)
                    Notifications.Add("CNPJ inválido");
            }
            else
                Notifications.Add("CNPJ inválido");
        }
    }
}
