import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {
    private _hubConnection: HubConnection | undefined;
    public currentCount = 0;
    public _message = '';

    public incrementCounter() {
        this.currentCount++;
        if (this._hubConnection) {
            this._hubConnection.invoke('Send', 'haha');
        }        
    }

    ngOnInit() {
        this._hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('/chatHub')
            .configureLogging(signalR.LogLevel.Information)
            .build();

        this._hubConnection.start().catch(err => console.error(err.toString()));

        this._hubConnection.on('Send', (data: any) => {
            const received = `Received: ${data}`;
            this._message = received;
        });
    }
}
