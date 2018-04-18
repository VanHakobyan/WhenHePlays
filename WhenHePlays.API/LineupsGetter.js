


function GetLineups() {
    $.get("http://localhost:54736/API/lineups", function (data, s) {
        var div = document.getElementById("Lineus-content");
        div.innerHTML = data;
        //for (var i = 0; i < data.length; i++) {
        //    div.createElement("h2").innerText = data[i];
        //}
    });
}

