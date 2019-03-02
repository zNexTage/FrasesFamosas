$(document).ready(function () {
    SelecionarUsuarios();
})

function CadastrarUsuario() {
    var Nome = $('#txtNome').val();
    var Email = $('#txtEmail').val();
    var Senha = $('#txtSenha').val();

    if (Nome == "" || Email == "" || Senha == "") {
        modalMessage('Aviso!!', 'Preencha todos os campos');
    }
    else {
        var Dados = { Nome: Nome, Email: Email, Senha: Senha }
        $.ajax({
            url: "Usuario.aspx/CadastrarUsuario",
            data: JSON.stringify({ Usuario: Dados }),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function () {
                modalMessage('Sucesso', 'Usuário cadastrado');
                SelecionarUsuarios();
            },
            error: function () {
                modalMessage('Aviso!!!', 'Ocorreu um erro ao cadastrar')
            }
        })
    }
}
function SelecionarUsuarios() {
    $.ajax({
        url: "Usuario.aspx/SelecionarUsuarios",
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON;charset=utf-8",
        success: function (data) {
            var DataOption = data.d;
            var arr = []
            $.each(DataOption, function (key, value) {
                var aux = [];
                aux = ["" + value.Id + "", "" + value.Nome + "", "" + value.Email + "", "<button data-id='" + value.Id + "' class='btn btn-info form-control'>Editar</button>", "<button data-id='" + value.Id + "' class='btn btn-danger form-control'>Remover</button>"]
                arr.push(aux);
            })
            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable("#tblUsuarios")) {
                    $('#tblUsuarios').DataTable().clear().destroy();
                }
                $('#tblUsuarios').DataTable({

                    data: arr,
                    columns: [
                        { title: "Id", "visible": false },
                        { title: "Nome" },
                        { title: "Email" },
                        { title: "Editar" },
                        { title: "Remover" },
                    ]
                })
            })
        },
        error: function () {
            modalMessage('Aviso!!', 'Ocorreu um erro ao selecionar os usuarios!!!')
        }
    })
}