using CSR_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Datos
{
    public class Datos_Contrato : I_CRUD<Contrato>
    {
        public void Actualizar(Contrato obj)
        {
            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Contrato_Update";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@id", obj.id);
                comando.Parameters.AddWithValue("@tipo", obj.tipo);
                comando.Parameters.AddWithValue("@notas", obj.notas);
                comando.Parameters.AddWithValue("@fecha_Vencimiento", obj.fecha_Vencimiento);
                comando.Parameters.AddWithValue("@fecha_Actual", obj.fecha_Actual);
                comando.Parameters.AddWithValue("@idArrendatario", obj.arrendatario.cedula);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Este metodo no lo usamos en este caso
        //por que para elliminar un arrendatario 
        //recivimos un string y este un int
        


        public void Eliminar(int id)
        {

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Contrato_DeleteRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                comando.Parameters.AddWithValue("@id",id);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Insertar(Contrato obj)
        {

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {

                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion SP
                string sql = "SP_Contrato_Insert";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4: Enviar los parametros
                //comando.Parameters.AddWithValue("@id", obj.id);
                comando.Parameters.AddWithValue("@tipo", obj.tipo);
                comando.Parameters.AddWithValue("@notas", obj.notas);
                comando.Parameters.AddWithValue("@fecha_Vencimiento", obj.fecha_Vencimiento);
                comando.Parameters.AddWithValue("@fecha_Actual", obj.fecha_Actual);
                comando.Parameters.AddWithValue("@idArrendatario", obj.arrendatario.cedula);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        //Este metodo no lo utilizamos por que recive un int
        //Utilizamos un string para seleccionar un Arrendatario
        
        public Contrato SeleccionarPorID(int id)
        {
            Contrato contrato = null;

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Contrato_SelectRow";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@id", id);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    contrato = new Contrato
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        tipo = Convert.ToInt32(reader["tipo"].ToString()),
                        notas = reader["notas"].ToString(),
                        fecha_Vencimiento = Convert.ToDateTime(reader["fecha_Vencimiento"].ToString()),
                        fecha_Actual = Convert.ToDateTime(reader["fecha_Actual"].ToString()),
                       // arrendatario = new Datos_Arrendatario().SeleccionarPorID(reader["cedula"].ToString()),
                        
                    };


                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return contrato;
        }

        public List<Contrato> SeleccionarTodos()
        {
            List<Contrato> lista = new List<Contrato>();

            //Paso 1: conexion BD
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                //Abrir la conexion
                conexion.Open();
                //Paso 2: Instruccion
                string sql = "SP_Contrato_SelectAll";

                //Paso 3: Comando para ejecutar el paso 2
                SqlCommand comando = new SqlCommand(sql, conexion);

                //Paso 4.1: Usar el Procedimineto Almacenado
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Paso 5: Ejecutar el Comando que permite obtener registros de la tabla
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Contrato contrato = new Contrato
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        tipo = Convert.ToInt32(reader["tipo"].ToString()),
                        notas = reader["notas"].ToString(),
                        fecha_Vencimiento = Convert.ToDateTime(reader["fecha_Vencimiento"].ToString()),
                        fecha_Actual = Convert.ToDateTime(reader["fecha_Actual"].ToString()),
                        // arrendatario = new Datos_Arrendatario().SeleccionarPorID(reader["cedula"].ToString()),

                    };

                    lista.Add(contrato);

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return lista;

        }
    }
}