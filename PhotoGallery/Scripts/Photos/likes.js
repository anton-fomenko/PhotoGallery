$(function () {
    updateLikes();
});

function updateLikes() {
    $(".like").each(function () {
        $(this).load('api/vote/' + $(this).attr('id'));
    });
}