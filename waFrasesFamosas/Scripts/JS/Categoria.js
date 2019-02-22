$(document).ready(function () { 
    SelecionarCategorias();
 })
function LimparCampos() {
    $('#txtCategoria').val('');
    $('#txtId').val('');
}

function InserirCategoria() {
    var Nome = $('#txtCategoria').val();   
    if (Nome == "") {
        modalMessage('Aviso!!', 'Preencha todos os campos');
    }
    else {
        var Nome = {
            Nome: Nome
        }
        
        $.ajax({
            url: "Categoria.aspx/InserirCategoria",
            data: JSON.stringify(Nome),
            type: "POST",
            dataType: "JSON",
            contentType:"Application/JSON; charset=utf-8",
            success: function () {
                modalMessage('Aviso', 'Categoria Adicionada com Sucesso');
                LimparCampos();
            },
            error: function () {
                modalMessage('Atenção', 'Ocorreu um erro');
                LimparCampos();
            }
        })
    }
}
function SelecionarCategorias() {
    $.ajax({
        url: "Categoria.aspx/ListarCategorias",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {

            var DataOption = data.d;
            var option = '';
            var arr = [];
            $.each(DataOption, function (key, value) {
                var aux = [];
                aux = ["" + value.Id + "", "" + value.Nome + "", "<button data-idCat=" + value.Id + " type='button'  id=" + value.Id + " onClick= '' class='btn btn-info form-control btnLiberar'>Editar <i class='glyphicon glyphicon-pencil'/></button>", "<button data-idCat=" + value.Id + " type='button'  id=" + value.Id + " onClick= 'Editar(this)' class='btn btn-danger form-control btnRemover'>Remover <i class='glyphicon glyphicon-pencil'/></button>"]
                arr.push(aux);
            });

            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable("#tblCategorias")) {
                    $('#tblCategorias').DataTable().clear().destroy();
                }
                $('#tblCategorias').DataTable({                   
                    "language": {
                        "sEmptyTable": "Nenhum registro encontrado",
                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ".",
                        "sLengthMenu": "_MENU_ Resultados por página",
                        "sLoadingRecords": "Carregando...",
                        "sProcessing": "Processando...",
                        "sZeroRecords": "Nenhum registro encontrado",
                        "sSearch": "Pesquisar",
                        "oPaginate": {
                            "sNext": "Próximo",
                            "sPrevious": "Anterior",
                            "sFirst": "Primeiro",
                            "sLast": "Último"
                        }

                    },
                    data: arr,
                    responsive: true,
                    columnDefs: [
                        { responsivePriority: 1, targets: 0 },
                        { responsivePriority: 2, targets: 1 }
                    ],
                    ordering: false,
                    columns: [
                        {
                            title: "ID",
                            "visible": false
                        },
                        { title: "Categoria" },
                        { title: "Editar" },
                        { title: "Remover" },                     
                    ],

                });
            });
        },
        error: function () {

        }

    })
}

function Editar(obj) {

}









/*var DataOption = data.d;
var option = '';
var arr = [];
$.each(DataOption, function (key, value) {
    var aux = [];
    aux = ["" + value.id_entrada + "", "" + value.nome_motorista + "", "" + value.nome_transp + "", "" + value.nome_cliente + "", "" + value.cliente_final + "", "" + value.placa + "", "" + value.docaIni + "", "" + value.docaF + "", "" + value.horaFormatada + "", "<button data-idEntrada=" + value.id_entrada + " type='button'  id=" + value.id_entrada + " onClick= alterarStatus(this) class='btn btn-info form-control btnLiberar'>Liberar <i class='glyphicon glyphicon-pencil'/></button>"]
    arr.push(aux);
});

$(document).ready(function () {

    if ($.fn.DataTable.isDataTable("#tblCategorias")) {
        $('#tblCategorias').DataTable().clear().destroy();
    }
    $('#tblCategorias').DataTable({
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ Resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            }

        },
        data: arr,
        ordering: false,
        columns: [
            {
                title: "ID",
                "visible": false
            },
            { title: "Nome" },
            { title: "Transportadora" },
            { title: "Cliente" },
            { title: "Cliente Final" },
            { title: "Placa" },
            { title: "Doca Inicial" },
            { title: "Doca Final" },
            { title: "Horário Entrada" },
            { title: "Liberar" }


        ],

    });
});
        },*/