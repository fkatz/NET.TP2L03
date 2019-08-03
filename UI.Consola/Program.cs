using Data.Database;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuarios usuarios = new Usuarios();
            AcademiaContext context = new AcademiaContext();
            usuarios.Menu();
        }
    }
}
