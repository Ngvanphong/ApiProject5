using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject5.TransferMore
{
   public class Constants
    {
        public const string TemplateView = "TemplateView";
        public const string LegendView = "Legend";
        public const string Pattern = "Pattern";
        public const string LineStyle = "LineStyle";
        public const string Material = "Material";
        public static List<string> ListOtherCate { get
            {
                return new List<string>() { TemplateView, LegendView, Pattern, LineStyle, Material };
            } }
    }
}
