using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    public class Resources
    {
        public string RequestsMemory { get; set; }
        public string RequestsCpu { get; set; }

        public string LimitsMemory { get; set; }
        public string LimitsCpu { get; set; }

        internal void AppendResources(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(RequestsCpu) || !string.IsNullOrWhiteSpace(RequestsMemory) || !string.IsNullOrWhiteSpace(LimitsCpu) || !string.IsNullOrWhiteSpace(LimitsMemory))
            {
                int space = 8;

                sb.AppendLine();
                sb.AppendWithTabs("resources:", space);
                if (!string.IsNullOrWhiteSpace(RequestsCpu) || !string.IsNullOrWhiteSpace(RequestsMemory))
                {
                    sb.AppendLine();
                    sb.AppendWithTabs("requests:", space + 2);

                    if (!string.IsNullOrWhiteSpace(RequestsCpu))
                    {
                        sb.AppendLine();
                        sb.AppendWithTabs($"cpu: {RequestsCpu}", space + 4);
                    }

                    if (!string.IsNullOrWhiteSpace(RequestsMemory))
                    {
                        sb.AppendLine();
                        sb.AppendWithTabs($"memory: {RequestsMemory}", space + 4);
                    }

                }

                if (!string.IsNullOrWhiteSpace(LimitsCpu) || !string.IsNullOrWhiteSpace(LimitsMemory))
                {
                    sb.AppendLine();
                    sb.AppendWithTabs("limits:", space + 2);

                    if (!string.IsNullOrWhiteSpace(LimitsCpu))
                    {
                        sb.AppendLine();
                        sb.AppendWithTabs($"cpu: {LimitsCpu}", space + 4);
                    }

                    if (!string.IsNullOrWhiteSpace(LimitsMemory))
                    {
                        sb.AppendLine();
                        sb.AppendWithTabs($"memory: {LimitsMemory}", space + 4);
                    }

                }
            }
        }
    }
}
