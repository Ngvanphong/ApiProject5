using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject5.RenumberElement
{
    public class MyOrder : IComparer<Element>
    {
        public int Compare(Element x, Element y)
        {
            LocationPoint loc = x.Location as LocationPoint;
            double pointCenter = loc.Point.X;
            LocationPoint locY = y.Location as LocationPoint;
            double pointCenterY = locY.Point.X;
            int compareLoc = pointCenter.CompareTo(pointCenterY);
            if (compareLoc == 0)
            {
                double pointCenter2 = loc.Point.Y;
                double pointCenter2Y = locY.Point.Y;
                return pointCenter2.CompareTo(pointCenter2Y);
            }
            return compareLoc;
        }
    }
    
}
