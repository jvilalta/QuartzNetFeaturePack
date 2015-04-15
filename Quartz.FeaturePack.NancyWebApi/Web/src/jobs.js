import {HttpClient} from 'aurelia-http-client';
import {inject} from 'aurelia-framework';

export class Jobs {
    
    static inject() {return [HttpClient]};
    constructor(http) {
        this.http = http;
        
    };
    activate(){
        return this.http.get("http://localhost:8888/api/jobs").then(response=>{
        this.jobs=response.content;
        console.log(this.jobs);
        })
    }
}
