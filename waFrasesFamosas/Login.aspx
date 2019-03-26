<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="waFrasesFamosas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <link href="Content/CSS/Login.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div class="wrapper fadeInDown">
                <div id="formContent">
                    <div class="fadeIn first">
                        <h2>WEB Frases</h2>
                    </div>
                    <input type="email" id="txtNomeUsuario" class="fadeIn second" name="login" placeholder="Email" />
                    <input type="password" id="txtSenha" class="fadeIn third" name="senha" placeholder="Senha" />
                    <asp:Button ID="btnLogin" runat="server" class="fadeIn fourth" Text="Logar" OnClick="btnLogin_Click" />
                </div>
            </div>
            <div class="container-fluid" style="text-align:center;">
                <hr />
                <button type="button" class="btn btn-link"  onclick="window.location.href='CadastrarUsuario.aspx'" style="text-decoration:none;">Clique aqui para se cadastrar!!</button>
            </div>
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

            function modalMessage(Header, body) {
                document.getElementById("header").innerHTML = Header;
                document.getElementById("body").innerHTML = body;

                $('#myModal').modal('show');
            }
        </script>
        <asp:PlaceHolder ID="phModal" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
