using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    public class CronJob : WorkLoadBase
    {
        public string Schedule { get; set; }

        public bool Suspend { get; set; }

        public string GenerateYaml()
        {
            StringBuilder sb = new StringBuilder(TemplateManager.GetTemplate("cronjob"));

            UpdateYaml(sb);

            sb.Replace("@suspend@", Suspend ? "true" : "false");
            sb.Replace("@schedule@", Schedule);


            return sb.ToString();
        }
    }
}
