import { Component, Inject } from '@angular/core';
import { Http } from "@angular/http";


@Component({
    selector: 'location',
    templateUrl: './location.component.html'
})
export class LocationComponent {
    public location = new Location(0, 0);
    public locationAvailable: boolean;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public sendLocation() {
        this.http.post(this.baseUrl + 'api/Location/Send', this.location).subscribe(error => console.error(error));
    }

    public locate() {
        if (!navigator.geolocation) {
            this.locationAvailable = false;
            return;
        }

        navigator.geolocation.getCurrentPosition(
            (pos) => this.onLocateSuccess(pos),
            this.onLocateFailure,
            { timeout: 10000 }
        );
    }

    private onLocateSuccess(position: Position) {
        this.locationAvailable = true;
        this.location = new Location(position.coords.latitude, position.coords.longitude);
        this.sendLocation();
    }

    private onLocateFailure() {
        this.locationAvailable = false;
    }
}

export class Location {
    constructor(public latitude: number, public longitude: number) {
        this.latitude = latitude;
        this.longitude = longitude;
    }
}
