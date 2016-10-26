$(function () {
    $(".btn-like")
        .on('click',
            function(event) {
                event.preventDefault();
                var likeSpan = $(this).children(".like");;
                $.ajax({
                    type: "PUT",
                    url: 'api/likes/' + likeSpan.attr('id'),
                    success: function(data) {
                        likeSpan.text(data);
                    }
                });
            });

    $(".btn-dislike")
    .click(function () {
        var likeSpan = $(this).children(".dislike");;
        $.ajax({
            type: "PUT",
            url: 'api/dislikes/' + likeSpan.attr('id'),
            success: function (data) {
                likeSpan.text(data);
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