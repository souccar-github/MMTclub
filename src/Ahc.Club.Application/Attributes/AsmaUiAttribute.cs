using System;

namespace Ahc.Club.Attributes
{
    public class AsmaUiAttribute : Attribute
    {
        public bool IsHidden { get; set; }
        public bool Optional { get; set; }
        public string IsReference { get; set; }
        public string IsEnum { get; set; }
        public bool AutoComplete { get; set; }
        public string RefTextField { get; set; }
        public string RefValueField { get; set; }
        public int MaxLength { get; set; }
    }
}
