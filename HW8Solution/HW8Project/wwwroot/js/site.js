console.log("hello");

function assignRequest() {
    let source = "dbv3/assign/show"

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: showAssign,
        error: errorOnAjax
    });
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}

function showAssign(data) {
    console.log(data);
    console.log(data[0].priority);
    for (var i = 0; i < data.length; i++)
    {
        console.log("looping");
        $("#ajaxtable").append($("<tr><td>" + data[i].priority + "</td><td>" + data[i].due + "</td><td>" + data[i].course.name + "</td><td>" + data[i].name
            + "</td><td>" + data[i].completion + "</td><td>" + data[i].notes + "</td></tr>"));
    }
}

$(document).ready(assignRequest());