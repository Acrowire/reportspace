

$(document).on("change", "#weekselector", function (ev) {
    var selected = $(this).find(":selected").text();
    var data = selected.split('-');
    ShowReport(data[0], data[1]);
});

function LoadWeekNames() {
    var url = 'Report_WeekNameData';
    
    $.get(url, function(data, ts, error) {
        var select = $('#weekselector');
        // Graph Data 
        for (var index in data) {
            var row = data[index];
            select.append('<option id="' + row.Week + '">' + row.Week_name + ' </option>');
        }
    });

}

$(document).on("click", ".group", function (ev) {
    
    var _class = $(this).attr('class');
    //collapsed-group
    if (_class.indexOf('collapsed-group') >= 0) {
        $('#analytics-area').empty();
        return;
    }
    $('#analytics-area').empty();

    var text = $(this).text();
    var selected = $('#weekselector').find(":selected").text();
    var data = selected.split('-');

    var url = 'Report_WeeklyClientHoursData?year=' + data[0] + '&week=' + data[1] + '&ClientName=' + text;
    $.get(url, function (data, ts, error) {

        var tr = [];
        // Graph Data 
        for (var index in data) {
            var row = data[index];
            tr.push({ 'user_name': row.user_name, "Measure": 'direct_labor', "value": row.direct_labor });
            tr.push({ 'user_name': row.user_name, "Measure": 'gross_revenue', "value": row.gross_revenue });
        }
        
        var svg = dimple.newSvg("#analytics-area", 590, 400);
        var myChart = new dimple.chart(svg, tr);
        myChart.setBounds(80, 30, 480, 330);
        var x = myChart.addMeasureAxis("x", ["value"]);
        myChart.addCategoryAxis("y", ["user_name", "Measure"]);
        myChart.addSeries("Measure", dimple.plot.bar);
        myChart.addLegend(60, 10, 510, 20, "right");
        myChart.draw();
        
    });
});

var table1;

function ShowReport(year, week) {
    var url = 'Report_WeeklyClientHoursData?week=' + week + '&year=' + year + '&ClientName=';
    
    $.get(url, function (data, ts, error) {
        
        $('#tbodytable').empty();
        var t = $('#report_table').dataTable();
        t.fnClearTable();
        t.fnDestroy();
        
        var $table = $('#report_table tbody');
        var $row = function (user_name, project, total_hours, billable_hours, gross_revenue, direct_labor) {
            var $r = $('<tr> ');
            $r.append("<td>" + project + "</td>");
            $r.append("<td>" + user_name + "</td>");
            $r.append("<td>" + total_hours + "</td>");
            $r.append("<td>" + billable_hours + "</td>");
            $r.append("<td>" + gross_revenue + "</td>");
            $r.append("<td>" + direct_labor + "</td>");
            $r.append("</tr>");
            return $r;
        };
        
        // Graph Data 
        for (var index in data) {
            var row = data[index];
            $table.append($row(row.user_name, row.project, row.total_hours, row.billable_hours, row.gross_revenue, row.direct_labor));
        }
        
        $('#report_table').dataTable({
            "bLengthChange": false,
            "bPaginate": false,
            "bJQueryUI": true,
            "bDestroy": true
            ,"bAutoWidth": false
        }).rowGrouping({
            bExpandableGrouping: true,
            bExpandSingleGroup: false,
            iExpandGroupOffset: -1,
            asExpandedGroups: [""]
        });

    });

}
$(document).ready(function () {
    LoadWeekNames();
    //ShowReport(2014,10);
    $('#report_table').dataTable().fnDestroy();
    
});

