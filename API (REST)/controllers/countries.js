// TODO Validation

var connection = require('../database/dbConnect.js');
var xmllint = require('xmllint');
var fs = require('fs');
const util = require('util');
const { fork } = require('child_process');
const Ajv = require("ajv");

function isValidJSON(json, schemaPath) {
	const data = JSON.parse(fs.readFileSync(schemaPath, 'utf8'));
	const ajv = new Ajv();
	const validate = ajv.compile(data);
	console.log(validate);
	return validate(json);
}


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


// Get All country codes semicolon seperated
const codes = (req, res, next) => {
	let sql = "SELECT Code, Name FROM country";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		var endResult = [];
		var result = results.map(function(val) {
		  return val.Name;
		}).join(';');

		var resultCode = results.map(function(val) {
		  return val.Code;
		}).join(';');
		
		endResult.push(resultCode);
		endResult.push(result);	
		res.send(JSON.stringify(endResult));		
		
	});
};

const countries = (req, res, next) => {

	let sql = "SELECT * FROM country;";
	let query = connection.query(sql, async (err, results) => {
		if(err) throw err;

		var result = null;
		var countriesJson = {
			Countries: []
		};

		for (var i = 0; i < results.length; i++) {
			var countryJson = {
				Country : results[i]
			};
			countriesJson.Countries.push(countryJson);
		}


		// if url contains xml it should parse json to xml
		if (req.headers['content-type'] == "application/xml"){

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
			result = xmlString;		
		} else {
			result = countriesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));

	});
};

const country = (req, res, next) => {
	// get body from request
	let data = [req.params.code];

	let sql = "SELECT * FROM country WHERE Code = ?;";
	let query = connection.query(sql, data, async (err, results) => {
		if(err) throw err;

		var result = null;
		var isValid = false;
		var countriesJson = {
			Countries: []
		};

		for (var i = 0; i < results.length; i++) {
			var countryJson = {
				Country : results[i]
			};
			countriesJson.Countries.push(countryJson);
		}


		// if url contains xml it should parse json to xml
		if (req.headers['content-type'] == "application/xml"){

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
			result = xmlString;
		} else {
			isValidJSON(countriesJson, "validation/json/schema.json");
			result = countriesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

const create = (req, res, next) => {
	let countries = null;
	let sql = "INSERT INTO country SET ?";
	if (req.headers['content-type'] == "application/xml"){
		countries = req.body.countries.country;

		let data = [];
		for (var i = 0; i < countries.length; i++) {
			data.push(countries[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}

	} else {
		countries = req.body.Countries;
		for (var i = 0; i < countries.length; i++) {
			let data = [];
			Object.keys(countries[i]).forEach(function(key) {
				let value = countries[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}
	

	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

const update = (req, res, next) => {
	let countries = null;
	let data = [];

	if (req.headers['content-type'] == "application/xml"){
		countries = req.body.countries.country;
		for (var i = 0; i < countries.length; i++) {
			data.push(countries[i]);
		}
	} else {
		countries = req.body.Countries;
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
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

const del = (req, res, next) => {
	let sql = "DELETE FROM country WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

module.exports = {
	codes,
	countries,
	country,
	create,
	update,
	del
};