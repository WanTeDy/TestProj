$('a.json').click(function (event) {
    var link = $(this).prop('href');
    event.preventDefault();
    loadPage(link);

});

function loadPage(link) {
    $.ajax({
        url: link,
        type: "GET",
        success: function (response) {
            $('.content').html(response);
        },
        error: function (response) {
            alert("Извините, при обработке запроса произошла ошибка");
        }
    });
};

function deleteRows(elems, pageNum, url) {

    var obj = {
        "Values": elems,
        "PageNumber": pageNum
    }
    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(obj),
        success: function (response) {
            $('.content').html(response);
        },
        error: function (response) {
            alert("Извините, при обработке запроса произошла ошибка");
        }
    });
};