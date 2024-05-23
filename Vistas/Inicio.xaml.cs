using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ClaseM6.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://192.168.17.29/appmovil/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> stud;


    public Inicio()
	{
		InitializeComponent();
		Obtener();
	}
	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List <Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		stud = new ObservableCollection<Estudiante>(mostrarEst);
		ListaEstudiantes.ItemsSource = stud;
	}
}