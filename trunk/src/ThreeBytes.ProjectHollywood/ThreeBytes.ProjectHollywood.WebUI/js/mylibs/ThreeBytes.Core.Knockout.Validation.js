(function () {

    ko.setupValidation = function (errors) {
        ko.bindingHandlers.error = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                ko.bindingHandlers.error.internalUpdate(element, valueAccessor, allBindingsAccessor, viewModel);
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                ko.bindingHandlers.error.internalUpdate(element, valueAccessor, allBindingsAccessor, viewModel);
            },
            internalUpdate: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var ele = jQuery(element), allErrors = valueAccessor()();
                ele.empty();
                if (allErrors != null && allErrors.length > 0) {
                    var container = jQuery('<div class="alert alert-error"></div>');
                    container.append(jQuery('<a class="close" data-dismiss="alert">').text('×'));
                    for (var i in allErrors)
                        container.append(jQuery('<div>').text(allErrors[i]));
                    ele.append(container);
                }
            }
        };

        return {

            createErrorCollections: function (obj, model, formIdentifier) {
                for (var i in obj) {
                    model[i + 'Errors'] = new ko.observableArray(typeof (errors[i]) != 'undefined' ? errors[i] : []);
                }

                model.hasErrors = false;
                model.formIdentifier = formIdentifier;
            },
            clearValidations: function (obj, model) {
                for (var i in obj) {
                    model[i + 'Errors'].removeAll();
                }
            },
            rebindValidations: function (obj, model, errors) {
                for (var i in obj) {
                    model[i + 'Errors'].removeAll();
                    jQuery.each(errors, function (index, item) {
                        if (item.PropertyName == i) {
                            model[i + 'Errors'].push(item.ErrorMessage);
                            model.hasErrors = true;
                        }
                    });
                }
            }
        };
    };
})();