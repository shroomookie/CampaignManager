var SpellsVM = function() {
    var self = this;
    var url = "/api/spell/";
    var refresh = function() {
        $.getJSON(url, {}, function(data) {
            self.Spells(data);
        });
    };

    self.Spells = ko.observableArray([]);
    refresh();
};

ko.applyBindings(new SpellsVM());
