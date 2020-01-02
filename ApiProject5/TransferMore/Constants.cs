using System.Collections.Generic;

namespace ApiProject5.TransferMore
{
    public class Constants
    {
        public const string TemplateView = "TemplateView";
        public const string LegendView = "Legend";
        public const string Pattern = "Pattern";
        public const string LineStyle = "LineStyle";
        public const string Material = "Material";

        public static List<string> ListOtherCate
        {
            get
            {
                return new List<string>() { TemplateView, LegendView, Pattern, LineStyle, Material };
            }
        }
        public static List<string> LineSystem { get
            {
                return new List<string>() { "Wide Lines","Lines","Thin Lines","Insulation Batting Lines","Axis of Rotation","Medium Lines","Hidden Lines" };
            }
        }


    }
}