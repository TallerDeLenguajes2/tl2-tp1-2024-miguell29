using System.Text.Json.Serialization;
public class Cadete
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }

    [JsonPropertyName("direccion")]
    public string Direccion { get; set; }

    [JsonPropertyName("telefono")]
    public int Telefono { get; set; }


    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
}