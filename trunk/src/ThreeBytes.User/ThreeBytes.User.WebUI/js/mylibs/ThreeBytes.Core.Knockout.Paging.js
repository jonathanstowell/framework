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

            jQuery(document).bind('resetPaging', function (event, pagingIdentifier, datetime) {
                resetPaging.execute(pagingIdentifier, datetime);
            });
        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_simpleGrid_grid", "\
                    <em>There&nbsp;<span data-bind=\"text:is_are\"></span>&nbsp;<span data-bind=\"text:totalItemCount\"></span>&nbsp;<span data-bind=\"text:plural\"></span></em>\
                    <table class=\"ko-grid zebra-striped\">\
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
                jQuery(document).trigger('resetPaging', [id, datetime]);
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
                        <div class=\"alert-message info\" data-bind=\"click: raiseOpen\">\
                            <em>There&nbsp;<span data-bind=\"text:is_are\"></span>&nbsp;<span data-bind=\"text:items().length\"></span>&nbsp;New&nbsp;<span data-bind=\"text:plural\"></span></em></p>\
                        </div>\
                        <div class=\"modal hide fade\">\
                            <div class=\"modal-header\">\
                                <a href=\"#\" class=\"close\" data-bind=\"click: raiseClose\">×</a>\
                                <h3>Latest Items</h3>\
                            </div>\
                            <div class=\"modal-body modal-body-scrollable\">\
                                <table class=\"ko-grid zebra-striped\">\
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
                                <button class=\"btn danger\" data-bind=\"click: raiseClose\">Close</button>\
                                <button class=\"btn primary\" data-bind=\"click: resetPaging\">Reset Paging</button>\
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