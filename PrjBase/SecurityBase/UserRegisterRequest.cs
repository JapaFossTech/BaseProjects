using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.SecurityBase;
public class UserRegisterRequest
{
    [Required]
    [MaxLength(255)]
    public string UserName { get; set; } = default!;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
