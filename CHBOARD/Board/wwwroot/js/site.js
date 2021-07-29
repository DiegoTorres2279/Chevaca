// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("btn_logout").onclick= function (){
    document.getElementById("form_logout").submit();
};

// document.getElementById("btn_logout").onclick= function (){
//     $.ajax({
//         url:'/Administrador/Logout',
//         type: "GET"
//     })
// };