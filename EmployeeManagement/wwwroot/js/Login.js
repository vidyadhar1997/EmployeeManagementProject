/*function validateforms() {
    var emailRegex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    var passwordRegex = /^[A-Za-z0-9!@#$%^&*()_]{6,20}$/;
    if (!emailRegex.test(document.myForms.email.value)) {
        alert("Error: please enter the valid email");
        document.myForms.email.focus();
        return false;
    } else if (!passwordRegex.test(document.myForms.password.value)) {
        alert("Error: password must contain at least one lowercase letter (a-z)!");
        document.myForms.password.focus();
        return false;
    }
    else {
        alert("Login is successfull");
        return true;
    }
}*/