/// <reference path="../lib/backbone-min.js" />


var quartzAdmin = quartzAdmin || {};

quartzAdmin.ScheduledJobsCollection = Backbone.Collection.extend({
    model: quartzAdmin.ScheduledJob,
    url: '/api/Jobs'
});