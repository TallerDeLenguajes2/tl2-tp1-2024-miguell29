
using System.Text.Json;

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria GetCadeteria()
    {
        try
        {
            var file = "./json/cadeteria.json";
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(pathFile))
            {
                var cadeteriajson = File.ReadAllText(pathFile);
                var cadeteria = JsonSerializer.Deserialize<Cadeteria>(cadeteriajson);
                return cadeteria;
            }
            else
            {
                Console.WriteLine("'cadeteria.csv' -> No encontrado");
                return null;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR AL LEER DATOS DE 'cadeteria.csv'");
            return null;
        }
    }

    public override List<Cadete> GetCadetes()
    {
        try
        {
            var file = "json/cadetes.json";
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(pathFile))
            {
                var json = File.ReadAllText(pathFile);
                var listadocadetes = JsonSerializer.Deserialize<List<Cadete>>(json).ToList();
                return listadocadetes;
            }
            else
            {
                Console.WriteLine("'cadetes.csv' -> No encontrado");
                return null;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR AL LEER DATOS DE 'cadete.csv'");
            return null;
        }
    }
}