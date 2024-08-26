using PracticoProyectos.Modelos;
using PracticoProyectos.Servicios;
using PracticoProyectos.Http;
namespace PracticoProyectos
{
    public partial class Form1 : Form
    {
        ProyectoServicio projectService = new ProyectoServicio();
        List<Proyecto> proyectos = new List<Proyecto>(); //se llena  al recibir la respuesta de la API
        Proyecto proyecto = new Proyecto(); //se llena al recibir la respuesta de la API

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Task.Run(async...
            // Crea un bloque de c�digo as�ncrono ya que llamar un m�todo as�ncrono
            // desde un m�todo s�ncrono puede bloquear la interfaz de usuario
            // debido a que el hilo principal se bloquea esperando la respuesta
            Task.Run(async () =>
            {
                //Obtener todos los proyectos
                proyectos = await projectService.Index();
                if(proyecto != null)
                {
                    foreach (var proyecto in proyectos)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = proyecto.Name;
                        row.Cells[1].Value = proyecto.Description;
                        row.Cells[2].Value = proyecto.Status;
                        row.Cells[3].Value = proyecto.WorkerHours;

                        dataGridView1.Rows.Add(row); 
                    }
                }
                //MessageBox.Show(proyectos.Count.ToString());

                // Obtener un proyecto por su ID
                proyecto = await projectService.Show(1);
                //MessageBox.Show(proyecto.Name);

                // Crear un nuevo proyecto.
                // primero se debe crear un objeto an�nimo con los datos del nuevo proyecto
                var nuevoProyecto = new
                {
                    name = "Este es el nombre del nuevo proyecto",
                    description = "Esta es la descripci�n del nuevo proyecto",
                    status = "pendiente",
                    totalHours = 100,
                    //no es necesario enviar el id ni las horas de trabajo, ya que se asignan autom�ticamente en la API
                    created_at = "2024-08-26"
                };

                //se debe serializar el objeto an�nimo a JSON para enviarlo a la API
                var proyectoCreado = await projectService.Create(nuevoProyecto);

                MessageBox.Show(proyectoCreado); //deber�a mostrar el mensaje de la API

            });
        }
    }
}
