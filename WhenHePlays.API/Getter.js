function GetMatch() {
    $.get("http://localhost:54736/api/arsenal", function (data, s) {
        var centered = document.getElementsByClassName("centered");
        centered[0].getElementsByTagName('img')[0].src = data[0];
        centered[1].getElementsByTagName('img')[0].src = data[1];
        centered[0].getElementsByTagName('h2')[0].innerText = data[2];
        centered[1].getElementsByTagName('h2')[0].innerText = data[3];
    });
}

GetMatch();