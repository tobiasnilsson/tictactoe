$(function () {

    var boardCanvas = document.getElementById("boardCanvas");
    var ctx = boardCanvas.getContext("2d");

    drawVerticalLines(ctx);
    drawHorizontalLines(ctx);

    //drawDisc(0, 0, "T");
    //drawDisc(330, 540, "U");
    //drawDisc(270, 180, "U");

    var gameHub = $.connection.game;
    gameHub.client.addMessage = function (message) {
        $('#messages').append('<li>' + message + '</li>');
    };
    
    gameHub.client.addDisc = function (connId, x, y, playerName) {
        drawDisc(x, y, playerName);
    };

    // Start the connection
    $.connection.hub.start().done(function () {
        $("#playButton").click(function () {
            // Call the play method on the server
            gameHub.server.play();
        });
    });

    function drawDisc(x, y, name) {
        ctx.fillStyle = "rgb(255,0,0)";
        ctx.fillRect(x, y, 30, 30);

        ctx.fillStyle = "rgb(0,255,0)";
        ctx.font = "bold 16px Arial";
        ctx.fillText(name, x+10, y+20);
    }

    function drawHorizontalLines(ctx) {
        for (var i = 0; i <= 20; i++) {
            var startX = 0;
            var startY = i * 30;
            var endX = 600;
            var endY = startY;

            drawLine(ctx, startX, startY, endX, endY);
        }
    }
    
    function drawVerticalLines(ctx) {
        for (var i = 0; i <= 20; i++) {
            var startX = i * 30;
            var startY = 0;
            var endX = startX;
            var endY = 600;

            drawLine(ctx, startX, startY, endX, endY);
        }
    }
    
    function drawLine(ctx, startX, startY, endX, endY) {
        ctx.beginPath();
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.stroke();
    }

});