"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (arrayOfMessages = []) {
   console.log(arrayOfMessages);
   var list =document.getElementById("messagesList")
   list.innerHTML = ""; //check out if "this" idea does not work
   arrayOfMessages.forEach(thing => {
       var li = document.createElement("li"); //change to separate div instead of making a list
       li.classList.add("btn");
       li.classList.add("btn-dark");
       li.classList.add("my-2");
       li.textContent = thing.encodedMsg + " ---------- " + thing.voteCount;
       li.addEventListener("click", function() {
           // add to the count of this exact card.
           connection.invoke("Vote", thing).catch(function (err) {
                console.error(err.toString());
            });
    
       });
       list.appendChild(li);
   });
   // loop through arrayOfMessages
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var verb = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var str1 = document.getElementById("string1").value;
    var str2 = document.getElementById("string2").value;
    var str3 = document.getElementById("string3").value;
    var userId = document.getElementById("loggeduserId").value;
    connection.invoke("SendMessage", verb, message, str1, str2, str3, userId).catch(function (err) {
        return console.error(err.toString());
    });
}); 

