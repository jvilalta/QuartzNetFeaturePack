/// <reference path="../lib/backbone-min.js" />
/// 
var quartzAdmin = quartzAdmin || {};

quartzAdmin.View = Backbone.View.extend({
    el: '#quartzAdmin',
    initialize: function () {
        this.schedulerView = new quartzAdmin.SchedulerView();
    },
    render: function () {
    }
});
$(function () {
    new quartzAdmin.View();
});