(function () {
    // Private function
    function getColumnsForScaffolding(data) {
        if ((typeof data.length !== 'number') || data.length === 0) {
            return [];
        }
        var columns = [];
        for (var propertyName in data[0]) {
            columns.push({ headerText: propertyName, rowText: propertyName });
        }
        return columns;
    }

    ko.pagedGrid = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {

            this.items = configuration.data.Items;
            this.originalRequestDateTime = configuration.data.OriginalRequestDateTime;
            this.pageCount = configuration.data.PageCount;
            this.totalItemCount = configuration.data.TotalItemCount;
            this.pageNumber = configuration.data.PageNumber;
            this.pageSize = configuration.data.PageSize || 5;
            this.hasPreviousPage = configuration.data.HasPreviousPage;
            this.hasNextPage = configuration.data.HasNextPage;
            this.isFirstPage = configuration.data.IsFirstPage;
            this.isLastPage = configuration.data.IsLastPage;
            this.additionalFunctions = configuration.additionalFunctions;
            this.orderBy = ko.observable('Name');
            this.isAsc = ko.observable(true);
            this.pagingComponentIdentfier = configuration.pagingComponentIdentifier;
            this.updateEvent = configuration.updateEvent || null;
            this.deleteEvent = configuration.deleteEvent || null;

            // If you don't specify columns configuration, we'll use scaffolding
            this.columns = configuration.columns || getColumnsForScaffolding(ko.utils.unwrapObservable(this.items));

            this.plural = ko.dependentObservable(function () {
                return this.totalItemCount() == 1 ? configuration.singular : configuration.plural;
            }, this);

            this.is_are = ko.dependentObservable(function () {
                return this.totalItemCount() == 1 ? 'is' : 'are';
            }, this);

            this.navigate = function (nav, page) {

                if (nav === 'next') {
                    if (this.pageNumber() < ko.utils.unwrapObservable(this.pageCount())) {
                        this.pageNumber(this.pageNumber() + 1);
                    }
                }
                else if (nav === 'prev') {
                    if (this.pageNumber() > 1) {
                        this.pageNumber(this.pageNumber() - 1);
                    }
                }
                else {
                    this.pageNumber(page);
                }

                var sortBy = this.isAsc() ? 'Asc' : 'Desc';

                jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': this.pageNumber(), 'datetime': ko.utils.toISOStringFromJson(this.originalRequestDateTime()), 'orderBy': this.orderBy(), 'sortBy': sortBy }, function (data) {
                    configuration.loadPageCallback(data);
                });
            };

            this.pageNavigation = ko.dependentObservable(function () {
                return ko.utils.range(1, this.pageCount());
            }, this);

            this.setOrderBy = function (orderBy) {
                if (this.orderBy() == orderBy) {
                    if (this.isAsc()) {
                        this.isAsc(false);
                    }
                    else {
                        this.isAsc(true);
                    }
                } else {
                    this.orderBy(orderBy);
                    this.isAsc(true);
                }

                var sortBy = this.isAsc() ? 'Asc' : 'Desc';

                jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': this.pageNumber(), 'datetime': ko.utils.toISOStringFromJson(this.originalRequestDateTime()), 'orderBy': this.orderBy(), 'sortBy': sortBy }, function (data) {
                    configuration.loadPageCallback(data);
                });
            };

            var resetPaging = {};

            (function (index, model) {
                index.execute = function (pagingIdentifier, datetime) {

                    if (model.pagingComponentIdentfier == pagingIdentifier) {
                        model.originalRequestDateTime(datetime);

                        var sortBy = model.isAsc() ? 'Asc' : 'Desc';

                        jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': model.pageNumber(), 'datetime': ko.utils.toISOStringFromJson(model.originalRequestDateTime()), 'orderBy': model.orderBy(), 'sortBy': sortBy }, function (data) {
                            configuration.loadPageCallback(data);
                        });
                    }
                };
            } (resetPaging, this));

            jQuery(document).bind('resetPaging', function (event, pagingIdentifier, datetime, items) {
                resetPaging.execute(pagingIdentifier, datetime);
            });

            if (this.deleteEvent != null) {
                jQuery(document).bind(this.deleteEvent, function (event, id) {
                    var toRemove = ko.utils.arrayFirst(index.Items(), function (item) {
                        return item.Id() == id;
                    });

                    if (toRemove == null || toRemove == undefined)
                        return;

                    index.Items.remove(toRemove);

                    if (index.Items().length < 10) {
                        jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': model.PageNumber(), 'datetime': ko.utils.toISOStringFromJson(model.originalRequestDateTime()), 'orderBy': model.orderBy(), 'sortBy': sortBy }, function (data) {
                            ko.mapping.fromJS(data, index);
                        });
                    }
                });
            }

            if (this.updateEvent != null) {
                jQuery(document).bind(this.updateEvent, function(event, newItem) {
                    var update = ko.utils.arrayFirst(index.Items(), function(item) {
                        return item.Id() == id;
                    });

                    if (update == null || update == undefined)
                        return;

                    update.Title(newItem.Title());
                    update.Content(newItem.Content());

                    for (var propertyName in update[0]) {
                        if (newItem[propertyName] != null || newItem[propertyName] != undefined) {
                            update[propertyName](newItem[propertyName]());
                        }
                    }
                });
            }
        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_simpleGrid_grid", "\
                    <em>There&nbsp;<span data-bind=\"text:is_are\"></span>&nbsp;<span data-bind=\"text:totalItemCount\"></span>&nbsp;<span data-bind=\"text:plural\"></span></em>\
                    <table class=\"ko-grid table table-striped table-bordered table-condensed\">\
                        <thead>\
                            <tr data-bind=\"foreach: columns\">\
                               <th data-bind=\"text: headerText\" class=\"header\"></th>\
                            </tr>\
                        </thead>\
                        <tbody data-bind=\"foreach: items\">\
                           <tr data-bind=\"foreach: $parent.columns\">\
                               <td data-bind=\"text: typeof rowText == 'function' ? rowText($parent) : $parent[rowText] \"></td>\
                            </tr>\
                        </tbody>\
                    </table>");
    templateEngine.addTemplate("ko_simpleGrid_pageLinks", "\
                    <div class=\"pagination pull-right\" data-bind=\"visible: items().length > 0\">\
                        <ul>\
                            <li data-bind=\"css: { disabled: pageNumber() === 1 }\" class=\"prev-container\">\
                                <a data-bind=\"click: function (event) { navigate('prev') }\" href=\"#\" class=\"prev\">← Previous</a>\
                            </li>\
                            <li data-bind=\"css: { disabled: pageNumber() === 1 }\" class=\"first-container\">\
                                <a data-bind=\"click: function() { navigate('first', 1); }\" href=\"#\" class=\"first\">First</a>\
                            </li>\
                            <span data-bind=\"foreach: pageNavigation\" id=\"pages-container\">\
                                <li data-bind=\"css: { active: $parent.pageNumber() == $data }\" class=\"first-container\"><a href=\"#\" title=\"View Page $data\" data-bind=\"click: function() { $parent.navigate('page', $data); }\"><span data-bind=\"text: $data\"></span></a></li>\
                            </span>\
                            <li data-bind=\"css: { disabled: pageNumber() === pageCount() }\" class=\"last-container\">\
                                <a data-bind=\"click: function() { navigate('last', pageCount()); }\" href=\"#\" id=\"last\">Last</a>\
                            </li>\
                            <li data-bind=\"css: { disabled: pageNumber() === pageCount() }\" class=\"next-container\">\
                                <a data-bind=\"click: function (event) { navigate('next') }\" href=\"#\" class=\"next\">Next →</a>\
                            </li>\
                        </ul>\
                    </div>");
    templateEngine.addTemplate("ko_simpleGrid_basicPageLinks", "\
                    <div class=\"pagination pagination-centered\">\
                        <ul>\
                            <li data-bind=\"css: { disabled: pageNumber() === 1 }\" class=\"prev-container\">\
                                <a data-bind=\"click: function (event) { navigate('prev') }\" href=\"#\" class=\"prev\">←</a>\
                            </li>\
                            <li data-bind=\"css: { disabled: pageNumber() === pageCount() }\" class=\"next-container\">\
                                <a data-bind=\"click: function (event) { navigate('next') }\" href=\"#\" class=\"next\">→</a>\
                            </li>\
                        </ul>\
                    </div>");

    ko.bindingHandlers.pagedGrid = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            // Empty the element
            while (element.firstChild)
                ko.removeNode(element.firstChild);

            // Allow the default templates to be overridden
            var gridTemplateName = allBindings.pagedGridTemplate || "ko_simpleGrid_grid",
                pageLinksTemplateName = allBindings.pagedGridPagerTemplate || "ko_simpleGrid_pageLinks";

            // Render the main grid
            var gridContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTemplateName, viewModel, { templateEngine: templateEngine }, gridContainer, "replaceNode");

            // Render the page links
            var pageLinksContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(pageLinksTemplateName, viewModel, { templateEngine: templateEngine }, pageLinksContainer, "replaceNode");
        }
    };
})();

(function () {
    // Private function
    function getColumnsForScaffolding(data) {
        if ((typeof data.length !== 'number') || data.length === 0) {
            return [];
        }
        var columns = [];
        for (var propertyName in data[0]) {
            columns.push({ headerText: propertyName, rowText: propertyName });
        }
        return columns;
    }

    ko.latestItems = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {

            this.items = configuration.data.Items;
            this.originalRequestDateTime = configuration.data.OriginalRequestDateTime;
            this.requestDateTime = configuration.data.RequestDateTime;
            this.pagingComponentIdentfier = configuration.pagingComponentIdentifier;
            this.createdModal = false;

            // If you don't specify columns configuration, we'll use scaffolding
            this.columns = configuration.columns || getColumnsForScaffolding(ko.utils.unwrapObservable(this.items));

            this.plural = ko.dependentObservable(function () {
                return this.items() == 1 ? configuration.singular : configuration.plural;
            }, this);

            this.is_are = ko.dependentObservable(function () {
                return this.items() == 1 ? 'is' : 'are';
            }, this);

            this.raiseOpen = function () {
                if (this.createdModal == false) {
                    this.detailModal = jQuery('#' + configuration.divIdentifier + ' .modal').modal({ backdrop: true, closeOnEscape: true, modal: true });
                    this.createdModal = true;
                }

                this.detailModal.modal('show');
            };

            this.raiseClose = function () {
                this.detailModal.modal('hide');
            };

            this.resetPaging = function () {
                var id = this.pagingComponentIdentfier;
                var datetime = this.requestDateTime();
                var items = this.items();
                jQuery(document).trigger('resetPaging', [id, datetime, items]);
                this.items.removeAll();
                this.originalRequestDateTime(this.requestDateTime());
                this.detailModal.modal('hide');
            };

            setInterval(function () {
                jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'datetime': ko.utils.toISOStringFromJson(configuration.data.OriginalRequestDateTime()) }, function (data) {
                    configuration.loadPageCallback(data);
                });
            }, 5000);
        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_latest_items", "\
                    <div class=\"latest-items\" data-bind=\"visible: items().length > 0\">\
                        <div class=\"alert alert-info\" data-bind=\"click: raiseOpen\">\
                            <em>There&nbsp;<span data-bind=\"text:is_are\"></span>&nbsp;<span data-bind=\"text:items().length\"></span>&nbsp;New&nbsp;<span data-bind=\"text:plural\"></span></em></p>\
                        </div>\
                        <div class=\"modal hide fade\">\
                            <div class=\"modal-header\">\
                                <a href=\"#\" class=\"close\" data-bind=\"click: raiseClose\">×</a>\
                                <h3>Latest Items</h3>\
                            </div>\
                            <div class=\"modal-body modal-body-scrollable\">\
                                <table class=\"ko-grid table table-striped table-bordered table-condensed\">\
                                    <thead>\
                                        <tr data-bind=\"foreach: columns\">\
                                            <th data-bind=\"text: headerText\" class=\"header\"></th>\
                                        </tr>\
                                    </thead>\
                                    <tbody data-bind=\"foreach: items\">\
                                        <tr data-bind=\"foreach: $parent.columns\">\
                                            <td data-bind=\"text: typeof rowText == 'function' ? rowText($parent) : $parent[rowText] \"></td>\
                                        </tr>\
                                    </tbody>\
                                </table>\
                            </div>\
                            <div class=\"modal-footer\">\
                                <button class=\"btn btn-danger\" data-bind=\"click: raiseClose\">Close</button>\
                                <button class=\"btn btn-primary\" data-bind=\"click: resetPaging\">Reset Paging</button>\
                            </div>\
                        </div>\
                    </div>");

    ko.bindingHandlers.latestItems = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            // Empty the element
            while (element.firstChild)
                ko.removeNode(element.firstChild);

            // Allow the default templates to be overridden
            var latestItemsTemplateName = allBindings.latestItemsTemplate || "ko_latest_items";

            // Render the main grid
            var itemContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(latestItemsTemplateName, viewModel, { templateEngine: templateEngine }, itemContainer, "replaceNode");
        }
    };
})();

(function () {

    ko.pagedList = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {
            
            var itemMapping = {
			    'CreationDateTime': ko.utils.getTimeAgoFromJson(),
                'LastModifiedDateTime': ko.utils.getDateFromJson('dd/MMM HH:mm')
		    };

            var itemViewModel = function(data) {
			    ko.mapping.fromJS(data, itemMapping, this);
		    };

            var mapping = {	
			    'Items': {
				    create: function(options) {
					    return new itemViewModel(options.data);
				    }
			    }
		    };

            this.items = configuration.data.Items;
            this.originalRequestDateTime = configuration.data.OriginalRequestDateTime;
            this.pageCount = configuration.data.PageCount;
            this.totalItemCount = configuration.data.TotalItemCount;
            this.pageNumber = configuration.data.PageNumber;
            this.pageSize = configuration.data.PageSize || 5;
            this.hasPreviousPage = configuration.data.HasPreviousPage;
            this.hasNextPage = configuration.data.HasNextPage;
            this.isFirstPage = configuration.data.IsFirstPage;
            this.isLastPage = configuration.data.IsLastPage;
            this.additionalFunctions = configuration.additionalFunctions;
            this.orderBy = ko.observable('Name');
            this.isAsc = ko.observable(true);
            this.pagingComponentIdentfier = configuration.pagingComponentIdentifier;
            this.updateEvent = configuration.updateEvent || null;
            this.deleteEvent = configuration.deleteEvent || null;

            this.plural = ko.dependentObservable(function () {
                return this.totalItemCount() == 1 ? configuration.singular : configuration.plural;
            }, this);

            this.is_are = ko.dependentObservable(function () {
                return this.totalItemCount() == 1 ? 'is' : 'are';
            }, this);
            
            var more = {};

            (function (index, model) {
                index.more = true;
                index.execute = function () {
                    if(!more)
                        return;
                    
                    model.pageNumber((model.pageNumber() + 1));
                    
                    jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': model.pageNumber(), 'datetime': ko.utils.toISOStringFromJson(model.originalRequestDateTime()) }, function (data) {
                        if(data.Items.length == 0) {
                            more = false;
                            return;
                        }

                        var newItems = ko.mapping.fromJS(data, mapping);
                        
                        ko.utils.arrayForEach(newItems.Items(), function(item) {
                            model.items.push(item);
                        });
                    });
                };
            } (more, this));
            
            jQuery(window).scroll(function () {
                if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                    more.execute();
               }
            });
            
            var resetPaging = {};

            (function (index, model) {
                index.execute = function (pagingIdentifier, datetime, items) {

                    if (model.pagingComponentIdentfier == pagingIdentifier) {
                        ko.utils.arrayForEach(items, function(item) {
                            model.items.unshift(item);
                            model.totalItemCount((model.totalItemCount() + 1));
                        });
                    }
                };
            } (resetPaging, this));
            
            jQuery(document).bind('resetPaging', function (event, pagingIdentifier, datetime, items) {
                resetPaging.execute(pagingIdentifier, datetime, items);
            });

            if (this.deleteEvent != null) {
                jQuery(document).bind(this.deleteEvent, function (event, id) {
                    var toRemove = ko.utils.arrayFirst(index.Items(), function (item) {
                        return item.Id() == id;
                    });

                    if (toRemove == null || toRemove == undefined)
                        return;

                    index.Items.remove(toRemove);

                    if (index.Items().length < 10) {
                        jQuery.getJSON('/' + configuration.controller + '/' + configuration.action, { 'page': model.PageNumber(), 'datetime': ko.utils.toISOStringFromJson(model.originalRequestDateTime()), 'orderBy': model.orderBy(), 'sortBy': sortBy }, function (data) {
                            ko.mapping.fromJS(data, index);
                        });
                    }
                });
            }

            if (this.updateEvent != null) {
                jQuery(document).bind(this.updateEvent, function(event, newItem) {
                    var update = ko.utils.arrayFirst(index.Items(), function(item) {
                        return item.Id() == id;
                    });

                    if (update == null || update == undefined)
                        return;

                    update.Title(newItem.Title());
                    update.Content(newItem.Content());

                    for (var propertyName in update[0]) {
                        if (newItem[propertyName] != null || newItem[propertyName] != undefined) {
                            update[propertyName](newItem[propertyName]());
                        }
                    }
                });
            }
        }
    };
    
    var templateEngine = new ko.nativeTemplateEngine();

    ko.bindingHandlers.pagedList = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            // Empty the element
            while (element.firstChild)
                ko.removeNode(element.firstChild);

            // Allow the default templates to be overridden
            var gridTemplateName = allBindings.pagedListTemplate;

            // Render the main grid
            var gridContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTemplateName, viewModel, { templateEngine: templateEngine }, gridContainer, "replaceNode");
        }
    };
})();