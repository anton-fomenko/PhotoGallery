﻿$(function () {
    $(".btn-like")
        .on('click',
            function (event) {
                var button = $(this);
                var likeSpan = button.children(".like");;
                $.ajax({
                    type: "PUT",
                    url: 'api/likes/' + likeSpan.attr('id'),
                    success: function(data) {
                        likeSpan.text(data);
                        button.addClass('disabled');
                    }
                });
            });

    $(".btn-dislike")
    .click(function () {
        var button = $(this);
        var likeSpan = button.children(".dislike");;
        $.ajax({
            type: "PUT",
            url: 'api/dislikes/' + likeSpan.attr('id'),
            success: function (data) {
                likeSpan.text(data);
                button.addClass('disabled');
            }
        });
    });

    updateLikes();
});

function updateLikes() {
    $(".like").each(function () {
        $(this).load('api/likes/' + $(this).attr('id'));
    });

    $(".dislike").each(function () {
        $(this).load('api/dislikes/' + $(this).attr('id'));
    });
}