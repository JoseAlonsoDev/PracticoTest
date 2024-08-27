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
            // Crea un bloque de c�digo as�ncrono ya que llamar un m�todo as�ncrono
            // desde un m�todo s�ncrono puede bloquear la interfaz de usuario
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

                var proyectoActualizado = new
                {
                    name = "Probando update",
                    description = "Descripci�n actualizada del proyecto",
                    status = "completado",
                    totalHours = 120,
                    created_at = "2024-08-26"
                };

                var resultadoActualizacion = await projectService.Update(52, proyectoActualizado);
                MessageBox.Show($"Resultado de la actualizaci�n del proyecto: {resultadoActualizacion}");


            });
            Task.Run(async () =>
            {
                try
                {
                    // Obtener todos los proyectos
                    proyectos = await projectService.Index();
                    MessageBox.Show($"N�mero de proyectos: {proyectos.Count}");

                    // Obtener todas las tareas
                    tareas = await taskService.Index();
                    MessageBox.Show($"N�mero de tareas: {tareas.Count}");

                    // Obtener una tarea por su ID
                    tarea = await taskService.Show(1); // Cambia el ID seg�n sea necesario
                    MessageBox.Show($"Descripci�n de la tarea: {tarea.Description}");

                    // Eliminar una tarea
                    var tareaEliminada = await taskService.Delete(21); // Cambia el ID seg�n sea necesario
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
                        description = "Descripci�n de la nueva tarea",
                        start_date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                        status = "pendiente",
                        hours = "5",
                        area = "�rea de ejemplo",
                        project_id = "1", // Cambia seg�n el proyecto asociado
                        user_id = "1" // Cambia seg�n el usuario asignado
                    };

                    var tareaCreada = await taskService.Create(nuevaTarea);
                    MessageBox.Show($"Respuesta al crear tarea: {tareaCreada}");

                    // Actualizar una tarea existente
                    var tareaActualizada = new
                    {
                        description = "Descripci�n actualizada de la tarea",
                        start_date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"), // ISO 8601 format
                        status = "completado",
                        hours = "10",
                        area = "�rea actualizada",
                        project_id = "1", // Cambia seg�n el proyecto asociado
                        user_id = "1" // Cambia seg�n el usuario asignado
                    };

                    var resultadoActualizacion = await taskService.Update(8, tareaActualizada); // Cambia el ID seg�n sea necesario
                    MessageBox.Show($"Resultado de la actualizaci�n de la tarea: {resultadoActualizacion}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}");
                }
            });
        }
    }
}
