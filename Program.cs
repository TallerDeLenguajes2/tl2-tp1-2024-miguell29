

Console.Clear();
Console.WriteLine("Cargando Datos...");
Thread.Sleep(1000);
Console.Clear();

List<Cadete> listadoCadetes = Datos.GetCadetes();
Cadeteria cadeteria = Datos.GetCadeteria();
if (listadoCadetes == null || cadeteria == null)
{
    Console.WriteLine("No es posible iniciar la aplicacion.");
}else
{
    Console.WriteLine(@"->            BIENVENIDO            <-");
    var sistema = new Sistema(listadoCadetes, cadeteria);
    sistema.Init();

}
