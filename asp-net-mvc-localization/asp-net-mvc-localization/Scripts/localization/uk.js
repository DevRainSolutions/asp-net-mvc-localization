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
    var pattern = /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/;
    return this.optional(element) || pattern.test(value);
}