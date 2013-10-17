/// <reference path=backbone-min.js" />
/// <reference path=lodash.min.js" />

var quartzAdmin = quartzAdmin || {};
quartzAdmin.SchedulerView = Backbone.View.extend({
    el: '#scheduler',
    className: 'scheduler',
    template: _.template($("#scheduler-template").html()),
    initialize: function () {
        this.model = new quartzAdmin.Scheduler();
        this.listenTo(this.model, 'change', this.render);
        this.model.fetch({ reset: true });
    },
    render: function () {
        this.$el.html(this.template(this.model.toJSON()));
    }
});