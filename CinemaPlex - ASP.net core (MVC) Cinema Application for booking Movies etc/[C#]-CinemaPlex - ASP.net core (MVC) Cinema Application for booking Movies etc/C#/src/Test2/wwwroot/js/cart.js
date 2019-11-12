/* Set rates + misc */
var fadeTime = 50;


$('.product-removal button').click(function () {
    removeItem(this);
});

$('#checkout').click(function () {

    if (window.PaymentRequest) {
        // We're good to go...
        var paymentMethods = [
            // We'll accept regular credit and debit cards
            { supportedMethods: ['basic-card'] }
        ];
        var details = {
            total: {
                label: 'Something that costs money',
                amount: { currency: 'AUD', value: '9.99' }
            }
        };
        // Show a native Payment Request UI and handle the result
        new PaymentRequest(paymentMethods, details)
          .show()
          .then(function (uiResult) {
              processPayment(uiResult);
          })
          .catch(function (error) {
              handlePaymentError(error);
          });
    } else {
        // Alas! Use your legacy checkout form...
        post('/Cart/Checkout/');
    }
});

/* Remove item from cart */
function removeItem(removeButton) {
    /* Remove row from DOM and recalc cart total */
    var productRow = $(removeButton).parent().parent();
    var sessionId = $(productRow).attr('id');
    post('/Cart/Remove/', { id: sessionId });
    productRow.slideUp(fadeTime, function () {
        productRow.remove();
    });
}


