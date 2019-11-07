(function () {
	"use strict";

	WinJS.UI.Pages.define("./pages/nav_settings/nav_settings.html", {
		// This function is called whenever a user navigates to this page. It
		// populates the page elements with the app's data.
		ready: function (element, options) {
			// Initialize the page here.

			//keeps effect button for split views after page change
			myAppObject.hoverSplitView('cmdSettings');

			//Creates ToggleSwitch and apply label
			var mySwitchControl = new WinJS.UI.ToggleSwitch(document.querySelector("#exampleSwitch"));
			mySwitchControl.labelOn = "On";
			mySwitchControl.labelOff = "Off";

			//recover setting from localstorage
			var valueSwitch = myAppObject.readItem("valueSwitch");
			if (valueSwitch != null && valueSwitch == "1") {
				mySwitchControl.checked = true;
			}
			else {
				mySwitchControl.checked = false;
			}

			// control event for switch
			mySwitchControl.addEventListener('change', function () { saveSwitch(mySwitchControl); });

			//enter animation effect
			WinJS.UI.Animation.enterPage([[document.querySelector("header")], [document.querySelector("section")]], null);

		}

	});

	function saveSwitch(mySwitchControl) {
		if (mySwitchControl.checked == true) {
			myAppObject.saveItem("valueSwitch", "1");//save setting in localstorage (see index.js)
		}
		else {
			myAppObject.saveItem("valueSwitch", "0");//save setting in localstorage (see index.js)
		}
	};


})();
