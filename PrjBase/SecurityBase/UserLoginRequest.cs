using PrjBase.ModelBase.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.SecurityBase;
public class UserLoginRequest
{
    [Required]
    [MaxLength(255)]
    [CustomKeyValue("x-test-1", "value 1")]
    [CustomKeyValue("x-test-2", "value 2")]
    public string UserName { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
