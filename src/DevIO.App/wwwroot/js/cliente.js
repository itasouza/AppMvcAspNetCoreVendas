


    function ExibirModalExcluir(idRecebido, nome, controller) {

        var t = $("input[name='__RequestVerificationToken']").val();
        $(".nome")[0].innerHTML = nome;
        $("#modal-excluir").modal();

        $(".btn-Confirmar").on("click", function (e) {
            e.preventDefault();
            var urlCompleto = "/" + controller + "/DeleteEndereco/";

            $.ajax({
                method: "POST",
                headers:
                {
                    "RequestVerificationToken": t
                },
                url: urlCompleto,
                data: { id: idRecebido },
                success: function (resultado) {
                    if (resultado.result) {
                        toastr[resultado.result](resultado.mensaje);
                        $(".modal").modal("hide");
                        location.reload(true);
                    }
                    else {
                        toastr[resultado.result](resultado.mensaje)
                    }
                }
            });
        });

    }


    function ExibirModalEditarEndereco(idEndereco, controller) {
        var t = $("input[name='__RequestVerificationToken']").val();
        $("#texto-titulo")[0].innerHTML = "Alteração do endereço";
        $("#modal-adicao-edicao").modal();
        BuscaCep();

        //=====================================================================

        var DadosEndereco = [];
        $.each($("#DetalheEndereco tbody tr"), function (index, value) {

            var IdParaConsulta = $(this).find('td:eq(0)').html().trim();

            if (IdParaConsulta == idEndereco) {

                DadosEndereco.push({
                    IdEndereco: $(this).find('td:eq(0)').html(),
                    logradouro: $(this).find('td:eq(1)').html(),
                    numero: $(this).find('td:eq(2)').html(),
                    complemento: $(this).find('td:eq(3)').html(),
                    bairro: $(this).find('td:eq(4)').html(),
                    cep: $(this).find('td:eq(5)').html(),
                    cidade: $(this).find('td:eq(6)').html(),
                    estado: $(this).find('td:eq(7)').html()
                });

            }

        });


        //Preenche Campos
        $("#Endereco_Id").val(idEndereco);
        $("#Endereco_Logradouro").val(DadosEndereco[0].logradouro.trim());
        $("#Endereco_Numero").val(DadosEndereco[0].numero.trim());
        $("#Endereco_Complemento").val(DadosEndereco[0].complemento.trim());
        $("#Endereco_Bairro").val(DadosEndereco[0].bairro.trim());
        $("#Endereco_Cep").val(DadosEndereco[0].cep.trim());
        $("#Endereco_Cidade").val(DadosEndereco[0].cidade.trim());
        $("#Endereco_Estado").val(DadosEndereco[0].estado.trim());

        //========================================================================

        $("#eviarAjax").click(function (e) {
            e.preventDefault();

            var urlCompleto = "/" + controller + "/AtualizarEndereco/";
            // var urlAction = '@Url.Action("Edit", "Fornecedores")';
            var formulario = $("#formulario");

            $.ajax({
                method: "POST",
                headers:
                {
                    "RequestVerificationToken": t
                },
                url: urlCompleto,
                data: formulario.serialize(),
                success: function (resultado) {
                    if (resultado.result) {
                        toastr[resultado.result](resultado.mensaje)
                        // window.location.href = urlAction;
                        location.reload(true);
                    }
                    else {
                        toastr[resultado.result](resultado.mensaje)
                    }
                }
            });
        });
    }


    function ExibirModalAdicionarEndereco(controller) {

        var t = $("input[name='__RequestVerificationToken']").val();
        $("#modal-adicao-edicao").modal();
        $("#texto-titulo")[0].innerHTML = "Adicionar novo endereço";

        $("#Endereco_Logradouro").val("");
        $("#Endereco_Numero").val(""); 
        $("#Endereco_Complemento").val(""); 
        $("#Endereco_Bairro").val(""); 
        $("#Endereco_Cep").val(""); 
        $("#Endereco_Cidade").val(""); 
        $("#Endereco_Estado").val(""); 
        BuscaCep();

        $("#eviarAjax").click(function (e) {
            e.preventDefault();

            var urlCompleto = "/" + controller + "/AdicionarEndereco/";
            var formulario = $("#formulario");


            $.ajax({
                method: "POST",
                headers:
                {
                    "RequestVerificationToken": t
                },
                url: urlCompleto,
                data: formulario.serialize(),
                success: function (resultado) {
                    if (resultado.result) {
                        toastr[resultado.result](resultado.mensaje)
                        location.reload(true);
                    }
                    else {
                        toastr[resultado.result](resultado.mensaje)
                    }
                }
            });
        });
    }





