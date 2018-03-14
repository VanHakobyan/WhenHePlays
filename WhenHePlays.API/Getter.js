function GetMatch() {
    $.get("http://localhost:54736/API/ARSENAL", function (data, s) {
        var div = document.getElementById("center");
        div.innerHTML += data.trim();
        div.appendChild(div.firstChild);
        document.getElementsByClassName("card__footer")[0].remove();
        document.getElementsByClassName("fixture-match__versus")[0].remove();
        var teams = document.getElementsByClassName("team-crest");
        teams[0].id = "home";
        teams[1].id = "away";
    });
}

GetMatch();

