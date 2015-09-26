<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consume WCF Rest Service with jQuery</title>
    <link rel="stylesheet"
        href="<%= Url.Content("~/Content/Styles/Site.css") %>"
        type="text/css" />
</head>
<body>
    <div id="divContainer">
    <div id="divDepartmentHeader"></div>
    <div id="divStudentList"></div>
    <div id="divNewStudent">
        <span>Pending new student: - Click "Add student to department" button</span>
        <br />
        <span id="spanStudentList"></span>
    </div>

    <div id="divButtonContainer" style="float: right; margin: 2px">
        <button id="btnAquireNewStudent">Aquire a new student</button>
        <button id="btnAddStudentToDepartment">
            Add student to department</button>
    </div>
    </div>
</body>
</html>

<script src='<%= Url.Content("~/Content/Scripts/jquery-1.4.4.min.js") %>'
        type="text/javascript">
</script>

<script type="text/javascript">
    // Urls to access the WCF Rest service methods
    var GetDepartmentURl = "http://localhost:4305/Service/GetDepartment";
    var GetAStudent = "http://localhost:4305/Service/GetAStudent";
    var AddStudentToDepartment = "http://localhost:4305/Service/AddStudentToDepartment";

    var nextStudentID = 1;
    var jDepartment = null;
    var jPendingStudent = null;

    // Utility function - Create HTML table on Json data
    function makeTable(jObject) {
        var jArrayObject = jObject
        if (jObject.constructor != Array) {
            jArrayObject = new Array();
            jArrayObject[0] = jObject;
        }

        var table = document.createElement("table");
        table.setAttribute('cellpadding', '4px');
        table.setAttribute('rules', 'all');
        var tboby = document.createElement("tbody");

        var trh = document.createElement('tr');
        for (var key in jArrayObject[0]) {
            var th = document.createElement('th');
            th.appendChild(document.createTextNode(key));
            trh.appendChild(th);
        }
        tboby.appendChild(trh);

        $.each(jArrayObject, function (i, v) {
            var tr = document.createElement('tr');
            for (var key in v) {
                var td = document.createElement('td');
                td.appendChild(document.createTextNode(v[key]));
                tr.appendChild(td);
            }
            tboby.appendChild(tr);
        });
        
        table.appendChild(tboby)

        return table;
    }

    $(document).ready(function () {
        $.ajax({
            cache: false,
            type: "GET",
            async: false,
            dataType: "json",
            url: GetDepartmentURl,
            success: function (department) {
                jDepartment = department;

                var div = document.createElement("div");
                var span = document.createElement("span");
                span.setAttribute('id', 'DepartmentHeader');
                span.appendChild(document.createTextNode(department.SchoolName));
                span.appendChild(document.createTextNode(" - "));
                span.appendChild(document.createTextNode(department.DepartmentName));
                div.appendChild(span);
                span = document.createElement("span");
                div.appendChild(document.createElement("br"));
                span.appendChild(document.createTextNode("List of students:"));
                div.appendChild(span);

                $("#divDepartmentHeader").html("").append(div);
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });

        $("#btnAquireNewStudent").click(function () {
            if (jPendingStudent != null) {
                alert("Please add the pending student to the department first");
                return;
            }

            $.ajax({
                cache: false,
                type: "GET",
                async: false,
                url: GetAStudent + "(" + nextStudentID + ")",
                dataType: "json",
                success: function (student) {
                    jPendingStudent = student;
                    nextStudentID++;

                    var table = makeTable(student);
                    $("#spanStudentList").html("").append(table);
                    $("#divNewStudent").css("visibility", "visible");
                    $("#divNewStudent").show();
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        });

        $("#btnAddStudentToDepartment").click(function () {
            if (jDepartment == null) {
                alert("Please wait until the department loads");
                return;
            }
            if (jPendingStudent == null) {
                alert("Please first get a new student to add to the department");
                return;
            }

            var jData = {};
            jData.department = jDepartment;
            jData.student = jPendingStudent;

            $.ajax({
                cache: false,
                type: "POST",
                async: false,
                url: AddStudentToDepartment,
                data: JSON.stringify(jData),
                contentType: "application/json",
                dataType: "json",
                success: function (department) {
                    jPendingStudent = null;
                    jDepartment = department;

                    var table = makeTable(department.Students);
                    $("#divStudentList").html("").append(table);
                    $("#divNewStudent").hide();
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
        });
    });
</script>