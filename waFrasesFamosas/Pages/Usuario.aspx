<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="waFrasesFamosas.Pages.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center">Usuários
        </h1>
        <hr />
        <div class="card">
            <div class="card-header" style="font-weight: bold;">
                Cadastro de usuários
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <label>Nome</label>
                        <input type="text" id="txtNome" class="form-control" />
                    </div>

                    <div class="col-md-4">
                        <label>Email</label>
                        <input type="email" id="txtEmail" class="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label>Senha</label>
                        <input type="password" id="txtSenha" class="form-control" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <button type="button" onclick="CadastrarUsuario()" class="btn btn-outline-primary">Cadastrar</button>
                    </div>
                </div>
            </div>
        </div>
        <table id="tblUsuarios" class="table table-striped" style="width: 100%"></table>
    </div>

    <div class="modal fade" id="modalEditUser" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Usuário</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-8">
                                <label>Nome:</label>
                                <input id="txtEditNome" type="text" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <label>Email:</label>
                                <input id="txtEditEmail" type="text"  class="form-control"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <label>Senha:</label>
                                <input id="txtEditSenha" type="password"  class="form-control"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="Atualizar($id)">Salva Alterações</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $id = 0;
        function modalEditUser(Id, Nome, Email, Senha) {            
            $id = Id;
            document.getElementById("txtEditNome").value = Nome;
            document.getElementById("txtEditEmail").value = Email;
            document.getElementById("txtEditSenha").value = Senha;
            $('#modalEditUser').modal('show');
        }        
    </script>
    <script src="../Scripts/JS/Usuario.js"></script>
    
</asp:Content>

