var newTrapMarkup = "<div class='draggableDiv'>${TrapBase} ${TrapEffects} ${TrapDamage}</div>";
$.template("newTrapTemplate", newTrapMarkup);

function AddTrap() {
	"use strict";
	$.ajax({
		type: "GET",
		url: "home/GenerateNewTrap",
		success: function (newTrap) {
			$.tmpl("newTrapTemplate", newTrap).appendTo("#TrapComponents").draggable({ revert: true });
		}
	});
}

function KeptTrapPrintWindow(keptTraps) {
	"use strict";
	var trapWindow = window.open("", "Kept Traps", "height=400,width=600");
	trapWindow.document.write("<html><head><title>Kept Traps</title></head><body>");
	trapWindow.document.write(keptTraps);
	trapWindow.document.write("</body></html>");
};

$(function () {
	"use strict";
	$(".draggableDiv").draggable({
		revert: true,
	});
	$(".droppableDiv").droppable({
		tolerance: "pointer",
		drop: function (event, ui) {
			debugger;
			$(this).append(ui.draggable);
		}
	});
});

$("#addNewTrap").click(function () {
	"use strict";
	AddTrap();
});

$("#ClearGeneratedTraps").click(function () {
	"use strict";
	$("#GeneratedTraps").siblings().remove();
});

$("#clearPreservedTraps").click(function () {
	"use strict";
	$("#trapsToKeep").siblings().remove();
});

$("#exportPreservedTraps").click(function () {
	var keptTrapArray = new Array();
	$("#trapsToKeep").siblings().each(function () {
		keptTrapArray.push(this.innerHTML);
	})

	$.ajax({
		type: "Post",
		url: "home/DisplayPreservedTraps",
		data: { mykeptTraps: keptTrapArray },
		traditional: true,
		success: function (traps) {
			KeptTrapPrintWindow(traps);
		},
		error: function () {
			alert("error");
		}
	});
});