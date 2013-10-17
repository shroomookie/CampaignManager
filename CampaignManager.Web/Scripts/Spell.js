var SpellsVM = function() {
    var self = this;
    var url = "/api/spell/";
    var refresh = function() {
        $.getJSON(url, {}, function(data) {
            self.Spells(data);
        });
    };

    self.Spell = ko.observableArray();
    self.Spells = ko.observableArray([]);

    self.SpellSelect = ko.computed({
        read: self.Spell,
        write: function(spell) {
            if (spell) {
                $.getJSON('/api/spell/' + spell, null, function(data) {
                    self.Spell(data);

                });
            }
        }
    });
    refresh();
};

ko.applyBindings(new SpellsVM());
