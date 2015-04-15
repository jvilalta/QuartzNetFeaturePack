System.register(["aurelia-http-client", "aurelia-framework"], function (_export) {
    var HttpClient, inject, _createClass, _classCallCheck, Jobs;

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

            Jobs = _export("Jobs", (function () {
                function Jobs(http) {
                    _classCallCheck(this, Jobs);

                    this.http = http;
                }

                _createClass(Jobs, {
                    activate: {
                        value: function activate() {
                            var _this = this;

                            return this.http.get("http://localhost:8888/api/jobs").then(function (response) {
                                _this.jobs = response.content;
                                console.log(_this.jobs);
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

                return Jobs;
            })());
        }
    };
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImpvYnMuanMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtRQUFRLFVBQVUsRUFDVixNQUFNLGlDQUVELElBQUk7Ozs7QUFIVCxzQkFBVSxzQkFBVixVQUFVOztBQUNWLGtCQUFNLHFCQUFOLE1BQU07Ozs7Ozs7OztBQUVELGdCQUFJO0FBR0YseUJBSEYsSUFBSSxDQUdELElBQUksRUFBRTswQ0FIVCxJQUFJOztBQUlULHdCQUFJLENBQUMsSUFBSSxHQUFHLElBQUksQ0FBQztpQkFFcEI7OzZCQU5RLElBQUk7QUFPYiw0QkFBUTsrQkFBQSxvQkFBRTs7O0FBQ04sbUNBQU8sSUFBSSxDQUFDLElBQUksQ0FBQyxHQUFHLENBQUMsZ0NBQWdDLENBQUMsQ0FBQyxJQUFJLENBQUMsVUFBQSxRQUFRLEVBQUU7QUFDdEUsc0NBQUssSUFBSSxHQUFDLFFBQVEsQ0FBQyxPQUFPLENBQUM7QUFDM0IsdUNBQU8sQ0FBQyxHQUFHLENBQUMsTUFBSyxJQUFJLENBQUMsQ0FBQzs2QkFDdEIsQ0FBQyxDQUFBO3lCQUNMOzs7QUFWTSwwQkFBTTsrQkFBQSxrQkFBRztBQUFDLG1DQUFPLENBQUMsVUFBVSxDQUFDLENBQUE7eUJBQUM7Ozs7dUJBRjVCLElBQUkiLCJmaWxlIjoiam9icy5qcyIsInNvdXJjZVJvb3QiOiIvc3JjLyJ9