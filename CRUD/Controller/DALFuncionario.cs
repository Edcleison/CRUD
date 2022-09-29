using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD
{
    public static class DALFuncionario
    {
        static string cnn = @"Server=LAPTOP-JV98S2OU\SQLEXPRESS;Database=CRUD;Trusted_Connection=True;";



        public static void inserirFuncionario(Funcionario fun)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [dbo].[FUNCIONARIO]
                   ([NOME]
                   ,[CPF]
                   ,[RG]
                   ,[ORGAO_EMISSOR_RG]
                   ,[TITULO_ELEITOR]
                   ,[CNH]
                   ,[GESTOR])
                    VALUES(@NOME
                            ,@CPF
                            ,@RG
                            ,@ORGAO_EMISSOR_RG
                            ,@TITULO_ELEITOR
                            ,@CNH
                            ,@GESTOR)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", fun.Nome);
                        cmd.Parameters.AddWithValue("CPF", fun.Cpf);
                        cmd.Parameters.AddWithValue("RG", fun.Rg);
                        cmd.Parameters.AddWithValue("ORGAO_EMISSOR_RG", fun.OrgaoEmissor);
                        cmd.Parameters.AddWithValue("TITULO_ELEITOR", fun.TituloEleitor);
                        cmd.Parameters.AddWithValue("CNH", fun.Cnh);
                        cmd.Parameters.AddWithValue("GESTOR", fun.Gestor);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }
            }
        }

        public static DataTable buscaFuncionarios()
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT 
                                                    F.[ID] AS ID_FUNCIONARIO
,                                                   F.[NOME]
                                                    , F.[CPF]
                                                    , F.[RG]
                                                    , F.[ORGAO_EMISSOR_RG]
                                                    , F.[TITULO_ELEITOR]
                                                    , F.[CNH]
                                                    , F.[GESTOR]
                                                    , E.[CEP]
                                                    , E.[ENDERECO]
                                                    , E.[NUMERO]
                                                    , E.[COMPLEMENTO]
                                                    , E.[BAIRRO]
                                                    , E.[CIDADE]
                                                    , E.[ESTADO]
                                                    , E.[PONTO_REFERENCIA]
                                                    , E.[ATIVO]
                                                    FROM[dbo].[FUNCIONARIO] F
                                                    INNER JOIN[dbo].[ENDERECO] E ON(F.ID = E.ID_FUNCIONARIO)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        return dt;
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }

            }
        }
        public static DataTable buscaFuncionarioId(string Id)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT
                                                    F.[ID] AS ID_FUNCIONARIO
,                                                   F.[NOME]
                                                    , F.[CPF]
                                                    , F.[RG]
                                                    , F.[ORGAO_EMISSOR_RG]
                                                    , F.[TITULO_ELEITOR]
                                                    , F.[CNH]
                                                    , F.[GESTOR]
                                                    , E.[CEP]
                                                    , E.[ENDERECO]
                                                    , E.[NUMERO]
                                                    , E.[COMPLEMENTO]
                                                    , E.[BAIRRO]
                                                    , E.[CIDADE]
                                                    , E.[ESTADO]
                                                    , E.[PONTO_REFERENCIA]
                                                    , E.[ATIVO]
                                                    FROM[dbo].[FUNCIONARIO] F
                                                    INNER JOIN[dbo].[ENDERECO] E ON(F.ID = E.ID_FUNCIONARIO) where F.ID=@ID", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.Connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        return dt;
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }

            }
        }
        public static int buscaFuncionarioCpf(string Cpf)
        {
            Funcionario fun = new Funcionario();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1
                                                    ID
                                                    FROM[DBO].[FUNCIONARIO] 
                                                    WHERE CPF=@CPF ORDER BY ID DESC", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@CPF", Cpf);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            fun.Id = Convert.ToInt32(registro["ID"]);


                        }
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return fun.Id;
                }

            }
        }
        public static void alterarFuncionario(Funcionario fun)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"UPDATE [dbo].[FUNCIONARIO]
                    SET [NOME]= @NOME
                   ,[CPF]=@CPF
                   ,[RG] =@RG
                   ,[ORGAO_EMISSOR_RG] =@ORGAO_EMISSOR_RG
                   ,[TITULO_ELEITOR] =@TITULO_ELEITOR
                   ,[CNH] =@CNH
                   ,[GESTOR]=@GESTOR WHERE CPF=@_CPF", connection))

                {
                    try
                    {
                        cmd.Parameters.AddWithValue("_CPF", fun.Cpf);
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", fun.Nome);
                        cmd.Parameters.AddWithValue("CPF", fun.Cpf);
                        cmd.Parameters.AddWithValue("RG", fun.Rg);
                        cmd.Parameters.AddWithValue("ORGAO_EMISSOR_RG", fun.OrgaoEmissor);
                        cmd.Parameters.AddWithValue("TITULO_ELEITOR", fun.TituloEleitor);
                        cmd.Parameters.AddWithValue("CNH", fun.Cnh);
                        cmd.Parameters.AddWithValue("GESTOR", fun.Gestor);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }
            }
        }          
        public static void excluirFuncionario(int Id)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE FROM[dbo].[FUNCIONARIO]
                                                   WHERE ID =@ID", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.Connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }

            }
        }

    }
}