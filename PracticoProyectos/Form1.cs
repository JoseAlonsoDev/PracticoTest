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
        
        TareaServicio taskService = new TareaServicio();
        List<Tarea> tareas = new List<Tarea>();
        Tarea tarea = new Tarea();

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
            // Crea un bloque de código asíncrono ya que llamar un método asíncrono
            // desde un método síncrono puede bloquear la interfaz de usuario
            // debido a que el hilo principal se bloquea esperando la respuesta
            Task.Run(async () =>
            {
                //Obtener todos los proyectos
                proyectos = await projectService.Index();
            
                //MessageBox.Show(proyectos.Count.ToString());
               
                // Obtener un proyecto por su ID
                /*proyecto = await projectService.Show(1);
                MessageBox.Show(proyecto.Description);
                */
                proyecto = await projectService.Delete(64);

                // Crear un nuevo proyecto.
                // primero se debe crear un objeto anónimo con los datos del nuevo proyecto
                var nuevoProyecto = new
                {
                    name = "Este es el nombre del nuevo proyecto",
                    description = "Esta es la descripción del nuevo proyecto",
                    status = "pendiente",
                    totalHours = 100,
                    //no es necesario enviar el id ni las horas de trabajo, ya que se asignan automáticamente en la API
                    created_at = "2024-08-26"
                };

                //se debe serializar el objeto anónimo a JSON para enviarlo a la API
                var proyectoCreado = await projectService.Create(nuevoProyecto);

                MessageBox.Show(proyectoCreado); //debería mostrar el mensaje de la API

                var proyectoActualizado = new
                {
                    name = "Probando update",
                    description = "Descripción actualizada del proyecto",
                    status = "completado",
                    totalHours = 120,
                    created_at = "2024-08-26"
                };

                var resultadoActualizacion = await projectService.Update(52, proyectoActualizado);
                MessageBox.Show($"Resultado de la actualización del proyecto: {resultadoActualizacion}");


            });
            Task.Run(async () =>
            {
                try
                {
                    // Obtener todos los proyectos
                    proyectos = await projectService.Index();
                    MessageBox.Show($"Número de proyectos: {proyectos.Count}");

                    // Obtener todas las tareas
                    tareas = await taskService.Index();
                    MessageBox.Show($"Número de tareas: {tareas.Count}");

                    // Obtener una tarea por su ID
                    tarea = await taskService.Show(1); // Cambia el ID según sea necesario
                    MessageBox.Show($"Descripción de la tarea: {tarea.Description}");

                    // Eliminar una tarea
                    var tareaEliminada = await taskService.Delete(21); // Cambia el ID según sea necesario
                    if (tareaEliminada == null)
                    {
                        MessageBox.Show("La tarea con ID 21 no se pudo eliminar o no existe.");
                    }
                    else
                    {
                        MessageBox.Show($"Tarea eliminada: {tareaEliminada.Description}");
                    }

                    // Crear una nueva tarea
                    var nuevaTarea = new
                    {
                        description = "Descripción de la nueva tarea",
                        start_date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                        status = "pendiente",
                        hours = "5",
                        area = "Área de ejemplo",
                        project_id = "1", // Cambia según el proyecto asociado
                        user_id = "1" // Cambia según el usuario asignado
                    };

                    var tareaCreada = await taskService.Create(nuevaTarea);
                    MessageBox.Show($"Respuesta al crear tarea: {tareaCreada}");

                    // Actualizar una tarea existente
                    var tareaActualizada = new
                    {
                        description = "Descripción actualizada de la tarea",
                        start_date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                        status = "completado",
                        hours = "10",
                        area = "Área actualizada",
                        project_id = "1", // Cambia según el proyecto asociado
                        user_id = "1" // Cambia según el usuario asignado
                    };

                    var resultadoActualizacion = await taskService.Update(8, tareaActualizada); // Cambia el ID según sea necesario
                    MessageBox.Show($"Resultado de la actualización de la tarea: {resultadoActualizacion}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}");
                }
            });
        }
    }
}
