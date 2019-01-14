using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.common
{
    class Index
    {
        private static Dictionary<String, int> angle_index = new Dictionary<string, int>()
        {   { "Square",0},
            { "Parallelogram",1},
            { "Triangle_big",2},
            { "Triangle_medium",3},
            { "Triangle_small",4} };

        public static int getAngleIndex(String type)
        {
            return angle_index[type];   
        }


    }
}
