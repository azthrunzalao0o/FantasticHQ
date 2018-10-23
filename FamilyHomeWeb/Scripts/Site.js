function SelectUser(userName, url) {
    console.log(userName);
    $.ajax({
        url: url,
        type: "GET",
        data: {
            userName: userName
        },
        success: function (result) {
            if (result === "Good") {
                location.reload();
            } else {
                alert("Cannot set to user. Please contact server admin.")
            }
        },
        error: function (result) {
            alert("Unexpected Error. Please contact server admin.")
        }
    });
}