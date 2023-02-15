// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onLoginLoad() {
	const formLogin = document.getElementById("login");


	formLogin.addEventListener("submit",async function (event) {
		event.preventDefault();
		const encoder = new TextEncoder();
		const userName = formLogin.getElementsByClassName("username")[0].value;
		const passwordraw = formLogin.getElementsByClassName("password")[0].value
		if (passwordraw != "" && userName != "") {


			const passworddata = encoder.encode(passwordraw);
			const password = await crypto.subtle.digest("SHA-256", passworddata);//.then(AJAXfunc(userName, password));
			const passwordarr = Array.from(new Uint8Array(password));
			//const password = formLogin.getElementsByClassName("password")[0].value;
			AJAXfunc(userName, passwordarr.map((b) => b.toString(16).padStart(2, '0')).join(''));
		}
		else {
			alert("please enter a valid username and password")
        }
	});
}


function AJAXfunc(username, password) {
	var parameter = JSON.stringify({ "username": username, "password": password })
	$.ajax({
		type: "POST",
		contentType: 'application/json; charset=utf-8',
		url: 'api/LoginFunc/0', //?handler=LoginFunc',// .aspx/LoginFunc',//
		data: parameter,
		dataType: 'json',
		/*
		beforeSend: function (xhr) {
			xhr.setRequestHeader("XSRF-TOKEN",
				$('input:hidden[name="__RequestVerificationToken"]').val());
		},
		*/
		headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },

		success: function (data) {
			onsuccess(data)
		},
		error: function (data, success, error) {
			alert("Error: " + error + " - " + data + " - " + success + " - " + data.value)
        }
    })
}
//https://www.talkingdotnet.com/handle-ajax-requests-in-asp-net-core-razor-pages/
function onsuccess(data) {
	
	alert(data);
}