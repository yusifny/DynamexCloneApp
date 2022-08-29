$(document).ready(function () {
    $("#sendButton").click(function(e){
        e.preventDefault();
        sendEmail();
        // alert("Mesaj uğurla göndərildi!");
        Swal.fire({
            text: "Mesaj uğurla göndərildi!",
            confirmButtonColor: "#fd475d"
        }).then(function(){
            window.location.href = "https://localhost:5001/Contact";
            $(document).scrollTop(0);
        });
        $("#form").trigger('reset'); //jquery
    });
    function sendEmail() {
        const params = {
            message: $("#text-message").val(),
            firstName: $("#first-name").val(),
            lastName: $("#last-name").val(),
            emailAddress: $("#email-address").val(),
            phoneNumber: $("#phone-number").val(),
        }
        emailjs.send('DynamexContactForm', 'DynamexContactForm', params)
    }
});