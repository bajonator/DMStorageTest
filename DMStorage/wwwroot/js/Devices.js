
function AddDevice() {
    var result = ValidateDevice();
    if (result == false) {
        return false;
    }
    var formData = $('#deviceForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/Device/Device',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == "") {
                console.log(response);
            }
            else {
                alert(response)
                ClearValueDevice();
                GetDevices();
                var deviceIdValue = Number($('#DeviceId').val());
                if (deviceIdValue > 0) {
                    $('#exampleModal').modal('hide');
                }
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function GetDevices() {
    $.ajax({
        url: '/device/GetDevices',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var object = '';
            if (response.length === 0) {
                object += '<tr>';
                object += '<td colspan="6" class="text-center">Brak dostępnych urządzeń</td>';
                object += '</tr>';
            } else {
                $.each(response, function (index, typeDevice) {
                    console.log(response, typeDevice);
                    $.each(typeDevice.devices, function (index, device) {
                        object += '<tr>';
                        object += '<td>' + device.departmentName + '</td>';
                        object += '<td>' + typeDevice.typeName + '</td>';
                        object += '<td>' + device.name + '</td>';
                        object += '<td>' + (device.machineName || '') + '</td>';
                        object += '<td>' + (device.ip || '') + '</td>';
                        object += '<td>' + (device.macAdress || '') + '</td>';
                        object += '<td>' + (device.inventoryNumber || '') + '</td>';
                        object += '<td>' + (device.serialNumber || '') + '</td>';
                        object += '<td>' + (device.wpaUserName || '') + '</td>';
                        object += '<td>' + (device.wpaPassword || '') + '</td>';
                        object += '<td>' + (device.state || '') + '</td>';
                        object += '<td>' + (device.description || '') + '</td>';
                        object += '<td style="width:100px">';
                        object += '<button class="btn bg-transparent btn-sm btn-outline-primary text-warning border-0 btn-delete mr-3" style="font-size:14px; padding:0;" data-toggle="modal" data-target="#exampleModal" title="Edituj" data-url="/Device/AddDevice?id=' + device.id + '" onclick="loadDevicePartialView(this)" style="cursor: pointer;">';
                        object += '<i class="fas fa-pencil-alt"></i>';
                        object += '</button>';
                        object += '<button class="btn bg-transparent btn-sm btn-outline-primary text-danger border-0 btn-delete" style="font-size:14px; padding:0;" title="Odstranit" onclick="deleteDevice(' + device.id + ', this)">';
                        object += '<i class="fas fa-trash-alt"></i>';
                        object += '</button>';
                        object += '</td>';
                        object += '</tr>';
                    });
                });
            }
            $('#tDeviceBody').html(object);
        },
        error: function () {
            alert('Coś poszło nie tak');
        }
    });
}
function AddTypeDevice() {
    var result = ValidateTypeDevice();
    if (result == false) {
        return false;
    }
    var formData = $('#deviceTypeForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/Device/TypeDevice',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == "") {
                console.log(response);
            }
            else {
                alert(response)
                ClearValueTypeDevice();
                console.log(response);
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function ClearValueDevice() {
    $('#deviceForm input').each(function () {
        $(this).val('');
    });
    $('#deviceForm textarea').each(function () {
        $(this).val('');
    });
    $('#deviceForm select').each(function () {
        $(this).val('');
    });
    //$('#deviceName').val('');
    //$('#typeDeviceId').val('');
    //$('#deviceIp').val('');
    //$('#deviceMacAdress').val('');
    //$('#deviceDesc').val('');    
}
function ClearValueTypeDevice() {
    $('#deviceTypeName').val('');
}

function ValidateDevice() {
    var isValid = true;
    if ($('#deviceName').val().trim() == "") {
        $('#deviceName').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#deviceName').css('border', '1px solid lightgrey');
    }

    if ($('#typeDeviceId').val().trim() == "") {
        $('#typeDeviceId').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#typeDeviceId').css('border', '1px solid lightgrey');
    }
}
function ValidateTypeDevice() {
    var isValid = true;
    if ($('#deviceTypeName').val().trim() == "") {
        $('#deviceTypeName').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#deviceTypeName').css('border', '1px solid lightgrey');
    }
}

$('#deviceTypeName').change(function () {
    ValidateTypeDevice();
});
$('#deviceName').change(function () {
    ValidateDevice();
});
$('#typeDeviceId').change(function () {
    ValidateDevice();
});