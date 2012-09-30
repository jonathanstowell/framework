(function () {

    function currentUserViewModel(username, colour) {
        this.Username = username;
        this.Colour = colour;
    }

    ko.currentlyViewingComponent = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {

            this.currentViewers = ko.observableArray([]);

            var index = this;

            this.initialiseCurrentViewers = function (currentUsers) {

                index.currentViewers.removeAll();

                ko.utils.arrayForEach(currentUsers, function (item) {
                    index.currentViewers.push(new currentUserViewModel(item.Username, item.Colour));
                });
            };

            configuration.hub.handleImViewingMessage = function (username, colour, id) {
                if (configuration.id() != id)
                    return;

                var findResult = ko.utils.arrayFirst(index.currentViewers(), function (item) {
                    return item.Username == username;
                });

                if (findResult == null)
                    index.currentViewers.push(new currentUserViewModel(username, colour));

                jQuery('a[rel=tooltip]').tooltip();
            };

            configuration.hub.handleImLeavingMessage = function (username, id) {
                if (configuration.id() != id)
                    return;

                index.currentViewers.remove(function (item) {
                    return item.Username == username;
                });
            };

            jQuery(configuration.modalSelector).bind('show', function () {
                configuration.hub.imViewing(configuration.id());
            });

            jQuery(configuration.modalSelector).bind('hide', function () {
                configuration.hub.imLeaving(configuration.id());
            });
        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_currentlyViewing", "<div data-bind=\"foreach: currentViewers\" class=\"pull-left\"><a data-bind=\"attr: { title: Username, 'class': Colour }\" rel='tooltip'>&nbsp;</a></div>");

    ko.bindingHandlers.currentlyViewingComponent = {
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
            var currentlyViewingTemplateName = allBindings.currentlyViewingTemplate || "ko_currentlyViewing";

            // Render the main grid
            var currentlyViewingContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(currentlyViewingTemplateName, viewModel, { templateEngine: templateEngine }, currentlyViewingContainer, "replaceNode");
        }
    };
})();