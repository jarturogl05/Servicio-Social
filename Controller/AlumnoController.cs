using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Controller.OrganizacionController;

namespace Controller
{
    public class AlumnoController
    {
        public OperationResult AddAlumno(String Matricula, String Nombre, String Seccion, String Bloque, String Carrera, String Contraseña)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetAlumnoByMatricula(Matricula).Matricula == null)
            {
                Alumno alumno = new Alumno();
                alumno.Matricula = Matricula;
                alumno.NombreAlumno = Nombre;
                alumno.Seccion = Seccion;
                alumno.Visibilidad = "Visible";
                alumno.Bloque = Bloque;
                alumno.Correo = Matricula + "@estudiantes.uv.mx";
                alumno.Estado = "No asignado";
                alumno.Carrera = Carrera;
                AlumnoDAO alumnoDAO = new AlumnoDAO();
                if ((OperationResult)alumnoDAO.AddAlumno(alumno) == OperationResult.Success)
                {
                    if (CreateUserForAlumno(Matricula, Contraseña, Nombre) == OperationResult.Success)
                    {
                        operation = OperationResult.Success;
                    }
                    else
                    {
                        DeleteAlumno(Matricula);
                        operation = OperationResult.UnknowFail;
                    }
                }
                else
                {
                    operation = OperationResult.UnknowFail;
                }

            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }
            return operation;

        }
        private OperationResult CreateUserForAlumno(String Matricula, String Password, String Nombre)
        {
            OperationResult operation = OperationResult.UnknowFail;
            Usuario user = new Usuario();
            user.Name = Nombre;
            user.Email = Matricula + "@estudiantes.uv.mx";
            user.UserType = "Alumno";
            user.UserName = Matricula;
            user.Password = Password;
            user.RegisterDate = DateTime.Today;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            operation = (OperationResult)usuarioDAO.AddUsuario(user);
            return operation;
        }
        public List<Alumno> GetAlumno()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            List<Alumno> list = alumnoDAO.GetAlumno();
            return list;
        }

        public Alumno GetAlumnoByMatricula(String Matricula)
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            return alumnoDAO.GetAlumnoByMatricula(Matricula);
        }
        public OperationResult DeleteAlumno(String Matricula)
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            return (OperationResult)alumnoDAO.DeleteAlumnoByMatricula(Matricula);
        }
    }
}
