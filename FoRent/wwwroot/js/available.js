$(document).ready(function () {
    $("#btnSave").click(function () {
        //alert("");  
        var form = $(this).parent("form");
        $.ajax({
            cache: false,
            type: "POST",
            url: form.attr("asp-action"),
            data: form.serialize,
            dataType: "application/json; charset=utf-8",
            contentType: date,
            success: function (response) {
                if (response.success)
                    alert(response.responseText);
                error: function (response) {
                   
                    alert("התאריך נקלט במערכת");
                //swal("התאריך נקלט במערכת", "באפשרותך להזין תאריכים נוספים", "success");
            }

            }
        });
        return false;
    });
});