// JavaScript source code
(function () {
    function init() {
        var modal = document.getElementById('myModal');
        document.getElementById("startingLineups").onclick = function () {
            $.get("http://localhost:54736/API/lineups", function (data, s) {
                var div = document.getElementById("Lineus-content");
                div.innerHTML += data;
                //for (var i = 0; i < data.length; i++) {
                //    div.createElement("h2").innerText = data[i];
                //}
            });
            //if (startDay != new Date().getDay() ||
            //(new Date() - new Date(new Date().getFullYear(), new Date().getMonth(), startDay, startTime[0], startTime[1]) >=
            //    3600000)) return; // return something, f.e. no lineup info before 1 hour
            modal.style.display = "block";
        };

        // When the user clicks on <span> (x), close the modal
        document.getElementsByClassName("close")[0].onclick = function () {
            modal.style.display = "none";
        };

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }

    window.onload = init;
})();