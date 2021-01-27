using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eidavid.K8sCreateYaml
{
    public abstract class WorkLoadBase
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public Dictionary<string, string> Labels { get; set; }
        public Dictionary<string, string> Annotations { get; set; }

        public string ImagePullSecretsName { get; set; } = null;

        public IEnumerable<Container> Containers { get; set; }

        internal void UpdateYaml(StringBuilder sb)
        {

            if (Labels == null)
                Labels = new Dictionary<string, string>();

            if (!Labels.Any() || !Labels.ContainsKey("app"))
                Labels.Add("app", Name);

            sb.Replace("@name@", Name);

            GenerateNameSpace(sb);

            GenerateLabels(sb, "@labels@", 2);

            GenerateLabels(sb, "@labelsTemplate@", 6);

            GenerateAnnotations(sb);

            GenerateContainers(sb);

            GenerateImagePullSecretsName(sb);

        }

        private void GenerateContainers(StringBuilder sbToReplace)
        {
            StringBuilder sb = new StringBuilder();
            if (Containers?.Any() == true)
            {
                sb.AppendLine();
                sb.AppendWithTabs("containers", 6);
                foreach (var container in Containers)
                {
                    container.AppendContainer(sb);
                }
            }

            sbToReplace.Replace("@containers@", sb.ToString());
        }

        internal void GenerateNameSpace(StringBuilder sbToReplace)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Namespace))
            {
                sb.AppendLine();
                sb.AppendWithTabs($"namespace: {Namespace}", 2);
            }
            sbToReplace.Replace("@namespace@", sb.ToString());
        }

        internal void GenerateAnnotations(StringBuilder sbToReplace)
        {
            int space = 6;

            StringBuilder sb = new StringBuilder();
            if (Annotations?.Any() == true)
            {
                sb.AppendLine();
                sb.AppendLineWithTabs("annotations:", space);

                foreach (var annotation in Annotations)
                {
                    sb.AppendLine();
                    sb.AppendWithTabs($"{annotation.Key}: \"{annotation.Value}\"", space + 2);
                }
            }

            sbToReplace.Replace("@annotations@", sb.ToString());
        }

        internal void GenerateLabels(StringBuilder sbToReplace, string section, int space)
        {
            StringBuilder sb = new StringBuilder();
            if (Labels?.Any() == true)
            {
                sb.AppendLine();
                sb.AppendWithTabs("labels:", space);

                foreach (var label in Labels)
                {
                    sb.AppendLine();
                    sb.AppendWithTabs($"{label.Key}: \"{label.Value}\"", space + 2);
                }
            }

            sbToReplace.Replace(section, sb.ToString());
        }

        internal void GenerateImagePullSecretsName(StringBuilder sbToReplace)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(ImagePullSecretsName))
            {
                sb.AppendLine();
                sb.AppendLineWithTabs("imagePullSecrets:", 6);
                sb.AppendWithTabs($"- name: {ImagePullSecretsName}", 8);
            }
            sbToReplace.Replace("@imagePullSecrets@", sb.ToString());
        }
    }
}
