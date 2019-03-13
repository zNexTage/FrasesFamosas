<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="waFrasesFamosas.Pages.CadastrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <link href="Content/CSS/loadingGIF.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="preloader"></div>
    <form id="form1" runat="server">
        <div>
            <header>
                <nav class="navbar navbar-expand-lg navbar navbar-dark bg-primary">
                    <a class="navbar-brand" href="#">WEB Frases</a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                        <div class="navbar-nav">
                            <a class="nav-item nav-link active" href="Login.aspx">Logar <span class="sr-only">(current)</span></a>
                            <a class="nav-item nav-link" href="CadastrarUsuario.aspx">Cadastrar</a>
                        </div>
                    </div>
                </nav>
            </header>
            <main>
                <div class="container-fluid">
                    <h1 style="text-align: center">Cadastrar Usuário
                    </h1>
                    <hr />
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Nome:
                            </label>
                            <input type="text" class="form-control" id="txtNome" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Email:
                            </label>
                            <input type="email" class="form-control" id="txtEmail" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Senha:
                            </label>
                            <input type="password" class="form-control" id="txtSenha" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <button class="btn btn-success" id="btCadastrar" onclick="CadastrarUsuario();return false;">Cadastrar</button>
                        </div>
                    </div>
                    <div class="alert alert-success" id="alertSucesso" role="alert" style="display:none">
                        Conta criada com sucesso!!! <a href="Login.aspx" style="text-decoration:none;">Clique aqui para logar</a>
                    </div>
                </div>
            </main>
        </div>
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="header"></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p id="body"></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="close">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(window).on("load", function (e) {
                $('.preloader').fadeOut(1700);
            });
            function modalMessage(Header, body) {
                document.getElementById("header").innerHTML = Header;
                document.getElementById("body").innerHTML = body;

                $('#myModal').modal('show');
            }
            function CadastrarUsuario() {
                var Nome = $('#txtNome').val();
                var Email = $('#txtEmail').val();
                var Senha = $('#txtSenha').val();

                if (Nome == "" || Email == "" || Senha == "") {
                    modalMessage('Aviso!!', 'Preencha todos os campos');
                }
                else {
                    var Dados = { Nome: Nome, Email: Email, Senha: Senha }
                    $.ajax({
                        url: "Pages/Usuario.aspx/ChecarEmail",
                        data: JSON.stringify({ Usuario: Dados }),
                        dataType: "JSON",
                        type: "POST",
                        contentType: "Application/JSON; charset=utf-8",
                        success: function (data) {
                            if (data.d == false) {
                                $.ajax({
                                    url: "Pages/Usuario.aspx/CadastrarUsuario",
                                    data: JSON.stringify({ Usuario: Dados }),
                                    dataType: "JSON",
                                    type: "POST",
                                    contentType: "Application/JSON; charset=utf-8",
                                    success: function () {
                                        modalMessage('Sucesso', 'Usuário cadastrado');
                                        $('#txtNome').val('');
                                        $('#txtEmail').val('');
                                        $('#txtSenha').val('');
                                        $('#alertSucesso').fadeIn('slow');
                                    },
                                    error: function () {
                                        modalMessage('Aviso!!!', 'Ocorreu um erro ao cadastrar')
                                    }
                                })
                            }
                            else {
                                modalMessage('Aviso!!!', 'Esse email já está cadastrado no nosso sistema, tente novamente!!!!');
                            }
                        },
                        error: function () {
                            modalMessage('Aviso!!!', 'Ocorreu um erro ao cadastrar')
                        }
                    })
                }
            }
        </script>
    </form>


</body>
</html>
