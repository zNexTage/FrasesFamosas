<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="waFrasesFamosas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center;">Bem vindo
            <asp:Label ID="lblNomeUsuario" runat="server" Text=""></asp:Label>
        </h1>
        <hr />
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header" style="font-weight: bold;">
                        Opções para navegação!!!               
                    </div>
                    <div class="card-body">
                        <h5 class="card-title" style="text-align: center;">Escolha uma das opções e navegue pelo site!!!</h5>
                        <div class="row">
                            <div class="col-md-2" id="divBts"></div>
                            <div class="col-md-5">
                                <div class="btn-group" role="group" aria-label="Basic example">
                                    <button type="button" class="btn btn-outline-primary btn-lg" onclick="window.location.href='Frases.aspx'">Frases</button>
                                    <button type="button" class="btn btn-outline-info btn-lg" onclick="window.location.href='Autor.aspx'">Autores</button>
                                    <button type="button" class="btn btn-outline-success btn-lg" onclick="window.location.href='Categoria.aspx'">Categorias</button>
                                    <button type="button" class="btn btn-outline-dark btn-lg" onclick="window.location.href='Usuario.aspx'" id="btUsuario">Usuários</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    
</asp:Content>
