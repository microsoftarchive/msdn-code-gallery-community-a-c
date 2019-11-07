using System;
using App.Web.ViewModels;
using FluentValidation;

namespace App.Web.ModelValidation
{
    public class StudentValidation  : AbstractValidator<StudentViewModel>
    {
        public StudentValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be blank");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("First name cannot be blank");
            RuleFor(x => x.SelectedPaymentMethods).NotNull().WithMessage("Select payment methods");
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Select the country");
            RuleFor(x => x.DateOfBirth).Must(IsDateValid).WithMessage("Please enter the date of birth");
            RuleFor(x => x.SelectedGender).NotEmpty().WithMessage("Select gender");
        }

        bool IsDateValid(DateTime dateTime)
        {
            if (dateTime == default(DateTime))
            {
                return false;
            }
            return true;
        }
    }
}