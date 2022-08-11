namespace ControlMultasTransito
{
    public partial class frmMultas : Form
    {
        ListViewItem item;
        public frmMultas()
        {
            InitializeComponent();
        }

        private void frmMultas_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Calculando los datos
            string placa = txtPlaca.Text;
            double velocidad = double.Parse(txtVelocidad.Text);
            DateTime fecha = DateTime.Parse(lblfecha.Text);
            DateTime hora = DateTime.Parse(lblHora.Text);

            //Procesando
            double multa = 0;
            if (velocidad <= 70)
                multa = 0;
            else if (velocidad > 70 && velocidad <= 90)
                multa = 120;
            else if (velocidad > 90 && velocidad <= 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 350;

            //Imprimiendo los resuñtados
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(lblfecha.Text);
            fila.SubItems.Add(lblHora.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));
            lvMultas.Items.Add(fila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro que desea salir?",
                                                "Control de multas de transito",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
            item = lvMultas.GetItemAt(e.X, e.Y);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("Multa Eliminada Correctamente");
            }
            else
            {
                MessageBox.Show("debe seleccionar una multa de la lista");
            }
        }
    }
}