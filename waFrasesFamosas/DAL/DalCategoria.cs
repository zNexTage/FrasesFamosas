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
    public class DalCategoria
    {
        public void Inserir(clsCategoria obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_CATEGORIA", con);
            try
            {              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CATEGORIA", obj.Nome);
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
        public void Alterar(clsCategoria obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_CATEGORIA", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@CATEGORIA", obj.Nome);
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
            SqlCommand cmd = new SqlCommand("SPR_DELETAR_CATEGORIA", con);
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_CATEGORIAS", con);
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
        
        public DataTable Localizar(string valor)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_CATEGORIAS WHERE  CATEGORIA LIKE '% "+valor+"%'", con);
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
        public clsCategoria ListarPorID(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_CATEGORIA", con);
            clsCategoria obj = new clsCategoria();
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
                    obj.Nome = Convert.ToString(reader["CATEGORIA"]);
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