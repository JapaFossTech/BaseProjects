using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.ModelBase.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter,
                AllowMultiple = true)]
public class CustomKeyValueAttribute : Attribute
{
    public CustomKeyValueAttribute(string? key, string? value)
    {
        Key = key;
        Value = value;
    }

    public string? Key { get; set; }

    public string? Value { get; set; }
}
