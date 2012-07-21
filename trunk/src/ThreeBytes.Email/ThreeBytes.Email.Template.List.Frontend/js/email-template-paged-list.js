var email_template_paged_list  = {};

    (function (index) {
        
        email_template_paged_list = index;

        index.requestedPages = ko.observableArray([]);

        index.plural = ko.dependentObservable(function () {
            return this.TotalItemCount() == 1 ? 'template' : 'templates';
        }, index);

        index.is_are = ko.dependentObservable(function () {
            return this.TotalItemCount() == 1 ? 'is' : 'are';
        }, index);
        
        index.navigate = function(obj) {
            
            var el = obj.target;

            if (el.id === "next") {
                if (index.PageNumber() < ko.utils.unwrapObservable(index.PageCount())) {
                     index.PageNumber(index.PageNumber() + 1);
                }
            } 
            else if (el.id === "prev") {
                if (index.PageNumber() > 1) {
                    index.PageNumber(index.PageNumber() - 1);
                }
            } 
            else {
                index.PageNumber(parseInt(el.innerText));
            }

            var makeRequest = true;

            jQuery.each(index.requestedPages(), function() {
                if (this == index.PageNumber()) {
                    makeRequest = false;
                }
            });
            
            if (makeRequest) {
                jQuery.getJSON("/EmailTemplateList/List", { 'page': index.PageNumber(), 'datetime': GetDotNetDate(index.OriginalRequestDateTime()) }, function(data) {
                    jQuery.each(data.Items, function() {
                        index.Items.push(ko.mapping.fromJS(this));
                    });

                    index.requestedPages.push(index.PageNumber());
                });
            }
        };
        
        index.showCurrentPage = ko.dependentObservable(function () {
            var startIndex = 10 * (index.PageNumber() - 1);
            return index.Items.slice(startIndex, startIndex + 10);
        }); 

        index.raiseEdit = function (obj) {
            jQuery(document).trigger('emailTemplateEdit', [obj.Id()]);
        };
        
        index.raiseDetails = function (obj) {
            jQuery(document).trigger('emailTemplateDetails', [obj]);
        };
        
        index.raiseDelete = function (obj) {
            jQuery(document).trigger('emailTemplateDelete', [obj.Id()]);
        };

        jQuery(function() {
            
            jQuery.getJSON("EmailTemplateList/List", function (data) {
                index = ko.mapping.fromJS(data);
                index.requestedPages.push(data.PageNumber);
            });
            
            ko.applyBindings(index, jQuery('#paged-templates-container')[0]);
        });

        jQuery(document).bind('newEmailTemplates', function(event, items) {
            jQuery.each(items, function(i, item) {
                index.Items.unshift(item);
            });
        });

        jQuery(document).bind('emailTemplateUpdated', function (event, id) {
            setTimeout(function() {
                jQuery.getJSON("/EmailTemplateList/Get", { 'id': id }, function(data) {
                    var replacement = ko.mapping.fromJS(data);
                    
                    jQuery.each(index.Items(), function(i, item) {
                        if (item.Id() == id) {
                            index.Items.splice(i, 1, replacement);
                            return false;
                        }
                    });
                });
            }, 200);
        });
        
        jQuery(document).bind('emailTemplateDeleted', function (event, id) {
            jQuery.each(index.Items(), function(i, item) {
                if (item.Id() == id) {
                    index.Items.splice(i, 1);
                    return false;
                }
            });
            
            if (index.Items().length < 10) {
                jQuery.getJSON("/EmailTemplateList/List", { 'page': index.PageNumber(), 'datetime': GetDotNetDate(index.OriginalRequestDateTime()) }, function(data) {
                    ko.mapping.fromJS(data, index);
                });
            }
        });

    } (email_template_paged_list));