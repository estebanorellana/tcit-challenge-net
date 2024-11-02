using api.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(ILogger<PersonaController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna una lista de Personas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public dynamic List()
        {
            var result = new Model.PersonaModel().List();

            switch (result.status)
            {
                case "ok":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 200 };
                case "error":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                case "exception":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                default:
                    return new ContentResult { Content = "", ContentType = "application/json", StatusCode = 401 };

            }
        }

        /// <summary>
        /// Agrega un Registro de Persona
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public dynamic Add(PersonaModel model)
        {
            var result = new Model.PersonaModel().Add(model);

            switch (result.status)
            {
                case "ok":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 200 };
                case "error":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                case "exception":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                default:
                    return new ContentResult { Content = "", ContentType = "application/json", StatusCode = 401 };

            }
        }

        /// <summary>
        /// Elimina un Registro de Persona en base al id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public dynamic Delete(int id)
        {
            var result = new Model.PersonaModel().Delete(id);

            switch (result.status)
            {
                case "ok":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 200 };
                case "error":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                case "exception":
                    return new ContentResult { Content = JsonConvert.SerializeObject(result), ContentType = "application/json", StatusCode = 500 };
                default:
                    return new ContentResult { Content = "", ContentType = "application/json", StatusCode = 401 };

            }
        }
    }
}