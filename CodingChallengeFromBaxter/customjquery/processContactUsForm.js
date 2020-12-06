$(document).ready(function () {

    processContactUsForm();
    document.redirectToHomePage = redirectToHomePage;


    function processContactUsForm() {


        let contactUsData;
        let type = "POST";
        let url = "/Home/SubmitContactUsForm";
        let confirmationModal = $('#confirmationModal');
        let modalTitle = $('#confirmationModal #title');
        let modalBody = $('#confirmationModal #modalBody');

        $('#contactUsForm').submit(function (e) {

            $('#contactUsForm #btnSubmit').html("Processing...");

            e.preventDefault();
            contactUsData = $('#contactUsForm').serialize();

            $.ajax({
                type: type,
                url: url,
                data: contactUsData,
                success: function (data) {

                    if (data.contactUsFormSavedSuccessfully && data.emailSentSuccessfully) {

                        modalTitle.append('Thank you for contacting us.');
                        modalBody.append('We will get back to you shortly.');

                    }
                    else if (data.contactUsFormSavedSuccessfully) {

                        modalTitle.append('Thank you for contacting us.');
                        modalBody.append('We have received your query and we will get back to you shortly. </br>' +
                            'Unfortunately an error occured sending the confirmation.');
                    } else {
                        modalTitle.append('Error processing the form.');
                        modalBody.append('We ran into a problem processing your form.</br>Please call us on: 01325-xxxx-xxxx');

                    }

                    showConfirmationModal(confirmationModal);
                }

            });

        });

    };

    function redirectToHomePage() {
        window.location.href = "/Home";
    }
    function showConfirmationModal(confirmationDialog) {
        confirmationDialog.modal('show');
    }

});

