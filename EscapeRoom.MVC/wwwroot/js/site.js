const RenderEscapeRoomReviews = (reviews, container) => {
    container.empty();

    for (const review of reviews) {

        let stars = '';
        for (let i = 0; i < review.starRating; i++) {
            stars += `<img src="/content/images/star.png" alt="gwiazdka">`;
        }

        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 18rem; margin: 5px;">
                <div class="card-header">${review.reviewerName}</div>
                 <div class="card-body">
                     <h6 class="card-title">${review.review}</h6> 
                 </div>
                  <div class="card-footer">
                     ${stars}
                 </div>
             </div>`
        )
    }
}


const LoadEscapeRoomReviews = () => {
    const container = $("#reviews")
    const escapeRoomEncodedName = container.data("encodedName");

    $.ajax({
        url: `/EscapeRoom/${escapeRoomEncodedName}/EscapeRoomReview`,
        type: 'get',
        success: function (data) {
            if (!data.length) {
                container.html("Ten Escape Room nie ma jeszcze recenzji")
            } else {
                RenderEscapeRoomReviews(data, container)
            }
        },
        error: function () {
            toastr["error"]("Cos poszlo nie tak")
        }
    })
}

const CreateEscapeRoomReview = () => {
    $("#createEscapeRoomReviewModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Utworzono recenzje")
                LoadEscapeRoomReviews()
            },
            error: function () {
                toastr["error"]("Cos poszlo nie tak, pusty formularz lub niezalogowany")
            }
        })
    });
}