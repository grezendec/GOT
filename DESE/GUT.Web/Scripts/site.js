// --------------------------------------- BLOCK-UI ---------------------------------------
var blockTimer;
function BloquearTela() {
    clearTimeout(blockTimer);
    $(document).css('cursor', 'auto');
    $.unblockUI();

    $(document).css('cursor', 'wait');
    $.blockUI({
        // fadeIn time in millis; set to 0 to disable fadeIn on block 
        fadeIn: 0,
        fadeOut: 0,
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        },
        message: '<img src="' + urlPrefix + 'Images/BlockUI/loading.gif" />'
    });
}

function DesbloquearTela() {
    setTimeout(function () {
        clearTimeout(blockTimer);
        $(document).css('cursor', 'auto');
        $.unblockUI();
    }, 500);
}

// --------------------------------------- GRITTER ---------------------------------------

var GritterType = {
    Success: 'Images/Gritter/gritter-success.png',
    Info: 'Images/Gritter/gritter-info.png',
    Alert: 'Images/Gritter/gritter-alert.png',
    Error: 'Images/Gritter/gritter-error.png'
};

function ShowGritter(title, message, gritterType, time, stick) {

    if (title == undefined || title == null) {
        switch (gritterType) {
            case GritterType.Success:
                title = "Sucesso";
                break;
            case GritterType.Alert:
                title = "Alerta";
                break;
            case GritterType.Error:
                title = "Erro";
                break;
            case GritterType.Info:
                title = "Informação";
                break;
            default:
                title = "Sucesso";
        }
    }

    $.gritter.add({
        title: title,
        text: message,
        image: urlPrefix + gritterType,
        sticky: stick,
        time: time * 1000

    });
}