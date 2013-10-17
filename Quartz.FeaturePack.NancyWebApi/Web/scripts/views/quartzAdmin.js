/// <reference path="../lib/backbone-min.js" />
/// 
var quartzAdmin = quartzAdmin || {};

quartzAdmin.View = Backbone.View.extend({
    el: '#quartzAdmin',
    initialize: function () {
        this.schedulerView = new quartzAdmin.SchedulerView();
        this.scheduledJobs = new quartzAdmin.ScheduledJobsView();
    },
    render: function () {
    }
});
$(function () {
    new quartzAdmin.View();
});