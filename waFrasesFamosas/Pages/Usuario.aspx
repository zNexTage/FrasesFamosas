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
        <table id="tblUsuarios" class="table table-striped" style="width:100%"></table>
    </div>
    <script src="../Scripts/JS/Usuario.js"></script>
</asp:Content>

