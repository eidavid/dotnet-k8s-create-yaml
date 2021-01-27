using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    public class Service
    {
        public string Name { get; set; }
        public string Namespace { get; set; }

        public string App { get; set; }
        public string Type { get; set; }

        public IEnumerable<ServicePort> Ports { get; set; }

        public string GenerateYaml()
        {
            StringBuilder sb = new StringBuilder(TemplateManager.GetTemplate("svc"));

            sb.Replace("@name@", Name);

            sb.Replace("@app@", App);

            sb.Replace("@type@", Type);

            GenerateNameSpace(sb);

            AppendPorts(sb);

            return sb.ToString();
        }

        void GenerateNameSpace(StringBuilder sbToReplace)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Namespace))
            {
                sb.AppendLine();
                sb.AppendWithTabs($"namespace: {Namespace}", 2);
            }
            sbToReplace.Replace("@namespace@", sb.ToString());
        }

        private void AppendPorts(StringBuilder sbToReplace)
        {
            StringBuilder sb = new StringBuilder();
            if (Ports?.Any() == true)
            {
                int space = 2;
                sb.AppendLine();
                sb.AppendWithTabs("ports:", space);
                foreach (var port in Ports)
                {
                    sb.AppendLine();
                    sb.AppendLineWithTabs($"- port: {port.Port}", space);
                    sb.AppendLineWithTabs($"protocol: {port.Protocol}", space + 2);
                    sb.AppendWithTabs($"targetPort: {port.TargetPort}", space + 2);
                }
            }
            sbToReplace.Replace("@ports@", sb.ToString());
        }
    }

    public class ServicePort
    {
        public ServicePort(int port, string protocol = "TCP", int targetPort = -1)
        {
            Port = port;
            TargetPort = targetPort <= 0 ? port : targetPort;
            Protocol = protocol;
        }

        public int Port { get; set; }
        public int TargetPort { get; set; }
        public string Protocol { get; set; }
    }
}
