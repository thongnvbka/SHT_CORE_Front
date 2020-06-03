// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.carousel').carousel({
        carouselWidth: 930,
        carouselHeight: 330,
        directionNav: true,
        shadow: true,
        buttonNav: 'bullets'
    });
});