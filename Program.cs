


Console.WriteLine(@"            *Seleccione la fuente de datos*
    (1) CSV
    (2) JSON
    
    (por defecto JSON - cualquier tecla)");
if (int.TryParse(Console.ReadLine(), out int opcion))
{
    Console.Clear();
    Console.WriteLine("Cargando Datos...");
    Thread.Sleep(1000);
    Console.Clear();
    AccesoADatos datos = opcion switch
    {
        1 => new AccesoCSV(),
        _ => new AccesoJSON(),
    };
    List<Cadete> listadoCadetes = datos.GetCadetes();
    Cadeteria cadeteria = datos.GetCadeteria();
    if (listadoCadetes == null || cadeteria == null)
    {
        Console.WriteLine("No es posible iniciar la aplicacion - ERROR al cargar datos");
    }
    else
    {
        Console.WriteLine(@"->            BIENVENIDO            <-");
        var sistema = new Sistema(listadoCadetes, cadeteria);
        sistema.Init();

    }
}

