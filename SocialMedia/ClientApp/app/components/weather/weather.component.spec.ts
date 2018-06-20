/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { WeatherComponent } from './weather.component';

let component: WeatherComponent;
let fixture: ComponentFixture<WeatherComponent>;

describe('weather component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ WeatherComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(WeatherComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});