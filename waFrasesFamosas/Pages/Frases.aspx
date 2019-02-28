<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frases.aspx.cs" Inherits="waFrasesFamosas.Pages.Frases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center;">Frases
        </h1>
        <hr />
        <div class="card">
            <div class="card-header">
                Adicionar uma nova frase
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-3">
                        <label>
                            Frase:
                        </label>
                        <input type="text" class="form-control" id="txtFrase"/>
                    </div>
                     <div class="col-md-2">
                        <label>
                            Autor:
                        </label>
                        <select class="form-control" id="cbAutores">
                            <option value="0">Selecione</option>
                        </select>
                    </div>
                      <div class="col-md-2">
                        <label>
                            Categoria:
                        </label>
                        <select class="form-control" id="cbCategorias">
                            <option value="0">Selecione</option>
                        </select>
                    </div>
                    <div class="col-md-1">
                        <label>
                            Confirmar:
                        </label>
                       <button class="btn btn-success" id="btCadastrar">Cadastrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/JS/Frases.js"></script>
</asp:Content>
