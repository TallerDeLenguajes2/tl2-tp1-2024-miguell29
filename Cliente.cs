class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string datosReferenciaDireccion;

    public Cliente()
    {
        
    }
    public Cliente(string nombre, string direccion, int telefono, string datosReferenciaDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }
    

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
}