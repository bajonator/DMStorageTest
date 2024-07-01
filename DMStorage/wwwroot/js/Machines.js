//AddMachineScript

function AddMachine() {
    var result = ValidateMachine();
    if (result == false) {
        return false;
    }
    var formData = $('#machineForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/machine/Machine',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == "") {
                console.log(response);
            }
            else {
                alert(response)
                ClearValueMachine();
                GetMachines();
                var machineIdValue = Number($('#MachineId').val());
                if (machineIdValue > 0) {
                    $('#exampleModal').modal('hide');
                }
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function GetMachines() {
    $.ajax({
        url: '/machine/GetMachines',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var object = '';
            if (response.length === 0) {
                object += '<tr>';
                object += '<td colspan="6" class="text-center">Brak dostępnych produktów</td>';
                object += '</tr>';
            } else {
                $.each(response, function (index, department) {
                    console.log(response, department);
                    $.each(department.machines, function (index, machine) {
                        object += '<tr>';
                        object += '<td>' + department.number + '</td>';
                        object += '<td>' + department.departmentName + '</td>';
                        object += '<td>' + machine.name + '</td>';
                        object += '<td>' + (machine.ip || '') + '</td>';
                        object += '<td>' + (machine.vLan || '') + '</td>';
                        object += '<td>' + (machine.macAdress || '') + '</td>';
                        object += '<td>' + (machine.original_PLC || '') + '</td>';
                        object += '<td>' + (machine.opC_Driver || '') + '</td>';
                        object += '<td>' + (machine.opC_PLC || '') + '</td>';
                        object += '<td>' + (machine.dmcZ_Connection || '') + '</td>';
                        object += '<td>' + (machine.port || '') + '</td>';
                        object += '<td style="width:100px">';
                        object += '<button class="btn bg-transparent btn-sm btn-outline-primary text-warning border-0 btn-delete mr-3" style="font-size:14px; padding:0;" data-toggle="modal" data-target="#exampleModal" title="Edituj" data-url="/Machine/AddMachine?id=' + machine.id + '" onclick="loadMachinePartialView(this)" style="cursor: pointer;">';
                        object += '<i class="fas fa-pencil-alt"></i>';
                        object += '</button>';
                        object += '<button class="btn bg-transparent btn-sm btn-outline-primary text-danger border-0 btn-delete" style="font-size:14px; padding:0;" title="Odstranit" onclick="deleteMachine(' + machine.id + ', this)">';
                        object += '<i class="fas fa-trash-alt"></i>';
                        object += '</button>';
                        object += '</td>';
                        object += '</tr>';
                    });
                });
            }
            $('#tMachineBody').html(object);
        },
        error: function () {
            alert('Coś poszło nie tak');
        }
    });
}

function ClearValueMachine() {
    $('#machineForm input').each(function () {
        $(this).val('');
    });
    $('#machineForm textarea').each(function () {
        $(this).val('');
    });
    $('#machineForm select').each(function () {
        $(this).val('');
    });
    //$('#machineName').val('');
    //$('#departmentId').val('');
    //$('#machineIp').val('');
    //$('#machineVlan').val('');
    //$('#machineMacAdress').val('');
    //$('#machinePlcName').val('');    
}

function ValidateMachine() {
    var isValid = true;
    if ($('#machineName').val().trim() == "") {
        $('#machineName').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#machineName').css('border', '1px solid lightgrey');
    }

    if ($('#departmentId').val().trim() == "") {
        $('#departmentId').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#departmentId').css('border', '1px solid lightgrey');
    }
}
$('#machineName').change(function () {
    ValidateMachine();
});
$('#departmentId').change(function () {
    ValidateMachine();
});

//AddDepartmentScript

function AddDepartment() {
    var result = ValidateDepartment();
    if (result == false) {
        return false;
    }
    var formData = $('#departmentForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/Machine/Department',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == "") {
                console.log(response);
            }
            else {
                alert(response)
                ClearValueDepartment();
                console.log(response);
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function ValidateDepartment() {
    var isValid = true;
    if ($('#departmentName').val().trim() == "") {
        $('#departmentName').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#departmentName').css('border', '1px solid lightgrey');
    }
}
function ClearValueDepartment() {
    $('#departmentName').val(''); 
    $('#departmentNumber').val('');
}

$('#departmentName').change(function () {
    ValidateDepartment();
});


//AddVariableScript
function AddVariable() {
    var result = ValidateVariable();
    if (result == false) {
        return false;
    }
    var formData = $('#variableForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/Machine/Variable',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == "") {
                console.log(response);
            }
            else {
                alert(response)
                ClearValueVariable();
                console.log(response);
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function ValidateVariable() {
    var isValid = true;
    if ($('#variableName').val().trim() == "") {
        $('#variableName').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#variableName').css('border', '1px solid lightgrey');
    }
    var isValid = true;
    if ($('#machineId').val().trim() == "") {
        $('#machineId').css('border', '3px solid Red');
        isValid = false;
    }
    else {
        $('#machineId').css('border', '1px solid lightgrey');
    }
}
function ClearValueVariable() {
    $('#variableName').val('');
    $('#machineId').val('');
    $('#variableDataType').val('');
    $('#variableDescription').val('');
}
$('#variableName').change(function () {
    ValidateVariable();
});
$('#machineId').change(function () {
    ValidateVariable();
});