$(document).ready(function () {
    selecionarPagina('room');    
    listarSalas();
});

function listarSalas(){
    mostrarCarregamento();
    var pagina = $("#numeroPagina").val();

    $.ajax({
        type: "GET",
        url: "/Sala/ListarSalas?numeroPagina=" + pagina,
        success: function (data) {
            $("#divListaSalas").html(data);
        },
        complete: function () {
            ocultarCarregamento();
        }
    });
}

function alterarPagina(valor, numeroMaximo) {
    if (valor > numeroMaximo || valor < 0)
        return;

    $("#numeroPagina").val(valor);
    listarSalas();
}