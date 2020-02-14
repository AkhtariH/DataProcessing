// Used different routes for XML because of parsing libraries only can support one type of layout
// import libraries
var express = require('express');
var router = express.Router();
var mysql = require('mysql');
var js2xmlparser = require("js2xmlparser");
var xmlparser = require('express-xml-bodyparser');

router.use(xmlparser());


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


//add new country
router.post('/', function (req, res) {
	// gets post data
	let data = [
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

	console.log(req.body);

	let sql = "INSERT INTO country VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
	let query = conn.query(sql, data,(err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
});

//update country
router.put('/:code', function (req, res) {
	// gets post data
	let data = {
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
	
	console.log(req.body);
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