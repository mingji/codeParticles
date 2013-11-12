// home-index.js
var homeIndexModule = angular.module("homeIndex", []);

function MainController($scope) {

    $scope.downloader = function () {
        //send ajax to download string that's currently in "code"
        $.ajax({
            type: 'post',
            url: "/download/Save",
            data: { 'reportData': editor.getValue() },
            success: function (data) {
                // We received token here. We need to go back to server with that token retrieve that file
                var anchor = $("<iframe style='display:none;'></iframe>)").attr("src", "/download/GetFile?token=" + data);
                anchor.appendTo("body");
            },
            error: function (err) {
                alert("error: " + err.responseText)
            }
        });


    }

    $scope.uploader = function () {
        //send ajax to download string that's currently in "code"

        $.ajax({
            type: 'post',
            url: "/download/Upload",
            data: { 'reportData': editor.getValue() },
            success: function (data) {
                console.log(data);
                return true;
            },
            error: function (err) {
                alert("error: " + err.responseText)
            }
        });
    }

}










//// home-index.js
//var homeIndexModule = angular.module("homeIndex", []);

//function MainController($scope) {

//    $scope.downloader = function () {
//        //send ajax to download string that's currently in "code"

//        $.ajax({
//            dataType: 'json',
//            type: 'post',
//            //traditional: true,
//            url: "/download/Save",
//            data: { 'reportData': $("#code").val() },
//            success: function (results) {
//                //window.location = results.url;
//                //alert("success: " + results.url);
//            },
//            error: function (err) {
//                alert("error: " + err.responseText)
//            }
//        });


//    }


//}
