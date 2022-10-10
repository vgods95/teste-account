async function adicionarCandidato() {
    var nome = document.querySelector("nomeCandidato")
    var nomeVice = document.querySelector("nomeVice")
    var legenda = document.querySelector("legendaCadastro")
    const candidato = JSON.stringify({
        "nomeCandidato": nome,
        "nomeVice": nomeVice,
        "legenda": legenda
    })
    try {
        await fetch("https://localhost:7004/api/CadastroDeCandidato/", { method: 'POST', body: candidato })
            .then(function (response) {
                if (response.ok) {
                    $("#titulo").html(response)
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