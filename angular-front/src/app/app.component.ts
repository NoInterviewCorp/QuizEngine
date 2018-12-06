import { Component } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import {MessagePackHubProtocol} from '@aspnet/signalr-protocol-msgpack';  
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-front';
  constructor() {

  }
  ngOnInit() {
    const divMessages: HTMLDivElement = document.querySelector('#divMessages');
    const tbMessage: HTMLInputElement = document.querySelector('#tbMessage');
    const btnSend: HTMLButtonElement = document.querySelector('#btnSend');
    const username = new Date().getTime();
    const user = "akashg524";
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('http://172.23.238.173:/test?username='+user)
      // .withHubProtocol(new MessagePackHubProtocol())      
      .build();
    connection.start()
		.then(() => {
			console.log('connection established');
		})
		.catch((err) => console.log('Error::: ', err));
    connection.on('messageReceived', (username: string, message: string) => {
      const m = document.createElement('div');

      m.innerHTML =
        `<div class='message__author'>${username}</div><div>${message}</div>`;

      divMessages.appendChild(m);
      divMessages.scrollTop = divMessages.scrollHeight;
    });

    tbMessage.addEventListener('keyup', (e: KeyboardEvent) => {
      if (e.keyCode === 13) {
        send();
      }
    });

    btnSend.addEventListener('click', send);
    function send() {
      connection.send('newMessage', username, tbMessage.value)
        .then(() => tbMessage.value = '');
    }
  }
}
