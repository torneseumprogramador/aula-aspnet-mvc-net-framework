$('#botao_cadastro').on('click', function () {
    window.location.href = window.location.origin + '/usuario/form'
});

function atualizarUsuario(id){
    //$.get(window.location.origin + "", function ()){ };
    console.log("atualizar este usuario!" + id);

}

function excluiUsuario(id) {
    $.get(window.location.origin +"/clientes/excluir/"+id);
    console.log("excluir este usuario =>"+id);
}