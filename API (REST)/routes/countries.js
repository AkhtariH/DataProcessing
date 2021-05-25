// TODO: Schemas, display all countries

// import libraries
var express = require('express');
var router = express.Router();
var js2xmlparser = require('js2xmlparser');
var xmlparser = require('express-xml-bodyparser');
var bodyParser = require('body-parser');
var dbConnect = require('./dbConnect.js');

var app = exports.app;

// Get All country codes semicolon seperated
app.get('/codes', function(req, res, next) {
	let sql = "SELECT Code, Name FROM country";
	let query = dbConnect.query(sql, (err, results) => {
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
});

// Show all countries
router.get('/',function(req, res) {
	let data = [];
	let sql = "SELECT * FROM country;";
	let query = dbConnect.query(sql, data, (err, results) => {
		if(err) throw err;

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
			res.send(xmlString);
		} else {
			res.send(countriesJson);
		}

	});

});

// Show single result
router.get('/:code',function(req, res) {
	
	// get body from request
	let data = [
		req.params.code
	];

	let sql = "SELECT * FROM country WHERE Code = ?;";
	let query = dbConnect.query(sql, data, (err, results) => {
		if(err) throw err;

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
			res.send(xmlString);
		} else {
			res.send(countriesJson);
		}

	});

});


//add new country
router.post('/', function (req, res) {

	let data = [];
	if (req.headers['content-type'] == "application/xml"){
		data = [
			req.body.data.code,
			req.body.data.name,
			req.body.data.continent,
			req.body.data.region,
			req.body.data.surfacearea,
			req.body.data.population,
			req.body.data.lifeexpectancy,
			req.body.data.gnp,
			req.body.data.headofstate,
			req.body.data.capital,
			req.body.data.code2
		];

	} else if (req.headers['content-type'] == "application/json"){
		// gets post values
		data = [
			req.body.Code,
			req.body.Name,
			req.body.Continent,
			req.body.Region,
			req.body.SurfaceArea,
			req.body.Population,
			req.body.LifeExpectancy,
			req.body.GNP,
			req.body.HeadOfState,
			req.body.Capital,
			req.body.Code2
		];
	}

	console.log(req.headers['content-type']);
	

	let sql = "INSERT INTO country VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
	let query = dbConnect.query(sql, data,(err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});

//update country
router.put('/:code', function (req, res) {

	let data = {};
	if (req.headers['content-type'] == "application/xml"){
		data = {
			Code: req.body.data.code,
			Name: req.body.data.name,
			Continent: req.body.data.continent,
			Region: req.body.data.region,
			SurfaceArea: req.body.data.surfacearea,
			Population: req.body.data.population,
			LifeExpectancy: req.body.data.lifeexpectancy,
			GNP: req.body.data.gnp,
			HeadOfState: req.body.data.headofstate,
			Capital: req.body.data.capital,
			Code2: req.body.data.code2
		};
	} else if (req.header['content-type'] == "application/json"){
		//gets all post values
		data = {
			Code: req.body.Code,
			Name: req.body.Name,
			Continent: req.body.Continent,
			Region: req.body.Region,
			SurfaceArea: req.body.SurfaceArea,
			Population: req.body.Population,
			LifeExpectancy: req.body.LifeExpectancy,
			GNP: req.body.GNP,
			HeadOfState: req.body.HeadOfState,
			Capital: req.body.Capital,
			Code2: req.body.Code2
		};
	}

	

	let sql = "UPDATE country SET ? WHERE Code = '" + req.params.code + "'";
	let query = dbConnect.query(sql, data, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});

//Delete country
router.delete('/:code',function (req, res) {
	let sql = "DELETE FROM country WHERE Code = '" + req.params.code + "'";
	let query = dbConnect.query(sql, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});


module.exports = router;