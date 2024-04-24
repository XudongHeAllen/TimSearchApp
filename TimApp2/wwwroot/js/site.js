// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function myFunction1() {
    //Declare variables
    var input;
    var filter;
    var div;
    var partner;

    input = document.getElementById('searchInput');
    console.log("input:"input);
    div = document.getElementById('partners');
    console.log("div:"div);
    partner = div.getElementsByTagName("div");
    console.log("partner:"partner)

    //use loop to hide all unmatch divs
}