async function votar() {
    var voto = $("#legenda").html()
    const cabecalho = [['Content-Type', 'application/json'], ['Accept']]
    const opcoes = {
        method: 'POST',
        headers: cabecalho,
        mode: 'no-cors',
        body: JSON.stringify({ voto: voto })
    }
    console.log(voto)
    try {
        const resposta = await fetch("https://localhost:7004/api/Voto/", { opcoes })
        var dados = resposta.json()
        console.log(dados)
    }
    catch (erro) {
        console.error(erro)
    }
}