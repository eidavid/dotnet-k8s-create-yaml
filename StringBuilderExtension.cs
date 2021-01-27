using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    internal static class StringBuilderExtension
    {
        public static void AppendLineWithTabs(this StringBuilder sb, string text, int space) =>
            sb.AppendLine($"{new string(' ', space)}{text}");

        public static void AppendWithTabs(this StringBuilder sb, string text, int space) =>
            sb.Append($"{new string(' ', space)}{text}");
    }
}
