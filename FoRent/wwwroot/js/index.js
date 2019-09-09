function CreateWeatherJson(json) {


}

$("#submitButton").click(function (e) {
    $.ajax({
        type: "POST",
        url: "http://api.openweathermap.org/data/2.5/group?id=281184,293396,8199378,294800,294952&appid=de6d52c2ebb7b1398526329875a49c57&units=metric",
        dataType: "json",
        success: function (result, status, xhr) {

            var newJson = "";
            $('#weatherTable').append('<thead>< tr ><th scope="col">איזור</th><th scope="col">מזג אויר</th></tr ></thead ><tbody>');
            for (i = 0; i < result.list.length; i++) {
                cityId = result.list[i].id;
                cityName = result.list[i].name;
                temp = result.list[i].main.temp
                pressure = result.list[i].main.pressure
                humidity = result.list[i].main.humidity
                tempmin = result.list[i].main.temp_min
                tempmax = result.list[i].main.temp_max

                $('#weatherTable').append('<tr><td >' + cityName + '</td><td>' + temp + '</td></tr>');
            }
            $('#weatherTable').append(' </tbody></table >');
        }
    });
});

