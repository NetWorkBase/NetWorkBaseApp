/// <reference path="jquery-1.4.1-vsdoc.js" />
function onSilverlightError(sender, args) {
    var appSource = "";
    if (sender != null && sender != 0) {
        appSource = sender.getHost().Source;
    }

    var errorType = args.ErrorType;
    var iErrorCode = args.ErrorCode;

    if (errorType == "ImageError" || errorType == "MediaError") {
        return;
    }

    var errMsg = "Silverlight 应用程序中未处理的错误 " + appSource + "\n";

    errMsg += "代码: " + iErrorCode + "    \n";
    errMsg += "类别: " + errorType + "       \n";
    errMsg += "消息: " + args.ErrorMessage + "     \n";

    if (errorType == "ParserError") {
        errMsg += "文件: " + args.xamlFile + "     \n";
        errMsg += "行: " + args.lineNumber + "     \n";
        errMsg += "位置: " + args.charPosition + "     \n";
    }
    else if (errorType == "RuntimeError") {
        if (args.lineNumber != 0) {
            errMsg += "行: " + args.lineNumber + "     \n";
            errMsg += "位置: " + args.charPosition + "     \n";
        }
        errMsg += "方法名称: " + args.methodName + "     \n";
    }
}
function pluginLoaded(sender) {
    slCtl = document.getElementById("MultiFileUploader");
    slCtl.Content.Files.SingleFileUploadFinished = SingleFileFinished;
    //alert("plugin Loaded")
}
