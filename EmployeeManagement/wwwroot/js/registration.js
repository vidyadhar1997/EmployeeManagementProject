/*function validateForm() {
    var emailRegex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var passwordRegex = /^[A-Za-z0-9!@#$%^&*()_]{6,20}$/;
    var firstNameRegex = /^[A-Z]{1}[a-z]{2,}$/;
    var lastNameRegex = /^[A-Z]{1}[a-z]{2,}$/;
    var phoneNumberRegex = /^[0-9]{2}[ ][0-9]{10}$/;
    var City = document.myForm.City.value;
    var State = document.myForm.State.value;
    var Zip = document.myForm.Zip.value;
    var ConfirmPassword = document.myForm.ConfirmPassword.value;
    var Password = document.myForm.password.value;
    if (!firstNameRegex.test(document.myForm.FirstName.value)) {
        alert("Error:First name start with Capital letter");
        document.myForm.FirstName.focus();
        return false;
    } else if (!lastNameRegex.test(document.myForm.LastName.value)) {
        alert("Error:Last name start with Capital letter ");
        document.myForm.LastName.focus();
        return false;
    } else if (!emailRegex.test(document.myForm.email.value)) {
        alert("Error: please enter the valid email");
        document.myForm.email.focus();
        return false;
    } else if (!passwordRegex.test(document.myForm.password.value)) {
        alert("Error: password must contain at least one lowercase letter (a-z)!");
        document.myForm.password.focus();
        return false;
    } else if (Password != ConfirmPassword) {
        alert("Error:Confirm Password should match with password ");
        return false;
    } else if (!phoneNumberRegex.test(document.myForm.PhoneNumber.value)) {
        alert("Error: Phone number must be 10 character");
        document.myForm.PhoneNumber.focus();
        return false;
    }
    else if (City == null || City == "") {
        alert("Error:City filed should not be empty ");
        document.myForm.City.focus();
        return false;
    }
    else if (State == null || State == "") {
        alert("Error:State filed should not be empty ");
        document.myForm.State.focus();
        return false;
    } else if (Zip == null || Zip == "") {
        alert("Error:Zip filed should not be empty ");
        document.myForm.Zip.focus();
        return false;
    }
    else {
        alert("Registration successful");
    }
    var employee = {};
    employee.FirstName = $("#FirstName").val();
    employee.LastName = $("#LastName").val();
    employee.Email = $("#Email").val();
    employee.Password = $("#Password").val();
    employee.PhoneNumber = $("#PhoneNumber").val();
    employee.Address = $("#Address").val();
    employee.City = $("#City").val();
    employee.State = $("#State").val();
    employee.Zip = $("#Zip").val();
    $.ajax({
        type: "POST",
        url: '@Url.Action("createEmployee")',
        date: '{std:' + JSON.stringify(employee) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            alert("Data has been added successfully.");
            return true;

        },
        error: function () {
            alert("Error while inserting data");
        }
    });
    return false;
}*/
  