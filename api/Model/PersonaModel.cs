using Npgsql;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api.Model
{
    public class PersonaModel
    {
        //ATRIBUTOS
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


        ///OPERACIONES
        public dynamic List()
        {
            try
            {
                List<PersonaModel> personas = new List<PersonaModel>();

                string sql = "select id, nombre, descripcion from persona";
                var conecction = new Conecction().Connect();

                using var cmd = new NpgsqlCommand(sql, conecction);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var persona = new PersonaModel() { Id = reader.GetInt32(0), Nombre = reader.GetString(1), Descripcion = reader.GetString(2) };
                    personas.Add(persona);
                }

                conecction.Close();

                return new { status = "ok", message = "Personas listadas correctamente.", body = personas };
            }
            catch (Exception ex)
            {
                return new { status = "exception", message = ex.ToString() };
            }
        }

        public dynamic Add(PersonaModel model)
        {
            try
            {
                List<PersonaModel> personas = new List<PersonaModel>();

                var conecction = new Conecction().Connect();

                string sql = "INSERT INTO persona (nombre, descripcion) VALUES (@nombre, @descripcion)";

                using var cmd = new NpgsqlCommand(sql, conecction);
                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", model.Descripcion);
                int affected = cmd.ExecuteNonQuery();

                conecction.Close();

                if (affected > 0)
                {
                    return new { status = "ok", message = "Persona creada correctamente." };
                }
                else
                {
                    return new { status = "error", message = "Persona no pudo se creada." };
                }
            }
            catch (Exception ex)
            {
                return new { status = "exception", message = ex.ToString() };
            }
        }

        public dynamic Delete(int id)
        {
            try
            {
                List<PersonaModel> personas = new List<PersonaModel>();

                var conecction = new Conecction().Connect();

                string sql = "DELETE FROM persona WHERE id = @id";

                using var cmd = new NpgsqlCommand(sql, conecction);
                cmd.Parameters.AddWithValue("@id", id);
                int affected = cmd.ExecuteNonQuery();

                conecction.Close();

                if (affected > 0)
                {
                    return new { status = "ok", message = "Persona eliminada correctamente." };
                }
                else
                {
                    return new { status = "error", message = "Persona no pudo se eliminada." };
                }
            }
            catch (Exception ex)
            {
                return new { status = "exception", message = ex.ToString() };
            }
        }
    }
}