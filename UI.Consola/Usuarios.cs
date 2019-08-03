using Business.Entities;
using Business.Logic;
using System;

namespace UI.Consola
{
    class Usuarios
    {
        UsuarioLogic UsuarioNegocio = new UsuarioLogic();
        public void Menu()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú Principal");
                Console.WriteLine("1 - Listado General");
                Console.WriteLine("2 - Consulta");
                Console.WriteLine("3 - Agregar");
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("6 - Salir");
                byte option = 0;
                do
                {
                    try
                    {
                        Console.Write("\nIngrese opción: ");
                        option = byte.Parse(Console.ReadLine());
                        if (!(option > 0 && option <= 6))
                        {
                            throw new Exception();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada inválida. Debe ser un número entero");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Entrada incorrecta");
                    }
                } while (!(option > 0 && option <= 6));
                switch (option)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    case 6:
                        exit = true;
                        break;
                }
            } while (!exit);
        }

        private void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        private void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: " + usr.ID);
            Console.WriteLine("\t\tNombre de Usuario: " + usr.NombreUsuario);
            Console.WriteLine("\t\tClave: " + usr.Clave);
            Console.WriteLine("\t\tHabilitado: " + usr.Habilitado);
            Console.WriteLine();
        }
        private void Consultar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a consultar: ");
            int ID = 0;
            try
            {
                ID = int.Parse(Console.ReadLine());
                MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException)
            {
                Console.WriteLine("ID inválido. Ingrese un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de Usuario(1-Si/Otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {
                Console.WriteLine("El ID debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void Agregar()
        {
            try
            {
                Console.Clear();
                Usuario usuario = new Usuario();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de Usuario(1-Si/Otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                UsuarioNegocio.Save(usuario);
                Console.WriteLine();
                Console.WriteLine("ID: " + usuario.ID);

            }
            catch (FormatException)
            {
                Console.WriteLine("El ID debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine("El ID debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
