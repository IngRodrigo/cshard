using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Declaraciones_Statiic
{
    class Estudiante
    {
        public static int Id { get; set; }

        public Estudiante()
        {
            
        }

        public static void mensaje()
        {
            MessageBox.Show("Hola mundo");
        }
    }
}
