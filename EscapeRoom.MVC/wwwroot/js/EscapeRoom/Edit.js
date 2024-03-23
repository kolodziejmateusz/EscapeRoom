$(document).ready(function () {
    $("#createEscapeRoomReviewModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Utworzono recenzje")
            },
            error: function () {
                toastr["error"]("Cos poszlo nie tak")
            }
        })
    });
});