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
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlbGNvbWUuanMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IjtxQ0FBYSxPQUFPOzs7Ozs7Ozs7OztBQUFQLGFBQU87QUFLUCxpQkFMQSxPQUFPLEdBS0o7Z0NBTEgsT0FBTzs7QUFNaEIsY0FBSSxDQUFDLE9BQU8sR0FBRyxnREFBZ0QsQ0FBQztBQUNoRSxjQUFJLENBQUMsU0FBUyxHQUFHLE1BQU0sQ0FBQztBQUN4QixjQUFJLENBQUMsUUFBUSxHQUFHLEtBQUssQ0FBQztTQUN2Qjs7cUJBVFUsT0FBTztBQVdkLGtCQUFRO2lCQUFBLFlBQUc7QUFDYixxQkFBTyxJQUFJLENBQUMsU0FBUyxHQUFHLEdBQUcsR0FBRyxJQUFJLENBQUMsUUFBUSxDQUFDO2FBQzdDOztBQUVELGlCQUFPO21CQUFBLG1CQUFHO0FBQ1IsbUJBQUssQ0FBQyxXQUFXLEdBQUcsSUFBSSxDQUFDLFFBQVEsR0FBRyxHQUFHLENBQUMsQ0FBQzthQUMxQzs7OztlQWpCVSxPQUFPIiwiZmlsZSI6IndlbGNvbWUuanMiLCJzb3VyY2VSb290IjoiL3NyYy8ifQ==