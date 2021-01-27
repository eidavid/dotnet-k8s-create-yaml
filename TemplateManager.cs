using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    internal static class TemplateManager
    {
        internal static string GetTemplate(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var file = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith($"{name}.tpl"));

            using (var reader = new StreamReader(assembly.GetManifestResourceStream(file)))
                return reader.ReadToEnd();
        }
    }
}
