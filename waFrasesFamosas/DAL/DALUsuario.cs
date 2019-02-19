using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using waFrasesFamosas.Class;


namespace waFrasesFamosas.DAL
{
    public class DALUsuario
    {
        public void Inserir(clsUsuario obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_USUARIO", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOME_USUARIO", obj.Nome);
                cmd.Parameters.AddWithValue("@EMAIL_USUARIO", obj.Email);
                cmd.Parameters.AddWithValue("@SENHA_USUARIO", obj.Senha);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        public void Alterar(clsUsuario obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_USUARIO", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@NOME_USUARIO", obj.Nome);
                cmd.Parameters.AddWithValue("@EMAIL_USUARIO", obj.Email);
                cmd.Parameters.AddWithValue("@SENHA_USUARIO", obj.Senha);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        public void Deletar(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_DELETAR_USUARIO", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
        //Ocorre uma sobrecarga dos metodos Localizar. Se não for passado nenhum parametro ele ira executar o metodo
        //abaixo, pois não possui parametros. Caso tenha ele irá executar o que possui.

        public DataTable Localizar()
        {
            //SqlCommand cmd = new SqlCommand("SPR_LISTAR_CATEGORIA", con);
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOME_USUARIO, EMAIL_USUARIO * FROM TBL_USUARIOS", con);
            try
            {
                da.Fill(tabela);
                return tabela;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable Localizar(string NomeUsuario, string EmailUsuario)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM TBL_USUARIOS WHERE NOME_USUARIO LIKE '%"+NomeUsuario+"%' OR EMAIL_USUARIO LIKE '%"+EmailUsuario+"%'", con);
            try
            {
                da.Fill(tabela);
                return tabela;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public clsUsuario ListarPorID(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_USUARIO", con);
            clsUsuario obj = new clsUsuario();            
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    obj.Id = Convert.ToInt32(reader["ID"]);
                    obj.Nome = Convert.ToString(reader["NOME_USUARIO"]);
                    obj.Email = Convert.ToString(reader["EMAIL_USUARIO"]);                   
                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
    }
}