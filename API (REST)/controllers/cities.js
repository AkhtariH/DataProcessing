// Get connection
var connection = require('../database/dbConnect.js');

// Get all cities
const cities = (req, res, next) => {
	// Execute SQL Query
	let sql = "SELECT * FROM city;";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		// Create base JSON structure
		var result = null;
		var citiesJson = {
			Cities: []
		};

		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var cityJson = {
				City : results[i]
			};
			citiesJson.Cities.push(cityJson);
		}

		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){
			// Build XML Structre
			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Cities xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<City>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</City>\n";
			}

			xmlString += "</Cities>\n";

			res.charset = 'utf-8';
			// Put XMLString into the results variable 
			result = xmlString;		
		} else {
			// Put JSON into the results variable
			result = citiesJson;
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

// Gets cities of a specific country with specified Code
const city = (req, res, next) => {
	// Get request Parameter Code
	let data = [req.params.code];
	// Execute SQL Query
	let sql = "SELECT * FROM city WHERE CountryCode = ?;";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;
		// Create base JSON structure
		var result = null;
		var citiesJson = {
			Cities: []
		};
		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var cityJson = {
				City : results[i]
			};
			citiesJson.Cities.push(cityJson);
		}
		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){

			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Cities xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<City>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</City>\n";
			}

			xmlString += "</Cities>\n";

			res.charset = 'utf-8';
			// Put XMLString into the results variable 
			result = xmlString;
		} else { // If Header is nothing or JSON
			// Put JSON into the results variable
			result = citiesJson; 
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

// Creates city entry in DB
const create = (req, res, next) => {
	let cities = null;
	let sql = "INSERT INTO city SET ?";
	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		cities = req.body.cities.city;
		// For each City entry, execute INSERT Query
		let data = [];
		for (var i = 0; i < cities.length; i++) {
			data.push(cities[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}
	} else { // If request headers are nothing or JSON
		// Get body of request
		cities = req.body.Cities;
		// For each Country entry, execute INSERT Query
		for (var i = 0; i < cities.length; i++) {
			let data = [];
			Object.keys(cities[i]).forEach(function(key) {
				let value = cities[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}
	
	// Send response with Status, Error and Result
	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

// Update city entry in DB
const update = (req, res, next) => {
	let cities = null;
	let data = [];

	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		cities = req.body.cities.city;
		// For each City entry, execute UPDATE Query
		for (var i = 0; i < cities.length; i++) {
			data.push(cities[i]);
		}
	} else {
		// Get body of request
		cities = req.body.Cities;
		// For each City entry, execute UPDATE Query
		for (var i = 0; i < cities.length; i++) {
			Object.keys(cities[i]).forEach(function(key) {
				let value = cities[i][key];
				data.push(value);
			});
		}
	}

	let sql = "UPDATE city SET ? WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Delete city with specified Code
const del = (req, res, next) => {
	let sql = "DELETE FROM city WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Get disctricts from sspecific Country
const districts = (req, res, next) => {
	let sql = "SELECT District FROM `city` WHERE CountryCode = '" + req.params.code + "' GROUP BY District";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Export all modules and operations
module.exports = {
	cities,
	city,
	create,
	update,
	del,
	districts
};