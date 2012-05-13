$(document).ready(function () {

	//$("#gpWidget-1").hide();

	hideAll();

	$("#calculateButton").click(function () {
		var inputValue = $("#givenMeasurement").val();
		var calcType = $("#givenParameter").val();
		var derivedSideLength;
		switch (calcType) {
			case "selectApothem":
				derivedSideLength = sideLengthApothem(inputValue);
				break;
			case "selectArea":
				derivedSideLength = sideLengthArea(inputValue);
				break;
			case "selectCenterToPoint":
				derivedSideLength = sideLengthCtoP(inputValue);
				break;
			case "selectFlatToFlat":
				derivedSideLength = sideLengthFtoF(inputValue);
				break;
			case "selectPerimeter":
				derivedSideLength = sideLengthPerimeter(inputValue);
				break;
			case "selectPointToPoint":
				derivedSideLength = sideLengthPtoP(inputValue);
				break;
			case "selectSide":
				derivedSideLength = sideLength(inputValue);
				break;
		}

		$("#apothem").text(apothemLength(derivedSideLength));

		$("#area").text(areaFromSideLength(derivedSideLength));

		$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));

		$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));

		$("#perimeter").text(perimeterFromSideLength(derivedSideLength));

		$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));

		$("#side").text(sideLengthFromSideLength(derivedSideLength));
	});

	$("#givenParameter").change(function () {
		var calcType = $("#givenParameter").val();
		switch (calcType) {
			case "emptySelect":
				hideAll();
				break;
			case "selectApothem":
				showApothem();
				break;
			case "selectArea":
				showArea();
				break;
			case "selectCenterToPoint":
				showCenterToPoint();
				break;
			case "selectFlatToFlat":
				showFlatToFlat();
				break;
			case "selectPerimeter":
				showPerimeter();
				break;
			case "selectPointToPoint":
				showPointToPoint();
				break;
			case "selectSide":
				showSide();
				break;
		}
	});
});