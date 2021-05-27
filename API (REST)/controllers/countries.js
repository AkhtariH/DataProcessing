// Get connection and import dependencies
var connection = require('../database/dbConnect.js');
var xmllint = require('xmllint');
var fs = require('fs');
const util = require('util');
const { fork } = require('child_process');
const Ajv = require("ajv");

// Check if JSON is valid
function isValidJSON(json, schemaPath) {
	const data = JSON.parse(fs.readFileSync(schemaPath, 'utf8'));
	const ajv = new Ajv();
	const validate = ajv.compile(data);
	return validate(json);
}

// Check if XML is valid
async function isValidXML(xmlString, xsdString){
	var check = await new Promise(resolve => {
	    const lint = fork(`./xmllint.js`);
	    const data = fs.readFileSync(xsdString, 'utf8');
	    lint.on('message', resolve);
	    lint.send({ xml: xmlString, xsd: data });
	});

	if (!check.errors) {
		return true;
	} else {
		return false;
	}
}


// Get all country codes semicolon seperated
const codes = (req, res, next) => {
	// Execute SQL Query
	let sql = "SELECT Code, Name FROM country";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		// Put results into Array with JSON structure
		var endResult = [];
		for (var i = 0; i < results.length; i++) {
			endResult.push({Code: results[i].Code, Name: results[i].Name});
		}
		
		// Send response
		res.send(JSON.stringify(endResult));
	});
};

// Check if a specified Code exists
const exist = (req, res, next) => {
	// Gets url parameter
	let data = [req.params.code];

	// Executes SQL Query
	let sql = "SELECT Code FROM country WHERE Code = ?;";
	let query = connection.query(sql, data, async (err, results) => {
		if(err) throw err;

		// If exists, return true, if not reutrn false
		var exists;
		if (results.length > 0) {
			exists = true;
		} else {
			exists = false;
		}
		
		// Send response
		res.send(exists);
	});
};

// Get all countries
const countries = (req, res, next) => {
	// Execute SQL Query
	let sql = "SELECT * FROM country;";
	let query = connection.query(sql, async (err, results) => {
		if(err) throw err;

		// Create base JSON structure
		var result = null;
		var countriesJson = {
			Countries: []
		};

		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var countryJson = {
				Country : results[i]
			};
			countriesJson.Countries.push(countryJson);
		}


		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){
			// Build XML Structre
			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Countries xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Country>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Country>\n";
			}

			xmlString += "</Countries>\n";

			res.charset = 'utf-8';

			// Put XMLString into the results variable 
			result = xmlString;		
		} else { // If Header is nothing or JSON
			// Put JSON into the results variable
			result = countriesJson;
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};


// Gets country with specified Code
const country = (req, res, next) => {
	// Get request Parameter Code
	let data = [req.params.code];

	// Execute SQL Query
	let sql = "SELECT * FROM country WHERE Code = ?;";
	let query = connection.query(sql, data, async (err, results) => {
		if(err) throw err;
		// Create base JSON structure
		var result = null;
		var countriesJson = {
			Countries: []
		};
		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var countryJson = {
				Country : results[i]
			};
			countriesJson.Countries.push(countryJson);
		}
		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){
			// Build XML Structure
			var xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
			xmlString += "<Countries xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Country>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Country>\n";
			}

			xmlString += "</Countries>\n";
			res.charset = 'utf-8';

			// Put XMLString into the results variable 
			result = xmlString;
		} else { // If Header is nothing or JSON
			// Put JSON into the results variable
			result = countriesJson;
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

// Creates country entry in DB
const create = (req, res, next) => {
	let countries = null;
	let sql = "INSERT INTO country SET ?";
	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		countries = req.body.countries.country;
		// For each Country entry, execute INSERT Query
		let data = [];
		for (var i = 0; i < countries.length; i++) {
			data.push(countries[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}

	} else { // If request headers are nothing or JSON
		// Get body of request
		countries = req.body.Countries;
		// For each Country entry, execute INSERT Query
		for (var i = 0; i < countries.length; i++) {
			let data = [];
			Object.keys(countries[i]).forEach(function(key) {
				let value = countries[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}
	
	// Send response with Status, Error and Result
	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

// Update country entry in DB
const update = (req, res, next) => {
	let countries = null;
	let data = [];

	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		countries = req.body.countries.country;
		// For each Country entry, execute UPDATE Query
		for (var i = 0; i < countries.length; i++) {
			data.push(countries[i]);
		}
	} else {
		// Get body of request
		countries = req.body.Countries;
		// For each Country entry, execute UPDATE Query
		for (var i = 0; i < countries.length; i++) {
			Object.keys(countries[i]).forEach(function(key) {
				let value = countries[i][key];
				data.push(value);
			});
		}
	}

	let sql = "UPDATE country SET ? WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Delete country with specified Code
const del = (req, res, next) => {
	let sql = "DELETE FROM country WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Export all modules and operations
module.exports = {
	codes,
	exist,
	countries,
	country,
	create,
	update,
	del
};