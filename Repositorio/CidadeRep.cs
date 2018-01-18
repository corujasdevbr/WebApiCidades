using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApiCidades.Models;

namespace WebApiCidades.Repositorio
{
    public class CidadeRep
    {
         string connectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;uid=sa;pwd=senai@123";


        public List<CidadeModel> Listar(){
            List<CidadeModel> lstCidades = new List<CidadeModel>();
            
            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades";

            SqlCommand cmd = new SqlCommand(SqlQuery,con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read()){
                CidadeModel cidade = new CidadeModel();

                cidade.Id = Convert.ToInt16(sdr["Id"]);
                cidade.Nome = sdr["Nome"].ToString();
                cidade.Estado = sdr["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt32(sdr["Habitantes"]);

                lstCidades.Add(cidade);
            }

            con.Close();

            return lstCidades;
        }

        public void Cadastrar(CidadeModel cidade){
            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "insert into Cidades(Nome, Estado, Habitantes)" + 
            "values('" + cidade.Nome +"','"+ cidade.Estado + "'," + cidade.Habitantes+")";           
            
            SqlCommand cmd = new SqlCommand(SqlQuery,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string Editar(CidadeModel cidade){
            SqlConnection con = new SqlConnection(connectionString);
            string msg;   
            try
            {                       
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Cidades set nome = @n, estado =@e, habitantes = @h where id =@id";
                cmd.Parameters.AddWithValue("@n", cidade.Nome);
                cmd.Parameters.AddWithValue("@e", cidade.Estado );
                cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
                cmd.Parameters.AddWithValue("@id", cidade.Id);
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if(r > 0)
                    msg = "Atualização Efetuada";
                else
                    msg = "Não foi possível atualizar";

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            } 
            catch (System.Exception e)
            {
                throw new Exception("Erro inesperado " + e.Message);
                throw;
            } 
            finally{
                con.Close();
            }

            return msg;
        }

        public string Excluir(int Id){
            SqlConnection con = new SqlConnection(connectionString);
            string msg;   
            try
            {                       
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Cidades where id =@id";
                cmd.Parameters.AddWithValue("@id", Id);
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if(r > 0)
                    msg = "Atualização Efetuada";
                else
                    msg = "Não foi possível atualizar";

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            } 
            catch (System.Exception e)
            {
                throw new Exception("Erro inesperado " + e.Message);
                throw;
            } 
            finally{
                con.Close();
            }

            return msg;
        }
    }
}