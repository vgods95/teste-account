async function adicionarCandidato() {
    var nome = document.getElementById("nomeCandidato")
    var nomeVice = document.getElementById("nomeVice")
    var legenda = document.getElementById("legendaCadastro")
    var opcoes = {
        method: 'POST',
        mode: 'no-cors',    
        body: JSON.stringify({
            Nomecandidato: nome,
            NomeVice: nomeVice,
            Legenda: legenda
        })
    }
    try {

        $.ajax({
            type: "POST",
            url: 'https://localhost:7208/Home/CadastroDeCandidato/',
            data: { 
                JSON({
                NomeCandidato: nome,
                NomeVice: nomeVice,
                Legenda: legenda
                })
            },
            cache: false,
            success: function (datas) {
                $(".dadosCandidato").html(datas)
            },
            error: function (xhr, status, error) { }
        })
    }
    catch (erro) {
        console.error(erro)
    }
}