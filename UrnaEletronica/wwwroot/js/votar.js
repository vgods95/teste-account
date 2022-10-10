async function votar() {
    var legenda = $("#legenda").html()
    var idCandidato = $("#idCandidato").html()
    const votacao = JSON.stringify({
        "idCandidato": idCandidato,
        "quantidadeDeVotos": 1,
        "legenda": legenda
    })
    try {
        await fetch("https://localhost:7004/api/votar", { method: 'POST', headers: { 'content-type': 'application/json', 'Content-Type': 'application/json; charset=utf-8' }, body: votacao })
            .then(function (response) {
                if (response.ok) {
                    $(".dadosCandidato").html("<p style='font-size: 40pt; text-align: center;'>Fim</p>")
                    return response.text()
                }
                throw new Error("Erro da requisição")
            })
            .then(function (text) {
                console.log("Sucesso na requisição" + text)
            })
            .catch(function (erro) {
                console.log("ERRO DE REQ " + erro)
            })
    }
    catch (erro) {
        console.error(erro)
    }
}