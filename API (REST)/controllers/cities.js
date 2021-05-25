// TODO Validation

var connection = require('../database/dbConnect.js');

const cities = (req, res, next) => {
	let sql = "SELECT * FROM city;";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		var result = null;
		var citiesJson = {
			Cities: []
		};

		for (var i = 0; i < results.length; i++) {
			var cityJson = {
				City : results[i]
			};
			citiesJson.Cities.push(cityJson);
		}


		// if url contains xml it should parse json to xml
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
			result = xmlString;		
		} else {
			result = citiesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));

	});
};

const city = (req, res, next) => {
	// get body from request
	let data = [req.params.code];

	let sql = "SELECT * FROM city WHERE CountryCode = ?;";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;

		var result = null;
		var citiesJson = {
			Cities: []
		};

		for (var i = 0; i < results.length; i++) {
			var cityJson = {
				City : results[i]
			};
			citiesJson.Cities.push(cityJson);
		}


		// if url contains xml it should parse json to xml
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
			result = xmlString;
		} else {
			result = citiesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

const create = (req, res, next) => {
	let cities = null;
	let sql = "INSERT INTO city SET ?";
	if (req.headers['content-type'] == "application/xml"){
		cities = req.body.cities.city;

		let data = [];
		for (var i = 0; i < cities.length; i++) {
			data.push(cities[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}

	} else {
		cities = req.body.Cities;
		for (var i = 0; i < cities.length; i++) {
			let data = [];
			Object.keys(cities[i]).forEach(function(key) {
				let value = cities[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}
	

	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

const update = (req, res, next) => {
	let cities = null;
	let data = [];

	if (req.headers['content-type'] == "application/xml"){
		cities = req.body.cities.city;
		for (var i = 0; i < cities.length; i++) {
			data.push(cities[i]);
		}
	} else {
		cities = req.body.Cities;
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
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

const del = (req, res, next) => {
	let sql = "DELETE FROM city WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

module.exports = {
	cities,
	city,
	create,
	update,
	del
};