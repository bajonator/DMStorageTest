$(document).ready(function () {
    function loadPartialView(partialViewUrl) {
        console.log("Loading partial view from URL: " + partialViewUrl);
        $.get(partialViewUrl, function (data) {
            $('#partialContent').html(data);
        });
    }

    $("#addDepartmentBtn").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });

    $("#addMachineBtn").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });

    $("#addVariableBtn").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });
    $("#addDepartmentBtn2").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });

    $("#addMachineBtn2").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });

    $("#addVariableBtn2").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Department URL: " + url);
        loadPartialView(url);
    });

    $("#addTypeDeviceBtn").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Device URL: " + url);
        loadPartialView(url);
    });
    $("#addDeviceBtn").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Device URL: " + url);
        loadPartialView(url);
    }); 
    $("#addTypeDeviceBtn2").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Device URL: " + url);
        loadPartialView(url);
    });
    $("#addDeviceBtn2").click(function (e) {
        var url = $(this).data('url');
        console.log("Add Device URL: " + url);
        loadPartialView(url);
    });
});
