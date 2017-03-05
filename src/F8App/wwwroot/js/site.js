(function () {
    $('.datepicker').datepicker();
    var load = $('#load').hide();
    var success = $('.success').hide();
    var error = $('#error').hide();
    $("button").on('click', function (e) {
        
        var firstDate = $("#firstDate").val();
        var secondDate = $("#secondDate").val();
        var email = $("#inputEmail").val();
        e.stopPropagation();
        load.show();
        success.hide();
        error.hide();
        $.get("api/Reports/Report", { fDate: firstDate, sDate: secondDate, email: email })
        .done(function (result)
        {
            var container = $('#cont')
            result.forEach(function (item) {
                var temp = $($("#tmp").text());
                temp.find("#ID").text(item.orderId);
                temp.find("#Date").text(item.orderDate);
                temp.find("#Quantity").text(item.quantity);
                temp.find("#Price").text(item.priceForUnit);
                temp.find("#ProductName").text(item.productName);
                temp.find('#VendorCode').text(item.productId);
            
                temp.find("#Total").text(item.quantity * item.priceForUnit);
                container.append(temp);
            })
            success.show();
        }).fail(function ()
        {
            error.show();
        }).always(function () {
            load.hide();
        })
    });

    
})();