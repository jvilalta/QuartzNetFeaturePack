System.register([], function (_export) {
    var _createClass, _classCallCheck, Welcome;

    return {
        setters: [],
        execute: function () {
            "use strict";

            _createClass = (function () { function defineProperties(target, props) { for (var key in props) { var prop = props[key]; prop.configurable = true; if (prop.value) prop.writable = true; } Object.defineProperties(target, props); } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

            _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } };

            Welcome = _export("Welcome", (function () {
                function Welcome() {
                    _classCallCheck(this, Welcome);

                    this.heading = "Welcome to the Aurelia Navigation App (VS/TS)!";
                    this.firstName = "John";
                    this.lastName = "Doe";
                }

                _createClass(Welcome, {
                    fullName: {
                        get: function () {
                            return this.firstName + " " + this.lastName;
                        }
                    },
                    welcome: {
                        value: function welcome() {
                            alert("Welcome, " + this.fullName + "!");
                        }
                    }
                });

                return Welcome;
            })());
        }
    };
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiO3VDQUFhLE9BQU87Ozs7Ozs7Ozs7O0FBQVAsbUJBQU87QUFDTCx5QkFERixPQUFPLEdBQ0Y7MENBREwsT0FBTzs7QUFFWix3QkFBSSxDQUFDLE9BQU8sR0FBRyxnREFBZ0QsQ0FBQztBQUNoRSx3QkFBSSxDQUFDLFNBQVMsR0FBRyxNQUFNLENBQUM7QUFDeEIsd0JBQUksQ0FBQyxRQUFRLEdBQUcsS0FBSyxDQUFDO2lCQUN6Qjs7NkJBTFEsT0FBTztBQU1aLDRCQUFROzZCQUFBLFlBQUc7QUFDWCxtQ0FBTyxJQUFJLENBQUMsU0FBUyxHQUFHLEdBQUcsR0FBRyxJQUFJLENBQUMsUUFBUSxDQUFDO3lCQUMvQzs7QUFDRCwyQkFBTzsrQkFBQSxtQkFBRztBQUNOLGlDQUFLLENBQUMsV0FBVyxHQUFHLElBQUksQ0FBQyxRQUFRLEdBQUcsR0FBRyxDQUFDLENBQUM7eUJBQzVDOzs7O3VCQVhRLE9BQU8iLCJmaWxlIjoiYXBwLmpzIiwic291cmNlUm9vdCI6Ii9zcmMvIn0=