using Exportador.Controller;

namespace Exportador
{
    public partial class Form1 : Form
    {
        Acciones acc = new Acciones();
        public Form1()
        {
            InitializeComponent();
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            gd.DataSource = acc.ObtenerEmpDep();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            acc.ExportarAExcel(acc.ObtenerEmpDep());
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            acc.ImportarDesdeExcel();
            gd.DataSource = acc.ObtenerEmpDep();
        }
    }
}
