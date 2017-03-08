$(document).ready(function () {

    // Hide the "busy" Gif at load:
    $("#divProcessing").hide();

    $("#Phone").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and -
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 189]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true) ||
            // Allow: home, end, left, right, down, up
            e.keyCode >= 35 && e.keyCode <= 40) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
});

function requiredFields() {

    // Handle the form submit event, and make the Ajax request:
    $("#createOrUpdateHotelForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("createHotel").disabled = true;
    });

    $("#createOrUpdateRoomForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("createRoom").disabled = true;
    });

    $("#createOrUpdateRoomTypeForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("createRoomType").disabled = true;
    });

    $("#createOrUpdateCustomerForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("createCustomer").disabled = true;
    });

    $("#deleteRoomForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("deleteRoom").disabled = true;
    });

    $("#deleteHotelForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("deleteHotel").disabled = true;
    });

    $("#deleteRoomTypeForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("deleteRoomType").disabled = true;
    });

    $("#deleteCustomerForm").on("submit", function () {

        // Show the "busy" Gif:
        $("#divProcessing").show();
        document.getElementById("deleteCustomer").disabled = true;
    });
}

