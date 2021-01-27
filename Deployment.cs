using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidavid.K8sCreateYaml
{
    public class Deployment : WorkLoadBase
    {
        public int Replicas { get; set; } = 1;

        public string GenerateYaml()
        {

            StringBuilder sb = new StringBuilder(TemplateManager.GetTemplate("deployment"));

            UpdateYaml(sb);

            sb.Replace("@replicas@", Replicas.ToString());

            return sb.ToString();
        }

    }
}
