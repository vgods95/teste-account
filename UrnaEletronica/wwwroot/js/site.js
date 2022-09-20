function limparTela() {
    $("#legenda").html("")
    $(".dadosCandidato").hide()
    $("#legenda").show(150)
    $(".tipoCandidato").show(150)
}

function abrirCandidatos() {
    $(".candidatos").show(150)
    $(".Urna").hide(150)
    $(".tetoUrna").hide(150)
}

function fecharListaCandidatos(){
    $(".candidatos").hide(150)
    $(".Urna").show(150)
    $(".tetoUrna").show(150)
}