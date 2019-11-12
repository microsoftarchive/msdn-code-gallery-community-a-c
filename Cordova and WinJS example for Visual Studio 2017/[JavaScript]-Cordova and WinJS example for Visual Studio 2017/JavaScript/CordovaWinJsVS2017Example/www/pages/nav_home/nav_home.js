(function () {
	"use strict";

	WinJS.UI.Pages.define("./pages/nav_home/nav_home.html", {
		// This function is called whenever a user navigates to this page. It
		// populates the page elements with the app's data.
		ready: function (element, options) {
			// Initialize the page here.

			//keeps effect button for split views after page change
			myAppObject.hoverSplitView('cmdHome');

			//listview example
			listViewControl = document.querySelector("#listView").winControl;
			loadListView();

			//enter animation effect
			WinJS.UI.Animation.enterPage([[document.querySelector("header")], [document.querySelector("section")]], null);
		}
	});

	var listViewControl;

	function loadListView() {

		var itemArray = [
				{ planet: "Mercury", radius: "2,439.7", picture: "./images/img48x48.png" },
				{ planet: "Earth", radius: "6,378.1", picture: "./images/img48x48.png" },
				{ planet: "Mars", radius: "3,396.2", picture: "./images/img48x48.png" },
				{ planet: "Jupiter", radius: "71,492", picture: "./images/img48x48.png" }
		];

		var dataBindingList = new WinJS.Binding.List(itemArray).reverse();

		listViewControl.itemDataSource = dataBindingList.dataSource;
		listViewControl.itemTemplate = document.querySelector(".smallListIconTextTemplate");
		listViewControl.selectionMode = 'single';
		listViewControl.tapBehavior = 'directSelect';
		listViewControl.layout = { type: WinJS.UI.ListLayout };

	};

})();