$(document).ready(function () {
    $('.img-thumbnail').click(function () {
        var photoId = $(this).data('id');
        var url = $('#photoModal').data('url') + '/' + photoId;
        
        $.get(url, function (data) {
            $('#photoModal').html(data);

            $('#photoModal').modal('show');
        });
    });
});