//Jquery Server Module
var Server = (function () {

    //Handling HTTP Errors.
    $(document).ajaxError(function (event, xhr) {
        alert(xhr.status + ":" + xhr.statusText);
    });

    //Get Matrix in json format. 
    var getMatrix = function (size, base) {
        var matrixUrl = ServerURL.getURL();
        return $.ajax(matrixUrl + "?matrixSize=" + size + "&matrixBase=" + base);
    };

    return {
        //register function in module.
        getMatrix: getMatrix
    };

}());


(function () {

    //Register DOM events.
    var wireEvents = function () {
        $(document).on("click", "#getMatrix", getMatrix);
        $(document).on("mouseover", "#showTooltip", getMatrix);

    };

    //Call Server usign parameters in Form.
    var getMatrix = function () {
        var matrix_size = $("#matrix_size").val();
        var matrix_base = $("#matrix_base").val();

        //validations.
        if (matrix_size >= 3 && matrix_size <= 15)
            //Invoke Server function.
            Server.getMatrix(matrix_size, matrix_base).done(drawTable);
        else {
            alert("Oops!! Select a Matrix Size between 3 and 15.");
            $("#matrix").empty();
        }
        return false;
    };

    //Function to draw the table using Jquery
    var drawTable = function (data) {

        var $matrix = $("<table class='table table - bordered'></table>");
        var $row;

        for (var i = 0; i < data.Rows.length; i++) {
            $row = $("<tr></tr>");
            for (var j = 0; j < data.Rows.length; j++) {

                var $cell;
                //html attribute to include tooltip in Cells.
                var $tooltip = "title='" + data.Rows[i].Columns[0].Value + " X " + data.Rows[0].Columns[j].Value + " = " + data.Rows[i].Columns[j].Value + "'";
                //Marking a header
                if (data.Rows[i].Columns[j].TypeOfCell == 1)
                    $cell = $("<th scope='col' class='table-primary'>" + data.Rows[i].Columns[j].Value + "</th>");
                //Marking a Corner.
                else if (data.Rows[i].Columns[j].TypeOfCell == 2)
                    $cell = $("<th scope='col'>X</th>");
                //Marking a Prime.
                else if (data.Rows[i].Columns[j].TypeOfCell == 3)
                    $cell = $("<td class='table-info'" + $tooltip + ">" + data.Rows[i].Columns[j].Value + "</tr>");
                //Marking a normal number
                else if (data.Rows[i].Columns[j].TypeOfCell == 4)
                    $cell = $("<td " + $tooltip + ">" + data.Rows[i].Columns[j].Value + "</tr>");
                //Marking the diagonal
                else if (data.Rows[i].Columns[j].TypeOfCell == 5)
                    $cell = $("<td class='table-primary'" + $tooltip + "><strong>" + data.Rows[i].Columns[j].Value + "</strong></tr>");

                $row.append($cell);
            }
            $matrix.append($row);
        }
        $("#matrix").empty();
        $matrix.appendTo($("#matrix"));

    };

    $(function () {
        wireEvents();
    });

}());