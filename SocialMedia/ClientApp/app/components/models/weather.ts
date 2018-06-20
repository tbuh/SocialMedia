export class Weather {
    constructor(public weather: any) {
        this.dateFormatted = weather.dateFormatted;
        this.description = weather.description;
        this.temp = weather.temp;
        this.tempMax = weather.tempMax;
        this.tempMin = weather.tempMin;

    }

    public dateFormatted: string;
    public description: string;
    public temp: string;
    public tempMin: string;
    public tempMax: string;
}