"use strict";
import { clsMensajeUsuario } from './EntitiesJS/clsMensajeUsuario.js'

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${message.nombre} : ${message.mensaje}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var mensaje = document.getElementById("messageInput").value;
    const messageUsuario = new clsMensajeUsuario(user, mensaje);
    connection.invoke("SendMessage", messageUsuario).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});