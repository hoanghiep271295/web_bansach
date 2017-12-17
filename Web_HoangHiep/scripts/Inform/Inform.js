﻿var alert = document.createElement('div');
alert.classList += 'notification';
alert.id = 'alert';
var span = document.createElement('span');
span.classList += 'span_alert';

alert.appendChild(span);

var style_alert = "font-family:'serif'; position: fixed; z-index: 10000;height:50px; bottom: 15%; right: 1%; width:fit-content; font-size: 1em; padding: 1em 1em; border-radius: 8px;";

alert.setAttribute("style", style_alert);


var style = "display: none;  z-index: 10000; padding: 50px; position: fixed; top: 40% ; transform: translateX(-50%); left: 50%; width: 500px;";



$(document).ready(function () {
    var main = document.getElementById('page-wrapper');
    main.appendChild(alert);
});

var log = new Log();

function Log() {
    this.show = function (message, result) {
        span.innerText = message;
        alert.style.display = 'block';
        if (result) {
            alert.style.backgroundColor = 'rgba(7, 138, 5, 0.5)';
            span.style.color = '#e5fbe0';
        }
        else {
            alert.style.backgroundColor = 'rgba(181, 72, 72, 0.5)';
            span.style.color = '#e5fbe0';
        }

        setTimeout(function () {
            alert.style.display = 'none';
        }, 2500);
    }
}
