$(document).ready(function () {
    SelecionarAutores();
    SelecionarCategorias();
    SelecionarFrases();
})

function SelecionarAutores() {
    $.ajax({
        url: "Frases.aspx/SelecionarAutores",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {
            var DataOption = data.d;
            var arr = "";

            $.each(DataOption, function (key, value) {
                arr += "<option value=" + value.Id + ">" + value.Nome + "</option>";
            });
            $('#cbAutores').append(arr);
            $('#cbEditAutor').append(arr);
        },
        error: function () {
            modalMessage("Atenção", "Houve um erro ao selecionar os autores!!!");
        }

    })
}
function SelecionarCategorias() {
    $.ajax({

        url: "Frases.aspx/SelecionarCategorias",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {
            var DataOption = data.d;
            var arr = "";

            $.each(DataOption, function (key, value) {
                arr += "<option value=" + value.Id + ">" + value.Nome + "</option>";
            })
            $('#cbCategorias').append(arr);
            $('#cbEditCategoria').append(arr);
        },
        error: function () {
            modalMessage("Atenção", "Houve um erro ao selecionar as categorias!!!");
        }
    })
}
function InserirFrase() {
    var frase = $('#txtFrase').val();
    var autor = $('#cbAutores').val();
    var categoria = $('#cbCategorias').val();

    if (frase == "" || autor == '0' || categoria == '0') {
        modalMessage('Aviso', 'Preencha todos os campos');
    }
    else {
        var Frase = { Frase: frase, FKAutor: autor, FKCategoria: categoria }
        $.ajax({
            url: "Frases.aspx/InserirFrase",
            data: JSON.stringify(Frase),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function () {
                modalMessage('Sucesso', 'Frase inserida com sucesso');
                $('#txtFrase').val('');
                $('#cbAutores').val(0);
                $('#cbCategorias').val(0);
                SelecionarFrases();
            },
            error: function () {
                modalMessage('Erro', 'Não foi possivel cadastrar');
            }
        })
    }
}
function SelecionarFrases() {
    $.ajax({
        url: "Frases.aspx/SelecionarFrases",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {
            var DataOption = data.d;
            var arr = [];
            $.each(DataOption, function (key, value){
                var aux = [];
                aux = ["" + value.Id + "", "" + value.Frase + "", "" + value.getAutorName + "", "" + value.getCategoriaName + "", "<button class='btn btn-primary form-control' data-id=" + value.Id + " data-autor=" + value.FKAutor+" data-categoria="+value.FKCategoria+" onclick='Editar(this);return false;'>Editar</button>", "<button class='btn btn-danger form-control' data-id="+value.Id+" onclick='Remover(this);return false;'>Remover</button>"];
                arr.push(aux);
            })
            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable('#tblFrases')) {
                    $('#tblFrases').DataTable().clear().destroy();
                }
               
                $('#tblFrases').DataTable({
                    data: arr,
                    columns: [
                        { title: "Id", "visible": false },
                        { title: "Frase" },
                        { title: "Autor" },
                        { title: "Categoria" },
                        { title: "Editar" },
                        { title: "Remover"}
                    ]

                })
            })
        },
        error: function () {
            modalMessage('Aviso!!!', 'Ocorreu um erro');
        }
    })
}

function Editar(obj) {
    var Id = $(obj).data('id');     
    var JSONid = {Id:Id}
    $.ajax({
        url: "Frases.aspx/SelecionarPeloId",
        data: JSON.stringify(JSONid),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {            
            ModalEditFrase(data.d.Id, data.d.Frase, data.d.FKAutor, data.d.FKCategoria);
        },
        error: function () {
            modalMessage('Aviso', 'Ocorreu um erro ao editar')
        }
    })
}
function Atualizar(id) {
    var Frase = $('#txtEditFrase').val();
    var Autor = $('#cbEditAutor').val();
    var Categoria = $('#cbEditCategoria').val();
    var Dados = { Id: id, Frase: Frase, FKAutor:Autor, FKCategoria:Categoria };
    $.ajax({
        url: "Frases.aspx/AtualizarFrase",
        data: JSON.stringify(Dados),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function () {
            modalMessage('Sucesso', 'Frase atualizada');
            $('#txtEditFrase').val('');
            $('#cbEditAutor').val(0);
            $('#cbEditCategoria').val(0);
            SelecionarFrases();
        },
        error: function () {
            modalMessage('Erro', 'Ocorreu um erro ao atualizar a frase');
        }
    })
}
function Remover(obj) {
    if (confirm("Deseja remover está frase?")) {
        var id = $(obj).data('id');
        var JSONid = { Id: id };
        $.ajax({
            url: "Frases.aspx/RemoverFrase",
            data: JSON.stringify(JSONid),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function () {
                modalMessage('Sucesso!!!', 'Frase removida');
                SelecionarFrases();
            },
            error: function () {
                modalMessage('Atenção!!!', 'Houve um erro ao remover a frase');
            }
        })
    }
}