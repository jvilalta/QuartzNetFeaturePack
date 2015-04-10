System.register(["aurelia-framework", "aurelia-router"], function (_export) {
    var inject, Router, _createClass, _classCallCheck, App;

    return {
        setters: [function (_aureliaFramework) {
            inject = _aureliaFramework.inject;
        }, function (_aureliaRouter) {
            Router = _aureliaRouter.Router;
        }],
        execute: function () {
            "use strict";

            _createClass = (function () { function defineProperties(target, props) { for (var key in props) { var prop = props[key]; prop.configurable = true; if (prop.value) prop.writable = true; } Object.defineProperties(target, props); } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

            _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } };

            App = _export("App", (function () {
                function App(router) {
                    _classCallCheck(this, App);

                    this.router = router;
                    this.router.configure(function (config) {
                        config.title = "Quartz.Net Manager";
                        config.map([{ route: ["", "scheduler"], moduleId: "./scheduler", nav: true, title: "Scheduler" }]);
                    });
                }

                _createClass(App, null, {
                    inject: {
                        value: function inject() {
                            return [Router];
                        }
                    }
                });

                return App;
            })());
        }
    };
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiO1FBQVEsTUFBTSxFQUNOLE1BQU0saUNBRUQsR0FBRzs7OztBQUhSLGtCQUFNLHFCQUFOLE1BQU07O0FBQ04sa0JBQU0sa0JBQU4sTUFBTTs7Ozs7Ozs7O0FBRUQsZUFBRztBQUdELHlCQUhGLEdBQUcsQ0FHQSxNQUFNLEVBQUU7MENBSFgsR0FBRzs7QUFJUix3QkFBSSxDQUFDLE1BQU0sR0FBRyxNQUFNLENBQUM7QUFDckIsd0JBQUksQ0FBQyxNQUFNLENBQUMsU0FBUyxDQUFDLFVBQUEsTUFBTSxFQUN4QjtBQUNJLDhCQUFNLENBQUMsS0FBSyxHQUFHLG9CQUFvQixDQUFDO0FBQzVDLDhCQUFNLENBQUMsR0FBRyxDQUFDLENBQ1QsRUFBRSxLQUFLLEVBQUUsQ0FBQyxFQUFFLEVBQUMsV0FBVyxDQUFDLEVBQUcsUUFBUSxFQUFFLGFBQWEsRUFBTyxHQUFHLEVBQUUsSUFBSSxFQUFFLEtBQUssRUFBQyxXQUFXLEVBQUUsQ0FDekYsQ0FBQyxDQUFDO3FCQUNOLENBQUMsQ0FBQztpQkFDTjs7NkJBWlksR0FBRztBQUNMLDBCQUFNOytCQUFBLGtCQUFHO0FBQUMsbUNBQU8sQ0FBQyxNQUFNLENBQUMsQ0FBQTt5QkFBQzs7Ozt1QkFEeEIsR0FBRyIsImZpbGUiOiJhcHAuanMiLCJzb3VyY2VSb290IjoiL3NyYy8ifQ==