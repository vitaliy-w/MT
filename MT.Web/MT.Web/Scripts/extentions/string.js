String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{\{|\}\}|\{(\d+)\}/g, function (m, n) {
        if (m == "{{") { return "{"; }
        if (m == "}}") { return "}"; }
        return args[n];
    });
};

String.prototype.endsWith = function(suffix) {
    return (this.substr(this.length - suffix.length) === suffix);
};

String.prototype.startsWith = function(prefix) {
    return (this.substr(0, prefix.length) === prefix);
};