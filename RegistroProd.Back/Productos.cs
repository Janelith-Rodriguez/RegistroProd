using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RegistroProd.Back
{
    public class Productos
    {
        public DataTable ListaDT { get; set; } = new DataTable();

        public Productos()
        {
            ListaDT.TableName = "ListaProductos";
            ListaDT.Columns.Add("Producto");
            ListaDT.Columns.Add("Referencia", typeof(int));
            ListaDT.Columns.Add("Valor", typeof(int));
            LeerArchivo();
        }

        public void LeerArchivo()
        {
            if (System.IO.File.Exists("Productos.xml"))
            {
                ListaDT.ReadXml("Productos.xml");
            }
        }
        public void InsertProducto(Producto aProducto)
        {
            ListaDT.Rows.Add();  //Agrego reglon vacio
            int NuevoRenglon = ListaDT.Rows.Count - 1;
            ListaDT.Rows[NuevoRenglon]["Producto"] = aProducto.Productos;
            ListaDT.Rows[NuevoRenglon]["Referencia"] = aProducto.Referencia;
            ListaDT.Rows[NuevoRenglon]["Valor"] = aProducto.Valor;

            ListaDT.WriteXml("Productos.xml");
        }

    }
}
