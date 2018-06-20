import { Component, OnInit, AfterViewChecked, ElementRef, ViewChild } from '@angular/core';
import { SocialService } from '../services/social.service';
import { Weather } from '../models/weather';
import { forEach } from '@angular/router/src/utils/collection';


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

    weathers: Weather[];
    counter = 0;
    city = '';
    date: string;
    weatherVisibility: boolean = false;

    constructor(private socialService: SocialService) {
        this.weathers = new Array<Weather>();
    }

    ngOnInit() {
        this.getTime()

    }
    getWeather(city: string) {


        this.socialService.getWeather(city).subscribe(data => {
            this.weathers.push(data);
            console.log(data);
        });
        this.weatherVisibility = true;


    }
    getWeatherCallBack(weather: Weather[]) {

    }
    getTime() {
        const time = new Date;
        this.date = time.getHours() + ":" + time.getMinutes()
    }
}

