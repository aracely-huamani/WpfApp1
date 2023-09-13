using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Cadena de conexión a la base de datos
        public static string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS;Initial Catalog=Tecsup2023;User ID=tecsup;Password=1234";


        public MainWindow()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = LoadCollectionData;

        }
        private List<Student> LoadCollectionData()
        {
            List<Student> estudiantes = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para seleccionar datos
                string query = "SELECT Id, FirstName, LastName FROM Estudiantes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer datos de la fila actual
                            int id = reader.GetInt32(0); // Suponiendo que Id es un entero
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);

                            // Crear un objeto Student y agregarlo a la lista
                            Student student = new Student
                            {
                                Id = id,
                                FirstName = firstName,
                                LastName = lastName
                            };
                            estudiantes.Add(student);
                        }
                    }

                }

                private void RowColorButton_Click(object sender, RoutedEventArgs e)
                {
                    Student author = (Student)McDataGrid.SelectedItem;
                    //  MessageBox.Show("Selected author: " + author.Name);
                }
            }
        }
    }
}