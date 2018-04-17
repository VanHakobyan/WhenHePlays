var months = {
    "Jan": 1,
    "Feb": 2,
    "Mar": 3,
    "Apr": 4,
    "May": 5,
    "Jun": 6,
    "Jul": 7,
    "Aug": 8,
    "Sep": 9,
    "Oct": 10,
    "Nov": 11,
    "Dec": 12
};

var startDay = 0;
var startTime = [0, 0];

function GetMatch() {
    $.get("http://localhost:54736/api/arsenal", function (data, s) {
        var centered = document.getElementsByClassName("centered");
        centered[0].getElementsByTagName('img')[0].src = data[0];
        centered[1].getElementsByTagName('img')[0].src = data[1];
        centered[0].getElementsByTagName('h2')[0].innerText = data[2];
        centered[1].getElementsByTagName('h2')[0].innerText = data[3];

        document.getElementsByClassName('startDate')[0].innerText = _toArmTime(data[4]) + " | " + data[5];
    });
}

function _toArmTime(date) {
    var spl = date.split(' ');
    var time = spl[4].split(':');
    startDay = spl[2];
    startTime[0] = Number(time[0]) + 3;
    startTime[1] = Number(time[1]);
    return  spl[2] + "/" + months[spl[1]] + "/" + (new Date()).getFullYear().toString() + " - " + (Number(time[0]) + 3).toString() + ":" + time[1];
}

GetMatch();