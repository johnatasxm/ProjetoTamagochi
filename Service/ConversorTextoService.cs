using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTamagochi.Util
{
    internal class ConversorTextoService
    {
        internal static String ToPascalCase(String texto)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto);
        }
    }
}
