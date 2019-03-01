<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Frases.aspx.cs" Inherits="waFrasesFamosas.Pages.Frases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center;">Frases
        </h1>
        <hr />
        <div class="card">
            <div class="card-header" style="font-weight:bold;">
                Adicionar uma nova frase
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-3">
                        <label>
                            Frase:
                        </label>
                        <input type="text" class="form-control" id="txtFrase" />
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
                        <button class="btn btn-success" id="btCadastrar" onclick="InserirFrase();return false;">Cadastrar</button>
                    </div>
                </div>
            </div>
        </div>
        <table id="tblFrases" class="table table-striped" style="width: 100%"></table>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="ModalEditFrase">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Frase</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-8">
                                <label>Frase:</label>
                                <input type="text" class="form-control" id="txtEditFrase" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <label>Autor:</label>
                                <select id="cbEditAutor" class="form-control" name="EditAutor">
                                    <option value="0">Selecione</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <label>Categoria:</label>
                                <select id="cbEditCategoria" class="form-control" name="EditCategoria">
                                    <option value="0">Selecione</option>
                                </select>
                            </div>
                        </div>
                    </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="Atualizar($id)" data-dismiss="modal">Salvar Alterações</button>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script>
        $id = 0;
        function ModalEditFrase(id, frase, FKAutor, FKCategoria) {
            $id = id;
            $('#txtEditFrase').val(frase);
            $('[name=EditAutor]').val(FKAutor);
            $('[name=EditCategoria]').val(FKCategoria);
            $('#ModalEditFrase').modal('show');
        }
    </script>
    <script src="../Scripts/JS/Frases.js"></script>

</asp:Content>
