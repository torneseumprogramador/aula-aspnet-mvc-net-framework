console.log("Deu tudo certo");

$(document).ready(function () {
    $("input[name='cep']").change(function () {
        console.log("Deu tudo certo2");
        var numCep = $("#cep").val();
        console.log(numCep);
        var url = "https://viacep.com.br/ws/" + numCep + "/json/";
        console.log(url);

        $.get(url, function (dados){
            console.log(dados);
        }, "json");
    });
});
//JQuery(function ($){
//    $("input[name='cep']").change(function () {
//        var cep_code = $(this).val();
//        if (cep_code.length <= 0) return;

//        $.get("https://viacep.com.br/ws/" + cep_code + "/json/", function (result, status) {
//            if (result.erro) {
//                alert("Cep não encontrado!");
//                return;
//            }

//            if (status === "success" & status != 400) {
//                $("input[name='cep']").val(result.cep);
//                $("input[name='estado']").val(result.uf);
//                $("input[name='cidade']").val(result.localidade);
//                $("input[name='bairro']").val(result.bairro);
//                $("input[name='endereco']").val(result.logradouro);
//            } else {
//                alert("Cep em formato inválido!");
//                return;
//            }
//        });
//    });
//});