// TODO Validation

var connection = require('../database/dbConnect.js');

const languages = (req, res, next) => {
	let sql = "SELECT * FROM countrylanguage;";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		var result = null;
		var languagesJson = {
			Languages: []
		};

		for (var i = 0; i < results.length; i++) {
			var languageJson = {
				Language : results[i]
			};
			languagesJson.Languages.push(languageJson);
		}


		// if url contains xml it should parse json to xml
		if (req.headers['content-type'] == "application/xml"){

			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Languages xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Language>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Language>\n";
			}

			xmlString += "</Languages>\n";

			res.charset = 'utf-8';
			result = xmlString;		
		} else {
			result = languagesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));

	});
};

const language = (req, res, next) => {
	// get body from request
	let data = [req.params.code];

	let sql = "SELECT * FROM countrylanguage WHERE CountryCode = ?;";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;

		var result = null;
		var languagesJson = {
			Languages: []
		};

		for (var i = 0; i < results.length; i++) {
			var languageJson = {
				Language : results[i]
			};
			languagesJson.Languages.push(languageJson);
		}


		// if url contains xml it should parse json to xml
		if (req.headers['content-type'] == "application/xml"){

			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Languages xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Language>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Language>\n";
			}

			xmlString += "</Languages>\n";

			res.charset = 'utf-8';
			result = xmlString;
		} else {
			result = languagesJson;
		}

		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));

	});
};

const create = (req, res, next) => {
	let languages = null;
	let sql = "INSERT INTO countrylanguage SET ?";
	if (req.headers['content-type'] == "application/xml"){
		languages = req.body.languages.language;

		let data = [];
		for (var i = 0; i < languages.length; i++) {
			data.push(languages[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}

	} else {
		languages = req.body.Languages;
		for (var i = 0; i < languages.length; i++) {
			let data = [];
			Object.keys(languages[i]).forEach(function(key) {
				let value = languages[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}
	

	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

const update = (req, res, next) => {
	let languages = null;
	let data = [];

	if (req.headers['content-type'] == "application/xml"){
		languages = req.body.languages.language;
		for (var i = 0; i < languages.length; i++) {
			data.push(languages[i]);
		}
	} else {
		languages = req.body.Languages;
		for (var i = 0; i < languages.length; i++) {
			Object.keys(languages[i]).forEach(function(key) {
				let value = languages[i][key];
				data.push(value);
			});
		}
	}

	let sql = "UPDATE countrylanguage SET ? WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

const del = (req, res, next) => {
	let sql = "DELETE FROM countrylanguage WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

module.exports = {
	languages,
	language,
	create,
	update,
	del
};