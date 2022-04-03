using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UI_Testing_2
{
    class Color_codes
    {

        
        public Brush cd_fill(string code)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString(code);
            return brush;
        }

    }
}
