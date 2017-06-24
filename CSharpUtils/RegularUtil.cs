using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpUtils
{
    public class RegularUtil
    {
        /// <summary>
        /// 验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="express">正则表达式的内容。</param>
        /// <param name="value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsMatchString(string express, string value)
        {
            if (value == null || value.Length == 0)
                return false;
            Regex myRegex = new Regex(express);
            return myRegex.IsMatch(value);
        }

        /// <summary>
        /// 匹配出字符串中符合指定的正则表达式的内容
        /// </summary>
        /// <param name="express">正则表达式的内容</param>
        /// <param name="value">需匹配的字符串</param>
        /// <returns></returns>
        public static string MatchString(string express, string value)
        {
            if (value == null || value.Length == 0)
                return null;
            Regex myRegex = new Regex(express);
            return myRegex.Match(value).ToString();
        }
    }
}
