using System.Collections.Generic;
using System.Reflection;

namespace CityInformationsApp.Models
{
    public class ApplicationModel
    {
        #region Const
        public IReadOnlyList<string> ImagesToRandInHomePage = new List<string>
        {
            "RandomSiewierz1"
        };

        public string LogoName = "SiewierzLogo";

        #endregion

        public Assembly ProjectAssembly { get; private set; }

        public ApplicationModel(Assembly projectAssembly)
        {
            ProjectAssembly = projectAssembly;
        }
    }
}
