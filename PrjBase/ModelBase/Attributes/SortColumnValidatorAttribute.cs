using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrjBase.ExtensionBase;

namespace PrjBase.ModelBase.Attributes;
public class SortColumnValidatorAttribute : ValidationAttribute
{
    public Type? ModelType { get; set; }

    public SortColumnValidatorAttribute(Type modelType)
           : base("Provided field '{0}' must match an existing column.")
    {
        ModelType = modelType;
    }

    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        string? strValue = value as string;

        if (strValue.CheckIsNullOrEmpty())
        {
            //return new ValidationResult("Provided Sort Column is Null or Empty.");
            return ValidationResult.Success;
        }

        //* strValue is something; proceed

        if (ModelType is null)
        {
            throw new Exception($"SortColumnValidatorAttribute.IsValid.Exception"
                + $"The ModelType constructor parameter was not provided (is null)");
        }
        else
        {
            //bool isSortColumnExistInEntity = ModelType.GetProperties()
            //                    .Any(prop => prop.Name == strValue);
            bool isSortColumnExistInEntity = ModelType.GetProperties().Any(prop => 
                                                prop.Name.Equals(
                                                    strValue
                                                    , StringComparison.OrdinalIgnoreCase)
                                            );

            if (isSortColumnExistInEntity)
                return ValidationResult.Success;
        }

        return new ValidationResult(FormatErrorMessage(strValue!));
    }
}
