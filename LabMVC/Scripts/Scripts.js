$('#botao_cadastro').on('click', function () {
    window.location.href = window.location.origin + '/usuario/form'
});

function cadastrarCliente() {
    window.location.href = window.location.origin + "/clientes/Cadastrar/";
}

function atualizarUsuario(id){
    window.location.href = window.location.origin + "/clientes/Atualizar/" + id;
}

function excluiUsuario(id) {
    window.location.href = window.location.origin + "/clientes/excluir/" + id;
}