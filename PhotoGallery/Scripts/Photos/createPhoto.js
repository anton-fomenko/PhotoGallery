// Validation for updatinb the photo

jQuery.validator.unobtrusive.adapters.add(
    'filesize', ['maxsize'], function (options) {
        options.rules['filesize'] = options.params;
        if (options.message) {
            options.messages['filesize'] = options.message;
        }
    }
);

jQuery.validator.addMethod('filesize', function (value, element, params) {
    if (element.files.length < 1) {
        // No files selected
        return true;
    }

    if (!element.files || !element.files[0].size) {
        // This browser doesn't support the HTML5 API
        return true;
    }

    return element.files[0].size <= params.maxsize && element.files[0].type === 'image/jpeg';
}, '');