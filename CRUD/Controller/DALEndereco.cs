using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD
{
    public static class DALEndereco
    {
        static string cnn = @"Server=LAPTOP-JV98S2OU\SQLEXPRESS;Database=CRUD;Trusted_Connection=True;";


        public static void inserirEndereco(Endereco end)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [dbo].[ENDERECO]
                   ([ID_FUNCIONARIO]
                   ,[CEP]
                   ,[ENDERECO]
                   ,[NUMERO]
                   ,[COMPLEMENTO]
                   ,[BAIRRO]
                   ,[CIDADE]
                   ,[ESTADO]
                   ,[PONTO_REFERENCIA]
                   ,[ATIVO])
                    VALUES (@ID_FUNCIONARIO
                            ,@CEP
                            ,@ENDERECO
                            ,@NUMERO
                            ,@COMPLEMENTO
                            ,@BAIRRO
                            ,@CIDADE
                            ,@ESTADO
                            ,@PONTO_REFERENCIA
                            ,@ATIVO)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", end.IdFuncionario);
                        cmd.Parameters.AddWithValue("CEP", end.Cep);
                        cmd.Parameters.AddWithValue("ENDERECO", end._Endereco);
                        cmd.Parameters.AddWithValue("NUMERO", end.Numero);
                        cmd.Parameters.AddWithValue("COMPLEMENTO", end.Complemento);
                        cmd.Parameters.AddWithValue("BAIRRO", end.Bairro);
                        cmd.Parameters.AddWithValue("CIDADE", end.Cidade);
                        cmd.Parameters.AddWithValue("ESTADO", end.Estado);
                        cmd.Parameters.AddWithValue("PONTO_REFERENCIA", end.PontoReferencia);
                        cmd.Parameters.AddWithValue("ATIVO", end.Ativo);
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

        public static void alterarendereco(Endereco end)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"UPDATE [dbo].[ENDERECO]   
                    SET[CEP]=@CEP
                   ,[ENDERECO]=@ENDERECO
                   ,[NUMERO]=@NUMERO
                   ,[COMPLEMENTO]=@COMPLEMENTO
                   ,[BAIRRO]=@BAIRRO
                   ,[CIDADE]=@CIDADE
                   ,[ESTADO]=@ESTADO
                   ,[PONTO_REFERENCIA]=@PONTO_REFERENCIA
                   ,[ATIVO]=@ATIVO WHERE ID_FUNCIONARIO=@ID_FUNCIONARIO", connection))

                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", end.IdFuncionario);
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("CEP", end.Cep);
                        cmd.Parameters.AddWithValue("ENDERECO", end._Endereco);
                        cmd.Parameters.AddWithValue("NUMERO", end.Numero);
                        cmd.Parameters.AddWithValue("COMPLEMENTO", end.Complemento);
                        cmd.Parameters.AddWithValue("BAIRRO", end.Bairro);
                        cmd.Parameters.AddWithValue("CIDADE", end.Cidade);
                        cmd.Parameters.AddWithValue("ESTADO", end.Estado);
                        cmd.Parameters.AddWithValue("PONTO_REFERENCIA", end.PontoReferencia);
                        cmd.Parameters.AddWithValue("ATIVO", end.Ativo);
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

        public static void excluirEndereco(int IdFuncionario)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE FROM[dbo].[ENDERECO]
                                                   WHERE ID_FUNCIONARIO =@ID_FUNCIONARIO", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", IdFuncionario);
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