public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadete;

    public Pedido(int nro, string obs = "ninguna", Estado estado = Estado.EnPreparacion)
    {
        AgregarCliente();
        Nro = nro;
        this.obs = obs;
        this.estado = estado;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public void VerDireccionCliente()
    {
        Console.WriteLine(@$"   Cliente: {cliente.Nombre}   -   Direccion: {cliente.Direccion}");
    }
    public void VerDatosCliente()
    {
        Console.WriteLine(@$"***
            Datos Del Cliente:
        Nombre: {cliente.Nombre}
        Direccion: {cliente.Direccion}
        Telefono: {cliente.Telefono}
        Datos de Referencia: {cliente.DatosReferenciaDireccion}
    ***");
    }
    private void AgregarCliente(){
        Console.WriteLine(@"*Datos de cliente*");
        Console.WriteLine("Ingrese el nombre");
        var nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion");
        var direccion = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono");
        if(int.TryParse(Console.ReadLine(),out var telefono))
        Console.WriteLine("Ingrese algun dato de Referencia");
        var datosReferencia = Console.ReadLine();
        cliente = new Cliente(nombre, direccion, telefono, datosReferencia);
    }
}