function GetDate(jsonDate) {
    if (jsonDate != null) {
        var date = eval(jsonDate.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        return dateFormat(date, "dd/mm/yyyy HH:MM:ss");
    }

    return "Not Set";
}

function GetDotNetDate(jsonDate) {
    if (jsonDate != null) {
        var date = eval(jsonDate.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        return dateFormat(date, "mm/dd/yyyy HH:MM:ss");
    }

    return "Not Set";
}

function EscapeDotNet(item) {
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
}