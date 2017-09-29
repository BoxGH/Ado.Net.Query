 var productsdescript = new Array();

    $(':button[name="add_to_bag"]').click(function () {

        var cell = $(this).closest("tr").find("td");
        //alert(cell.eq(0).text() + " - " + cell.eq(1).text() + " - "+cell.eq(3).find("input").first().val());
        var count_product = parseInt(cell.eq(4).find("input").first().val());

        var count = parseInt($('#count_product').text());
        $('#count_product').text(count + count_product);

        var tot_price = parseInt($('#total_price').text());
        var cur_price = parseInt(cell.eq(2).text());
        $('#total_price').text(tot_price + cur_price * count_product);
        
        productsdescript[productsdescript.length] = {
            ProductId: cell.eq(0).text(),
            NameProduct: cell.eq(1).text(),
            PriceProduct: cur_price,
            QuantityProduct: count_product
        };
    });

    $('#send_to_server').click(function () {
        if ($('#total_price').text() == '0')
        {
            alert('Товар не выбран');
            return;
        }
        var products = {
            CustomerId: parseInt( $('#name_customer').val()),
            TotalPrice: parseFloat( $('#total_price').text()),
            CustomerName: $('#name_customer option:selected').text(),
            ProductsDescript: productsdescript
        };

        $.post('/Commutator/SetOrder', products)
                    .fail(function (ex) { alert('failed, ' + ex); })
                    .done(function (data) {
                        //alert("Data Loaded: " + data);
                        productsdescript.splice(0, productsdescript.length);
                        $('#count_product').text('0');
                        $('#total_price').text('0');
                    });
    });

    $(':button[name="remove_from_bag"]').click(function () {
        var cell = $(this).closest("tr").find("td");
        for (i = 0; i <productsdescript.length; i++)
        {
            if (productsdescript[i].ProductId === cell.eq(0).text())
            {
                productsdescript.splice(i, 1);

                var count_product = parseInt(cell.eq(4).find("input").first().val());
                var count = parseInt($('#count_product').text());
                $('#count_product').text(count - count_product);

                var tot_price = parseInt($('#total_price').text());
                var cur_price = parseInt(cell.eq(2).text());
                $('#total_price').text(tot_price - cur_price * count_product);

                //alert(productsdescript.length)
                break;
            }
        }
    });
