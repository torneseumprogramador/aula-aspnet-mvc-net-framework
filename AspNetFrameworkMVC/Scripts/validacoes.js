var ValidaExclusao = function (id, evento) {
    if (confirm("Deseja mesmo excluir o dado?")) {
        return true;
    }
else {
    evento.preventDefault();
return false;
    }
        
}