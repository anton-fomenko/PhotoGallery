$(function () {
    $(".like")
        .click(function () {
            var button = $(this);
            $.ajax({
                type: "PUT",
                url: 'api/vote/' + $(this).attr('id'),
                success: function(data) {
                    button.html(data);
                }
            });
        });

    updateLikes();
});

function updateLikes() {
    $(".like").each(function () {
        $(this).load('api/vote/' + $(this).attr('id'));
    });
}