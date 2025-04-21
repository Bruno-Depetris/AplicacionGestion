using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AplicacionGestion.BaseDatos.Conexion;
using AplicacionGestion.Formularios.Vender;


namespace WindowsFormsApp1 {
    public partial class AplicacionGestion : Form {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public AplicacionGestion() {
            InitializeComponent();
            this.MouseDown += AplicacionGestion_MouseDown;
            panel_Senializador.Visible = false;
            ComprobarConexion();
        }

        private void AplicacionGestion_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private Form FormActivo = null;
        private void ComprobarConexion() {
            if (Conectar.Comprobar()) {
                panel_EstadoConeccion.BackColor = Color.Green;
                label_Estado.Text = "Exitosa";    
            } else {
                panel_EstadoConeccion.BackColor = Color.Red;
                label_Estado.Text = "Defectuosa";
            }

        }
        private void AbrirFormNuevo(Form FormHijo) {
            if (FormActivo != null) {
                FormActivo.Close();
            }

            FormActivo = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            FormHijo.Dock = DockStyle.Fill;
            panel_Contenedor.Controls.Add(FormHijo);
            panel_Contenedor.Tag = FormHijo;
            FormHijo.Show();
        }
        private void MoverPanel(ReaLTaiizor.Controls.ParrotButton botonActual) {
            panel_Senializador.Visible = true;
            panel_Senializador.Height = botonActual.Height ;
            panel_Senializador.Top = botonActual.Top - 1;
            panel_Senializador.Left = botonActual.Left - 20;
            
            panel_Senializador.BringToFront();
        }
        private void AplicacionGestion_SizeChanged(object sender, EventArgs e) {
            this.Refresh();
            this.PerformLayout();
        }

        private void AplicacionGestion_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?","Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (result == DialogResult.No) {
                e.Cancel = true; // Esto evita que se cierre la app
            }
        }

        private void parrotButton_Vender_Click(object sender, EventArgs e) {
            MoverPanel(parrotButton_Vender);
            AbrirFormNuevo(new VenderForm());
        }

        private void parrotButton_Stock_Click(object sender, EventArgs e) {
            MoverPanel(parrotButton_Stock);
        }

        private void parrotButton_Caja_Click(object sender, EventArgs e) {
            MoverPanel(parrotButton_Caja);
        }

        private void parrotButton_Cliente_Click(object sender, EventArgs e) {
            MoverPanel(parrotButton_Cliente);
        }

        private void parrotButton_Configuracion_Click(object sender, EventArgs e) {
            MoverPanel(parrotButton_Configuracion);
        }

        private void timer_Tick(object sender, EventArgs e) {
            bigLabel_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
