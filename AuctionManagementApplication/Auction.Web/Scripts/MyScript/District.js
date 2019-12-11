$(document).ready(function() {


    //form validation
    $("#districtForm").validate({
        rules: {
            Name: {
                required: true
            }
        },
        messages: {
            Name: {
                required:"Name is required"
            }
        }

    });

    //get create form
    $("#createButton").click(function () {
        $.ajax({
                type: "GET",
                url: "/Admin/District/Create"

            })
            .done(function (response) {
                $("#createDistrictModal .modal-dialog").html(response);


            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });
    });


    //name input field keyup
    var nameError = false;
    $('input[name="Name"]').keyup(function (e) {
       
        var x = document.getElementById("NameError");
        $.ajax({
            url: "/Admin/District/UniqueName",
            type: "POST",
            data: $("#districtForm").serialize(),
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

    //get edit modal
    $(".editButton").click(function () {

        $.ajax({
                type: "GET",
                url: "/Admin//District/Edit",
                data: {
                    Id: $(this).attr("data-id")
                }

            })
            .done(function (response) {
                $("#editModal .modal-dialog").html(response);
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Fail");
            });

    });

    //delete a record

    $(".deleteButton").click(function () {
        Swal.fire({
            icon: 'warning',
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "POST",
                    url: "/Admin/District/Delete",
                    data: {
                        Id: $(this).attr("data-id")
                    }

                })
                .done(function (response) {
                    Swal.fire({
                        title: 'Deleted Successfully',
                        icon: 'success',
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });
                })
                .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                    alert("Fail");
                });

            }
        });

    });


    //save button click

    $("#saveButton").click(function() {
        if ($("#districtForm").valid() && !nameError) {
            $.ajax({
                type: "POST",
                url: "/District/Create",
                data:$("#districtForm").serialize()
            })
            .done(function(response) {
                if (response.Success) {
                    //sweet alert
                    Swal.fire({
                        title: "Saved Successfully",
                        icon: "success",
                        confirmButtonColor: "#3085d6",
                        cancelButtonColor: "#d33",
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });
                }
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                Swal.fire({
                    title: "Failed to Save",
                    icon: "error",
                    confirmButtonColor: "#3085d6",
                    cancelButtonColor: "#d33",
                    confirmButtonText: "OK"
                });
            });
        }
    });

    $("#closeButton").click(function () {
        window.location.reload();
    });


    //edit button click
    $("#updateButton").click(function () {
        if ($("#districtForm").valid() && !nameError) {
            $.ajax({
                    type: "POST",
                    url: "/District/Edit",
                    data: $("#districtForm").serialize()
            })
            .done(function (response) {
                if (response.Success) {
                    //sweet alert
                    Swal.fire({
                        title: "Updated Successfully",
                        icon: "success",
                        confirmButtonColor: "#3085d6",
                        cancelButtonColor: "#d33",
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });
                } else {
                    Swal.fire({
                        title: "Updated Successfully",
                        icon: "success",
                        confirmButtonColor: "#3085d6",
                        cancelButtonColor: "#d33",
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.value) {
                            window.location.reload();
                        }
                    });
                }
            })
            .fail(function (xmlHttpRequest, textStatus, errorThrown) {
                Swal.fire({
                    title: "Failed to Update",
                    icon: "error",
                    confirmButtonColor: "#3085d6",
                    cancelButtonColor: "#d33",
                    confirmButtonText: "OK"
                });
            });
        }
    });


});