using System.Collections.Generic;
using System.Globalization;
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

        #region Properties
        public CultureInfo cultureInfo { get; private set; }
        #endregion

        public Assembly ProjectAssembly { get; private set; }

        public ApplicationModel(Assembly projectAssembly)
        {
            ProjectAssembly = projectAssembly;
            cultureInfo = new CultureInfo("pl-PL");
        }
    }
}
