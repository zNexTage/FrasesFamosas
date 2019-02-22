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
                        <label for="recipient-name" class="col-form-label" id="lblTitulo">Categoria:</label>
                        
                        <input type="text" class="form-control" id="txtNome">
                        <p><label style="font-size:25px; font-weight:bold;" id="lblNome"></label></p>                       
                    </div>
                    <div class="form-group">
                        <label class="col-form-label" id="lblAcao" style="color: white;"></label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Sair</button>
                    <button type="button" class="btn btn-primary" id="btAcao" onclick="Acao()" data-dismiss="modal"></button>
                </div>
            </div>
        </div>
    </div>


    <script>
        $id = 0;
        $acao = 3;
        function Acao() {
            var id = $id;
            var nome = $('#txtNome').val();
            var acao = $acao;
            var Categoria
            if (acao == 0) {
                Categoria = { Id: id, Nome: nome }
                console.log(Categoria);
                $.ajax({
                    url: "Categoria.aspx/AtualizarCategoria",
                    data: JSON.stringify(Categoria),
                    dataType: "JSON",
                    type: "POST",
                    contentType: "Application/JSON; charset=utf-8",
                    success: function () {
                        modalMessage("Aviso!!", "Categoria Atualizada com sucesso");
                        SelecionarCategorias();
                    },
                    error: function () {
                        modalMessage("Aviso!!", 'Um erro ocorreu');
                    }

                })
            }
            else {
                Categoria = { Id: id };
                $.ajax({
                    url: "Categoria.aspx/RemoverCategoria",
                    data: JSON.stringify(Categoria),
                    dataType: "JSON",
                    type: "POST",
                    contentType: "Application/JSON; charset=utf-8",
                    success: function () {
                        modalMessage("Aviso!!", "Categoria Removida com sucesso");
                        SelecionarCategorias();
                    },
                    error: function () {
                        modalMessage("Aviso!!", 'Um erro ocorreu');
                    }

                })
            }
        }
        function ModalCategoria(Id, Nome, Acao) {
            if (Acao == 0) {
                document.getElementById("Header").innerHTML = "Atualizar Categoria";
                document.getElementById("lblTitulo").innerHTML = "Digite no campo o novo nome da categoria!!!";
                document.getElementById("txtNome").value = Nome;
                $('#txtNome').css('display', 'block');
                $('#lblNome').css('display', 'none');
                document.getElementById("lblAcao").innerHTML = "Editar";
                document.getElementById("btAcao").innerHTML = "Editar";
                document.getElementById("lblAcao").style.color = 'blue';
                document.getElementById("btAcao").className = "btn btn-primary";
                $id = Id;
                $acao = Acao;
                $('#Categoria').modal('show');
            }
            else {
                document.getElementById("Header").innerHTML = "Remover Categoria";
                 document.getElementById("lblTitulo").innerHTML = "Deseja Remover esta categoria?";
                $('#txtNome').css('display', 'none');
                $('#lblNome').css('display', 'block');
                document.getElementById("lblNome").innerHTML = Nome;
                document.getElementById("lblAcao").innerHTML = "Remover";
                document.getElementById("btAcao").innerHTML = "Sim";
                document.getElementById("lblAcao").style.color = 'red';
                document.getElementById("btAcao").className = "btn btn-danger";
                $id = Id;
                $acao = Acao;
                $('#Categoria').modal('show');
            }
        }
    </script>
</asp:Content>


