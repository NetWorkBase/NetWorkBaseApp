var NetWorGroupScript = function () {
    /// <summary>公共JavaScript功能类</summary>
    this.CountChecked = function () {
        /// <summary>检查选择的CheckBox的个数</summary>
        var inputs = $("input");
        var count = 0;
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].id.substring(0, 6) == "Check$") {
                if (inputs[i].checked) {
                    count++;
                }
            }
        }
        return count;
    };
    this.CheckAll = function () {
        /// <summary>
        /// 选择所有的CheckBox控件
        /// </summary>        
        var CheckAllBox = $("#CheckAll");
        var inputs = $("input");
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].id.substring(0, 6) == "Check$") {
                inputs[i].checked = CheckAllBox.is(":checked");
            }
        }
    };
    this.SelectSignle = function () {
        var Count = this.CountChecked();
        if (Count > 1) {
            alert("不能选择多行数据！");
        } else if (Count == 0) {
            alert("您没有选择任何数据！");
        } else {
            var inputs = $("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].id.substring(0, 6) == "Check$") {
                    if (inputs[i].checked) {
                        return inputs[i].value;
                    }
                }
            }
        }
    };
    this.LocationUrl = function (Url) {
        window.location.href = Url;
    };
    this.ShowDialog = function (Url, Width, Height, scro) {
        /// <summary>
        /// 打开一个窗口或者网页对话框
        /// </summary>
        /// <param name="Url" type="String">要打开的URL地址</param>
        /// <param name="Width" type="Int">打开的窗口宽度</param>
        /// <param name="Height" type="Int">打开的窗口高度</param>
        /// <param name="scro" type="Boolean">是否显示滚动条</param>
        var info = "";
        var result = "";
        var ie = document.all ? 1 : 0;
        if (scro == null) {
            info = "Status:YES;dialogWidth:" + Width + "px;dialogHeight:" + Height + "px;help:no;scroll:no";
        } else {
            info = "Status:YES;dialogWidth:" + Width + "px;dialogHeight:" + Height + "px;help:no;scroll:yes";
        }
        if (ie) {
            result = showModalDialog(Url, window, info);
        } else {
            window.open(Url, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=yes,width=" + Width + ",height=" + Height + ",left=100,top=100,screenX=0,screenY=0");
        }
        return result;
    };
    this.Update = function (Url, Width, Height, scro) {
        /// <summary>
        /// 修改信息数据URL可不填写
        /// </summary>
        /// <param name="Url" type="String">要打开的URL地址</param>
        /// <param name="Width" type="String">打开的窗口宽度</param>
        /// <param name="Height" type="String">打开的窗口高度</param>
        /// <param name="scro" type="String">是否显示滚动条</param>
        var result = "";
        var Count = this.CountChecked();
        if (Count > 1) {
            alert("不能选择多行数据！");
        } else if (Count == 0) {
            alert("您没有选择任何数据，请选择好后进行修改！");
        } else {
            var inputs = $("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].id.substring(0, 6) == "Check$") {
                    if (inputs[i].checked) {
                        if (Url == undefined) {
                            result = this.ShowDialog("Update/" + inputs[i].value, Width, Height, scro);
                        } else {
                            result = this.ShowDialog(Url + inputs[i].value, Width, Height, scro);
                        }
                    }
                }
            }
        }
        return result;
    };
    this.Delete = function (Url) {
        if (confirm("确定要删除选定的数据吗？")) {
            var DeleteArray = "";
            var Count = this.CountChecked();
            if (Count > 0) {
                var inputs = $("input");
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].id.substring(0, 6) == "Check$") {
                        if (inputs[i].checked) {
                            DeleteArray += inputs[i].value + ",";
                        }
                    }
                }
                if (Url == undefined) {
                    $.post("Delete", { ID: DeleteArray.substr(0, DeleteArray.length - 1) }, function (result) {
                        alert(result);
                        window.location.reload();
                    });
                } else {
                    $.post(Url, { ID: DeleteArray.substr(0, DeleteArray.length - 1) }, function (result) {
                        alert(result);
                        window.location.reload();
                    });
                }
            } else {
                alert("您没有选择任何数据，请选择后执行删除操作！");
            }
        }
    };
    this.Logout = function () {
        if (confirm("您确定要退出登陆吗？")) {
            $.post("/WebManager/Logout", function (result) {
                parent.location.href = result;
            });
        }
    }
    this.Chose = function () {
        var Array = "";
        var Count = this.CountChecked();
        if (Count > 1) {
            alert("藏品展示图片不能选择多个！");
        } else if (Count > 0) {
            var inputs = $("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].id.substring(0, 6) == "Check$") {
                    if (inputs[i].checked) {
                        Array += inputs[i].value + ",";
                    }
                }
            }
            window.returnValue = Array.substr(0, Array.length - 1);
            window.close(this);
        } else {
            alert("您没有选择任何数据！");
        }
    };
    this.Redirect = function (Url) {
        var Count = this.CountChecked();
        if (Count > 1) {
            alert("不能选择多行数据！");
        } else if (Count == 0) {
            alert("您没有选择任何数据！");
        } else {
            var inputs = $("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].id.substring(0, 6) == "Check$") {
                    if (inputs[i].checked) {
                        if (Url != undefined) {
                            window.location.href = Url + inputs[i].value;
                        }
                    }
                }
            }
        }
    };
    this.DoAppend = function (Url) {
        if (Url == undefined) {
            result = this.ShowDialog('Append/', 500, 500, '');
        } else {
            result = this.ShowDialog(Url, 500, 500, true);
        }
        if (result != undefined) alert(result);
        if (result != undefined && result != null) {
            if (result.toString().indexOf("成功") != -1) {
                window.location.reload();
            }
        }
    };
    this.DoAppend = function (Url,Width,Height) {
        if (Url == undefined) {
            result = this.ShowDialog('Append/', Width, Height, '');
        } else {
            result = this.ShowDialog(Url, Width, Height, true);
        }
        if (result != undefined) alert(result);
        if (result != undefined && result != null) {
            if (result.toString().indexOf("成功") != -1) {
                window.location.reload();
            }
        }
    };
    var result = '';
    this.DoUpdate = function () {
        var result = this.Update();
        if (result != undefined && result != "") {
            alert(result);
        }
        if (result != undefined && result != null) {
            if (result.toString().indexOf("成功") != -1) {
                window.location.reload();
            }
        }
    };
    this.DoUpdate = function (Url, Width, Height) {
        var result = this.Update(Url,Width,Height,false);
        if (result != undefined && result != "") {
            alert(result);
        }
        if (result != undefined && result != null) {
            if (result.toString().indexOf("成功") != -1) {
                window.location.reload();
            }
        }
    };
    this.DoUpdateLocation = function () {
        /// <summary>
        /// 修改信息数据URL可不填写
        /// </summary>
        var Count = this.CountChecked();
        if (Count > 1) {
            alert("不能选择多行数据！");
        } else if (Count == 0) {
            alert("您没有选择任何数据，请选择好后进行修改！");
        } else {
            var inputs = $("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].id.substring(0, 6) == "Check$") {
                    if (inputs[i].checked) {
                        window.location.href = ("Update/" + inputs[i].value);
                    }
                }
            }
        }
    };
    this.GetMaxShotIndex = function () {
        $.post("/WebManager/Tables/Product/GetMaxShotIndex", function (result) {
            $("#ShotIndex").val(result);
        });
    };
}
var JScript = new NetWorGroupScript();