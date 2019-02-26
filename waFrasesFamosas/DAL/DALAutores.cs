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
    public class Autores
    {
        public  void Inserir(clsAutor obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_AUTOR", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOME_AUTOR", obj.Nome);
                cmd.Parameters.AddWithValue("@ORIGEM_AUTOR", obj.Origem);
                cmd.Parameters.AddWithValue("@FOTO_AUTOR", obj.Foto);
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

        public void Alterar(clsAutor obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_AUTOR", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@NOME_AUTOR", obj.Nome);
                cmd.Parameters.AddWithValue("@ORIGEM_AUTOR", obj.Origem);
                cmd.Parameters.AddWithValue("@FOTO_AUTOR", obj.Foto);
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_DELETAR_AUTOR", con);
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

        public static List<clsAutor> SelecionarAutores()
        {
            //SqlCommand cmd = new SqlCommand("SPR_LISTAR_CATEGORIA", con);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_SELECIONAR_AUTORES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            List<clsAutor> lista = new List<clsAutor>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsAutor autor = new clsAutor();
                    autor.Id = Convert.ToInt32(reader["ID_AUTOR"]);
                    autor.Nome = Convert.ToString(reader["NOME_AUTOR"]);
                    autor.Origem = Convert.ToString(reader["ORIGEM_AUTOR"]);
                    autor.Foto = Convert.ToString(reader["FOTO_AUTOR"]);
                    lista.Add(autor);
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

        public DataTable Localizar(string NomeAutor, string OrigemAutor)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM TBL_AUTORES WHERE  (NOME_AUTOR LIKE '% " + NomeAutor + "%') OR (ORIGEM_AUTOR LIKE '%"+OrigemAutor+"'%)", con);
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
        public clsAutor ListarPorID(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_AUTOR", con);
            clsAutor obj = new clsAutor();
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
                    obj.Nome = Convert.ToString(reader["NOME_AUTOR"]);
                    obj.Origem = Convert.ToString(reader["ORIGEM_AUTOR"]);
                    obj.Foto = Convert.ToString(reader["FOTO_AUTOR"]);
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