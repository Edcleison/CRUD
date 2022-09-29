using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rParametro = "";
            if (!IsPostBack)
            {

                if (Request.QueryString["FUNCIONARIO_E"] != null)
                {
                    rParametro = Request.QueryString["FUNCIONARIO_E"];
                    DataTable dta = DALFuncionario.buscaFuncionarioId(rParametro);
                    txtNome.Text = dta.Rows[0]["NOME"].ToString();
                    txtCpf.Text = dta.Rows[0]["CPF"].ToString();
                    txtRg.Text = dta.Rows[0]["RG"].ToString();
                    txtEmissor.Text = dta.Rows[0]["ORGAO_EMISSOR_RG"].ToString();
                    txtTitulo.Text = dta.Rows[0]["TITULO_ELEITOR"].ToString();
                    txtCnh.Text = dta.Rows[0]["CNH"].ToString();
                    ddlGestor.SelectedValue = dta.Rows[0]["GESTOR"].ToString();
                    txtCep.Text = dta.Rows[0]["CEP"].ToString();
                    txtEndereco.Text = dta.Rows[0]["ENDERECO"].ToString();
                    txtNumero.Text = dta.Rows[0]["NUMERO"].ToString();
                    txtComplemento.Text = dta.Rows[0]["COMPLEMENTO"].ToString();
                    txtBairro.Text = dta.Rows[0]["BAIRRO"].ToString();
                    txtCidade.Text = dta.Rows[0]["CIDADE"].ToString();
                    ddlUf.SelectedValue = dta.Rows[0]["ESTADO"].ToString();
                    txtPontoReferencia.Text = dta.Rows[0]["PONTO_REFERENCIA"].ToString();
                    ddlAtivo.SelectedValue = dta.Rows[0]["ATIVO"].ToString();

                    mdBack.Visible = false;
                    mdTodos.Visible = false;
                }

            }
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {

            int rId = 0;
            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
            rId = DALFuncionario.buscaFuncionarioCpf(cpf);
            if (rId == 0)
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text) && !string.IsNullOrEmpty(txtRg.Text)
               && !string.IsNullOrEmpty(txtEmissor.Text) && !string.IsNullOrEmpty(txtTitulo.Text) && !string.IsNullOrEmpty(txtCnh.Text)
               && !string.IsNullOrEmpty(txtEndereco.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtNumero.Text)
               && !string.IsNullOrEmpty(txtComplemento.Text) && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtCidade.Text)
               && !string.IsNullOrEmpty(txtPontoReferencia.Text))
                {
                    Funcionario fun = new Funcionario();
                    fun.Nome = txtNome.Text;
                    fun.Cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
                    fun.Rg = txtRg.Text.Replace(".", "").Replace("-", "");
                    fun.OrgaoEmissor = txtEmissor.Text.Replace("/", "");
                    fun.TituloEleitor = txtTitulo.Text;
                    fun.Cnh = txtCnh.Text;
                    fun.Gestor = int.Parse(ddlGestor.SelectedValue);
                    DALFuncionario.inserirFuncionario(fun);
                    int id = DALFuncionario.buscaFuncionarioCpf(fun.Cpf);


                    Endereco end = new Endereco();
                    end.IdFuncionario = id;
                    end._Endereco = txtEndereco.Text;
                    end.Cep = txtCep.Text.Replace("-", "");
                    end.Numero = txtNumero.Text;
                    end.Complemento = txtComplemento.Text;
                    end.Bairro = txtBairro.Text;
                    end.Cidade = txtCidade.Text;
                    end.Estado = ddlUf.Text;
                    end.PontoReferencia = txtPontoReferencia.Text;
                    end.Ativo = int.Parse(ddlAtivo.SelectedValue);
                    DALEndereco.inserirEndereco(end);
                    Response.Redirect("~/Index.aspx");

                }
                else
                {
                    string msg = $"<script> alert('Preencha todos os campos'); </script>";
                    Response.Write(msg);
                }


            }
            else
            {
                string msg = $"<script> alert('CPF já cadastrado'); </script>";
                Response.Write(msg);

            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text) && !string.IsNullOrEmpty(txtRg.Text)
               && !string.IsNullOrEmpty(txtEmissor.Text) && !string.IsNullOrEmpty(txtTitulo.Text) && !string.IsNullOrEmpty(txtCnh.Text)
               && !string.IsNullOrEmpty(txtEndereco.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtNumero.Text)
               && !string.IsNullOrEmpty(txtComplemento.Text) && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtCidade.Text)
               && !string.IsNullOrEmpty(txtPontoReferencia.Text))
            {
                Funcionario fun = new Funcionario();
                fun.Nome = txtNome.Text;
                fun.Cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
                fun.Rg = txtRg.Text.Replace(".", "").Replace("-", "");
                fun.OrgaoEmissor = txtEmissor.Text.Replace("/", "");
                fun.TituloEleitor = txtTitulo.Text;
                fun.Cnh = txtCnh.Text;
                fun.Gestor = int.Parse(ddlGestor.SelectedValue);
                DALFuncionario.alterarFuncionario(fun);
                int id = DALFuncionario.buscaFuncionarioCpf(fun.Cpf);


                Endereco end = new Endereco();
                end.IdFuncionario = id;
                end._Endereco = txtEndereco.Text;
                end.Cep = txtCep.Text.Replace("-", "");
                end.Numero = txtNumero.Text;
                end.Complemento = txtComplemento.Text;
                end.Bairro = txtBairro.Text;
                end.Cidade = txtCidade.Text;
                end.Estado = ddlUf.Text;
                end.PontoReferencia = txtPontoReferencia.Text;
                end.Ativo = int.Parse(ddlAtivo.SelectedValue);
                DALEndereco.alterarendereco(end);
                Response.Redirect("~/Index.aspx");

            }


        }
        protected void lnkCancelar_Click(object sender, EventArgs e)
        {

            string cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
            int id = DALFuncionario.buscaFuncionarioCpf(cpf);
            if (id > 0)
            {
                DALEndereco.excluirEndereco(id);
                DALFuncionario.excluirFuncionario(id);
                Response.Redirect("~/Index.aspx");

            }
        }
        protected void lnkTodos_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdTodos.Visible = true;
            carregarTabelaTodos();
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdTodos.Visible = false;
        }
        private void carregarTabelaTodos()
        {


            DataTable rDta = new DataTable();
            rDta = DALFuncionario.buscaFuncionarios();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table id='example' class='display' style='width: 80% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CPF</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>RG</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ORGÃO EMISSOR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>TITULO ELEITOR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CNH</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>GESTOR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CEP</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ENDERECO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NUMERO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>COMPLEMENTO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>BAIRRO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CIDADE</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ESTADO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>PONTO REFERÊNCIA</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center> {dtr["NOME"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center> {dtr["CPF"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["RG"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["ORGAO_EMISSOR_RG"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["TITULO_ELEITOR"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["CNH"]}</center></td>");
                if (dtr["GESTOR"].ToString() == "0")
                {
                    sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>NÃO</center></td>");
                }
                else
                {
                    sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>SIM</center></td>");
                }
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["CEP"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["ENDERECO"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["NUMERO"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["COMPLEMENTO"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["BAIRRO"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["CIDADE"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["ESTADO"]}</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["PONTO_REFERENCIA"]}</center></td>");
                if (dtr["ATIVO"].ToString() == "0")
                {
                    sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>NÂO</center></td>");
                }
                else
                {
                    sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>SIM</center></td>");
                }
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center><a href='Index.aspx?FUNCIONARIO_E={dtr["ID_FUNCIONARIO"].ToString()}'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                sb.AppendLine("</tr>");


            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");


            PanelTodos.Controls.Clear();
            PanelTodos.Controls.Add(new LiteralControl(sb.ToString()));

        }
    }
       
}