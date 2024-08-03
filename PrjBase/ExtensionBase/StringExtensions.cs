using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.ExtensionBase;

public static class StringExtensions
{
    /// <summary>
    /// Returns TRUE if it has data
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool CheckHasData(this string? data)
    {
        string? s = data;

        if (s is not null)
            s = s.Trim();

        return !string.IsNullOrEmpty(s);
    }
    /// <summary>
    /// Returns TRUE if it is NULL or Empty
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool CheckIsNullOrEmpty(this string? data)
    {
        return string.IsNullOrEmpty(data);
    }

    public static bool ToBoolean(this string? data)
    {
        if (string.IsNullOrEmpty(data))
            return false;

        string dataLower = data.Trim().ToLower() + ";";
        bool result = dataLower.IndexOf("y;yes;true;1;") != -1;
        return result;
    }
    public static double ToDouble(this string? data)
    {
        if (string.IsNullOrEmpty(data))
            return 0;

        double convertedData = Convert.ToDouble(data.Trim());
        return convertedData;
    }
    public static int ToInt32(this string? data)
    {
        if (string.IsNullOrEmpty(data))
            return 0;

        int convertedData = Convert.ToInt32(data.Trim());
        return convertedData;
    }
    public static decimal ToDecimal(this string? data)
    {
        if (string.IsNullOrEmpty(data))
            return 0;

        decimal convertedData = Convert.ToDecimal(data.Trim());
        return convertedData;
    }
    public static DateTime? ToDateTime(this string? data)
    {
        if (string.IsNullOrEmpty(data))
            return null;

        DateTime convertedDate = Convert.ToDateTime(data.Trim());
        return convertedDate;
    }
}

