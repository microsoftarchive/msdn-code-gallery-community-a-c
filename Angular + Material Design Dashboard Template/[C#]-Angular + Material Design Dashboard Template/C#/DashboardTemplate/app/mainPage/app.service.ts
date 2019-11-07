import { Injectable, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class AppService {

    constructor(private http: Http) { }
    @Output() fire: EventEmitter<any> = new EventEmitter();
    @Output() fire2: EventEmitter<any> = new EventEmitter();

    apiKey: string = "<ADD YOUR INQSTATS KEY HERE>";

    getINQStatsData(data, region) {
        console.log('http://inqstatsapi.inqubu.com?api_key=' + this.apiKey + '&countries=' + region + '&data=' + data + '&lang=en');

        return this.http.get('http://inqstatsapi.inqubu.com?api_key='+this.apiKey+'&countries='+region+'&data='+data+'&lang=en')
            .map(function (res: Response) {
                let body = res.json();
                return body;
            })
    }

    updateView(data) {
        this.fire.emit(data);
    }

    getUpdatedView() {
        return this.fire2;
    }

    resizeView() {
        this.fire2.emit();
    }

    getEmittedValue() {
        return this.fire;
    }

}