ko.bindingHandlers.fadeInText = {
    highlight: false,
    update: function (element, valueAccessor) {
        jQuery(element).hide();
        ko.bindingHandlers.text.update(element, valueAccessor);

        if (ko.bindingHandlers.fadeInText.highlight)
            jQuery(element).effect("highlight", { mode: "show" }, 5000);
        else
            jQuery(element).show();
    }
};