function Get() {
    $.get("http://localhost:54736/API/ARSENAL/lineups", function (data, s) {
        var div = document.getElementById("center");
        div.innerHTML += data.trim();
        div.appendChild(div.firstChild);
    });
}

Get();

