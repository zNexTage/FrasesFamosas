<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Autor.aspx.cs" Inherits="waFrasesFamosas.Pages.Autor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center;">Autores
        </h1>
        <hr />
        <div class="row">
            <div class="col-md-3">
                <label>
                    Nome:
                </label>
                <input type="text" id="txtNome" class="form-control" name="txtNome" />
            </div>
            <div class="col-md-3">
                <label>
                    Origem(Pais, estado, cidade e etc...):
                </label>
                <input type="text" id="txtOrigem" class="form-control" name="txtOrigem" />
            </div>
            <div class="col-md-3">
                <label>
                    Foto do Autor:
                </label>
                <asp:FileUpload ID="fileFoto" runat="server" />
            </div>
            <div class="col-md-1">
                <label>
                    Confirmar:
                </label>
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnConfirmar_Click" UseSubmitBehavior="False"  />
            </div>
        </div>        
        <table id="tblAutor" class="table"></table>
    </div>
    <script src="../Scripts/JS/Autor.js"></script>    
</asp:Content>
