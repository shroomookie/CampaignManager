var Character = function (character) {
    var self = this;
    //self.Id = ko.observable(character ? character.Id : 0);
    self.Name = ko.observable(character ? character.Name : '');
    self.RaceId = ko.observable(character ? character.Race : '');
    self.Gender = ko.observable(character ? character.Gender : '');
    self.Age = ko.observable(character ? character.Age : '');
    self.Height = ko.observable(character ? character.Height : '');
    self.Weight = ko.observable(character ? character.Weight : '');
    self.Hair = ko.observable(character ? character.Hair : '');
    self.Eyes = ko.observable(character ? character.Eyes : '');
    self.AlignmentId = ko.observable(character ? character.Alignment : '');
    //self.Deity = ko.observable(character ? character.Deity : '');
};

var CharacterClass = function (characterClass) {
    var self = this;
    self.Id = ko.observable(characterClass ? characterClass.Id : '');
};

var Skill = function (skill) {
    var self = this;
    self.Id = ko.observable(skill ? skill.Id : 0);

};

var CharacterManagerVM = function () {
    var self = this;
    
    self.character = ko.observable(new Character());

    var retrieveJSON = function (url, field) {
        $.getJSON(url, null, function(data) {
            field(data);
            });
        };

    var initialize = function() {
        retrieveJSON('/api/alignment/', self.alignments);
        retrieveJSON('/api/characterclass/', self.characterClasses);
        retrieveJSON('/api/skill/', self.skills);
        retrieveJSON('/api/race/', self.races);
    };

    self.races = ko.observableArray([]);
    self.alignments = ko.observableArray([]);
    self.characterClasses = ko.observableArray([]);
    self.characterClass = ko.observable();
    self.skills = ko.observableArray([]);

    self.raceSelect = ko.computed({        
        read: self.character().RaceId,
        write: function (race) {
            self.character().RaceId(race);
        }
    });
    
    self.alignmentSelect = ko.computed({        
        read: self.character().AlignmentId,
        write: function (alignment) {
            self.character().AlignmentId(alignment);
            if (alignment) {
                $.getJSON('/api/alignment/' + alignment, null, function(data) {
                    self.characterClasses(data.CharacterClasses);
                });
            }
        }
    });
    
    self.characterClassSelect = ko.computed({
        read: self.characterClass,
        write: function (characterClass) {
            //if (characterClass) {
                self.characterClass(characterClass);
                $.getJSON('/api/characterclass/' + characterClass, null, function(data) {
                    for (i = 0; i < data.SkillNames.length; i++) {
                        $('#skill' + data.SkillNames[i].Id).attr('checked', true);
                    }
                });
            //}
        }
    });

    self.saveCharacter = function () {
       
        $.ajax({
            type: "POST",
            url: "/api/charactermanager/",
            data: JSON.stringify(ko.toJS(self.character())),
            datatype: 'json',
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function(data) {
                alert('success');
            },
            error: function() {
                alert('error');
            }
        });
    };
    
    initialize();
};

ko.applyBindings(new CharacterManagerVM());