/// <reference path=backbone-min.js" />
/// <reference path=lodash.min.js" />

var quartzAdmin = quartzAdmin || {};

quartzAdmin.JobDetailView = Backbone.View.extend({
    tag: 'div',
    template: _.template($('#jobDetail-template').html()),
    initialize: function () {
    },
    render: function () {
        this.$el.html(this.template(this.model.toJSON()));
        return this;
    }
});