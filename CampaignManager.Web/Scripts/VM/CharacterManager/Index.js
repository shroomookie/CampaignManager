var CharacterManagerVM = function () {
    var self = this;
    var url = "/api/charactermanager/";
    var refresh = function () {
        $.getJSON(url, {}, function (data) {
            self.Characters(data);
        });
    };

    self.Characters = ko.observableArray([]);
    refresh();
};

ko.applyBindings(new CharacterManagerVM());