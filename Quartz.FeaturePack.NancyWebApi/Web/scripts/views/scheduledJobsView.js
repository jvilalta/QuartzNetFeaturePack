/// <reference path="../lib/backbone-min.js" />


var quartzAdmin = quartzAdmin || {};

quartzAdmin.ScheduledJobsView = Backbone.View.extend({
    el: '#scheduledJobs',
    template: _.template($("#scheduledJobs-template").html()),
    initialize: function () {
        this.collection = new quartzAdmin.ScheduledJobsCollection();
        this.listenTo(this.collection, 'change', this.render);
        this.listenTo(this.collection, 'reset', this.render);
        this.collection.fetch({ reset: true });
    },
    render: function () {
        this.collection.each(function (jobDetail) {
            var jobDetailView = new quartzAdmin.JobDetailView({ model: jobDetail });
            this.$el.append(jobDetailView.render().el);
        }, this);
    }
});