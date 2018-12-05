function deleteCartItem(itemId) {
    $.ajax({
        type: 'POST',
        url: 'Cart/Delete',
        contentType: "application/json",
        data: JSON.stringify({ Id: itemId }),
        success: function () {
            location.reload();
        }
    });
}