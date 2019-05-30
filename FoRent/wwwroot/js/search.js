$(function () {
    $('#adult').keyup(function (event) {


        var form = $('#infoi');
        var url = form.attr('action');

        $.ajax({
            url: url,
            data: form.serialize(), // serializes the form's elements.
            success: function (data) {
                $('tbody').html(data); // show response from the php script.
            }
        });

    });
});