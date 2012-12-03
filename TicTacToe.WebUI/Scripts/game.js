$(function () {
    
    var boardCanvas = document.getElementById("boardCanvas");
    var ctx = boardCanvas.getContext("2d");

    resetBoard();
    setupMessageHistory();
    setupHub();
    
    function setupMessageHistory() {
        var oldResults = getOldResults();

        if (!oldResults)
            return;

        for (var i = 0; i < oldResults.length; i++) {
            addMessage(oldResults[i]);
        }
    }
    
    function addMessage(message) {
        $('#messages').prepend(
            $('<li>' + message + '</li>').hide().fadeIn('slow')
        );
    }

    function setupHub() {
        var gameHub = $.connection.game;

        gameHub.client.gameEnded = function (eventArgs) {

            var result = JSON.parse(eventArgs);
            markWinningCombo(result.WinningCombination);
            
            addMessage(result.Message);
            storeResult(result.message);
        };

        gameHub.client.addDisc = function (connId, x, y, playerName, message) {
            drawDisc(x, y, playerName);

            if (message && message.length > 0)
                addMessage(message);
        };

        // Start the connection
        $.connection.hub.start().done(function () {
            $("#playButton").click(function () {

                resetBoard();

                // Call the play method on the server
                gameHub.server.play();
            });
        });
    }
    
    function markWinningCombo(discs) {
        for (var i = 0; i < discs.length; i++) {
            var disc = discs[i];
            var x = disc.X;
            var y = disc.Y;
            var color = "rgb(0,255,0)";
            drawDisc(x, y, disc.PlayerName, color);
        }
    }
    
    var _playersAndColors = new Array();
    function getColor(playerName) {
        if (!_playersAndColors[playerName])
            _playersAndColors[playerName] = getRandomColor();

        return _playersAndColors[playerName];
    }
    function getRandomColor() {
        var colorStr = "rgb({r},{g},{b})";
        var r = Math.floor((Math.random() * 255) + 1);
        var g = Math.floor((Math.random() * 255) + 1);
        var b = Math.floor((Math.random() * 255) + 1);

        return colorStr.replace("{r}", r).replace("{g}", g).replace("{b}",b);
    }
    
    function storeResult(message) {
        if (Modernizr.localstorage) {
            // window.localStorage is available! Store the result
            localStorage.result = localStorage.result + "|" + message;
        }
    }

    function getOldResults() {
        if (!Modernizr.localstorage)
            return "";
        
        return localStorage.result ? localStorage.result.split("|") : "";
    }
    
    function resetBoard() {
        ctx.clearRect(0, 0, boardCanvas.width, boardCanvas.height);
        
        drawVerticalLines(ctx);
        drawHorizontalLines(ctx);
    }

    function drawDisc(x, y, name, rgbColor) {
        //Convert coords to fit the board since it is 30px spaces
        x = x * 30 - 30;
        y = y * 30 - 30;

        ctx.fillStyle = rgbColor ? rgbColor : getColor(name);
        ctx.fillRect(x, y, 30, 30);

        ctx.fillStyle = "rgb(0,0,0)";
        ctx.font = "bold 16px Arial";
        ctx.fillText(name, x+10, y+20);
    }

    function drawHorizontalLines() {
        for (var i = 0; i <= 20; i++) {
            var startX = 0;
            var startY = i * 30;
            var endX = 600;
            var endY = startY;

            drawLine(startX, startY, endX, endY);
        }
    }
    
    function drawVerticalLines() {
        for (var i = 0; i <= 20; i++) {
            var startX = i * 30;
            var startY = 0;
            var endX = startX;
            var endY = 600;

            drawLine(startX, startY, endX, endY);
        }
    }
    
    function drawLine(startX, startY, endX, endY) {
        ctx.beginPath();
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.stroke();
    }

});