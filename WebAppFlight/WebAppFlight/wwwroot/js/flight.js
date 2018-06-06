
$(document).ready(function ()
{
    $("#LoadingStatus").html("Loading....");
    $.get("/Flight/GetFlightList", null, DataBind);
    function DataBind(FlightList) {

        var SetData = $("#SetFlightList");
        for (var i = 0; i < FlightList.length; i++) {
            var Data = "<tr class='row_" + FlightList[i].flightId + "'>" +
                //"<td>" + FlightList[i].flightId + "</td>" +
                "<td>" + FlightList[i].flightDeparture + "</td>" +
                "<td>" + FlightList[i].flightArrival + "</td>" +
                "<td>" + FlightList[i].departureAirportName + "</td>" +
                "<td>" + FlightList[i].arrivalAirportName + "</td>" +
                "<td>" + FlightList[i].airlineName + "</td>" +
                "<td>" + FlightList[i].aircraftName + "</td>" +
                "<td>" + "<a href='#' class='btn btn-warning' onclick='EditFlightRecord(" + FlightList[i].flightId + ")' ><span class='glyphicon glyphicon-edit'></span></a>" + "</td>" +
                "<td>" + "<a href='#' class='btn btn-danger' onclick='DeleteFlightRecord(" + FlightList[i].flightId + ")'><span class='glyphicon glyphicon-trash'></span></a>" + "</td>" +
                "</tr>";

            SetData.append(Data);
            $("#LoadingStatus").html(" ");

        }
    }   
    $("#AddFlightRecord").click(function () {
            AddNewFlight(0);
        });
    $("#SaveFlightRecord").click(function () {
            saveFlight();
        });
});

//Show The Popup Modal For Add New Flight
function AddNewFlight(FlightId) {
    $("#form")[0].reset();
    $("#FlyId").val(0);
    $("#DropDwnDep option:selected").text("--Select DepAirport--");
    $("#DropDwnArr option:selected").text("--Select ArrAirport--");
    $("#DropDwnLst option:selected").text("--Select Company--")
    $("#DropDwnCraft option:selected").text("--Select Aircraft--")
    
    $("#ModalTitle").html("Add New Flight");
    $("#MyModal").modal();

}
function saveFlight() {
    var data = $("#SubmitForm").serialize();
    $.ajax({
        type: "Post",
        url: "/Flight/SaveFlight",
        data: data,
        success: function (result) {
           alert("Success!.."); 
            window.location.href = "/Flight/index";
            $("#MyModal").modal("hide");

        }
    })
}
//Show The Popup Modal For Edit Flight Record
function EditFlightRecord(flightId) {
    var url = "/Flight/GetFlightById?FlightId=" + flightId;
    $("#ModalTitle").html("Update Flight Record");
    $("#MyModal").modal();
    $.ajax({
        type: "GET",
        url: url,
        success: function (data)
        {
            var obj = JSON.parse(data);
            $("#FlyId").val(obj.FlightId);
            $("#FlyDep").val(obj.FlightDeparture);
            $("#FlyArri").val(obj.FlightArrival);
            $("#DropDwnDep option:selected").text(obj.DepartureAirportName);
            $("#DropDwnDep option:selected").val(obj.DepartureId);

            $("#DropDwnArr option:selected").text(obj.ArrivalAirportName);
            $("#DropDwnArr option:selected").val(obj.ArrivalId);

            
            $("#Flytime").val(obj.FlightTime);

            $("#DropDwnLst option:selected").text(obj.AirlineName);
            $("#DropDwnLst option:selected").val(obj.AirlineId);

            $("#DropDwnCraft option:selected").text(obj.AircraftName);
            $("#DropDwnCraft option:selected").val(obj.AircraftId);

        }
    })
}
//Show The Popup Modal For DeleteComfirmation
var DeleteFlightRecord = function DeleteFlightRecord (flightId) {
        $("#FlyId").val(flightId);
        $("#DeleteConfirmation").modal("show");
    }
var ConfirmDelete = function  () {
        var FlyId = $("#FlyId").val();
        $.ajax({
            type: "POST",
            url: "/Flight/DeleteFlightRecord?FlightId=" + FlyId,
            success: function (result) {
                $("#DeleteConfirmation").modal("hide");
                $(".row_" + FlyId).remove();
            }
        })
    
}
    
