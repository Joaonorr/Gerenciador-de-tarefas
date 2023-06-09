﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#Tabela-Tarefas').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "",
            "sInfoEmpty": "",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
});

$('.btn-close').click(function () {
    $('.alert-success').hide('hide');
})

$(document).ready(function () {
    // Inicialzia o Editor
    //$('.textarea-editor').wysihtml5();
    $('.textarea-editor').summernote(
        {
            height: 300,                 // define a altura do editor
            minHeight: null,           // define a altura minima
            maxHeight: null,          // define a altura máxima
            focus: true                  // define o foco na área editável apos a inicialização
        });
});