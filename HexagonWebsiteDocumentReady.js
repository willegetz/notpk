$(document).ready(function () {

	$("#gpWidget15388571").hide();

	$("#gpWidget15388572").hide();

	$("#gpWidget-1").hide();

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

});