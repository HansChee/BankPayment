import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptionsArgs, URLSearchParams, RequestOptions } from '@angular/http';

/**
 * common service
 */
@Injectable()
export class CommonService {
    constructor(private http: Http) { }

    postJson = (
        url: string
        , jsonObj: Object
        , next?: (value: Response) => void
        , error?: (error: any) => void
        , complete?: () => void) => {
        let headers = new Headers();
        headers.set("Content-Type", "application/json");

        let options = new RequestOptions({ headers: headers });
        let jsonString = JSON.stringify(jsonObj);
        this.http.post(url
            , jsonString
            , options
        ).subscribe(next, error, complete);
    }
}