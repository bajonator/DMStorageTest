function AssignUser(button) {
    var form = $(button).closest('form');
    var formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: '/Admin/AssignRole',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response.success) {
                alert("Změnu provedeno úspěšně");
                var userRow = $(button).closest('tr');
                userRow.find('.badge').text(response.user.roleName).attr('class', 'badge ' + getRoleBadgeClass(response.user.roleName));
            } else {
                alert(response.message);
            }
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function getRoleBadgeClass(roleName) {
    switch (roleName) {
        case "FiOT":
            return "badge-primary";
        case "Maintenance":
            return "badge-success";
        case "Technology":
            return "badge-danger";
        default:
            return "badge-secondary";
    }
}
