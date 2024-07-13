
///////////////// Account Transfer
$(document).ready(function () {
    $('#fromAccount_Id').change(function () {
        var accountId = $(this).val();
        if (accountId) {
            $.ajax({
                /*  url: '@Url.Action("GetAccountNumber")', */
                url: "?handler=AccountNumber", // Update with your controller name
                type: 'GET',
                data: { id: accountId },
                success: function (data) {
                   
                    $('#fromAccount_Number').val(data.account_no);
                    $('#toAccount_Id option').each(function () {
                        if ($(this).val() == accountId) {
                            $(this).remove();
                        }
                    });

                },
                error: function () {
                    alert('Failed to retrieve account number.');
                }
            });
        }
    });
});
$(document).ready(function () {
    $('#toAccount_Id').change(function () {
        var accountId = $(this).val();
        if (accountId) {
            $.ajax({
                /*  url: '@Url.Action("GetAccountNumber")', */
                url: "?handler=ToAccountNumber", // Update with your controller name
                type: 'GET',
                data: { id: accountId },
                success: function (data) {
                    console.log(data);
                    $('#toAccount_Number').val(data.account_no);
                },
                error: function () {
                    alert('Failed to retrieve account number.');
                }
            });
        }
    });
});

/// Select Pay To

$(document).ready(function () {
    // Ensure payTo_Id is hidden on page load
    $('#payTo_Id').hide();

    $('#payment_PurposeId').change(function () {
        if ($(this).val() === 'Salary') {
            $('#payTo_Id').show();
        } else {
            $('#payTo_Id').hide();
        }
    });
});