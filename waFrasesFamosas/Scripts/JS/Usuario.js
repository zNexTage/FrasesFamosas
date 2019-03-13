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
            url: "Usuario.aspx/ChecarEmail",
            data: JSON.stringify({ Usuario: Dados }),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function (data) {               
                if (data.d == false) {
                    $.ajax({
                        url: "Usuario.aspx/CadastrarUsuario",
                        data: JSON.stringify({ Usuario: Dados }),
                        dataType: "JSON",
                        type: "POST",
                        contentType: "Application/JSON; charset=utf-8",
                        success: function () {
                            modalMessage('Sucesso', 'Usuário cadastrado');
                            SelecionarUsuarios();
                            $('#txtNome').val('');
                            $('#txtEmail').val('');
                            $('#txtSenha').val('');
                        },
                        error: function () {
                            modalMessage('Aviso!!!', 'Ocorreu um erro ao cadastrar')
                        }
                    })
                }
                else {
                    modalMessage('Aviso!!!', 'Esse email já está cadastrado no nosso sistema, tente novamente!!!!');
                }
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
                aux = ["" + value.Id + "", "" + value.Nome + "", "" + value.Email + "", "<button data-id='" + value.Id + "' class='btn btn-info form-control' onClick='Editar(this);return false;'>Editar</button>", "<button data-id='" + value.Id + "' class='btn btn-danger form-control' onClick='Remover(this);return false;'>Remover</button>"]
                arr.push(aux);
            })
            $(document).ready(function () {
                if ($.fn.DataTable.isDataTable("#tblUsuarios")) {
                    $('#tblUsuarios').DataTable().clear().destroy();
                }
                $('#tblUsuarios').DataTable({
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
function Editar(obj) {
    var id = $(obj).data('id');
    var Id = {Id:id}
    $.ajax({
        url: "Usuario.aspx/SelecionarUsuarioPeloID",
        data: JSON.stringify({ Usuario: Id }),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {
            modalEditUser(data.d.Id, data.d.Nome, data.d.Email, data.d.Senha);
        },
        error: function () {
            modalMessage('Aviso!!!', 'Ocorreu um erro ao abrir o modal de atualização');
        }
    })
}

function Atualizar(id) {
    var Id = id;
    var Nome = $('#txtEditNome').val();
    var Email = $('#txtEditEmail').val();
    var Senha = $('#txtEditSenha').val();
    var Dados = { Id: Id, Nome: Nome, Email: Email, Senha: Senha }
    $.ajax({
        url: "Usuario.aspx/ChecarEmail",
        data: JSON.stringify({ Usuario: Dados }),
        dataType: "JSON",
        type: "POST",
        contentType: "Application/JSON; charset=utf-8",
        success: function (data) {           
            if (data.d == false) {
                $.ajax({
                    url: "Usuario.aspx/AtualizarUsuario",
                    data: JSON.stringify({ Usuario: Dados }),
                    dataType: "JSON",
                    type: "POST",
                    contentType: "Application/JSON; charset=utf-8",
                    success: function () {
                        modalMessage("Sucesso!!", "Usuário atualizado com sucesso!!");
                        SelecionarUsuarios();
                        $('#txtEditNome').val('');
                        $('#txtEditEmail').val('');
                        $('#txtEditSenha').val('');
                    },
                    error: function () {
                        modalMessage('Aviso!!!', 'Ocorreu um erro ao atualizar!');
                    }
                })
            }
            else {
                modalMessage('Aviso!!', 'Esse email já está cadastrado no nosso sistema, tente novamente!!!!');
            }
        }
    });
}
function Remover(obj) {
    if (confirm('Deseja apagar esse usuário?')) {
        var Id = $(obj).data('id');
        var Dados = { Id: Id };
        $.ajax({
            url: "Usuario.aspx/RemoverUsuario",
            data: JSON.stringify({ Usuario: Dados }),
            dataType: "JSON",
            type: "POST",
            contentType: "Application/JSON; charset=utf-8",
            success: function () {
                modalMessage('Sucesso!!', 'Usuário deletado!!');
                SelecionarUsuarios();
            },
            error: function () {
                modalMessage('Erro!!', 'Ocorreu um erro ao deletar o usuário!!');
            }
        })
    }
}