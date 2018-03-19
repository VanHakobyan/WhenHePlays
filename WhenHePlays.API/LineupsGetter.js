function GetLineups() {
    $.get("http://localhost:54736/API/lineups", function (data, s) {
        var div = document.getElementById("center");
        div.innerHTML += data.trim();
        div.appendChild(div.firstChild);
    });
}

GetLineups();

