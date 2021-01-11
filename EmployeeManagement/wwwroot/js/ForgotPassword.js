function validateForgotform() {
    var emailRegex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    if (!emailRegex.test(document.myForgotForm.email.value)) {
        alert("Error: please enter the valid email");
        document.myForm.email.focus();
        return false;
    } else {
        alert("Forgot password is successfull");
        return true;
    }
}