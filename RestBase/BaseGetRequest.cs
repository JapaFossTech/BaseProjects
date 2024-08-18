//using PrjBase.ModelBase.Attributes;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RestBase
//{
//    public class BaseGetRequest<T>: IValidatableObject
//    {
//        //* PageIndex

//        [DefaultValue(0)]
//        public int PageIndex { get; set; } = 0;

//        //* PageSize

//        [DefaultValue(10)]
//        [Range(1, 100)]
//        public int PageSize { get; set; } = 10;

//        //* SortColumn
//        public string? SortColumn { get; set; }

//        //* SortOrder

//        [SortOrderValidator]
//        [DefaultValue("ASC")]
//        public string? SortOrder { get; set; } = "ASC";

//        //* FilterQuery

//        [DefaultValue(null)]
//        public string? FilterQuery { get; set; } = null;

//        #region IValidatableObject implementation

//        //* IValidatableObject implementation
//        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//        {
//            var validator = new SortColumnValidatorAttribute(typeof(T));

//            ValidationResult? result = validator
//                                 .GetValidationResult(SortColumn, validationContext);

//            return (result is null)
//                ? Array.Empty<ValidationResult>()   //Same as: new ValidationResult[0]
//                : [result];                         //same as: new[] { result }
//        }

//        #endregion
//    }
//}
