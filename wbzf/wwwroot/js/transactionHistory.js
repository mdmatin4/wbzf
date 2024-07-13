var currentPage = 1;
var currentSize = 10;
var searchTerm = '';
var currentSortColumn = '';
var currentSortDirection = '';
var searchTermChanged = false;
var currentFromDate = '';
var currentToDate = '';
var currentAcId = '';

$(document).ready(function () {
    const params = new Map(location.search.slice(1).split('&').map(kv => kv.split('=')))
    var isReturn = 0;
    if (params.has("is_return")) {
        isReturn = params.get("is_return");
    }
  
    if (isReturn === '1') {
        currentPage = parseInt(getCookie('currentPage')) || 1;
        currentSize = parseInt(getCookie('currentSize')) || 10;
        searchTerm = getCookie('searchTerm') || '';
        currentSortColumn = getCookie('currentSortColumn') || '';
        currentSortDirection = getCookie('currentSortDirection') || '';
        currentFromDate = getCookie('fromDate') || '';
        currentToDate = getCookie('toDate') || '';
        currentAcId = getCookie("currentAcId");
        $('#selectitem').off('change');
        $('#selectitem').val(currentSize);
        $('#searchtxt').val(searchTerm);
    }
   // loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
});

// Initial sorting icon setup


$(document).on('change', '#selectitem', function () {
    currentSize = $(this).val();
    currentPage = 1; // reset page
    loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
});
//$(document).on('change', '#account_Id', function () {
//    currentSize = $(this).val();
//    currentPage = 1; // reset page
//    loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
//});
$(document).ready(function () {
   
    $(document).on('change', '#account_Id', function () {
        currentSize = $(this).val();
        currentPage = 1; // reset page
        
        currentAcId = $('#account_Id').val();
        
        loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);

    });
});

// Search with current values 
$(document).on('keyup', '#searchtxt', function () {
    searchTerm = $(this).val();
    currentPage = 1;
    searchTermChanged = true;
    loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
});
$(document).on('click', '#dateSearchButton', function () {


    var date1 = $("#fromDate").datepicker({ dateFormat: 'dd,MM,yyyy' }).val();

    currentFromDate = date1;
    // alert(currentFromDate);
    var date2 = $("#toDate").datepicker({ dateFormat: 'dd,MM,yyyy' }).val();

    currentToDate = date2;
    // alert(currentToDate);

    if (currentFromDate == null && currentToDate == null) {

        alert('Please select date!');
    }
    else if (currentFromDate > currentToDate) {

        alert('Fromdate can not be greater than Todate!')
    }

    else {

        loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
   
    }
});

// Add a click event handler for the "Next" button
$(document).on('click', '#nextPageLink', function () {
    currentPage++; // Increment the page number
    loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
});

// Optionally, you can also handle the "Previous" button similarly
// Add a click event handler for the "Previous" button
$(document).on('click', '#previousPageLink', function () {
    if (currentPage > 1) {
        currentPage--; // Decrement the page number (if not on the first page)
        loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
    }
});

$(document).on('click', 'th a', function (e) {
    e.preventDefault();
    currentSortColumn = $(this).data('column');
    var newSortDirection = currentSortDirection === 'asc' ? 'desc' : 'asc'; // Toggle sorting direction
    currentSortDirection = newSortDirection;
    // Remove sorting indicators from all other columns
    $('th a i').removeClass('fa-sort-asc fa-sort-desc').addClass('fa-sort');
    // Add sorting indicator to the clicked column
    $(this).find('i').removeClass('fa-sort').addClass(newSortDirection === 'asc' ? 'fa-sort-asc' : 'fa-sort-desc');

    loadComponent(currentPage, currentSize, searchTerm, currentSortColumn, currentSortDirection, currentFromDate, currentToDate, currentAcId);
});


function loadComponent(pageNumber, pageSize, SearchTerm, sortColumn, sortDirection, fromDate, toDate, accountId) {
    setCookie('currentPage', pageNumber, 365); // Store for 1 year
    setCookie('currentSize', pageSize, 365);
    setCookie('searchTerm', SearchTerm, 365);
    setCookie('currentSortColumn', sortColumn, 365);
    setCookie('currentSortDirection', sortDirection, 365);
    setCookie('fromDate', fromDate, 365);
    setCookie('tomDate', toDate, 365);
    setCookie('accountId', accountId, 365);



    /*showLoadingIcon();*/
    $.ajax({
        url: '?handler=TablePopup',
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        type: "POST",
        data: {

            pageIndex: pageNumber,
            pageSize: pageSize,
            SearchTerm: SearchTerm,
            sortColumn: sortColumn,
            sortDirection: sortDirection,
            fromDate: fromDate,
            toDate: toDate,
            accountId: accountId
        }
    }).done(function (result) {
        $("#tableComponent").html(result);

        $('th a').each(function () {
            var column = $(this).data('column');
            if (currentSortColumn === column) {
                if (currentSortDirection === 'asc') {
                    $(this).find('i').removeClass('fa-sort').addClass('fa-sort-asc');
                } else {
                    $(this).find('i').removeClass('fa-sort').addClass('fa-sort-desc');
                }
            }

        });

    }).fail(function (xhdr, statusText, errorText) {
        $("#tableComponent").text(JSON.stringify(xhdr));
    });;
}


function setCookie(name, value, days) {
    const expires = new Date(Date.now() + days * 24 * 60 * 60 * 1000).toUTCString();
    document.cookie = name + "=" + encodeURIComponent(value) + "; expires=" + expires + "; path=/";
}

// Function to get the value of a cookie by name
function getCookie(name) {
    const cookies = document.cookie.split('; ');
    for (const cookie of cookies) {
        const [cookieName, cookieValue] = cookie.split('=');
        if (cookieName === name) {
            return decodeURIComponent(cookieValue);
        }
    }
    return null;
}

