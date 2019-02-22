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
    public class DALCategoria
    {
        public static void Inserir(string Nome)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_CATEGORIA", con);
            try
            {
                clsCategoria obj = new clsCategoria();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CATEGORIA", Nome);
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
        public static void Alterar(int Id, string Nome)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_CATEGORIA", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.Parameters.AddWithValue("@CATEGORIA", Nome);
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
        public static void Deletar(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);

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
        
        public static List<clsCategoria> ListarCategorias()
        {
            //
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_CATEGORIA", con);
            List<clsCategoria> lista = new List<clsCategoria>();            
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsCategoria obj = new clsCategoria();
                    obj.Id = Convert.ToInt32(reader["ID_CATEGORIA"]);
                    obj.Nome = Convert.ToString(reader["CATEGORIA"]);
                    lista.Add(obj);
                }
                return lista;
            }
            
           
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
           
        }
        
        public DataTable Localizar(string valor)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);

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
        public static  clsCategoria ListarPorID(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_CATEGORIA", con);
            clsCategoria getCat = new clsCategoria();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);               
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    clsCategoria obj = new clsCategoria();
                    obj.Id = Convert.ToInt32(reader["ID_CATEGORIA"]);
                    obj.Nome = Convert.ToString(reader["CATEGORIA"]);
                    getCat = obj;
                }
                return getCat;

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