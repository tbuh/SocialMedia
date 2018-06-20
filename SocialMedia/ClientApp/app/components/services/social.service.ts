import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Weather } from '../models/weather';
import 'rxjs/add/operator/map';
import { Response } from '@angular/http/src/static_response';

@Injectable()
export class SocialService {

    constructor(private http: Http) { }

    getWeather(city: string) {
        const endpoint = `/api/media/WeatherForecasts?city=${city}`;
        return this.http.get(endpoint)
            .map((res: Response) => res.json())

    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
