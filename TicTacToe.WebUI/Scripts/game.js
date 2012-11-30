$(function () {

    var boardCanvas = document.getElementById("boardCanvas");
    var ctx = boardCanvas.getContext("2d");

    drawVerticalLines(ctx);
    drawHorizontalLines(ctx);

    drawDisc(10, 20, "T");
    drawDisc(100, 200, "U");

    //var gameHub = $.connection.game;
    //gameHub.play();

    function drawDisc(x, y, name) {
        ctx.fillStyle = "rgb(255,0,0)";
        ctx.fillRect(x, y, 20, 20);

        ctx.fillStyle = "rgb(0,255,0)";
        ctx.font = "bold 16px Arial";
        ctx.fillText(name, x, y);
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