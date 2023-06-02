using System.Collections.Generic;

namespace PayStackDotNetSDK.Models
{
    public class Metadata
    {
        public List<CustomField> custom_fields { get; set; } = null;

    }
    public class CustomField
    {
        public string display_name { get; set; } = null;
        public string variable_name { get; set; } = null;
        public string value { get; set; } = null;
    }
}
