"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, str1, str2, str3) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = str1 + " " + user + " " + str2 + " " + msg + " " + str3;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var str1 = document.getElementById("string1").value;
    var str2 = document.getElementById("string2").value;
    var str3 = document.getElementById("string3").value;
    connection.invoke("SendMessage", user, message, str1, str2, str3).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

}); 