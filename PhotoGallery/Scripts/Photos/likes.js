$(function () {
    $(".like")
        .click(function() {
            $.ajax({
                type: "PUT",
                url: 'api/vote/' + $(this).attr('id'),
                success: updateLikes()
            });
        });

    updateLikes();
});

function updateLikes() {
    $(".like").each(function () {
        $(this).load('api/vote/' + $(this).attr('id'));
    });
}