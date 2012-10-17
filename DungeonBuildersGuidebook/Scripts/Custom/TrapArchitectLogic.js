var newTrapTableMarkup = "<div class='newTrap draggableTable' style='margin: 10px;'><table><tbody style='cursor: move'><tr><td id='columnOne' style='width: 85px !important'>Trap Base</td><td>${TrapBase}</td></tr><tr><td id='columnOne' style='width: 85px !important'>Trap Effects</td><td>${TrapEffects}</td></tr><tr><td id='columnOne' style='width: 85px !important'>Trap Damage</td><td>${TrapDamage}</td></tr></tbody></table></div>";
$.template("newTrapTableTemplate", newTrapTableMarkup);

var newTrapMarkup = "<div class='newTrap draggableTable' style='margin: 5px; background-color: white; border-radius: 10px; z-index: 10;'><table><tbody style='cursor: move'><tr><td>${TrapBase} ${TrapEffects} ${TrapDamage}</td></tr></tbody></table></div>";
$.template("newTrapTemplate", newTrapMarkup);


$(function () {
	$(".draggableTable").draggable({
		revert: true,
		handle: "tbody",
	});
	$(".droppableDiv").droppable({
		tolerance: "touch",
		drop: function (event, ui) {
			(ui.draggable).css("z-index", 5);
			(ui.draggable).removeClass("newTrap");
			(ui.draggable).addClass("keptTrap");
			$(this).append(ui.draggable);
						
		}
	});
});

$("#addNewTrap").click(function () {
	AddTrap();
});

$("#ClearGeneratedTraps").click(function () {
	$(".newTrap").remove();
});

$("#clearPreservedTraps").click(function (){
	$(".keptTrap").remove();
});

$("#exportPreservedTraps").click(function (){
	var keptTraps = $(".keptTrap").toArray();
	var keptTrapArray = new Array()
	for (var i = 0; i < keptTraps.length; i++) {
	keptTrapArray.push(keptTraps[i].textContent);
	}
							
	$.ajax({
		type: "Post",
		url: "home/DisplayPreservedTraps",
		data: {keptTraps: keptTrapArray},
		traditional: true,
		success: function (traps){
			KeptTrapPrintWindow(traps);
		}
	});
});

function AddTrap() {
	$.ajax({
		type: "GET",
		url: "home/GenerateNewTrap",
		success: function (newTrap) {
			$.tmpl("newTrapTemplate", newTrap).appendTo("#TrapComponents").draggable({ revert: true });
		}
	});
};

function KeptTrapPrintWindow(keptTraps){
	var trapWindow = window.open("", "Kept Traps", "height=400,width=600");
	trapWindow.document.write("<html><head><title>Kept Traps</title></head><body>");
	trapWindow.document.write(keptTraps);
	trapWindow.document.write("</body></html>");
};