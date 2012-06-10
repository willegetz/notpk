	$(document).ready(function () {

	hideAll();

	$("#calculateButton").click(function () {
		var inputValue = $("#givenMeasurement").val();
		var calcType = $("#givenParameter").val();
		var derivedSideLength;
		switch (calcType) {
			case "selectApothem":
				derivedSideLength = sideLengthApothem(inputValue);
				$("#apothem").text(inputValue);
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectArea":
				derivedSideLength = sideLengthArea(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(inputValue);
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectCenterToPoint":
				derivedSideLength = sideLengthCtoP(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(inputValue);
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectFlatToFlat":
				derivedSideLength = sideLengthFtoF(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(inputValue);
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectPerimeter":
				derivedSideLength = sideLengthPerimeter(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(inputValue);
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectPointToPoint":
				derivedSideLength = sideLengthPtoP(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(inputValue);
				$("#side").text(sideLengthFromSideLength(derivedSideLength));
				break;
			case "selectSide":
				derivedSideLength = sideLength(inputValue);
				$("#apothem").text(apothemLength(derivedSideLength));
				$("#area").text(areaFromSideLength(derivedSideLength));
				$("#centertoPoint").text(centerToVertexFromSideLength(derivedSideLength));
				$("#flatToFlat").text(sideToSideFromSideLength(derivedSideLength));
				$("#perimeter").text(perimeterFromSideLength(derivedSideLength));
				$("#pointToPoint").text(vertexToVertexFromSide(derivedSideLength));
				$("#side").text(inputValue);
				break;
		}
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