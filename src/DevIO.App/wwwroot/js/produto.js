

$(document).ready(function () {

    $('.campovalor').mask('#.##0,00', { reverse: true });

});


//======================================================================

function ObterDadosFornecedor() {

    var idRecebido = $('#IdFornecedorRetorno').val();

    $.ajax({
        url: "/Produtos/ObterFornecedorParaAutocompleteId/" + idRecebido,
        dataType: 'json',
        type: 'GET',
        success: function (data) {
            // console.log(data.results);
            $(".fornecedor-edicao").empty();
            $.each(data, function (index, row) {
                $(".fornecedor-edicao").append("<option value='" + row.id + "'>" + row.nome + "</option>");
            });
        }
    });

}


$(".fornecedor-selecao").select2({
    placeholder: "Selecione",
    minimumInputLength: 1,
    ajax: {
        url: '/Produtos/ObterFornecedorParaAutocompleteTexto',
            type: 'GET',
            dataType: 'json',
            quietMillis: 250,
            allowClear: true,
            data: function (params) {
                return { 'text': params.term };
            },
            success: function (data) {
              //  console.log(data.results);
           },
           processResults: function (data) {
                var _results = [];
               $.each(data.results, function (index) {
                   //console.log(data.results[index].id);
                    _results.push({
                        id: data.results[index].id,
                        text: data.results[index].nome
                    });
                });
                return { results: _results };
            }

    }

});


//========================================================================



function CarregarImagem(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imagemProduto').attr('src', e.target.result).height("136px");
        };
    }
    reader.readAsDataURL(input.files[0]);
};


