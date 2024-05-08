class Superheroe
{
    public string Nombre{ get; set; }
    public string Ciudad{ get; set; }
    public double Peso{ get; set; }
    public double Fuerza{ get; set; }
    public double Velocidad{ get; set; }

    public Superheroe(string nombre, string ciudad, double peso, double fuerza, double velocidad){
        Nombre = nombre;
        Ciudad = ciudad;
        Peso = peso;
        Fuerza = fuerza;
        Velocidad = velocidad;
    }

    public double ObtenerSkill(double Velocidad, double Fuerza){
        Random rand = new Random();
        int Random = rand.Next(1, 10);
        double Skills;

        Skills = Random + Fuerza + Velocidad;

        return Skills;
    }
}