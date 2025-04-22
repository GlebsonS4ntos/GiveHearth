using FluentValidation;
using GiveHearth.Dtos;

namespace GiveHearth.Validations
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(2, 100)
                .WithMessage("Name must be between 2 and 100 characters.");
            RuleFor(r => r.Cpf)
                .Must(CpfIsValid)
                .WithMessage("Cpf is invalid.");
            RuleFor(r => r.RegisterDate)
                .Must(RegisterDateValidation)
                .WithMessage("Date to Register is invalid.");
            RuleFor(r => r.BirthDate)
                .Must(BirthDateValidation)
                .WithMessage("Must be 18 years old.");
        }

        private bool RegisterDateValidation(DateTime registerDate)
        {
            return registerDate.Date > TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo")).Date;
        }

        private bool BirthDateValidation(DateTime birthDate)
        {
            return birthDate.AddYears(18).Date <= TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo")).Date;
        }

        public static bool CpfIsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (!cpf.All(char.IsDigit))
                return false;

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            string cpfValidado = tempCpf + digito2;

            return cpf == cpfValidado;
        }

    }
}
