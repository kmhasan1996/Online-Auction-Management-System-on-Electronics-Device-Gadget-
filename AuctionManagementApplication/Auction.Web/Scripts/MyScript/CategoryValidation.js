$(document).ready(function() {

    //get create page
    $("#createButton").click(function () {
        $.ajax({
                type: "GET",
                url: "/Admin/Category/Create"

            })
            .done(function (response) {
                $("#createCategoryModal .modal-dialog").html(response);


            })
            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
    });
    
    //$('input[name="Name"]').keyup(function (e) {
    //    var regexp = /[^a-zA-Z]/g;
    //    if ($(this).val().match(regexp)) {
    //        $(this).val($(this).val().replace(regexp, ''));
    //    }
    //});

    var nameError = false;
    $('input[name="Name"]').keyup(function (e) {
       ;
        var x = document.getElementById("NameError");
        $.ajax({
            url: "/Admin/Category/UniqueName",
            type: "POST",
            data: $("#categoryForm").serialize(),
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            //data: "{'name': '" + $("#Name").val() + "','id': '" + $("#id").val() + "'}",
            dataFilter: function (response) {
                if (response === "True") {
                    nameError = true;
                    x.innerHTML = "Name already exist";
                    x.style.color = "red";

                } else {
                    nameError = false;
                    x.innerHTML = "";
                }

            }

        });

    });

    //$("#categoryForm").validate({
    //    rules: {
    //        //Image: {
    //        //    required: true
    //        //},
    //        Name: {
    //            required: true
    //        }
    //    },
    //    messages: {
    //        //Image: {
    //        //    required: "Image is required",
               
    //        //},
    //        Name: {
    //            required:"Name is required"
    //        }
    //    }
    //});

    
$("#saveButton").click(function () {
    //alert("out");
    //if ($("#categoryForm").valid() && !nameError) {
        //alert("in");
        $.ajax({
                type: "POST",
                url: "/Category/Create",
                data: $("#categoryForm").serialize()

        })
        .done(function (response) {
            if (response.Success) {
                Swal.fire({
                    title: 'Saved SuccessFully',
                    icon: 'success',
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.value) {
                        window.location.reload();
                    }
                });

            } 

        })
        .fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });
    //};
       
});

   
$("#updateButton").click(function () {

    if ($("#categoryForm").valid() && !nameError) {
        $.ajax({
                type: "POST",
                url: "/Category/EDit",
                data: $("#categoryForm").serialize()

        })
        .done(function (response) {
            if (response.Success) {
                Swal.fire({
                    title: 'Updated SuccessFully',
                    icon: 'success',
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.value) {
                        window.location.reload();
                    }
                });

            } 

        })
        .fail(function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Fail");
        });
     };

});

    $("#imageUpload").change(function () {
        var element = this;

        var formData = new FormData();

        var totalFiles = element.files.length;

        for (var i = 0; i < totalFiles; i++) {
            var file = element.files[i];
            formData.append("Photo", file);
        }

        $.ajax({
                type: 'POST',
                url: "/Admin/Shared/UploadImage/",
                dataType: 'json',
                data: formData,
                contentType: false,
                processData: false
            })
            .done(function (response) {
                console.log(response);

                if (response.Success) {
                    $("#ImageUrl").val(response.ImageURL);
                    $("#categoryImage").attr("src", response.ImageURL);
                }
            })
            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Fail to connect edit");
            });
    });

});