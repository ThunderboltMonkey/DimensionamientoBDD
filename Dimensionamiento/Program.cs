using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dimensionamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            int NoCampos = 0;
            Console.WriteLine("Ingrese el número de campos en su tabla: ");
            NoCampos = int.Parse(Console.ReadLine());

            int BytesControl = 0;
            Console.WriteLine("Ingrese los bytes de control requeridos para la tabla: ");
            BytesControl = int.Parse(Console.ReadLine());

            int longCampo = 0;
            int byteControlCampo = 0;

            for (int i = 0; i < NoCampos; i++)
            {
                Console.WriteLine("Ingrese la longitud del campo  " + (i + 1).ToString() + " (en bytes):");
                longCampo = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el tamaño (en bytes) para el control del campo " + (i + 1).ToString() + ": ");
                byteControlCampo = int.Parse(Console.ReadLine());

                longCampo += longCampo;
                byteControlCampo += byteControlCampo;
            }

            Console.WriteLine("Longitud de campos: " + longCampo);
            Console.WriteLine("Bytes de control: " + byteControlCampo);

            int tamBloque = 0;
            Console.WriteLine("\n\rIngrese el tamaño de bloque: (tenga en cuenta que la cantidad introducida se multiplicará por 1024 bytes) ");
            tamBloque = int.Parse(Console.ReadLine());

            int tamBloquef = 0;
            tamBloquef = tamBloque * 1024;
            Console.WriteLine("\n\rTamaño del bloque elegido = " + tamBloquef.ToString() + " bytes");

            int cabecera = 0;
            Console.WriteLine("\n\rIngrese el tamaño (en bytes) de cabecera de bloque: ");
            cabecera = int.Parse(Console.ReadLine());

            double tempPctFree = 0;
            double pctfree = 0;
            Console.WriteLine("\n\rIngrese el porcentaje de espacio usado: (Número entre 0 y 100) ");
            tempPctFree = double.Parse(Console.ReadLine());
            pctfree = tempPctFree / 100;

            // Calculamos el tamaño real del bloque que tendremos para trabajar
            double tamRealBloque = 0;
            double temp = 0;
            double restaPctfree = 0;
            temp = tamBloquef - cabecera;
            restaPctfree = temp * pctfree;
            tamRealBloque = temp - restaPctfree;
            Console.WriteLine("\n\rEl tamaño disponible del bloque es de: " + tamRealBloque.ToString() + " kilobytes");

            int registros = 0;
            Console.WriteLine("\n\rIngrese el número de registros: ");
            registros = int.Parse(Console.ReadLine());

            // Calcular los bytes por registro
            int bytesPorRegistro = 0;
            bytesPorRegistro = longCampo + byteControlCampo + BytesControl;
            Console.WriteLine("\n\rUn registro abarca " + bytesPorRegistro.ToString() + " bytes");

            // Cuantos registros puedo acumular en un bloque
            double regPorBloque = 0;
            regPorBloque = tamRealBloque / bytesPorRegistro;
            Console.WriteLine("\n\rCaben " + Math.Round(regPorBloque).ToString() + " registros en un bloque");

            //Bloques necesarios para almacenar los registros totales
            double bloquesNecesarios = 0;
            bloquesNecesarios = registros / regPorBloque;
            Console.WriteLine("\n\rSe necesitan " + Math.Ceiling(bloquesNecesarios).ToString() + " bloques en total");

            Console.ReadKey();
        }
    }
}
