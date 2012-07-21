function BindValidationsToForm(validations, form) {

    jQuery.each(validations.Errors, function(i, item) {
        jQuery("input[name='" + item.PropertyName + "']", form).next("span").empty();
    });

    jQuery.each(validations.Errors, function (i, item) {
            jQuery("[name='" + item.PropertyName + "']", form).parent().parent().addClass("error");
            jQuery("[name='" + item.PropertyName + "']", form).parent().parent().addClass("error");
            jQuery("[name='" + item.PropertyName + "']", form).addClass("error");
            jQuery("[name='" + item.PropertyName + "']", form).next("span").removeClass("field-validation-valid").addClass("help-inline");
            jQuery("[name='" + item.PropertyName + "']", form).next("span").append('<span for="' + item.PropertyName + '" generated="true">' + item.ErrorMessage + '</span>');
    });

}