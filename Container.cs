using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    public class Container
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public Resources Resources { get; set; }

        /// <summary>
        /// Key,Value
        /// </summary>
        public Dictionary<string, string> Environment { get; set; }

        /// <summary>
        /// Port, Name, Protocol
        /// </summary>
        public Dictionary<int, string> Ports { get; set; }


        internal void AppendContainer(StringBuilder sb)
        {
            sb.AppendLine();
            sb.AppendLineWithTabs($"- name: {Name}", 6);
            sb.AppendWithTabs($"image: {Image}", 8);

            AppendEnvs(sb);

            AppendPorts(sb);

            Resources?.AppendResources(sb);

        }

        private void AppendEnvs(StringBuilder sb)
        {
            if (Environment?.Any() == true)
            {
                sb.AppendLine();
                sb.AppendWithTabs("env:", 8);
                foreach (var env in Environment)
                {
                    sb.AppendLine();
                    sb.AppendLineWithTabs($"- name: {env.Key}", 8);
                    sb.AppendWithTabs($"value: \"{env.Value}\"", 10);
                }
            }
        }

        private void AppendPorts(StringBuilder sb)
        {
            if (Ports?.Any() == true)
            {
                sb.AppendLine();
                sb.AppendWithTabs("ports:", 8);
                foreach (var port in Ports)
                {
                    sb.AppendLine();
                    sb.AppendLineWithTabs($"- containerPort: {port.Key}", 8);
                    sb.AppendWithTabs($"protocol: {port.Value}", 10);
                }
            }
        }
    }
}
