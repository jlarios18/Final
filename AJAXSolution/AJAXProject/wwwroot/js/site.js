
$("#calculate").click(function () {
    let nr1 = $("#nr1").val();
    let nr2 = $("#nr2").val();
    $.ajax({
        //url: '@Url.Action("Math", "Home")?nr1=' + nr1 + '&nr2' + nr2,
        url: '@Url.Action("Math", "Home")?nr1=' + nr1 + '&nr2' + nr2,
        success: function (data) {
            if (data.status == "ok") {
                $("#results").html(data.result); //data.result a dynamic object too
            }
        }
    });
});