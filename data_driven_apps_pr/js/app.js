$(document).ready(function() {
    $('.form-select').select2();
});



function PopulateControl(list, control) {
    if (list.length > 0) {
        control.removeAttr("disabled");
        control.empty().append('<option selected="selected" value="">Please select</option>');
        $.each(list, function () {
            control.append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }
    else {
        control.empty().append('<option selected="selected" value="0">Not available<option>');
    }
}
