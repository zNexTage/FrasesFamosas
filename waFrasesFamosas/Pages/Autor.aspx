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
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnConfirmar_Click" UseSubmitBehavior="False" />
            </div>
        </div>
        <br />
        
        <h1 style="text-align:center">
            Lista de autores
        </h1>
        <hr />  
        <table id="tblAutor" class="table" style="width:100%"></table>
    </div>

    <div class="modal fade" tabindex="-1" role="dialog" id="EditModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Header"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Autor: </label>
                            <input type="text" class="form-control" id="txtEditNome" name="txtEditNome" />
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-4">
                            <label>Origem: </label>
                            <input type="text" class="form-control" id="txtEditOrigem" name="txtEditOrigem"/>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-4">
                            <label>Atualiza foto: </label>
                            <asp:FileUpload ID="editFoto" runat="server"  CssClass="form-control-file" />
                        </div>
                    </div>
                     <div class="row">
                        <input type="text" id="txtId" name="txtEditId" hidden/>
                    </div>
                </div>
                <div class="modal-footer">                    
                    <asp:Button ID="btAlteracoes" runat="server" Text="Salvar Alterações" CssClass="btn btn-primary" OnClick="btAlteracoes_Click" />
                </div>
            </div>
        </div>
    </div>

    <script src="../Scripts/JS/Autor.js"></script>

    <script>        
        function modalEdit(id, nome, origem, foto) {
            console.log(id + " " + nome + " " + origem + " " + foto);
            $id = id;
            $('#Header').text(nome);
            $('#txtEditNome').val(nome);
            $('#txtEditOrigem').val(origem);
            $('#imgProfile').attr('src', foto);
            $('#txtId').val(id);
            $('#EditModal').modal('show');
        }
    </script>
</asp:Content>
