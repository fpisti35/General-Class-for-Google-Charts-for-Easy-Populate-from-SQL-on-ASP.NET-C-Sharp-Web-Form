function displayDetails(row, col, value) {

    //console.log('selected: ' + JSON.stringify(selected));

    document.getElementById('lblMessage').innerHTML = "Row: " + (row + 1) + '<br />' +
        "Column: " + col + '<br />' +
        'Selected value: ' + value;
    $('#myModal').modal('toggle');
}