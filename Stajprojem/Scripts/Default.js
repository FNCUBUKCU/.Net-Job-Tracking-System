$(document).ready(function () {
    $(":input[data-datepicker]").datepicker({
        dateFormat: 'dd-mm-yy',
        beforeShow: function (input, inst) {
            $(":input[data-datepicker]").addClass("half_width")
        }
    });
    $('form').attr('autocomplete', 'off');

    var tt = new Date();
    var ay = new Array(12); ay[0] = "Ocak"; ay[1] = "Şubat"; ay[2] = "Mart"; ay[3] = "Nisan"; ay[4] = "Mayıs"; ay[5] = "Haziran"; ay[6] = "Temmuz"; ay[7] = "Ağustos"; ay[8] = "Eylül"; ay[9] = "Ekim"; ay[10] = "Kasım"; ay[11] = "Aralık";
    var gun = new Array(7); gun[0] = "Pazar"; gun[1] = "Pazartesi"; gun[2] = "Salı"; gun[3] = "Çarşamba"; gun[4] = "Perşembe"; gun[5] = "Cuma"; gun[6] = "Cumartesi";
    $(".t_gun").html(gun[tt.getDay()]);
    $(".t_sayi").html(tt.getDate());
    $(".t_tarih").html(ay[tt.getUTCMonth()] + " " + tt.getFullYear());


    $(".btn").click(function () {

        var form = $(this).parents('form');

        swal( "Good job!","success").then((value) => form.submit());
       
    });
    

});



$(function () {
    // a tagimizde bulunan .view classımıza click olduğunda
    $("body").on("click", ".view", function () {
        //data-target dan url mizi al
        var url = $(this).data("target");
        //bu urlimizi post et
        $.post(url, function (data) { })
            //eğer işlemimiz başarılı bir şekilde gerçekleşirse
            .done(function (data) {
                //gelen datayı .modal-body mizin içerise html olarak ekle
                debugger;
                $("#modelView .modal-body").html(data);
                //sonra da modalimizi göster
                $("#modelView").modal("show");
            })
            //eğer işlem başarısız olursa
            .fail(function () {
                debugger;
                //modalımızın bodysine Error! yaz
                $("#modelView .modal-body").text("Error!!");
                //sonra da modalimizi göster
                $("#modelView").modal("show");
            })

    });

})