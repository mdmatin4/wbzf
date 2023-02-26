$("body").on("click", "#btnAdd", function () {
    //Reference the Name and Country TextBoxes.
    var txtPassed = $("#txtPassed");
    var txtboardName = $("#txtboardName");
    var txtYrofPassing = $("#txtYrofPassing");
    var txtmarks = $("#txtmarks");
    var txtsubject = $("#txtsubject");
    var txtdiv = $("#txtdiv");
    var txtremarks = $("#txtremarks");

    //Get the reference of the Table's TBODY element.
    var tBody = $("#tblCustomers > TBODY")[0];

    //Add Row.
    var row = tBody.insertRow(-1);

    //Add cell.
    var cell = $(row.insertCell(-1));
    cell.html(txtPassed.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtboardName.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtYrofPassing.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtmarks.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtsubject.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtdiv.val());

    //Add  cell.
    cell = $(row.insertCell(-1));
    cell.html(txtremarks.val());

    //Add Button cell.
    cell = $(row.insertCell(-1));
    var btnRemove = $("<input />");


    btnRemove.attr("type", "button");
    btnRemove.attr("onclick", "Remove(this);");
    btnRemove.val("Remove");
    cell.append(btnRemove);

    //Clear the TextBoxes.
    txtPassed.val("");
    txtboardName.val("");
    txtYrofPassing.val("");
    txtmarks.val("");
    txtsubject.val("");
    txtdiv.val("");
    txtremarks.val("");
});

function Remove(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblCustomers")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

$("body").on("click", "#btnSave", function () {
    //Loop through the Table rows and build a JSON array.
    var customers = new Array();
    $("#tblCustomers TBODY TR").each(function () {
        var row = $(this);
        var customer = {};
        customer.Name = row.find("TD").eq(0).html();
        customer.Country = row.find("TD").eq(1).html();
        customers.push(customer);
    });
    //Send the JSON array to Controller using AJAX.
    $.ajax({
        type: "POST",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        url: "?handler=InsertCustomers",
        data: JSON.stringify(customers),
        contentType: "application/json; charset=utf-8",

        success: function (r) {
            alert(r + " record(s) inserted.");
        }
    });
});
$(document).ready(function () {
    var checkid = $('#popup_stat').val();
    viewElement(checkid);


    $('#popup_stat').change(function () {
        viewElement($(this).val());
    });

});

function viewElement(f) {
    if (f == 'false') {
        $('#image_area').hide();
        return true;
    }
    else if (f === 'true') {
        $('#image_area').show();
        return true;
    }
}