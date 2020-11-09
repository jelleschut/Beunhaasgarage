function initForm(name) {
    formAutoComplete(name);
    formNewBtnControl(name);
    formSaveBtnControl(name);
    formEditBtnControl(name);
    formUpdateBtnControl(name);
    formCancelBtnControl(name);
}

function formNewBtnControl(name) {
    $('#' + name + '-new-btn').click(function (e) {
        e.preventDefault();
        $('#' + name + '-form').trigger('reset');
        $('#' + name + '-form :input').prop('disabled', false);
        $('#' + name + '-edit-btn').addClass('d-none');
        $('#' + name + '-save-btn').removeClass('d-none');
        $('#' + name + '-cancel-btn').addClass('d-none');
        $('#' + name + '-update-btn').addClass('d-none');
    });
}

function formSaveBtnControl(name) {
    $('#' + name + '-save-btn').click((e) => {
        e.preventDefault();
        saveModel(name, $(this).parents('form').serialize());
    });
}

function formEditBtnControl(name) {
    $('#' + name + '-edit-btn').click(function (e) {
        e.preventDefault();
        $('#' + name + '-form :input').prop('disabled', false);
        $('#' + name + '-edit-btn').addClass('d-none');
        $('#' + name + '-save-btn').addClass('d-none');
        $('#' + name + '-cancel-btn').removeClass('d-none');
        $('#' + name + '-update-btn').removeClass('d-none');
        $('#' + name + '-btn-group').removeClass('offset-md-1');
        populateDropdown(car, brand);
        populateDropdown(car, owner, $("input[name='radio-owner-group']:checked").val());
        populateDropdown(car, carCustomer);
    });
}

function formCancelBtnControl(name) {
    $('#' + name + '-cancel-btn').click(function (e) {
        e.preventDefault();
        $('#' + name + '-edit-btn').addClass('d-none');
        $('#' + name + '-save-btn').removeClass('d-none');
        $('#' + name + '-cancel-btn').addClass('d-none');
        $('#' + name + '-update-btn').addClass('d-none');
        $('#' + name + '-btn-group').addClass('offset-md-1');
        fillForm(name, $('#' + name + '-id').val());
        $('#' + name + '-form :input').prop('disabled', true);
    });
}

function formUpdateBtnControl(name) {
    $('#' + name + '-update-btn').click(function (e) {
        e.preventDefault();
        $('#' + name + '-edit-btn').removeClass('d-none');
        $('#' + name + '-save-btn').addClass('d-none');
        $('#' + name + '-cancel-btn').addClass('d-none');
        $('#' + name + '-update-btn').addClass('d-none');
        $('#' + name + '-btn-group').addClass('offset-md-1');
        updateModel(name, parseInt($('#' + name + '-id').val()), $(this).parents('form').serialize());
        $('#' + name + '-form :input').prop('disabled', true);
    });
}

function updateModel(name, id, data) {
    $.ajax({
        url: 'Api/' + name + 'sApiEndpoint/' + id,
        method: 'PUT',
        data: data,
        success: (data) => {
            console.log('succes');
            console.log(data);
        },
        error: (data) => {
            console.log('failed');
            console.log(data);
        },
    });
}

function saveModel(name) {
    $.post({
        url: 'Api/' + name + 'sApiEndpoint/',
        data: $(this).parents('form').serialize(),
        success: (data) => {
            console.log('succes');
            console.log(data);
        },
        error: (data) => {
            console.log('failed');
            console.log(data);
        },
    });
}

function newPropertyBtnControl(model, name) {
    $('#new-' + model + '-' + name + '-btn').click(function () {
        $('#' + model + '-group-' + name + '-select').addClass('d-none');
        $('#' + model + '-group-' + name + '-text').removeClass('d-none');
        $('#' + model + '-' + name + '-text').attr('name', $('#' + name + '-select').attr('name'));
        $('#' + model + '-' + name + '-select').removeAttr('name');
    });
}

function getSuggestions(name) {
    let arr = [];
    $.get('/Api/' + name + 'sApiEndpoint',
        (data, status) => {
            for (let i = 0; i < data.length; i++) {
                var keys = Object.keys(data[i]);
                arr[i] = {
                    value: data[i][keys[1]],
                    data: data[i][keys[0]]
                }
            }
        });
    return arr;
}

function formAutoComplete(name) {
    $('#' + name + '-select').devbridgeAutocomplete({
        lookup: getSuggestions(name),
        onSelect: (suggestion) => {
            $('#' + name + '-form :input').prop('disabled', true);
            $('#' + name + '-save-btn').addClass('d-none');
            $('#' + name + '-edit-btn').removeClass('d-none').prop('disabled', false);
            fillForm(name, suggestion.data);
        }
    });
}

function fillForm(name, id) {
    $.get('/Api/' + name + 'sApiEndpoint/' + id, (data) => {
        Object.keys(data).forEach((key) => {
            if ($.isPlainObject(data[key])) {
                $('[id^="' + name + '-' + key.toLowerCase() + '"]').val(data[key].name);
                if ($('[id^="' + name + '-' + key.toLowerCase() + '"]').prop('tagName') === 'SELECT') {
                    $('[id^="' + name + '-' + key.toLowerCase() + '"]').empty();
                    $('[id^="' + name + '-' + key.toLowerCase() + '"]').append(
                        "<option value=" + data[key].id + ">" + data[key].name + "</option>"
                    )
                }
            } else {
                $('[id^="' + name + '-' + key.toLowerCase() + '"]').val(data[key]);
            }
        });
    });
}

function populateDropdown(model, name, api = name) {
    $.get('Api/' + api + 'sApiEndpoint/', (data) => {
        $('#' + model + '-' + name + '-select').empty();
        $.each(data, (index, value) => {
            $('#' + model + '-' + name + '-select').append("<option value=" + value.id + ">" + value.name + "</option>");
        });
    });
}

function populateDependentDropdown(model, name, dependency, extension) {
    $('#' + model + '-' + dependency + '-select').change(() => {
        $('#' + model + '-' + name + '-select').empty();
        $.get('Api/' + name + 'sApiEndpoint/' + extension + $('#' + model + '-' + dependency + '-select').val(), (data) => {
            $.each(data, (index, value) => {
                $('#' + model + '-' + name + '-select').append("<option value=" + value.id + ">" + value.name + "</option>");
            });
        });
    });
}