window.onload = function(){
    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");
    var bg = document.getElementById("bg");
    ctx.drawImage(bg, 0, 0, 300, 180);
}