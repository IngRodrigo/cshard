using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductosLaser
{
   public class Procesar
    {
        public static void procesarProductos()
        {

            productos ObjetoProductos = new productos();
            DataSet datos = ConexionOra.EjecutarConsultaOra(Sentencias.getProductos());
            string sku, stok, precio, porcentaje_impuesto, estadoString = "";
            bool estado = false;
            Item item;
            List<Item> lista = new List<Item>();
            foreach (DataRow dr in datos.Tables[0].Rows)
            {

                item= new Item();
                sku = dr["cod_interno"].ToString();
                stok= dr["existencia"].ToString();
                precio= dr["precio"].ToString();
                porcentaje_impuesto= dr["porcen_iva"].ToString();
                estadoString = dr["estado"].ToString();

                item.sku = sku;
                item.stock = System.Convert.ToDouble(stok);
                item.precio = System.Convert.ToDouble(precio);
                item.porcentaje_impuesto = System.Convert.ToDouble(porcentaje_impuesto);
                if (estadoString=="ACTIVO" || estadoString== "AGOTAR_STOCK")
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
                item.estado = estado;
                lista.Add(item);

            }
            ObjetoProductos.codigo_autorizacion = "null";
            ObjetoProductos.items = lista;

            string postData = JsonConvert.SerializeObject(ObjetoProductos);

            EnviarDatosAlApi(postData);

        }

        private static void EnviarDatosAlApi(string postData)
        {
            string url = "";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            string codigo = ((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                JObject JsonDe = JsonConvert.DeserializeObject<JObject>(responseFromServer);
                //string respuesta = JsonDe.GetValue("Error").ToString();
                //Console.WriteLine(respuesta);

            }
            // Close the response.
            response.Close();
        }
    }

    public class Item
    {
        public string sku { get; set; }
        public double stock { get; set; }
        public double precio { get; set; }
        public double porcentaje_impuesto { get; set; }
        public bool estado { get; set; }
    }

    public class productos
    {
        public string codigo_autorizacion { get; set; }
        public List<Item> items { get; set; }
    }
}
