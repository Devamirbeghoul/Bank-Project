using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopLayer.GlobalClasses
{
    public class clsDefaultValues
    {
        public static int SetPageSize(int Default = 7)
            => Default;

        public static string SetPageStringFormat(int Current , int Total ,  string Format = null)
            => (Format == null) ? $"{Current}\\{Total}" : Format;

        public static Font GetDefaultFont(Font Choice = null)
            => (Choice == null) ? 
            new Font("Segoe UI", 12, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) : 
            Choice;

        

    }
}
