$(document).ready(function () {
    ResizeDivContent();
});

function playAudio(song,id) {
    soundManager.setup({
        url: 'soundManager/',
        onready: function () {
            var mySound = soundManager.createSound({
                id: 'aSound' + id,
                url: '../Content/audio/' + song,
                autoLoad: true
        });
            mySound.play();
        }
        //ontimeout: function () {
        //    // Hrmm, SM2 could not start. Missing SWF? Flash blocked? Show an error, etc.?
        //}
    });
}

function rfidConnected(isScannerConnected = false) {
    if (isScannerConnected === false) {
        document.getElementById("led_rfid_scanner_state").className = "led rfid_scanner_error";
        iziToast.error({
            title: 'Oops!',
            message: 'Le lecteur RFID n\'est pas connecté ou mal configuré',
            position: 'topRight',
            timeout: 2000,
            //target: 'content',
            onOpened : playAudio("rfid-connection-error.mp3",'error')
        });
        return false;

    } else {
        document.getElementById("led_rfid_scanner_state").className = "led rfid_scanner_ok";
        iziToast.success({
            title: 'OK',
            message: 'Lecteur RFID detecté et configurer correctement.',
            position: 'topRight',
            timeout: 2000,
            //target: 'content',
            onOpened: playAudio("rfid-connection-ok.mp3","ok")
        });
        return true;
    }
}

function rfidReading(isScannerReading = false) {

    if (isScannerReading === true) {
        document.getElementById("led_rfid_scan_read_state").classList.add('rfid_reading_read');
        playAudio('rfid-read.mp3', 'read');
    } else {
        document.getElementById("led_rfid_scan_read_state").classList.remove('rfid_reading_read');
    }
}

function ResizeDivContent() {
    var p = document.getElementById("content"),
        header = document.getElementById("header"),
        h = window.getComputedStyle(header).getPropertyValue("height");
    p.style.marginTop = h;
}

function OnCommandExecuted(s, e) {
    var text = e.item.name;
    var url;
    switch (e.item.name) {
    case "fullscreen":
       toggleFullScreen();
       break;
    case "refresh":
        $("#content").load(url);
        break;
    case "logout":
        document.getElementById('logoutForm').submit();
        break;
    default:
        url = document.getElementById(text).value;
        $("#content").load(url);
    }
}

function toggleFullScreen() {
    screenfull.toggle($("#content-wrapper")[0]);
}


//function extraButtons2RightRibbon(text) {
//    var div = document.createElement("div");
//    div.id = 'extraButtons2RightRibbon';
//    div.classname = 'extraButtons2RightRibbon';
//    div.innerHTML = text;
//    var y = document.getElementsByClassName("dxtc-rightIndent")[0];
//    console.log(y);
//    y.append(div);
//}

(function() {

    var mainHub = $.connection.MainHub;
    $.connection.hub.logging = true;
    $.connection.hub.start();


}());
