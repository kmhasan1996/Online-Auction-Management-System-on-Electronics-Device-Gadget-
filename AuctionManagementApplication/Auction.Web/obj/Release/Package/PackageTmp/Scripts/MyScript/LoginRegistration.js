$(document).ready(function() {
    $("#DistrictId").on("change",
        function () {
            var districtId = $('#DistrictId').val();
            var jsonData = { districtId: districtId };

            $('#ThanaId').empty();

            if (districtId <= 0) {
                //alert("hi");
                var defaultValue = '<option value=0 > Select One</option>';
                $('#ThanaId').append(defaultValue);
            }
            else {
                var defaultValue1 = '<option value=0 > Select One</option>';
                $('#ThanaId').append(defaultValue1);
                $.ajax({
                    type: "POST",
                    url: "/User/GetThanaByDistrictId/",
                    data: JSON.stringify(jsonData),
                    //data: {
                    //    categoryId:$("#categoryId").val()
                    //} ,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $.each(data, function (key, thana) {
                            var optionText = "<option value='" + thana.Id + "' >" + thana.Name + "</option>";
                            $('#ThanaId').append(optionText);
                        });
                    }
                });
            }

        });


    $("#registerButton").click(function () {
        //if ($("#categoryForm").valid() && !nameError) {
            
            $.ajax({
                    type: "POST",
                    url: "/User/Register",
                    data: $("#registerForm").serialize()

            })
            .done(function (response) {
                if (response.Success) {
                    Swal.fire({
                        title: 'Registered Successful',
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.value) {
                            window.location.href = 'Login';
                        }
                    });

                }
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
        //};

    });




});