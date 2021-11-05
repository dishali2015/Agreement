
    var reporttype = '';
        var Salesyear;
        var region = '';
        var orglist = '';
        var segmentlist = '';
        var customercode = ''
        var recordtype = '';

    function AssignValues() {
        reporttype = $("Input[name='ReportType']:checked").val();
        Salesyear = $("#Salesyear").val();
        
    region = '';
            $("input.checkboxregion:checkbox:checked").each(function () {
        region = region + ($(this).val()) + ",";
    });
    orglist = '';
             $("input.checkboxorg:checkbox:checked").each(function () {
        orglist = orglist + ($(this).val()) + ",";
    });

   segmentlist = '';
            $("input.checkboxsegment:checkbox:checked").each(function () {
        segmentlist = segmentlist + ($(this).val()) + ",";
             });

customercode = $("#CustomerCode").val();

recordtype = $("Input[name='OptRecordType']:checked").val();

// alert(recordtype);

$("#ReportType").val(reporttype);

$("#RecordType").val(recordtype);  // OptRecordType

        $("#Year").val(Salesyear);
        $("#hdnSalesyear").val(Salesyear);
        
$("#RegionList").val(region.substring(0, region.length - 1));
$("#OrgList").val(orglist.substring(0, orglist.length - 1));
$("#SegmentList").val(segmentlist.substring(0, segmentlist.length - 1));
$("#CustomerCode").val(customercode.replace(/(\r\n|\n|\r)/gm, " "));
return true;
}


        $(document).ready(function () {
        //Select all check box check/uncheck event
        // Region control
        $(".checkboxregionAll").change(function () {  //"select all" change
            $(".checkboxregion").prop('checked', $(this).prop("checked")); //change all ".checkbox" checked status
        });
    //".checkbox" change
    $('.checkboxregion').change(function () {
            //uncheck "select all", if one of the listed checkbox item is unchecked
            if (false == $(this).prop("checked")) { //if this item is unchecked
        $(".checkboxregionAll").prop('checked', false); //change "select all" checked status to false
    }
    //check "select all" if all checkbox items are checked
            if ($('.checkboxregion:checked').length == $('.checkboxregion').length) {
        $(".checkboxregionAll").prop('checked', true);
    }
});

//Select all check box check/uncheck event
// Segment control
        $(".checkboxsegmentAll").change(function () {  //"select all" change
        $(".checkboxsegment").prop('checked', $(this).prop("checked")); //change all ".checkbox" checked status
    });
    //".checkbox" change
        $('.checkboxsegment').change(function () {
            //uncheck "select all", if one of the listed checkbox item is unchecked
            if (false == $(this).prop("checked")) { //if this item is unchecked
        $(".checkboxsegmentAll").prop('checked', false); //change "select all" checked status to false
    }
    //check "select all" if all checkbox items are checked
            if ($('.checkboxsegment:checked').length == $('.checkboxsegment').length) {
        $(".checkboxsegmentAll").prop('checked', true);
    }
});

//Select all check box check/uncheck event
// Segment control
        $(".checkboxorgAll").change(function () {  //"select all" change
        $(".checkboxorg").prop('checked', $(this).prop("checked")); //change all ".checkbox" checked status
    });
    //".checkbox" change
        $('.checkboxorg').change(function () {
            //uncheck "select all", if one of the listed checkbox item is unchecked
            if (false == $(this).prop("checked")) { //if this item is unchecked
        $(".checkboxorgAll").prop('checked', false); //change "select all" checked status to false
    }
    //check "select all" if all checkbox items are checked
            if ($('.checkboxorg:checked').length == $('.checkboxorg').length) {
        $(".checkboxorgAll").prop('checked', true);
            }
        });

            $(document).ajaxStart(function () {
                $('#wait').show();
            });
            $(document).ajaxStop(function () {
                $('#wait').hide();
            });
            $(document).ajaxError(function () {
                $('#wait').hide();
            });
            $(document).on('click', '.nav-item', function (e) {
                $(this).addClass('active').siblings().removeClass('active');
            });



})

function ExportToExcelDetailReport(tableId, reportname) {
    $('#wait').show();
    $(tableId).table2excel({
        name: "Worksheet Name",
        filename: reportname + '.xls',
        preserveColors: true // set to true if you want background colors and font colors preserved
    })
    $('#wait').hide();
}

