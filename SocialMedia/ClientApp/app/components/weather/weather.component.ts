import { Component, OnInit, AfterViewChecked, ElementRef, ViewChild } from '@angular/core';
import { SocialService } from '../services/social.service';


@Component({
    selector: 'app-weather',
    templateUrl: './weather.component.html',
    styleUrls: ['./weather.component.css'],
    providers: [SocialService]
})

export class WeatherComponent implements OnInit, AfterViewChecked {
    @ViewChild('scrollMe') private myScrollContainer: ElementRef;

    ngAfterViewChecked(): void {
        this.scrollToBottom();
    }

    scrollToBottom(): void {
        try {
            this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
            console.log(this.myScrollContainer.nativeElement.scrollTop);
        } catch (err) { }
    }

    //weathers: Weather[] = [];
    counter = 0;
    city = '';
    date: string;
    weatherVisibility: boolean = false;

    constructor(private socialService: SocialService) { }

    ngOnInit() {
        this.getTime()

    }
    //getWeather(city: string) {

    //    this.chatService.getWeather(city).subscribe((data) => {

    //        this.weathers.push(JSON.parse(data['_body']));
    //        this.weatherVisibility = true;

    //    })

    //}
    getTime() {
        const time = new Date;
        this.date = time.getHours() + ":" + time.getMinutes()
    }
}

