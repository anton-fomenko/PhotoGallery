$(function () {
    $(".deletePhotos")
        .on('click',
            function () {
                var checkboxes = $(".img-checkbox");
                var arrayOfPhotoIds = [];

                checkboxes.each(function () {
                    arrayOfPhotoIds.push($(this).data("photoid"));
                });

                $.ajax({
                    type: "DELETE",
                    url: '/api/album',
                    data: JSON.stringify(arrayOfPhotoIds),
                    success: function (data) {
                        location.reload();
                    }
                });
            });
});
