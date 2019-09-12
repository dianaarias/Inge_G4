using Manual_ASP_NET_WEB.Models;
using Manual_ASP_NET_WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manual_ASP_NET_WEB.Controllers
{
    public class InformacionGeneralController : Controller
    {
        //Establece la conexión con el modelo para poder ejecutar consultas con linq
        private Manual_ASP_NET_DBEntities db = new
   Manual_ASP_NET_DBEntities();
        // GET: InformacionGeneral
        public ActionResult Index()
        {
            //Se obtienen los datos para mandarle a la vista
            //Se obtiene la cantidad de médicos registrados
            int cantidadMedicos = db.Medicos.Count();

            //Se obtiene la cantidad de pacientes registrados
            int cantidadPacientes = db.Pacientes.Count();

            //Se obtiene la cantidad de contultas registradas
            int cantidadConsultas = db.Consultas.Count();

            //Obtener cantidad de personas que pesan mas de 60
            int cantMayorSesenta = db.Pacientes.Where(x => x.Peso > 60).Count();
            //Se crea el objeto con los datos obtenidos para enviarle a la vista
            var informacionObtenidaViewModel = new
InformacionGeneralViewModel
 {
     CantidadMedicos = cantidadMedicos,
     CantidadPacientes = cantidadPacientes,
     CantidadConsultas = cantidadConsultas,
     CantidadMayorSesenta = cantMayorSesenta
 };
            //Se retorna la vista con la cantidad de medicos, pacientes, y consultas actuales
            return View(informacionObtenidaViewModel);
        }
    }
}