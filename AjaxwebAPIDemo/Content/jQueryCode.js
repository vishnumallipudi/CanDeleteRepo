console.log("Hi ra vishnu");

$(document).ready(function () {

   // alert("hi ra vishnu");

    $("input[class='entered'").css("background-color", "yellow");
    
    $("#buttid").on("mouseenter mouseleave", myfun);
    //$("#buttid").detach();

    
    function myfun(e) {
        $(this).toggleClass("entered")
        console.warn($("#sdiv > p").first());
        console.log("focus out");
    }

    'use strict';

    (function () {
        var a = b = 3;
    })();

    console.log("a defined? " + (typeof a !== 'undefined'));
    console.log("b defined? " + (typeof b !== 'undefined'));


});