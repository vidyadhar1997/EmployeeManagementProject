function validatesform() {
    var passwordRegex = /^[A-Za-z0-9!@#$%^&*()_]{6,20}$/;
    var ConfirmPassword = document.myResetForm.ConfirmPassword.value;
    var Password = document.myResetForm.password.value;
    if (!passwordRegex.test(document.myResetForm.password.value)) {
        alert("Error: password must contain at least one lowercase letter (a-z)!");
        document.myResetForm.password.focus();
        return false;
    } else if (Password != ConfirmPassword) {
        alert("Error:Confirm Password should match with password ");
        return false;
    }
    else {
        alert("Reset Password Successfull");
        return true;
    }
}