function VerMensagens() {
    $('#modalMessages').modal('show');
}

$('[data-toggle="popover"]').popover(
    {
        html: true,
        content: function () {
            var objContent = $(this).attr("data-object-content");
            return $(objContent).html();
        }
    }
);

$('#Filter_DataHoraInicio').click(function () { $(this).val(""); });
$('#Filter_DataHoraInicioAte').click(function () { $(this).val(""); });
$('#Filter_DataHoraFim').click(function () { $(this).val(""); });
$('#Filter_DataHoraFimAte').click(function () { $(this).val(""); });

var cfgDateTime = {
    format: "d/m/Y H:i",
    step: 15,
    datepicker: true,
    timepicker: true,
    inline: false
};

$('#Filter_DataHoraInicio').datetimepicker(cfgDateTime);
$('#Filter_DataHoraInicioAte').datetimepicker(cfgDateTime);
$('#Filter_DataHoraFim').datetimepicker(cfgDateTime);
$('#Filter_DataHoraFimAte').datetimepicker(cfgDateTime);

function toSort(key, elementId) {
    var form = document.getElementById("form");
    var sortkey = document.getElementById(elementId);

    sortkey.value = key;

    form.submit();
    return false;
}

function toRedirect(controller, action) {
    var form = document.getElementById("form");

    form.action = ("/" + controller + "/" + action);

    form.submit();
    return false;
}