import {HttpClient} from 'aurelia-http-client';
import {inject} from 'aurelia-framework';

export class Scheduler {
    
    static inject() {return [HttpClient]};
    constructor(http) {
        this.http = http;
        
    };
    activate(){
        return this.http.get("http://localhost:8888/api/scheduler").then(response=>{
        this.scheduler=response.content;
        console.log(response.content);
        })
    }
}
