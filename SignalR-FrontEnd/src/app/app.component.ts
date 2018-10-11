import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private hubconnection: HubConnection) { }
  title = 'SignalR-FrontEnd';
  nick = '';
  message = '';
  messages: string[] = [];
  public sendMessage(): void {
    this.hubconnection
      .invoke('sendToAll', this.nick, this.message)
      .catch(err => console.error(err));
  }
  ngOnInIt() {
    this.nick = window.prompt('Your Name: ', 'John');
    this.hubconnection = new HubConnectionBuilder().withUrl('http://localhost:5001/chat').build();
    this.hubconnection
      .start()
      .then(() => console.log('Connection Started'))
      .catch(err => console.log('Error while establishing Connection:('));
    this.hubconnection.on('sendToAll', (nick: string, recieverMessage: string) => {
      const text = nick + ':' + recieverMessage;
      this.messages.push(text);
    });
  }
}
