// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onLoginLoad() {
	const formLogin = document.getElementById("login");
	

	formLogin.addEventListener("submit", function (event) {
		const userName = formLogin.getElementsByClassName("username")[0].value;
		const password = formLogin.getElementsByClassName("password")[0].value;
		// stop form submission
		event.preventDefault();
		// validate the form
		//let nameValid = hasValue(form.elements["name"], NAME_REQUIRED);
		//let emailValid = validateEmail(form.elements["email"], EMAIL_REQUIRED, EMAIL_INVALID);
		// if valid, submit the form.
		if (userName == "hi" && password == "123") {
			//getAJAXtest();
			AJAXfunc(username,password);
			
		}
		else {
			alert("nope");
        }
	});
}

function getAJAXtest() {
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function () {
		if (this.readyState == 4 && this.status == 200) {
			//alert(this.responseText);
			//return this.responseText;
			finalAJAX(this.responseText);
		}
	};
	xhttp.open("GET", "XMLtext.txt", true);
	xhttp.send();
	
}
function finalAJAX(input) {
	alert(input);

}

function AJAXfunc(username, password) {
	//var parameter = { "username": username, "password": password }
	$.ajax({
		type: "POST",
		url: '/Index?handler=LoginFunc',
		//data: "",//JSON.stringify(parameter),
		//contentType: 'application/json; charset=utf-8',
		dataType: 'json',
		//beforeSend: function (xhr) {
		//	xhr.setRequestHeader("XSRF-TOKEN",
		//		$('input:hidden[name="__RequestVerificationToken"]').val());
		//},
		headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },

		success: function (data) {
			onsuccess(data.responseText)
		},
		error: function (data, success, error) {
			alert("Error: " + error)
        }
    })
}
function onsuccess(data) {
	alert(data)
}