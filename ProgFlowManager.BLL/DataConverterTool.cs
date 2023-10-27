using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFlowManager.BLL
{
    public enum Space
    {
        Around, Before, After
    }

    public static class DataConverterTool
    {
        public static string Concat(List<string> values, string? delimiter = null, string? startChar = null, string? endChar = null)
        {
            StringBuilder sb = new();

            if (startChar is not null) sb.Append(startChar);
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine(values[i] + " : WTF " + i);
                sb.Append(" " + values[i]);
                if (delimiter is not null && i < values.Count - 1) sb.Append(" " + delimiter);
            }
            if (endChar is not null) sb.Append(endChar);

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        public static List<TResult> ConvertTo<TResult, TModel>(this List<TModel> list, Func<TModel, TResult> stringSelector)
        {
            List<TResult> result = new();

            foreach (TModel model in list)
                result.Add(stringSelector(model));

            return result;
        }
    }
}
