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
    public class DALFrase
    {
        public void Inserir(clsFrase obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_FRASE", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FRASE", obj.Frase);
                cmd.Parameters.AddWithValue("@FK_AUTOR", obj.FKAutor);
                cmd.Parameters.AddWithValue("@FK_CATEGORIA", obj.FKCategoria);
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

        public void Alterar(clsFrase obj)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_FRASE", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.Id);
                cmd.Parameters.AddWithValue("@FRASE", obj.Frase);
                cmd.Parameters.AddWithValue("@FK_AUTOR", obj.FKAutor);
                cmd.Parameters.AddWithValue("@FK_CATEGORIA", obj.FKCategoria);
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
            SqlCommand cmd = new SqlCommand("SPR_DELETAR_FRASE", con);
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FRASES", con);
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

        public DataTable Localizar(string frase, string NomeAutor, string Categoria)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM TBL_FRASES FRASES, AUTORES.NOME_AUTOR, CAT.CATEGORIA
                                                    LEFT JOIN TBL_AUTORES AUTORES ON FRASES.FK_AUTOR = AUTORES.ID_AUTOR
                                                    LEFT JOIN TBL_CATEGORIAS CAT ON FRASES.FK_CATEGORIA = CAT.ID_CATEGORIA
                                                    WHERE (FRASES.FRASE LIKE '%"+frase+@"%' OR FRASES.FRASE = '')  AND 
                                                    (AUTORES.NOME_AUTOR LIKE '%"+ NomeAutor + @"%' OR AUTORES.NOME_AUTOR = '') AND
                                                    (CAT.CATEGORIA LIKE '%"+Categoria+"'% OR CAT.CATEGORIA = '')", con);
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
        public clsFrase ListarPorID(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["dbfrasesfamosas"]);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_FRASE", con);
            clsFrase obj = new clsFrase();
            clsAutor aut = new clsAutor();
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
                    obj.Frase = Convert.ToString(reader["FRASE"]);
                    obj.FKAutor = Convert.ToString(reader["NOME_AUTOR"]);
                    obj.FKCategoria = Convert.ToString(reader["CATEGORIA"]);
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