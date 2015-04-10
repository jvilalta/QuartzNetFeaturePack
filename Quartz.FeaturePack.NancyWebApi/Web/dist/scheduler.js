System.register(["aurelia-http-client", "aurelia-framework"], function (_export) {
    var HttpClient, inject, _createClass, _classCallCheck, Scheduler;

    return {
        setters: [function (_aureliaHttpClient) {
            HttpClient = _aureliaHttpClient.HttpClient;
        }, function (_aureliaFramework) {
            inject = _aureliaFramework.inject;
        }],
        execute: function () {
            "use strict";

            _createClass = (function () { function defineProperties(target, props) { for (var key in props) { var prop = props[key]; prop.configurable = true; if (prop.value) prop.writable = true; } Object.defineProperties(target, props); } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

            _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } };

            Scheduler = _export("Scheduler", (function () {
                function Scheduler(http) {
                    _classCallCheck(this, Scheduler);

                    this.http = http;
                }

                _createClass(Scheduler, {
                    activate: {
                        value: function activate() {
                            var _this = this;

                            return this.http.get("http://localhost:8888/api/scheduler").then(function (response) {
                                _this.scheduler = response.content;
                                console.log(response.content);
                            });
                        }
                    }
                }, {
                    inject: {
                        value: function inject() {
                            return [HttpClient];
                        }
                    }
                });

                return Scheduler;
            })());
        }
    };
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNjaGVkdWxlci5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiO1FBQVEsVUFBVSxFQUNWLE1BQU0saUNBRUQsU0FBUzs7OztBQUhkLHNCQUFVLHNCQUFWLFVBQVU7O0FBQ1Ysa0JBQU0scUJBQU4sTUFBTTs7Ozs7Ozs7O0FBRUQscUJBQVM7QUFHUCx5QkFIRixTQUFTLENBR04sSUFBSSxFQUFFOzBDQUhULFNBQVM7O0FBSWQsd0JBQUksQ0FBQyxJQUFJLEdBQUcsSUFBSSxDQUFDO2lCQUVwQjs7NkJBTlEsU0FBUztBQU9sQiw0QkFBUTsrQkFBQSxvQkFBRTs7O0FBQ04sbUNBQU8sSUFBSSxDQUFDLElBQUksQ0FBQyxHQUFHLENBQUMscUNBQXFDLENBQUMsQ0FBQyxJQUFJLENBQUMsVUFBQSxRQUFRLEVBQUU7QUFDM0Usc0NBQUssU0FBUyxHQUFDLFFBQVEsQ0FBQyxPQUFPLENBQUM7QUFDaEMsdUNBQU8sQ0FBQyxHQUFHLENBQUMsUUFBUSxDQUFDLE9BQU8sQ0FBQyxDQUFDOzZCQUM3QixDQUFDLENBQUE7eUJBQ0w7OztBQVZNLDBCQUFNOytCQUFBLGtCQUFHO0FBQUMsbUNBQU8sQ0FBQyxVQUFVLENBQUMsQ0FBQTt5QkFBQzs7Ozt1QkFGNUIsU0FBUyIsImZpbGUiOiJzY2hlZHVsZXIuanMiLCJzb3VyY2VSb290IjoiL3NyYy8ifQ==