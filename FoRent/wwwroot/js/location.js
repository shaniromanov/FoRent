var my_token = "5a4b8472-b95b-4687-8179-0ccb621c7990";


var func_type = "";

$(document).ready(function () {
    govmap.createMap('map_div',
        {

            token: my_token,
            visibleLayers: [],
            layers: ["retzefMigrashim", "PARCEL_ALL", "SUB_GUSH_ALL"],
            layersMode: 2,
            showXY: true,
            identifyOnClick: true
        });
});


$(function () {

    $("#cbx_types li a").click(function () {

        $(".btn:first-child").text($(this).text());
        $(".btn:first-child").val($(this).text());

        func_type = $(this).text();
        var address = "";
        if (func_type == "AddUserPoint") {
            govmap.draw(govmap.drawType.Point).progress(function (e) {
                var data = {
                    'wkts': [e.wkt
                    ],

                    'names': ['p1'],
                    'geometryType': govmap.drawType.Point,
                    'defaultSymbol':
                    {
                        'url': 'http://maps.google.com/mapfiles/ms/micons/horsebackriding.png',
                        'width': 15,
                        'height': 15
                    },

                    'symbols': [{
                        'url': 'http://maps.google.com/mapfiles/ms/micons/horsebackriding.png',
                        'width': 15,
                        'height': 15
                    }
                    ],
                    'clearExisting': true,
                    'data': {
                        'tooltips': ['this is my tooltip'],
                        'bubbles': [''],
                        'bubbleUrl': 'https://ynet.co.il'
                    }
                };
                govmap.displayGeometries(data).then(function (e) {
                    console.log("point created");
                });
            });


        }

        if (func_type == "GeocodeString") {
            $("#myModal").modal("show");
        }
        if (func_type == "GetSearchAccuracy") {
            GovMapGisApi_GetSearchAccuracy(address, "GetSearchAccuracyResult");
        }
        if (func_type == "GetXY") {
            govmap.getXY().progress(function (e) {
                console.log(e);
                alert(e.mapPoint.x + " / " + e.mapPoint.y);
                govmap.setDefaultTool();
            });
        }
        if (func_type == "DrawRectangle") {
            govmap.draw(govmap.drawType.Rectangle).progress(function (e) {
                wkt = e.wkt;
                console.log(wkt);
                var thep = document.getElementById("info");
                thep.innerHTML = "";
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode("WKT:"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode(wkt));
                thep.appendChild(document.createElement("br"));
                thep.className = "lead";
                document.getElementById("myModalLabel").innerHTML = "Rectangle Info";
                $("#myInfoModal").modal("show");
            });

        }
        if (func_type == "DrawCircle") {
            govmap.draw(govmap.drawType.Circle).progress(function (e) {
                var thep = document.getElementById("info");
                thep.innerHTML = "";
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode("X Coordinate:"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode(e.x));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode("Y Coordinate:"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode(e.y));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode("Radius:"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode(e.radius));
                document.getElementById("myModalLabel").innerHTML = "Circle Info";
                thep.className = "lead";
                $("#myInfoModal").modal("show");
            });
        }
        if (func_type == "DrawPolygon") {
            govmap.draw(govmap.drawType.Polygon).progress(function (e) {
                console.log(e.wkt);
                var thep = document.getElementById("info");
                thep.innerHTML = "";
                thep.appendChild(document.createElement("WKT:"));
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode(e.wkt));
                document.getElementById("myModalLabel").innerHTML = "WKT Info";
                thep.className = "lead";
                $("#myInfoModal").modal("show");
            });
        }
        if (func_type == "ZoomToDrawing") {
            govmap.zoomToDrawing();
        }
        if (func_type == "ClearDrawing") {
            govmap.clearDrawings();
        }
        if (func_type == "FilterLayer") {
            govmap.filterLayers({ 'layerName': "PARCEL_ALL", 'whereClause': "GUSH_NUM =7620 AND PARCEL =274", 'zoomToExtent': true });
        }
        if (func_type == "AddressToLotParcel") {
            $("#myModalAddressToLotParcel").modal("show");

        }
        if (func_type == "LotParcelToAddress") {
            $("#myModalLotParcelToAddress").modal("show");
        }
        if (func_type == "intersectFeatures") {
            govmap.intersectFeatures({
                address: "הרוקמים 26 חולון",
                layerName: "PARCEL_ALL",
                fields: ['GUSH_NUM', 'PARCEL']
            }).then(function (e) {
                alert(e.data[0].Values[0] + " / " + e.data[0].Values[1]);
            });


        }

    });
});

function TestGovMap() {
    govmap.geocode({ keyword: document.getElementById("string_address").value }, govmap.geocodeType.FullResult)
        .then(function (response) {
            console.log("then:");
            console.log(response);
            govmap.zoomToXY({ x: response.data[0].X, y: response.data[0].Y, level: 10, marker: true });

        })
        .done(function (response) {
            console.log("done:");
            console.log(response);
        })
        .always(function (response) {
            console.log("always:");
            console.log(response);
        })
        .fail(function (response) {
            console.log("fail:");
            console.log(response);
        });
}

var addr_list = {};
var results;
function TestGovMapExpanded() {
    var thep = document.getElementById("additional results");
    thep.innerHTML = "";
    govmap.geocode({ keyword: document.getElementById("address").value + document.getElementById("city").value }, govmap.geocodeType.FullResult)
        .then(function (response) {
            console.log("then:");
            console.log(response);
            results = response.data;
            if (results.length == 1) {
                govmap.zoomToXY({ x: response.data[0].X, y: response.data[0].Y, level: 10, marker: true });
                document.getElementById("x").value = response.data[0].X;
                document.getElementById("y").value = response.data[0].Y;
            }
            if (results.length > 1) {
                document.getElementById("Coordinates").innerHTML = "";
                var thep = document.getElementById("additional results");
                thep.appendChild(document.createElement("br"));
                thep.appendChild(document.createTextNode("האם התכוונת ל: " + "\n"));
                thep = document.getElementById("additional results");
                thep.innerHTML = "";
                var addr_list_txt = "";
                addr_list = {};
                for (var i = 0; i < results.length; i++) {
                    addr_list[results[i].ResultLable] = [results[i].X, results[i].Y];
                    addr_list_txt = addr_list_txt + results[i].ResultLable + "\n";

                    var thep = document.getElementById("additional results");
                    thep.appendChild(document.createElement("br"));
                    thep.appendChild(document.createTextNode("\n"));
                    var r = results[i].ResultLable;
                    var btn = document.createElement("BUTTON");
                    btn.type = 'button';
                    btn.className = "btn btn-link";
                    btn.innerHTML = r;
                    btn.value = r;
                    btn.addEventListener('click', function () {
                        document.getElementById("myModalstring").value = this.value;
                        govmap.zoomToXY({ x: addr_list[this.value][0], y: addr_list[this.value][1], level: 10, marker: true });
                    }, false);
                    document.getElementById("additional results").appendChild(btn);
                }
            }

        })
        .done(function (response) {
            console.log("done:");
            console.log(response);
        })
        .always(function (response) {
            console.log("always:");
            console.log(response);
        })
        .fail(function (response) {
            console.log("fail:");
            console.log(response);
        });
}

function TestGovMapAddressToLotParcel() {
    govmap.searchAndLocate({
        type: govmap.locateType.lotParcelToAddress,
        address: document.getElementById("myModalstringAddressToLotParcel").value
    }).then(function (e) {
        e.data[0].Values[0];
        e.data[0].Values[1];
        document.getElementById("LotParcel").innerHTML = "גוש " + e.data[0].Values[0] + " חלקה " + e.data[0].Values[1]; //40095 13
    });

}

function TestGovMapLotParcelToAddress() {
    govmap.searchAndLocate({
        type: govmap.locateType.addressToLotParcel,
        lot: document.getElementById("myModalstringGush").value,
        parcel: document.getElementById("myModalstringParcel").value
    }).then(function (e) {
        var thep = document.getElementById("Addr");
        thep.innerHTML = "";
        var Addresses = e;
        thep.appendChild(document.createElement("Addresses:"));
        thep.appendChild(document.createElement("br"));
        for (i = 0; i < Addresses.data.length; i++) {

            thep.appendChild(document.createElement("br"));
            var r = Addresses.data[i].Values[0] + " " + Addresses.data[i].Values[1] + " " + Addresses.data[i].Values[2];
            var btn = document.createElement("BUTTON");
            btn.type = 'button';
            btn.className = "btn btn-link";
            btn.innerHTML = r;
            btn.value = r;
            btn.addEventListener('click', function () {
            }, false);
            thep.appendChild(btn);
        }
    });

}