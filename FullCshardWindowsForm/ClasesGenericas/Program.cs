using System;
using System.Collections.Generic;

namespace ClasesGenericas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Clase generica List
            List<Object> mi_lista = new List<Object>();
            mi_lista.Add("Hola mundo");
            mi_lista.Add(32);
            //mi_lista.Remove(32);
            mi_lista.Add(true);

            mi_lista.ForEach(Item =>
            {
                Console.WriteLine(Item);
            });

            for (int i = 0; i < mi_lista.Count; i++)
            {
                Console.WriteLine(i +" - "+ mi_lista[i]);
            }
            var buqueda = mi_lista.IndexOf(32);//si no encuentra devuelve -1
            Console.WriteLine("La busqueda esta en la posicion "+buqueda);
            Console.ReadLine();

        }
    }
}
