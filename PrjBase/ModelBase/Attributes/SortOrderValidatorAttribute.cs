using PrjBase.ExtensionBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.ModelBase.Attributes;
public class SortOrderValidatorAttribute : ValidationAttribute
{
    public string[] SortDirectionOptions { get; } = ["ASC", "DESC"];

    public SortOrderValidatorAttribute()
        : base("Value must be one of the following: {0}.") { }

    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        string? strValue = value as string;

        if (strValue.CheckIsNullOrEmpty())
        {
            return new ValidationResult("Provided Sort Direction is Null or Empty.");
        }

        //* strValue is something; proceed

        bool isSortDirectionValid = SortDirectionOptions.Contains(strValue);

        if (isSortDirectionValid)
            return ValidationResult.Success;
        else
        {
            return new ValidationResult(
                    FormatErrorMessage(string.Join(",", SortDirectionOptions))
                    );
        }
    }
}
