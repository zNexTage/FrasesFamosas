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
    public class DALFrases
    {
        public static void InserirFrase(string Frase, int FKAutor, int FKCategoria)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_INSERIR_FRASE", con);
            try
            {               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FRASE", Frase);
                cmd.Parameters.AddWithValue("@FK_AUTOR", FKAutor);
                cmd.Parameters.AddWithValue("@FK_CATEGORIA", FKCategoria);
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

        public static void AtualizarFrase(int Id, string Frase, string FKAutor, string FKCategoria)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_ATUALIZAR_FRASE", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.Parameters.AddWithValue("@FRASE", Frase);
                cmd.Parameters.AddWithValue("@FK_AUTOR", FKAutor);
                cmd.Parameters.AddWithValue("@FK_CATEGORIA", FKCategoria);
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

        public static void RemoverFrase(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
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

        public static List<clsFrase> SelecionarFrases()
        {          
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_SELECIONAR_FRASES", con);
            List<clsFrase> lista = new List<clsFrase>();
            
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsFrase Frase = new clsFrase();
                    Frase.Id = Convert.ToInt32(reader["ID_FRASE"]);
                    Frase.Frase = Convert.ToString(reader["FRASE"]);
                    Frase.getAutorName = Convert.ToString(reader["NOME_AUTOR"]);                    
                    Frase.getCategoriaName = Convert.ToString(reader["CATEGORIA"]);                    
                    lista.Add(Frase);
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
        public  static clsFrase SelecionarPeloId(int Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbfrasesfamosas"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SPR_LISTAR_POR_ID_FRASE", con);
            clsFrase obj = new clsFrase();
           
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    obj.Id = Convert.ToInt32(reader["ID_FRASE"]);
                    obj.Frase = Convert.ToString(reader["FRASE"]);
                    obj.getAutorName = Convert.ToString(reader["NOME_AUTOR"]);
                    obj.getCategoriaName = Convert.ToString(reader["CATEGORIA"]);
                    obj.FKAutor = Convert.ToInt32(reader["FK_AUTOR"]);
                    obj.FKCategoria = Convert.ToInt32(reader["FK_CATEGORIA"]);
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