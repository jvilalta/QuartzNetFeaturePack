/// <reference path=backbone-min.js" />
/// <reference path=lodash.min.js" />
var quartzAdmin = quartzAdmin || {};
quartzAdmin.Scheduler = Backbone.Model.extend({
    urlRoot:'/api/scheduler'
});
