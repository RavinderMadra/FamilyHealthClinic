
function Add() {
    var isError = false;
    var ErrorMessage = "";
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var phno = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
    if ($('#txtAppointmentDate').val() == null || $('#txtAppointmentDate').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Appointment Date </br>';

    }
    if ($('#txtAppointTime').val() == null || $('#txtAppointTime').val() == ''
        || $('#txtAppointTime').val() == 0) {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Appointment Time </br>';
    }
    if ($('#txtProblem').val() == null || $('#txtProblem').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp problem column </br>'

    }
    if ($('#txtName').val() == null || $('#txtName').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Name </br>'
            ;
    }
    if ($('#txtDob').val() == null || $('#txtDob').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Data of Birth </br>'

    }
    if ($('#txtGender').val() == null || $('#txtGender').val() == '' || $('#txtGender').val() == 0) {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Select Gender </br>'

    }
    if ($('#txtAddress').val() == null || $('#txtAddress').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Your Address </br>'

    }
    if ($('#txtEmail').val() == null || $('#txtEmail').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp your Email </br>'
    }
    if ($('#txtEmail').val() != null && $('#txtEmail').val() != '' && !emailReg.test($('#txtEmail').val())) {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp  enter valid email </br>'
    } 
    if ($('#txtPhone').val() == null || $('#txtPhone').val() == '') {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp Phone </br>'

    }
    if ($('#txtPhone').val() != null && $('#txtPhone').val() != '' && !phno.test($('#txtPhone').val())) {
        isError = true; ErrorMessage = ErrorMessage + '&nbsp&nbsp  enter valid phone </br>'
    } 
    if (!isError) {
       
        var pdtObj = {
            Id: 0,
            AppointmentDate: $('#txtAppointmentDate').val(),
            AppointmentTime: $("#txtAppointTime option:selected").val(),
            Problem: $('#txtProblem').val(),
            DateOfBirth: $('#txtDob').val(),
            Gender: $("#txtGender option:selected").val(),
            Address: $('#txtAddress').val(),
            Email: $('#txtEmail').val(),
            Phone: $('#txtPhone').val(),
            Name: $('#txtName').val(),
            AppointmentTimeName: $("#txtAppointTime option:selected").text()
        };
       
        $.ajax({
            url: "../../Home/SaveAppointment",
            data: JSON.stringify(pdtObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#errspan').removeClass('display-hide');
                $('#errspan').addClass('display');
                $('#errspan').removeClass('alert-danger');
                $('#errspan').addClass('alert-success');
                $('#errspan').html(result)
                clear();
            },
            error: function (errormessage) {
                $('#errspan').html(errormessage.responseText)
                $('#errspan').removeClass('display-hide');
                $('#errspan').addClass('display');


            }
        });
    }
    else {
        $('#errspan').removeClass('display-hide');
        $('#errspan').addClass('display');
        ErrorMessage = "Please fill the following &nbsp</br>" + ErrorMessage
        $('#errspan').html(ErrorMessage)

    }
}

    function clear() {           
            $('#txtAppointmentDate').val(''),
            $("#txtAppointTime").html(""),
            $("#txtAppointTime").append($("<option/>").val(0).text("select time")),
            $('#txtProblem').val(''),
            $('#txtDob').val(''),
            $('#txtGender').val('0').prop('selected', true),
            $('#txtAddress').val(''),
            $('#txtEmail').val(''),
            $('#txtPhone').val(''),
            $('#txtName').val('')
    }

function GetAvailableAppointment() 
    {
    if ($('#txtAppointmentDate').val() != null && $('#txtAppointmentDate').val() != '') {
        
        var date = $('#txtAppointmentDate').val();
        $("#txtAppointTime").html("");
        $("#txtAppointTime").append($("<option/>").val(0).text("select time"));
        $.ajax({
            url: "../../Home/GetAppointmentTimes",
            data: { date: date },
            //data: JSON.stringify(date),
            type: "POST",
            //contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                {
                    $.each(result, function (i, obj) {
                        $("#txtAppointTime").append($("<option/>").val(obj.Id).text(obj.Times));
                    });
                }
                //$('#errspan').removeClass('display-hide');
                //$('#errspan').addClass('display');
                //$('#errspan').removeClass('alert-danger');
                //$('#errspan').addClass('alert-success');
                //$('#errspan').html(result)
                
            },
            error: function (errormessage) {
                //$('#errspan').html(errormessage.responseText)
                //$('#errspan').removeClass('display-hide');
                //$('#errspan').addClass('display');
            }
        });
    }
    }