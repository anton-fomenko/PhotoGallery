$(function () {
    var deletePhotoButton = $(".deletePhotos");
    deletePhotoButton
        .on('click',
            function () {
                var checkboxes = $(".img-checkbox:checked");

                var request = {
                    arrayOfPhotoIds: [],
                    albumId: deletePhotoButton.data('id')
                }

                checkboxes.each(function () {
                    request.arrayOfPhotoIds.push($(this).data("photoid"));
                });

                $.ajax({
                    type: "DELETE",
                    url: '/api/AlbumApi',
                    contentType: 'application/json',
                    data: JSON.stringify(request),
                    success: function () {
                        location.reload();
                    }
                });
            });
});
