$(function () {
    var isCustomerRemoved = $('#IsCustomerRemoved').val().toLowerCase();
    if (isCustomerRemoved === "true") {
        var message = "<span uk-icon='icon: check'></span> Customer removed";
        UIkit.notification(message, "success");
    }

    UIkit.util.on('#remove-modal-confirm', 'click', function (e) {
        e.preventDefault();
        e.target.blur();
        var id = $(this).attr('customer-id');
        var string = "<p>Please note this action can't be undone</p>";
        UIkit.modal.confirm(string).then(function () {
            $.ajax({
                type: "DELETE",
                url: '/Customer/remove/' + id,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $('#customersList').html(data);
                },
            });
        });
    });
});