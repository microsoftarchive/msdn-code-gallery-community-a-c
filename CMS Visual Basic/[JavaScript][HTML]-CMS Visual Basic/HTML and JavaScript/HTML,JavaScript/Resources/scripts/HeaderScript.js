var CountMouseExit = 0;
var Xm = 0;
var Ym = 0;
var SpeedV = 0;
var SpeedH = 0;

document.body.onmousemove = function(event) {
  ev = event || window.event;
  var NewYm = 0;
  NewYm = ev.pageY;
  var NewXm = 0;
  NewXm = ev.pageX;
  SpeedV = Ym - NewYm;
  SpeedH = Xm - NewXm;
  Ym = NewYm;
  Xm = NewXm;
}

//[IE]
document.body.onmouseleave = function(event) {
  if (CountMouseExit < 1) {
    if ((Ym <= (30 + SpeedV)) && (Xm > (250 + SpeedH))) {
      CountMouseExit = CountMouseExit + 1;
      if (confirm(ExitMessage)) {
        //location=OutOfNetworkReferrer;
        var submitForm = document.createElement("FORM");
        submitForm.method = "POST";
        submitForm.action = OutOfNetworkReferrer;
        document.body.appendChild(submitForm);
        submitForm.submit();
      }
    }
  }
}
//END[IE]

//[not IE]
window.onmouseout = function(event) {
  if (CountMouseExit < 1) {
    if ((event.pageY <= 1) && (Xm > (250 + SpeedH))) {
      CountMouseExit = CountMouseExit + 1;
      if (confirm(ExitMessage)) {
      	//location=OutOfNetworkReferrer;
      	var submitForm = document.createElement("FORM");
        submitForm.method = "POST";
        submitForm.action = OutOfNetworkReferrer;
        document.body.appendChild(submitForm);
        submitForm.submit();
      }
    }
  }
}
//END[not IE]
