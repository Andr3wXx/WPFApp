using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTask();
        }


        void AddMessage(string message)
        {
            Messages.Content +=
                $"Mensaje: {message}," +
                $"Hilo actual: {Thread.CurrentThread.ManagedThreadId}\n";
        }
        void CreateTask()
        {
            Task T;
            // ¿Que es el delegado? Apuntadores  a funciones
            //Por ejemplo: Action y Func
            Action Code = new Action(ShowMessege);
            T = new Task(Code);
            Task T2 = new Task(delegate
            {
                MessageBox.Show("Ejecutando una tarea en metodo anonimo");
            }
            );
            Task T3A = new Task(ShowMessege);
            Task T3 = new Task(
                () => ShowMessege());

            // Expresión Lambda;
            // (Parametros de entrada( =>) Expresión
            //() => Expreión
            // El operador lambda (=>) se lee como se "Va hacia"


            Task T4 = new Task(() =>  MessageBox.Show("Ejecutando la Tarea 4"));

            Task T5 = new Task(() =>
            {
                DateTime CurrentDate = DateTime.Today;
                DateTime StartDate = CurrentDate.AddDays(30);
                MessageBox.Show($"Tarea 5. Fecha calculada: {StartDate}");
            }
            );

            Task T6 = new Task((message) =>
            MessageBox.Show(message.ToString()), "Expresión Lambda con parametros.");

            Task T7 = new Task(() => AddMessage("Ejecutando la Tarea"));
            T7.Start();
            AddMessage("En el hilo principal");
        }

        void ShowMessege()
        {
            MessageBox.Show("Ejecutando el metodo ShowMessage");
        }

        

}
}