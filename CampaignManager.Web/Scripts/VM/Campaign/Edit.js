var URL = window.location.pathname;
var CampaignID = url.substring(url.lastIndexOf('/') + 1);

$.ajax({});

var Campaign = function(campaign) {
    var self = this;
    self.CampaignId = ko.observable(campaign ? campaign.CampaignId : 0);
    self.Name = ko.observable(campaign ? campaign.Name : '');
};