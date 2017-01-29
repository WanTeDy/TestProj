$('#chk-all').change(function () {
    $('.chk').prop('checked', this.checked);
});

$('#btn-del').click(function (event) {
    event.preventDefault();
    var elements = $('input.chk:checked');
    var count = elements.length;
    if (count > 0) {
        var input = prompt('Вы хотите удалить ' + count + ' строк. Для подтверждения введите это количество в строке', 'Введите количество строк');
        if (parseInt(input) == count) {
            var values = elements.map(function () {
                return parseInt($(this).val());
            }).get();
            var page = parseInt($('#pageNumber').val());
            var url = $(this).prop('href');            
            deleteRows(values, page, url);
        }
        else if (input != null) {
            alert("Вы ввели неправильное количество строк")
        }
    }
});

$('.pagination').click(function (event) {
    if (event.target != this && event.target.nodeName == 'A') {
        var link = $(event.target).prop('href');
        event.preventDefault();
        if (link != '') {
            loadPage(link);
        }
    }
});