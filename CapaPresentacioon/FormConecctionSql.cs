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
    public partial class FormConecctionSql : Form
    {
        ClsGeneral cls_generales = new ClsGeneral();
        public FormConecctionSql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool respuesta = cls_generales.CambiardatosConexionSql(txtUser.Text, txtPass.Text, txtDataBase.Text, txtServer.Text);
            if (!respuesta)
            {
                MessageBox.Show("Error al conectar con la base de datos, verificar los datos de conexion", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("correcto");
                //this.Close();
                //FrmLogin abrir = new FrmLogin(false);
                //abrir.ShowDialog();

            }
        }

        private void FormConecction_Load(object sender, EventArgs e)
        {
            string[] datosConexion = cls_generales.verDatosConexionSql();
            txtUser.Text = datosConexion[0].ToString();
            txtPass.Text = datosConexion[1].ToString();
            txtDataBase.Text = datosConexion[2].ToString();
            txtServer.Text = datosConexion[3].ToString();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDataBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
