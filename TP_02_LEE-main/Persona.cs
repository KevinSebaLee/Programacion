class Persona
{
    public int DNI {get; set;}
    public string Apellido {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string Email {get; set;}

    public Persona(int dni, string apellido, string nombre, DateTime fecha, string mail){
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fecha;
        Email = mail;
    }

    public static int ObtenerEdad(DateTime fechaNacimiento){
        int edad;
        
        edad = DateTime.Today.Year - fechaNacimiento.Year;
        
        return edad;
    }

    public static bool PuedeVotar(int edad){
        bool PuedeVotar = false;

        if(edad > 18){
            PuedeVotar = true;
        }

        return PuedeVotar;
    }
}