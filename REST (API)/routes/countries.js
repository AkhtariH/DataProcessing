// import libraries
var express = require('express');
var router = express.Router();
var mysql = require('mysql');
var js2xmlparser = require("js2xmlparser");
var bodyParser = require('body-parser');

// initate parsers
router.use(bodyParser.json());
router.use(bodyParser.urlencoded({
  extended: true
}));




// Create database connection
var conn = mysql.createConnection({
	host: 'localhost',
	user: 'root',
	password: '',
	database: 'world',
	multipleStatements: true
});

// Connect to database
conn.connect((err) =>{
	if(err) throw err;
	console.log('Mysql Connected...');
});



// Show all results
router.get('/', function(req, res, next) {
	let sql = "SELECT Code, Name FROM country";
	let query = conn.query(sql, (err, results) => {
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


// Show single result
router.get('/:code/:format',function(req, res) {
	// get body from request
	let data = [
		req.params.code,
		req.params.code,
		req.params.code
	];

	let sql = "SELECT * FROM country WHERE Code = ?;SELECT Name, CountryCode, Population FROM city WHERE CountryCode = ?;SELECT CountryCode, Language, IsOfficial, Percentage FROM countrylanguage WHERE CountryCode = ?";
	let query = conn.query(sql, data, (err, results) => {
		if(err) throw err;

		// gets all tables and sorts city and languages in subcategories
		for(var i = 0; i <= results[0].length - 1; i++){
			var cities = [];
			var lang = [];

			for (var x = 0; x <= results[1].length - 1; x++){
				if (results[0][i].Code == results[1][x].CountryCode){
					cities.push(results[1][x]);
				}
			}

			results[0][i].Cities = cities;

			for (var x = 0; x <= results[2].length - 1; x++){
				if (results[0][i].Code == results[2][x].CountryCode){
					lang.push(results[2][x]);
				}
			}

			results[0][i].Languages = lang;
			
		}

		results.pop();
		results.pop();

		// if url contains xml it should parse json to xml
		if (req.params.format == "XML" || req.params.format == "xml"){
			results = js2xmlparser.parse("country", results);
			var s = results.replace("<country>", "<countries xmlns=''>");
			var s2 = s.replace(/.{8}$/,"countries>");	
			res.send(s2); 

		} else {
			res.send(results[0][0]); 
		}

		
		//js2xmlparser.parse("country", results)
	});

});


//add new country
router.post('/', function (req, res) {
	// gets post values
	let data = [
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

	console.log(req.body);

	let sql = "INSERT INTO country VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
	let query = conn.query(sql, data,(err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});

//update country
router.put('/:code', function (req, res) {

	//gets all post values
	let data = {
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
	

	let sql = "UPDATE country SET ? WHERE Code = '" + req.params.code + "'";
	let query = conn.query(sql, data, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});

//Delete country
router.delete('/:code',function (req, res) {
	let sql = "DELETE FROM country WHERE Code = '" + req.params.code + "'";
	let query = conn.query(sql, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});


module.exports = router;