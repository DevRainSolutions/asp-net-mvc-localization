$.validator.methods.range = function (value, element, param) {
    var globalizedValue;
    if (value.contains(",")) {
        globalizedValue = value.replace(",", ".");
    } else {
        globalizedValue = value.replace(".", ",");
    }
    
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:,\d+)?$/.test(value);
}

$.validator.methods.date = function(value, element) {
    if ($.browser.webkit) {
        //ES - Chrome does not use the locale when new Date objects instantiated:
        var d = new Date();

        return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
    }
    else {

        return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
    }
}

 