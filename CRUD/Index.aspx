<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.0/jquery.mask.js"></script>


  <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js"></script>

    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.2.3/css/buttons.dataTables.min.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/icon/themify-icons/themify-icons.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/icon/icofont/css/icofont.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/icon/feather/css/feather.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/icon/font-awesome/css/font-awesome.min.css") %>" />



    <script>
        $(document).ready(function () {
            var $CampoCpf = $("#txtCpf");
            $CampoCpf.mask('000.000.000-00', { reverse: true });
            var $CampoRg = $("#txtRg");
            $CampoRg.mask('00.000.000-0', { reverse: true });
            var $CampoEmissor = $("#txtEmissor");
            $CampoEmissor.mask('AAA/AA', { reverse: true });
            var $CampoCep = $("#txtCep");
            $CampoCep.mask('00000-000', { reverse: true });
        });
    </script>
    <script>
        function apenasNumeros(evt) {
            if (window.event) {
                var charCode = evt.keyCode;
            } else if (evt.which) {
                var charCode = evt.which
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "emptyTable": "Não foram encontrados registros",
                "language": {
                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
                    },
                    "search": "Pesquisar:",

                },
                "scrollY": '150px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": true,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ]



            });
        })
    </script>

    <style>
        .modal-personalizado {
            min-width: 95%;
            margin-left: auto;
            margin-right: auto;
        }

            .modal-personalizado.modal-content {
                min-height: 50vh;
            }

        .modal-body {
            max-height: calc(120vh - 210px);
            overflow-y: auto;
            overflow-x: auto;
        }
    </style>
    <title>Cadastro de Funcionários Novo Registro</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h5>Dados do Funcionário</h5>
        </div>
        <hr />
        <div class="jumbotron">
            <div class="form-group">
                <label>Nome:</label>
                <asp:TextBox ID="txtNome" class="form-control" runat="server" MaxLength="50" />
            </div>
            <div class="form-group">
                <label>CPF</label>
                <asp:TextBox class="form-control" runat="server" ID="txtCpf" />
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>RG:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtRg" />
                    </div>
                    <div class="col">
                        <label>Órgão emissor do RG:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtEmissor" />
                    </div>
                    <div class="col">
                        <label>Titulo de Eleitor:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtTitulo" MaxLength="12" onkeypress="return apenasNumeros(event);" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>CNH:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtCnh" MaxLength="11" onkeypress="return apenasNumeros(event);" />
                    </div>
                    <div class="col">
                        <asp:DropDownList runat="server" class="form-check-label" ID="ddlGestor">
                            <asp:ListItem Value="0">NÃO</asp:ListItem>
                            <asp:ListItem Value="1">SIM</asp:ListItem>
                        </asp:DropDownList>
                        <label>Considerar como gestor?</label>
                    </div>
                    <div class="col-4">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>CEP:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtCep" />
                    </div>

                    <div class="col">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>Endereço:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtEndereco" MaxLength="50" />
                    </div>

                    <div class="col-2">
                        <label>Número:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtNumero" MaxLength="10" onkeypress="return apenasNumeros(event);" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>Complemento:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtComplemento" MaxLength="20" />
                    </div>

                    <div class="col">
                        <label>Bairro:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtBairro" MaxLength="20" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>Cidade:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtCidade" MaxLength="20" />
                    </div>

                    <div class="col">
                        <label>Estado:</label>
                        <asp:DropDownList runat="server" class="form-control" ID="ddlUf">
                            <asp:ListItem>AC</asp:ListItem>
                            <asp:ListItem>AL</asp:ListItem>
                            <asp:ListItem>AP</asp:ListItem>
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>BA</asp:ListItem>
                            <asp:ListItem>CE</asp:ListItem>
                            <asp:ListItem>DF</asp:ListItem>
                            <asp:ListItem>ES</asp:ListItem>
                            <asp:ListItem>GO</asp:ListItem>
                            <asp:ListItem>MA</asp:ListItem>
                            <asp:ListItem>MT</asp:ListItem>
                            <asp:ListItem>MS</asp:ListItem>
                            <asp:ListItem>MG</asp:ListItem>
                            <asp:ListItem>PA</asp:ListItem>
                            <asp:ListItem>PB</asp:ListItem>
                            <asp:ListItem>PR</asp:ListItem>
                            <asp:ListItem>PE</asp:ListItem>
                            <asp:ListItem>PI</asp:ListItem>
                            <asp:ListItem>RJ</asp:ListItem>
                            <asp:ListItem>RN</asp:ListItem>
                            <asp:ListItem>RS</asp:ListItem>
                            <asp:ListItem>RO</asp:ListItem>
                            <asp:ListItem>RR</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>SP</asp:ListItem>
                            <asp:ListItem>SE</asp:ListItem>
                            <asp:ListItem>TO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-2">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label>Ponto de Referência:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtPontoReferencia" MaxLength="50" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-2">
                        <label>Ativo? </label>
                        <asp:DropDownList runat="server" class="form-control" ID="ddlAtivo">
                            <asp:ListItem Value="0">N&#195;O</asp:ListItem>
                            <asp:ListItem Value="1">SIM</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-3">
                </div>
                <div class="col">
                    <asp:LinkButton runat="server" ID="lnkNovo" OnClick="lnkNovo_Click" class="btn btn-success">Novo</asp:LinkButton>
                </div>
                <div class="col">
                    <asp:LinkButton runat="server" ID="lnkSalvar" OnClick="lnkSalvar_Click" class="btn btn-primary">Salvar</asp:LinkButton>
                </div>
                <div class="col">
                    <asp:LinkButton runat="server" ID="lnkCancelar" OnClick="lnkCancelar_Click" class="btn btn-danger">Cancelar</asp:LinkButton>
                </div>
                <div class="col">
                    <asp:LinkButton runat="server" ID="lnkTodos" OnClick="lnkTodos_Click" class="btn btn-info">Mostrar Todos</asp:LinkButton>
                </div>
                <div class="col-3">
                </div>
            </div>
        </div>
        <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
        <div class="modal fade show" id="mdTodos" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Todos Funcionários:</h5>
                        <asp:LinkButton runat="server" class="close" data-dismiss="modal" OnClick="btnVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="row">
                                <div id="PanelTodos" runat="server" visible="true">
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
