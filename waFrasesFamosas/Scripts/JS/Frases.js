$(document).ready(function () {
    SelecionarAutores();
    SelecionarCategorias();
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
                arr += "<option value=" + value.Id + ">" + value.Nome+"</option>";
            })
            $('#cbCategorias').append(arr);
        },
        error: function () {
            modalMessage("Atenção", "Houve um erro ao selecionar as categorias!!!");
        }
    })
}