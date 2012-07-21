(function () {

    ko.utils.padzero = function (n) {
        return n < 10 ? '0' + n : n;
    };

    ko.utils.pad2zeros = function (n) {
        if (n < 100) {
            n = '0' + n;
        }
        if (n < 10) {
            n = '0' + n;
        }
        return n;
    };

    ko.utils.toISOStringFromJson = function (d) {
        var value = eval(d.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        return value.getUTCFullYear() + '-' + ko.utils.padzero(value.getUTCMonth() + 1) + '-' + ko.utils.padzero(value.getUTCDate()) + 'T' + ko.utils.padzero(value.getUTCHours()) + ':' + ko.utils.padzero(value.getUTCMinutes()) + ':' + ko.utils.padzero(value.getUTCSeconds()) + '.' + ko.utils.pad2zeros(value.getUTCMilliseconds()) + 'Z';
    };

    ko.utils.getFormatedDateTimeNow = function() {
        var value = new Date();
        return dateFormat(value, "dd/mm/yyyy HH:MM:ss");
    };

    ko.utils.getDateFromJson = function () {
        return {
            create: function (options) {
                if (options.data == null)
                    return ko.observable("Not Set");

                var value = eval(options.data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                return ko.observable(dateFormat(value, "dd/mm/yyyy HH:MM:ss"));
            }
        };
    };

    ko.utils.jsonToEscapedDateString = function (d) {
        var value = eval(d.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        var item = dateFormat(value, "dd/mm/yyyy HH:MM:ss");

        var encodedInputString = escape(item);

        encodedInputString = encodedInputString.replace(/\+/g, "%2B");
        var newEncodedInputString = encodedInputString;
        do {
            encodedInputString = newEncodedInputString;
            newEncodedInputString = encodedInputString.replace("/", "%2F");
        }
        while (encodedInputString != newEncodedInputString);
        encodedInputString = newEncodedInputString;

        return encodedInputString;
    };

    ko.utils.getTimeAgoFromJson = function () {
        return {
            create: function (options) {
                if (options.data == null)
                    return "Not Set";

                var value = eval(options.data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                var stringDate = dateFormat(value, "mm/dd/yyyy HH:MM:ss");
                return jQuery.timeago(stringDate);
            }
        };
    };

    ko.utils.escapeDate = function (item) {
        var encodedInputString = escape(item);

        encodedInputString = encodedInputString.replace(/\+/g, "%2B");
        var newEncodedInputString = encodedInputString;
        do {
            encodedInputString = newEncodedInputString;
            newEncodedInputString = encodedInputString.replace("/", "%2F");
        }
        while (encodedInputString != newEncodedInputString);
        encodedInputString = newEncodedInputString;

        return encodedInputString;
    };

})();