using RegistroProd.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroProd.Front
{
    public partial class Form1 : Form
    {
        int i = 1;
        int poc;
        public Form1()
        {
            InitializeComponent();
            limpiar();
        }
        private void limpiar()
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtProducto.Text = "";
            txtReferencia.Text = "";
            txtValor.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string p, r, v;
            p = txtProducto.Text;
            r = txtReferencia.Text;
            v = txtValor.Text;
            dg.Rows.Add(i+"",p,r,v);
            i = i + 1;
            limpiar();
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dg.CurrentRow.Index;
            txtProducto.Text = dg[1,poc].Value.ToString();
            txtReferencia.Text = dg[2,poc].Value.ToString();
            txtValor.Text = dg[3,poc].Value.ToString();

            btnAgregar.Enabled = false;
            btnModificar.Enabled=false;
            btnEliminar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            btnAgregar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string p, r, v;
            p = txtProducto.Text;
            r = txtReferencia.Text;
            v = txtValor.Text;

            dg[1, poc].Value = txtProducto.Text;
            dg[2, poc].Value = txtReferencia.Text;
            dg[3, poc].Value = txtValor.Text;
           
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dg.Rows.RemoveAt(poc);
        }
    }
}
