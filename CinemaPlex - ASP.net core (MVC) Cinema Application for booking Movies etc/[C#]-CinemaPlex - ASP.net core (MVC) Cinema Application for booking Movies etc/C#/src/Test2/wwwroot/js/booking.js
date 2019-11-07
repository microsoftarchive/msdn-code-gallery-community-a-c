var price = 35; //price
$(document).ready(function () {
    var $cart = $('#selected-seats'), //Sitting Area
	$counter = $('#counter'), //Votes
	$total = $('#total'); //Total money
    var sessionId = $('#sessionId').text();
    $.getJSON("/api/sessions/" + sessionId, function (result) {
        try{
            $.each(result.bookedSeats, function (index, value) {
                sc.get([value]).status('unavailable');
            });
        }
        catch (exception) {
            console.log("Could not find any booked seats..")
        }
    });
    $('#bookSeats').click(function (e) {
        bookSeats(sc);
    });
    var sc = $('#seat-map').seatCharts({
        map: [  //Seating chart
			'_a_a_a_a_',
            '_________',
            'a__a_a__a',
            '_________',
            '_a_a_a_a_',
			'_________',
			'a__a_a__a',
			'_________',
			'_a_a_a_a_'
        ],
        naming: {
            top: false,
            getLabel: function (character, row, column) {
                return column;
            }
        },
        legend: { //Definition legend
            node: $('#legend'),
            items: [
				['a', 'available', 'Option'],
				['a', 'unavailable', 'Sold']
            ]
        },
        click: function () { //Click event
            if (this.status() == 'available') { //optional seat
                $('<li>R' + (this.settings.row + 1) + ' S' + this.settings.label + '</li>')
					.attr('id', 'cart-item-' + this.settings.id)
					.data('seatId', this.settings.id)
					.appendTo($cart);

                $counter.text(sc.find('selected').length + 1);
                $total.text(recalculateTotal(sc) + price);
                return 'selected';
            } else if (this.status() == 'selected') { //Checked
                //Update Number
                $counter.text(sc.find('selected').length - 1);
                //update totalnum
                $total.text(recalculateTotal(sc) - price);

                //Delete reservation
                $('#cart-item-' + this.settings.id).remove();
                //optional
                return 'available';
            } else if (this.status() == 'unavailable') { //sold
                return 'unavailable';
            } else {
                return this.style();
            }
        }
    });
    //sold seat
    

});
//sum total money
function recalculateTotal(sc) {
    var total = 0;
    sc.find('selected').each(function () {
        total += price;
    });

    return total;
}

function bookSeats(sc) {
    var seats = new Array();
    sc.find('selected').each(function (selected) {
        seats.push(this.settings.id)
    });
    var jsonSeats = JSON.stringify(seats);
    var sessionId = $('#sessionId').text();
    post('/Cart/AddSeats/', { id: sessionId, seats: jsonSeats });
}