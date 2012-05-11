<script type="text/javascript">

var apothemFromSideLength = function(sideLength){
return (Math.sqrt(3) / 2) * sideLength;
}

// Deriving the side length from the input
// Apothem:
var sideLengthApothem = function(apothem){
	return ((2 * apothem) / 3) * Math.sqrt(3);
}

// Area
var sideLengthArea = function(area){
	return Math.sqrt(2 * area) * Math.sqrt(Math.sqrt(3)) / 3;
}

// Center to Point:
var sideLengthCtoP = function(vertex){
	return vertex;
}

// Perimeter Length:
var sideLengthPerimeter = function(perimeter){
	return perimeter / 6;
}

// Side Length:
var sideLength = function(side){
	return side;
}

// Flat to Flat Length:
var sideLengthFtoF = function(sideToSide){
	return (sideToSide / 3) * Math.sqrt(3);
}

// Point to Point Length:
var sideLengthPtoP = function(vertexToVertex){
	return vertexToVertex / 2;
}

// Deriving the Other Measurements given the side length
// Apothem
var apothemLength = function(sideLength){
	return (Math.sqrt(3) / 2) * sideLength;
}

// Area
var areaFromSideLength = function(sideLength){
	return ((3 * Math.sqrt(3)) / 2) * Math.pow(sideLength, 2);
}

// Center to Vertex
var centerToVertexFromSideLength = function(sideLength){
	return sideLength;
}

// Perimeter
var perimeterFromSideLength = function(sideLength){
	return 6 * sideLength;
}

// Side Length
var sideLengthFromSideLength = function(sideLength){
	return sideLength;
}

//Side to Side
var sideToSideFromSideLength = function(sideLength){
	return 2 * ((Math.sqrt(3) / 2) * sideLength);
}

//Vertex to Vertex Length = 2 * side length
var vertexToVertexFromSide = function(sideLength){
	return 2 * sideLength;
}

</script>