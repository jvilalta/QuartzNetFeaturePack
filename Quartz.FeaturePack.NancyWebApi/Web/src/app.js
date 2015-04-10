import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
//import 'bootstrap';
//import 'bootstrap/css/bootstrap.css!';

export class App {
    static inject() {return [Router]};
    constructor(router) {
        this.router = router;
        this.router.configure(config => 
            {
                config.title = 'Aurelia';
        config.options.pushState=true;
        config.map([
          { route: '',  moduleId: './welcome',      nav: true, title:'Welcome' },
          { route: 'flickr',        moduleId: './flickr',       nav: true }
        ]);
    });
}
}
