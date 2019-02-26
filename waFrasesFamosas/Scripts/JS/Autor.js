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
                aux = ["" + value.Id + "", "" + value.Nome + "", "" + value.Origem + "", "<img width='200px' height='150px' src=" + value.Foto + ">", "<button data-id=" + value.Id + " class='btn btn-primary form-control'>Editar</button>", "<button data-id=" + value.Id + " class='btn btn-danger form-control'>Remover</button>"]
                arr.push(aux);
            });
            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable("#tblAutor")) {
                    $("#tblAutor").DataTable().clear.destroy();
                }
                $('#tblAutor').DataTable({
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

        }
    })
}