<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="waFrasesFamosas.Pages.Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 style="text-align: center;">Categorias</h1>
        <hr />
        <div class="card">
            <div class="card-header" style="font-weight: bold;">
                Categorias 
            </div>
            <div class="card-body">
                <div class="col-md-5">
                    <label>Nome da categoria: </label>
                    <input type="text" class="form-control" id="txtCategoria" placeholder="Categoria" />
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <button class="btn btn-primary" onclick="InserirCategoria();return false;">Inserir</button>
                        </div>
                        <a href="#" class="btn btn-danger" onclick=" LimparCampos();">Cancelar</a>
                    </div>
                    <input type="text" class="form-control" id="txtId" hidden />
                </div>
            </div>
        </div>
        <br />
        <div class="container-fluid">
            <h1 style="text-align: center;">Lista de categorias
            </h1>
            <hr />
        </div>
        <table id="tblCategorias" class="table table-striped table-bordered">
        </table>
    </div>
    <script src="../Scripts/JS/Categoria.js"></script>
    <!--------------------------------------->
    <div class="modal fade" id="Categoria" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="Header"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Categoria:</label>
                        <input type="text" class="form-control" id="txtNome">
                    </div>
                    <div class="form-group">
                        <label class="col-form-label" id="lblAcao"></label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Sair</button>
                    <button type="button" class="btn btn-primary" id="btAcao"></button>
                </div>
            </div>
        </div>
    </div>
    <script>
        function Select(Id, Nome, Acao) {
            $.ajax({


            })
        }
        function ModalCategoria(Nome, Acao) {
            if (Acao == 0) {
                document.getElementById("Header").innerHTML = "Atualizar Categoria";
                document.getElementById("txtNome").value = Nome;
                document.getElementById("lblAcao").innerHTML = "Editar";
                document.getElementById("btAcao").innerHTML = "Finalização";
            }
            else {
                document.getElementById("Header").innerHTML = "Remover Categoria";
                document.getElementById("txtNome").value = Nome;
                document.getElementById("lblAcao").innerHTML = "Remover";
                document.getElementById("btAcao").innerHTML = "Finalização";
            }
        }
    </script>
</asp:Content>


