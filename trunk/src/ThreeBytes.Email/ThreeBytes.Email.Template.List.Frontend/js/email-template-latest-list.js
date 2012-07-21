var email_template_latest_list  = {};
    
    (function (index) {
        
        email_template_latest_list = index;

        index.plural = ko.dependentObservable(function () {
            return this.Items().length == 1 ? 'template' : 'templates';
        }, index);

        index.is_are = ko.dependentObservable(function () {
            return this.Items().length == 1 ? 'is' : 'are';
        }, index);
        
        index.copyToPagedList = function () {
            jQuery(document).trigger('newEmailTemplates', [index.Items()]);
            jQuery.each(index.Items(), function(i, item) {
                index.Items.remove(item);
            });
        };

        jQuery(function() {
            
            jQuery.getJSON("EmailTemplateList/GetNewerThan", function (data) {
                index = ko.mapping.fromJS(data);         
            });
            
            ko.applyBindings(index, jQuery('#latest-templates-container')[0]);
            index.alertMessage = jQuery('#latest-templates-alert-message');
            
        });
        
        setInterval(function() {
            jQuery.getJSON("EmailTemplateList/GetNewerThan", { 'datetime': GetDotNetDate(index.RequestDateTime()) }, function (data) {
                ko.mapping.fromJS(data, index);           
            });
        }, 1000);

    } (email_template_latest_list));