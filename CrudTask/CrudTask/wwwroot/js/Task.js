var Task = function () {//Private
    var handleInitSucess = function (data) {
        if (data.key == true) {
            toastr.success(data.value, 'Success');
            setTimeout(function () {
                window.location.href = "/Home/Task";
            }, 1700);
        }
        else {
            toastr.error('An error occurred. Record not saved', 'Error');
        }
    };

  
    var handleBindTask = function () {
        Base.renderPartial("/Home/TaskListing", "#section-task");
    };
    var handleDeleteItem = function (id, url, renderUrl, element) {
        debugger;
        // Show confirmation dialog
        if (confirm("Are you sure you want to delete this item?")) {
            // User confirmed deletion
            $.ajax({
                url: url,
                type: 'post',
                dataType: 'json',
                data: { id: id },
                success: function (result) {
                    debugger;
                    if (result.key) {
                        // Show success message with SweetAlert
                        alert("Record Deleted Successfull");
                        setTimeout(function () {
                            window.location.href = "/Home/Task";
                        }, 1200);
                        // Handle rendering partial view
                        handleRenderPartial(renderUrl, element);
                    } else {
                        // Show error message with SweetAlert
                        alert("Error In Delete");
                    }
                },
                error: function () {
                    // Handle AJAX error with SweetAlert
                    Swal.fire("Error", "An error occurred while processing your request.", "error");
                }
            });
        } else {
            // User cancelled deletion
            console.log('Deletion cancelled');
        }
    };
    // Define handleDeleteTask function
    var handleDeleteTask = function (id) {
        debugger;
        // Call handleDeleteItem function
        handleDeleteItem(id, "/Home/DeleteTask", "/Home/TaskListing", "#section-task");
    };

    return {//Public
        initSucess: function (data) {
            debugger;
            handleInitSucess(data);
        },
        bindTask: function () {
            handleBindTask();
        },
        initDeleteTask: function (id) {
            handleDeleteTask(id);
        }
    };
}();