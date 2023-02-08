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
		if (userName == "hi" && password == "123") {
			//getAJAXtest();
			AJAXfunc(userName,password);
			
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
	var parameter = JSON.stringify({ "username": username, "password": password })
	$.ajax({
		type: "POST",
		contentType: 'application/json; charset=utf-8',
		url: '/Login?handler=LoginFunc',
		data: parameter,
		dataType: 'json',
		headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },

		success: function (data) {
			onsuccess(data.responseText)
		},
		error: function (data, success, error) {
			alert("Error: " + error + " - " + data + " - " + success + " - " + data.value)
        }
    })
}
//https://www.talkingdotnet.com/handle-ajax-requests-in-asp-net-core-razor-pages/
function onsuccess(data) {
	alert(data)
}