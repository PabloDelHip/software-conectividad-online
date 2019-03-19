using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;

namespace CapaPresentacioon
{
    public partial class inicio : Form
    {
        ClsGeneral cls_general = new ClsGeneral();
        public inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConecctionSql frm_conecction = new FormConecctionSql();
            frm_conecction.Show();
        }

        public void guardarDatos()
        {
            DataTable dt = cls_general.verProductos();
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count !=0)
            {
                foreach (DataRow filas in dt.Rows)
                {
                    cls_general.m_gm = 0;
                    cls_general.m_ww = 0;
                    cls_general.m_nissan = 0;
                    cls_general.m_status = 0;
                    if (filas["gm"].ToString().Equals("True"))
                    {
                        cls_general.m_gm = 1;
                    }

                    if (filas["ww"].ToString().Equals("True"))
                    {
                        cls_general.m_ww = 1;
                    }

                    if (filas["nissan"].ToString().Equals("True"))
                    {
                        cls_general.m_nissan = 1;
                    }

                    if (filas["status"].ToString().Equals("True"))
                    {
                        cls_general.m_status = 1;
                    }
                    cls_general.m_idcat_web_productos= Convert.ToInt32(filas["idcat_web_productos"].ToString());
                    cls_general.m_noref = Convert.ToInt32(filas["noref"].ToString());
                    cls_general.m_descipcion = filas["descipcion"].ToString();
                    cls_general.m_imagen = filas["imagen"].ToString();
                    cls_general.m_manual = filas["manual"].ToString();
                    cls_general.m_cpt_idlastedit = Convert.ToInt32(filas["cpt_idlastedit"].ToString());
                    cls_general.m_cpt_timestamp = Convert.ToInt32(filas["cpt_timestamp"].ToString());
                    cls_general.guardarProductos();
                   
                }

                cls_general.eliminarProductos();
                MessageBox.Show("Guardados de forma correcta");
            }
            
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = cls_general.verProductos();
            dataGridView1.DataSource = dt;
            guardarDatos();
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormConecction frm_conecction = new FormConecction();
            frm_conecction.Show();
        }
    }
}
