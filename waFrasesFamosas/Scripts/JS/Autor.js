$(document).ready(function () {
    SelecionarAutores();
})

function SelecionarAutores() {
    $.ajax({
        url: "Autor.aspx/SelecionarAutores",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charsert=utf-8",
        success: function (data) {
            var DataOption = data.d;
            var arr = [];
            $.each(DataOption, function (key, value) {
                var aux = [];
                aux = ["" + value.Id + "", "" + value.Nome + "", "" + value.Origem + "", "<img width='180px' height='150px' src='../IMAGENS/AUTORES/" + value.Foto + "'>", "<button data-id=" + value.Id + " class='btn btn-primary form-control' onclick='Editar(this);return false;'>Editar</button>", "<button data-id=" + value.Id + " onClick='Remover(this);return false;' class='btn btn-danger form-control'>Remover</button>"]
                arr.push(aux);
            });
            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable("#tblAutor")) {
                    $("#tblAutor").DataTable().clear.destroy();
                }
                $('#tblAutor').DataTable({
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
                        { title: "Id", "visible": false },
                        { title: "Nome" },
                        { title: "Origem" },
                        { title: "Foto" },
                        { title: "Editar" },
                        {title: "Remover"}
                    ]
                })
            })


        },
        error: function () {
            modalMessage('Aviso', "Ocorreu um erro ao selecionar os autores");
        }
    })
}

function Editar(obj) {
    var id = $(obj).data('id');
    var Jid = { Id: id };
   
    $.ajax({
        url: "Autor.aspx/SelecionarPeloId",
        data: JSON.stringify(Jid),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {
            modalEdit(data.d.Id, data.d.Nome, data.d.Origem, data.d.Foto);
        },
        error: function () {
            modalMessage('Aviso', "Ocorreu um erro ao selecionar o autor especifico");
        }
    })
}
function Atualizar(id) {
    var id = { Id: id };
    $.ajax({
        url: "Autor.aspx/Atualizar",
        data: JSON.stringify(Jid),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function () {
            
        },
        error: function () { }

    })
}

function Remover(obj) {
    if (confirm("Deseja deletar este autor?")) {
        var getId = $(obj).data('id');
        var JSONid = { Id: getId };
        $.ajax({
            url: "Autor.aspx/RemoverAutor",
            data: JSON.stringify(JSONid),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function () { 
                alert("Autor deletado com sucesso");
                window.location.reload()
                /*$('#close').click(function () { window.location.reload() })
                modalMessage('Sucesso!!', 'Autor deletado com sucesso');*/
                
            },
            error: function () {
                modalMessage('Erro!!', 'Não foi possivel deletar')
            }
        })
    }
  
}