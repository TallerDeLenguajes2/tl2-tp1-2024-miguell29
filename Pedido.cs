public class Pedido
{
    private int Nro;
    private string obs;
    private Cliente cliente;
    private Estado estado;

    public Pedido(int nro, string obs, Estado estado = Estado.EnPreparacion)
    {
        AgregarCliente();
        Nro = nro;
        this.obs = obs;
        this.estado = estado;
    }

    public int Nro1 { get => Nro; set => Nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }

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