"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable send button until connection is established

    
    document.getElementById("sendButton").disabled = true;
    let timer;
    // let countdown = 30;
    let timers = {};
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
    timerWindow.style.display = "inline";
    var resetbutton = document.getElementById("Reset");
    var logoutbutton = document.getElementById("Logout");
    var voteline = document.getElementById("VoteLine");
    var winnerline = document.getElementById("winnerline");
    document.body.appendChild(timerWindow);
    // var seconds = document.getElementById("timerWindow").textContent;
    // var countdown;

    function ResetTimer() {
        let seconds = 30;
        return setInterval(() => {
            seconds--;
            console.log(seconds);
            var timerwindow = $("#timerWindow");
            console.log("message to us TIMER WINDOW TEXT", timerwindow.text());
            timerwindow.text(`${seconds}`);
            if (seconds <= 0) {
                clearInterval(timers["interval"]);
                timers["interval"] = null;
                var winnername =  connection.invoke("CalculateWinner").catch(function (err) {
                    console.error(err.toString());
                });
                console.log(winnername);
                
                resetbutton.style.display = "inline";
                logoutbutton.style.display = "inline";
                let cardList = document.getElementById("messagesList");
                cardList.innerHTML = "";
                winnerline.style.display = "block";
                voteline.style.display = "none";
                // let placeholer = "USERNAME";
                winnername.then(function(result){
                    winnerline.textContent = ("Congratulations, " + result + " is the winner!");
                })
                
                gameover = true;
            }
        }, 1000);
    }


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



        timerWindow.textContent = 30;
        if (!timers["interval"]) {

            timers["interval"] = ResetTimer();
        }
        else {
            console.log("############################", timers["interval"]);
            clearInterval(timers["interval"]);
            timers["interval"] = null;
            timers["interval"] = ResetTimer();

        }

        // document.getElementById("timerWindow").addEventListener("oninput")


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
            li.textContent = cardInput.encodedMsg;
            li.addEventListener("click", function () {
                // add to the count of this exact card.
                //    li.classList.add("disabled");
                if (!hasvoted) {
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

    document.getElementById("Reset").addEventListener("click", function () {
        let cardList = document.getElementById("messagesList");

        connection.invoke("PlayAgain").catch(function (err) {
            console.error(err.toString());
        });
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
        var Username = document.getElementById("loggedUser").value;
        connection.invoke("SendMessage", verb, message, str1, str2, str3, userId, Username).catch(function (err) {
            return console.error(err.toString());
        });
    });


