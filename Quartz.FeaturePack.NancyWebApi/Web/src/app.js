import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

export class App {
    static inject() {return [Router]};

    constructor(router) {
        this.router = router;
        this.router.configure(config => 
            {
                config.title = 'Quartz.Net Manager';
        config.map([
          { route: ['','scheduler'],  moduleId: './scheduler',      nav: true, title:'Scheduler' }
        ]);
    });
}
}
