"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
let timer;
let countdown = 30;
let interval;
//jb
let hasvoted = false;
let gameover = false;
let timerWindow = document.createElement("div");
timerWindow.id = "timerWindow";
timerWindow.style.position = "absolute";
timerWindow.style.top = "50px";
timerWindow.style.right = "60px";
timerWindow.style.color = "red";
timerWindow.style.fontSize = "xx-large";
// timerWindow.textContent = 10;
timerWindow.style.display = "none";


//TIMER********************************************************************

document.body.appendChild(timerWindow);
connection.on("ReceiveMessage", function (arrayOfMessages = []) {
    // console.log("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
    // if(interval || timeout){
    //     console.log("*********************************");
    //     console.log(timeout);
    //     if(timer) clearTimeout(timeout);
    //     console.log("*********************************");
    //     console.log(interval);
    //     console.log(countdown);
    //     if(interval) clearInterval(interval);
    //     countdown = 30;
    // }
    // console.log("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
    // if(countdown != 30){
        
    //     countdown = 30;
    // } 

    // timer = setTimeout(()=> {
    //         // console.log("Times up mother fucker");
    //         var seconds = document.getElementById("timerWindow").textContent;
    //         if (seconds <=0 ) clearInterval(countdown);
    //         // clearInterval(countdown);
    //     }, 10000);
    //     interval = setInterval(()=> {
    //             timerWindow.innerHTML = countdown;
    //             countdown--;
    //         },1000)


    if(seconds != 10){
        console.log("############################");
        clearInterval(countdown)
    }
    timerWindow.style.display = "inline";
    timerWindow.textContent = 10;
    var seconds = document.getElementById("timerWindow").textContent;
    var countdown = setInterval(function(){
        seconds --;
        document.getElementById("timerWindow").textContent = seconds;
        if (seconds <= 0){
            clearInterval(countdown);
            connection.invoke("CalculateWinner").catch(function (err) {
                console.error(err.toString());
            });
            gameover = true;
        } 
    }, 1000);



   console.log(arrayOfMessages);
   var list = document.getElementById("messagesList")
   list.innerHTML = ""; //check out if "this" idea does not work
   arrayOfMessages.forEach(cardInput => {
       var li = document.createElement("button"); //change to separate div instead of making a list
       li.classList.add("btn");
       li.classList.add("btn-dark");
       li.classList.add("my-2");
       li.style.width = "40%";
       li.style.minHeight = "170px";
       li.style.marginRight = "3%";
       li.style.marginRight = "3%";
       li.style.backgroundColor = "#202020";
    //    li.classList.add("limitvote");
       li.textContent = cardInput.encodedMsg + "-------------->  VOTES: " + cardInput.voteCount;
       li.addEventListener("click", function() {
           // add to the count of this exact card.
        //    li.classList.add("disabled");
            if (!hasvoted)
            {
                connection.invoke("Vote", cardInput).catch(function (err) {
                     console.error(err.toString());
                 });
                 hasvoted = true;
            }
            // document.getElementsByClassName("limitvote").disabled = true;
       });
    //    list.appendChild(li);
       list.insertBefore(li, list.firstChild);
   });
   // loop through arrayOfMessages

});

///////////////////////////////////////////////////////////////////////////////////
// RESET /////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

       document.getElementById("Reset").addEventListener("click", function (){
           let cardList = document.getElementById("messagesList");
           console.log("FUCK THIS RESET UP")
        //    while(arrayOfMessages.firstChild){
        //        arrayOfMessages.pop();
        //    }
        //    while (cardList.firstChild){
            //     }
            // cardList.innerHTML = ""; //leave alone it only hides it not remove it
            
            console.log("213456789098765432123456789098765432123456789098765434567890098765432345678");
            cardList.remove("messagesList");
            console.log(cardList);
           
       })





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
    var userId = +document.getElementById("loggeduserId").value;
    
    connection.invoke("SendMessage", verb, message, str1, str2, str3, userId).catch(function (err) {
        return console.error(err.toString());
    });
}); 

