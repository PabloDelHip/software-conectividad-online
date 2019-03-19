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
    public partial class FormConecction : Form
    {
        ClsGeneral cls_generales = new ClsGeneral();
        public FormConecction()
        {
            InitializeComponent();
        }

        private void FormConecction_Load(object sender, EventArgs e)
        {
            string[] datosConexion = cls_generales.verDatosConexion();
            txtUser.Text = datosConexion[0].ToString();
            txtPass.Text = datosConexion[1].ToString();
            txtDataBase.Text = datosConexion[2].ToString();
            txtServer.Text = datosConexion[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool respuesta = cls_generales.CambiardatosConexion(txtUser.Text, txtPass.Text, txtDataBase.Text, txtServer.Text);
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
    }
}
