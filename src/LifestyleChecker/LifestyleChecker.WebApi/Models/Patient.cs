using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using LifestyleChecker.WebApi.Extensions;

namespace LifestyleChecker.WebApi.Models
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class Patient
    {
        [JsonProperty(PropertyName = "nhsNumber")]
        public string? NhsNumber { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "born")]
        public string? Born { get; set; }

        [JsonIgnore]
        public int Age
        {
            get
            {
                if (string.IsNullOrEmpty(Born)) return 0;

                return DateTime.ParseExact(Born, "dd-MM-yyyy", CultureInfo.InvariantCulture).Age();
            }
        }
    }
}
