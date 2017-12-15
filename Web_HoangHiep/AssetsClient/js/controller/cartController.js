$(function () {
    $('#btnContinue').off('click').on('click', function ()
        {
            window.location.href = "/";
        });
  

    $("#btnUpdate").off('click').on('click', function (e) {
        e.preventDefault();
        var sachlist = $('.txtQuantity');//lấy ra các sách có class = soluongsach(nó sẽ là 1 danh sách)
        var cardlist = [];

        $.each(sachlist, function (i, item) {
            cardlist.push({
                SoLuong: $(item).val(),
                Sach: {
                    MaSach: $(item).data('id')
                }
            });//cartlist thêm vào 1 đối tượng có thuộc tính soluong và sách
        });
            
                $.ajax({
                    url: '/ShoppingCart/UpdateBanGhi',
                    data: { model: JSON.stringify(cardlist) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/ShoppingCart";
                        }
                    }
                })
            });



    $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/ShoppingCart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShoppingCart";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/ShoppingCart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShoppingCart";
                    }
                }
            })
        });
});